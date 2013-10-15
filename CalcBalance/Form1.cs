using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Threading;

namespace CalcBalance_0_2_beta
{
    public partial class MainForm : Form
    {
        private static volatile int client_total = 0;

        // Query condition from query form
        private static QueryType _query_type;
        private static string _query_name = string.Empty;
        private static string _query_from = string.Empty;
        private static string _query_to = string.Empty;
        private static int duration = 0;

        //Stuff bonus, goal of daily banlance
        private struct StuffGoalInfo
        {
            public decimal balance;
            public decimal bonus;
        }
        private static Dictionary<string, StuffGoalInfo> _stuff_goal = new Dictionary<string,StuffGoalInfo>();

        // progress bar controller
        private static volatile int _progress_pos = 0;
        private delegate void _Dele_SetProgressPos(int pos);
        
        private void _SetProgressPos(int pos)
        {
            if (this.PrgMain.InvokeRequired)
            {
                _Dele_SetProgressPos set_progress_pos = new _Dele_SetProgressPos(_SetProgressPos);
                this.PrgMain.Invoke(set_progress_pos, new object[] { pos });
                return;
            } 
            else
            {
                this.PrgMain.Value = pos ;
                /*if (pos == 100)
                {
                    this.PrgMain.Visible = false;
                }*/
            }
        }
        
        private void DisplayProgressBar()
        {
            while (_progress_pos < client_total || _progress_pos == 0)
            {
                Thread.Sleep(100);
                if (client_total == 0) continue;
                _SetProgressPos(_progress_pos * 100 / client_total);
            }

            /*for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(100);
                _SetProgressPos(100 * i / 500);
            }*/
        }


        public MainForm()
        {
            InitializeComponent();
        }
        
        private static void _InsertDataToDB(FileInfo file, string key_data, string table, ref int id)
        {
            StreamReader s_read = new StreamReader(file.FullName, Encoding.GetEncoding("GB2312"));
            
            while (!s_read.EndOfStream)
            {
                string error_msg = string.Empty;
                string line = s_read.ReadLine();

                _TrimSpace(ref line);
                string[] tokens = line.Split(Common.DELIMITERS);

                if (tokens.Length < 3)
                {
                    continue;
                    //throw new Exception(@"文件内容错误.");
                }

                string sql;
                string ratio = @"100";
                if (table == Common.DB.CLIENT_DAILY_BALANCE)
                {
                    sql = "insert into " + table +
                          " select " + id + ", '" + key_data + "', '" +
                          tokens[0] + "', '" + tokens[1] + "', " + tokens[2] + ";";
                }
                else
                {
                    if (tokens.Length == 4)
                    {
                        ratio = tokens[3];
                    }
                    sql = "insert into " + table +
                          " select " + id + ", '" +
                          tokens[0] + "', '" + tokens[1] + "', '" + tokens[2] + "', " + ratio + ";";
                }

                if (!DbAdapter.TransInsert(out error_msg, sql))
                {
                    throw new Exception(error_msg);
                }
                id++;
            }
            s_read.Close();
        }

        private static void _TrimSpace(ref string str)
        {
            str = str.Replace(" ", "");
            str = str.Replace("\t", "");
        }

        private static bool _IsValidDate(string key_date)
        {
            try
            {
                DateTime.ParseExact(key_date, "yyyyMMdd", null);
                return true;
            }
            catch
            {
                return false; 
            }
        }

        private static bool _IsFloatDigit(string str)
        {
            string pattern = @"^[0-9]+[\.]?[0-9]+$";

            if (Regex.IsMatch(str, pattern))
            {
                return true;
            }
            return false;
        }

        private static bool _IsChineseName(string key_data)
        {
            string pattern = @"^[\u4e00-\u9fa5]{2,4}$";

            if (Regex.IsMatch(key_data, pattern))
            {
                return true;
            }

            return false; 
        }

        private static void _LoadDataFromFile(out string error_msg, string folder_path)
        {
            // TODO: support append data to table.

            DirectoryInfo root_dir = new DirectoryInfo(folder_path);
            DirectoryInfo[] sub_dirs = root_dir.GetDirectories();
            error_msg = string.Empty;
            int id = 1;
            DbAdapter.TransConn.Open();
            SQLiteTransaction trans = DbAdapter.TransConn.BeginTransaction();

            try
            {
                if (sub_dirs.Length != 0)
                {
                    foreach (DirectoryInfo dir in sub_dirs)
                    {
                        FileInfo[] files = dir.GetFiles();
                        string key_data = dir.FullName;
                 
                        key_data = key_data.Substring(key_data.Length - 8, 8);
                        if (!_IsValidDate(key_data))
                        {
                            continue;
                        }

                        foreach (FileInfo file in files)
                        {
                            _InsertDataToDB(file, key_data, Common.DB.CLIENT_DAILY_BALANCE, ref id);
                        }

                    }
                }
                else
                {
                    FileInfo[] files = root_dir.GetFiles();
                    client_total = files.Length;
                    foreach (FileInfo file in files)
                    {
                        string key_data = file.Name; 
                        key_data = key_data.Substring(0, key_data.IndexOf(".txt"));
                        if (_IsChineseName(key_data))
                        {
                            _InsertDataToDB(file, key_data, Common.DB.STUFF_CLIENT_INFO, ref id);
                        }
                    }
                }
                trans.Commit();
            }
            catch(Exception ex)
            {
                error_msg = ex.Message;
                trans.Rollback();
            }
            DbAdapter.TransConn.Close();
        }

        private void _ShowTable(string table_name)
        {
            string error_msg = string.Empty;

            string str_sql = "select * from " + table_name;
            DataTable dt = DbAdapter.ExecuteQuery(out error_msg, str_sql);

            if (!string.IsNullOrEmpty(error_msg))
            {
                Common.DisplayMsg(error_msg, this.Text);
            }
            dgvResult.DataSource = dt;

            foreach (DataGridViewColumn column in this.dgvResult.Columns)
            {
                column.HeaderText = Common.COLUMN_HEADER_TRANSFORM[column.HeaderText];
            }
        }

        private void btnLoadClientBalance_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open_folder_dlg = new FolderBrowserDialog();
            DialogResult result_dlg ;
            string folder_path;
            string error_msg;

            open_folder_dlg.ShowNewFolderButton = false;
            open_folder_dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            error_msg = string.Empty;
            folder_path = string.Empty;

            result_dlg = open_folder_dlg.ShowDialog();
            if (result_dlg == DialogResult.OK)
            {
                folder_path = open_folder_dlg.SelectedPath;
                _LoadDataFromFile(out error_msg, folder_path);

                if (string.IsNullOrEmpty(error_msg))
                {
                    result_dlg = Common.DisplayMsg(Common.Prompts.LOAD_DATA_SUCCESS +
                                                   Common.Prompts.DATA_TOO_BIG,
                                                   this.Text);
                    if (result_dlg == DialogResult.OK)
                    {
                        _ShowTable(Common.DB.CLIENT_DAILY_BALANCE);
                    }
                }
                else
                {
                    Common.DisplayMsg(error_msg, this.Text);
                }
            }
        }

        private void _LoadGoalInfoFromFile()
        {
            _stuff_goal.Clear();

            StreamReader s_read = new StreamReader(Common.Goal_INFO_FILE, Encoding.GetEncoding("GB2312"));

            while (!s_read.EndOfStream)
            {
                string line = s_read.ReadLine();
                string[] tokens = line.Split(Common.DELIMITERS);

                if (tokens.Length < 3)
                {
                    continue;
                }

                if (_IsFloatDigit(tokens[1]) && _IsFloatDigit(tokens[2]))
                {
                    _ReturnStuffGoal(tokens[0], tokens[1], tokens[2]);
                }
            }
            s_read.Close();
        }

        private void _SaveGoalInfoToFile()
        {
            StreamWriter s_write = new StreamWriter(Common.Goal_INFO_FILE, false, Encoding.GetEncoding("GB2312"));

            foreach (string key in _stuff_goal.Keys)
            {
                string line = key + "|" + _stuff_goal[key].balance.ToString() + "|" + _stuff_goal[key].bonus.ToString();
                s_write.WriteLine(line);
            }
            s_write.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbAdapter.ConnString = Common.DB.DB_PATH;
            _LoadGoalInfoFromFile();
        }

        private void btnUnloadClientBalance_Click(object sender, EventArgs e)
        {
            string error_msg = string.Empty;

            DbAdapter.DeleteTable(out error_msg, Common.DB.Tables.CLIENT_DAILY_BALANCE);
            if (string.IsNullOrEmpty(error_msg))
            {
                Common.DisplayMsg(Common.Prompts.UNLOAD_DATA_SUCCESS, this.Text);
                error_msg = string.Empty;
                DbAdapter.CreateTable(out error_msg, Common.DB.Tables.CLIENT_DAILY_BALANCE);
            }
            else
            {
                Common.DisplayMsg(error_msg, this.Text);
            }
        }

        private void btnLoadStaffInfo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open_folder_dlg = new FolderBrowserDialog();
            DialogResult result_dlg;
            string folder_path;
            string error_msg;

            open_folder_dlg.ShowNewFolderButton = false;
            open_folder_dlg.RootFolder = Environment.SpecialFolder.MyComputer;
            error_msg = string.Empty;
            folder_path = string.Empty;

            result_dlg = open_folder_dlg.ShowDialog();
            if (result_dlg == DialogResult.OK)
            {
                folder_path = open_folder_dlg.SelectedPath;
                _LoadDataFromFile(out error_msg, folder_path);

                if (string.IsNullOrEmpty(error_msg))
                {
                    result_dlg = Common.DisplayMsg(Common.Prompts.LOAD_DATA_SUCCESS +
                                                   Common.Prompts.DATA_TOO_BIG,
                                                   this.Text);
                    if (result_dlg == DialogResult.OK)
                    {
                        _ShowTable(Common.DB.STUFF_CLIENT_INFO);
                    }
                }
                else
                {
                    Common.DisplayMsg(error_msg, this.Text);
                }
            }
        }

        private void btnUnloadStaffInfo_Click(object sender, EventArgs e)
        {
            string error_msg = string.Empty;

            DbAdapter.DeleteTable(out error_msg, Common.DB.Tables.STAFF_CLIENT_INFO);
            if (!string.IsNullOrEmpty(error_msg))
            {
                Common.DisplayMsg(error_msg, this.Text);
            }                

            error_msg = string.Empty;
            DbAdapter.CreateTable(out error_msg, Common.DB.Tables.STAFF_CLIENT_INFO);
            if (string.IsNullOrEmpty(error_msg))
            {
                Common.DisplayMsg(Common.Prompts.UNLOAD_DATA_SUCCESS, this.Text);
            }
            else
            {
                Common.DisplayMsg(error_msg, this.Text);
            }
        }

        private void _ReturnQueryCondition(QueryType type,
                                           string name, 
                                           string from, 
                                           string to)
        {
            _query_type = type;

            if (type != QueryType.COMPUTE_AVERAGE_DAILY_BALANCE)
            {
                return;
            }

            if (from != "ALL")
            {
                _query_to = to.Replace("-", "");
                duration = Common.CalcDaysAmoungMounths(Convert.ToDateTime(from),
                                                        Convert.ToDateTime(to)) + 1;
            }
            else
            {
                string str_sql = @"select MIN(date) AS min, MAX(date) AS max FROM ClientDailyBalance;";
                string error_msg = string.Empty;
                DataTable dt = DbAdapter.ExecuteQuery(out error_msg, str_sql);

                if (string.IsNullOrEmpty(error_msg))
                {
                    string max = dt.Rows[0]["max"].ToString();
                    string min = dt.Rows[0]["min"].ToString();

                    duration = Convert.ToInt32(max) - Convert.ToInt32(min) + 1;
                }
                else
                {
                    Common.DisplayMsg(error_msg, this.Text);
                }
            }
            _query_from = from.Replace("-", "");
            _query_name = name;
        }

        private List<string> _GetStaffNameList()
        {
            // key word "distinct" should be uppercase.
            string str_sql = "select DISTINCT name from " + Common.DB.STUFF_CLIENT_INFO + ";";
            string error_msg = string.Empty;

            DataTable dt = DbAdapter.ExecuteQuery(out error_msg, str_sql);
            //dgvResult.DataSource = dt;

            List<string> client_list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                client_list.Add(row["name"].ToString());
            }

            return client_list;

        }

        private delegate void _Dele_ShowComputeBalanceResult(DataTable dt);

        void _ShowComputeBalanceResult(DataTable dt)
        {
            if (this.InvokeRequired)
            {
                _Dele_ShowComputeBalanceResult show_compute_result = new _Dele_ShowComputeBalanceResult(_ShowComputeBalanceResult);
                this.Invoke(show_compute_result, new object[] { dt });
                return;
            }

            this.dgvResult.DataSource = dt;
            this.PrgMain.Visible = false;

            foreach (DataGridViewColumn column in this.dgvResult.Columns)
            {
                column.HeaderText = Common.COLUMN_HEADER_TRANSFORM[column.HeaderText];
            }
        }

        private void _ComputeAverageDailyBalance()
        {
            string str_sql = string.Empty;
            string error_msg = string.Empty;
            DataTable dt = new DataTable();
            //DataTable dt_tmp = new DataTable();

            dt.Columns.Add("stuff_name", typeof(string));
            dt.Columns.Add("total_balance", typeof(decimal));
            dt.Columns.Add("avg_balance", typeof(decimal));
            dt.Columns.Add("goal_balance", typeof(decimal));
            dt.Columns.Add("task_ratio", typeof(string));
            dt.Columns.Add("bonus", typeof(decimal));
            dt.Columns.Add("deserved_bonus", typeof(decimal));

            if (_query_name == "ALL")
            {
                List<string> client_list = _GetStaffNameList();
                client_total = client_list.Count;
            
                foreach (string stuff_name in client_list)
                {
                    if (_query_from == "ALL")
                    {
                        str_sql = @"select sum(balance*ratio/100) as Total_Balance 
                                    from (select StuffClientInfo.ratio, ClientDailyBalance.balance 
                                          from ClientDailyBalance, StuffClientInfo
                                          where ClientDailyBalance.account = StuffClientInfo.account and  
                                                StuffClientInfo.name = '" + stuff_name + @"');";

                    }
                    else
                    {
                        str_sql = @"select sum(balance*ratio/100) as Total_Balance 
                                    from (select StuffClientInfo.ratio, ClientDailyBalance.balance 
                                          from ClientDailyBalance, StuffClientInfo
                                          where ClientDailyBalance.account = StuffClientInfo.account and  
                                                StuffClientInfo.name = '" + stuff_name + @"' and
                                                ClientDailyBalance.date BETWEEN '" + _query_from + @"' and '"
                                                                                   + _query_to + @"');";
                    }

                    DataRow tmp_row = dt.NewRow();
                    tmp_row["stuff_name"] = stuff_name;
                    tmp_row["total_balance"] = DbAdapter.ExecuteQuery(out error_msg, str_sql).Rows[0]["Total_Balance"];
                    if (error_msg != string.Empty)
                    {
                        Common.DisplayMsg(error_msg, this.Text);
                        return;
                    }

                    if (tmp_row["total_balance"] != DBNull.Value)
                    {
                        tmp_row["total_balance"] = Decimal.Round(Convert.ToDecimal(tmp_row["total_balance"]), 2);
                        tmp_row["avg_balance"] = Decimal.Round(Convert.ToDecimal(tmp_row["Total_Balance"]) / duration, 2);
                    }
                    if (_stuff_goal.ContainsKey(stuff_name))
                    {
                        tmp_row["goal_balance"] = _stuff_goal[stuff_name].balance;
                        tmp_row["bonus"] = _stuff_goal[stuff_name].bonus;
                        if (tmp_row["avg_balance"] != DBNull.Value)
                        {
                            decimal task_ratio = Convert.ToDecimal(tmp_row["avg_balance"]) / Convert.ToDecimal(tmp_row["goal_balance"]);
                            task_ratio = Decimal.Round(task_ratio * 100, 2);
                            tmp_row["task_ratio"] = Convert.ToString(task_ratio) + "%";
                            tmp_row["deserved_bonus"] = Convert.ToDecimal(tmp_row["bonus"]) * task_ratio;
                        }
                    }
 
                    dt.Rows.Add(tmp_row);
                    _progress_pos = dt.Rows.Count;
                }
            }
            else
            {
                client_total = 1;
                if (_query_from == "ALL")
                {
                    str_sql = @"select sum(balance*ratio/100) as Total_Balance 
                                    from (select StuffClientInfo.ratio, ClientDailyBalance.balance 
                                          from ClientDailyBalance, StuffClientInfo
                                          where ClientDailyBalance.account = StuffClientInfo.account and  
                                                StuffClientInfo.name = '" + _query_name + @"');"; ;
                }
                else
                {
                    str_sql = @"select sum(balance*ratio/100) as Total_Balance 
                                    from (select StuffClientInfo.ratio, ClientDailyBalance.balance 
                                          from ClientDailyBalance, StuffClientInfo
                                          where ClientDailyBalance.account = StuffClientInfo.account and  
                                                StuffClientInfo.name = '" + _query_name + @"' and
                                                ClientDailyBalance.date BETWEEN '" + _query_from + @"' and '"
                                                                                   + _query_to + @"');";
                }
                DataRow tmp_row = dt.NewRow();
                tmp_row["stuff_name"] = _query_name;
                tmp_row["total_balance"] = DbAdapter.ExecuteQuery(out error_msg, str_sql).Rows[0]["Total_Balance"];
                if (error_msg != string.Empty)
                {
                    Common.DisplayMsg(error_msg, this.Text);
                    return;
                }

                if (tmp_row["total_balance"] != DBNull.Value)
                {
                    tmp_row["total_balance"] = Decimal.Round(Convert.ToDecimal(tmp_row["total_balance"]), 2);
                    tmp_row["avg_balance"] = Decimal.Round(Convert.ToDecimal(tmp_row["Total_Balance"]) / duration, 2);
                }
                if (_stuff_goal.ContainsKey(_query_name))
                {
                    tmp_row["goal_balance"] = _stuff_goal[_query_name].balance;
                    tmp_row["bonus"] = _stuff_goal[_query_name].bonus;
                    if (tmp_row["avg_balance"] != DBNull.Value)
                    {
                        decimal task_ratio = Convert.ToDecimal(tmp_row["avg_balance"]) / Convert.ToDecimal(tmp_row["goal_balance"]);
                        task_ratio = Decimal.Round(task_ratio * 100, 2);
                        tmp_row["task_ratio"] = Convert.ToString(task_ratio) + "%";
                        tmp_row["deserved_bonus"] = Decimal.Round(Convert.ToDecimal(tmp_row["bonus"]) * task_ratio / 100, 2);
                    }
                }

                dt.Rows.Add(tmp_row);
                _progress_pos = dt.Rows.Count;
            }

            //dgvResult.DataSource = dt;
            _ShowComputeBalanceResult(dt);
        }

        private void BtnBeginQuery_Click(object sender, EventArgs e)
        {
            string str_sql = string.Empty;
            string error_msg = string.Empty;
            DialogResult dlg_result = DialogResult.None;
            QueryForm query_form = new QueryForm();

            query_form.Event_ReturnQueryCondition += new Dele_ReturnQueryCondition(_ReturnQueryCondition);
            this.PrgMain.Value = 0;
            this.PrgMain.Visible = false;
            this.dgvResult.DataSource = null;
   
            dlg_result = query_form.ShowDialog();
            if (dlg_result == DialogResult.OK)
            {
                switch (_query_type)
                {
                    case QueryType.CLIENT_DAILY_BALANCE_ONLY:
                        _ShowTable(Common.DB.CLIENT_DAILY_BALANCE);
                        break; 

                    case QueryType.STAFF_CLIENT_INFO_ONLY:
                        _ShowTable(Common.DB.STUFF_CLIENT_INFO);
                        break;

                    case QueryType.COMPUTE_AVERAGE_DAILY_BALANCE:

                        this.PrgMain.Visible = true;
                        Thread compute_thread = new Thread(new ThreadStart(_ComputeAverageDailyBalance));
                        //_ComputeAverageDailyBalance();
                        compute_thread.Start();

                        Thread display_progressbar = new Thread(new ThreadStart(DisplayProgressBar));
                        display_progressbar.Start(); 

                        break;
                    
                    default:
                        break;
                }
            }

      /*      string s1 = @"2013-01-05";
            string s2 = @"2013-04-30";
            int days = Common.CalcDaysAmoungMounths(Convert.ToDateTime(s1), 
                                                    Convert.ToDateTime(s2));

            Common.DisplayMsg(Convert.ToString(days), "hello");
            s1 = s1.Replace("-", "");
            str_sql = @"select sum(balance) 
                       from ClientDailyBalance
                       where client IN (select client from StuffClientInfo where name = '叶林峰');";

            str_sql = @"select * 
                       from ClientDailyBalance 
                         where date between '20130201' and '20130410';";


           str_sql = @"select client from StuffClientInfo where name = '叶林峰';";

            DataTable dt = DbAdapter.ExecuteQuery(out error_msg, str_sql);

            if (!string.IsNullOrEmpty(error_msg))
            {
                Common.DisplayMsg(error_msg, this.Text);
            }
            dgvResult.DataSource = dt;  */
        }

        private void _ReturnStuffGoal(string name, string balance, string bonus)
        {
            StuffGoalInfo stuff_goal_info = new StuffGoalInfo(); 

            stuff_goal_info.balance = Decimal.Round(Convert.ToDecimal(balance), 2);
            stuff_goal_info.bonus = Decimal.Round(Convert.ToDecimal(bonus), 2);

            _stuff_goal[name] = stuff_goal_info;
        }

        private void BtnLoadGoal_Click(object sender, EventArgs e)
        {
            DialogResult dlg_result = DialogResult.None;
            InputStuffGoalForm input_stuff_goal_form = new InputStuffGoalForm();

            input_stuff_goal_form._Event_ReturnStuffGoal += new _Dele_ReturnStuffGoal(_ReturnStuffGoal) ;

            dlg_result = input_stuff_goal_form.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _SaveGoalInfoToFile();
        }

        private void BtnUnloadGoal_Click(object sender, EventArgs e)
        {
            _stuff_goal.Clear();
        }
    }
}
