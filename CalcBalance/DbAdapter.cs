using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace CalcBalance_0_2_beta
{
    abstract class DbAdapter
    {
        private static string _conn_string = string.Empty;
        private static SQLiteConnection _trans_conn = null;

        private static string _CreateTableSql(Common.DB.Tables table)
        {
            string sql = string.Empty;

            switch (table)
            {
                case Common.DB.Tables.CLIENT_DAILY_BALANCE:

                    sql = "create table " + 
                          Common.DB.CLIENT_DAILY_BALANCE +
                          " (id int primary key, date varchar(8), account varchar(18), client varchar(50), balance decimal(15,2));";
                    break;

                case Common.DB.Tables.STAFF_CLIENT_INFO:

                    sql = "create table " +
                          Common.DB.STUFF_CLIENT_INFO +
                          " (id int primary key,  name varchar(20), account varchar(18), client varchar(50), ratio smallint);";
                    break; 

                default:
                    break;
            }

            return sql;
        }

        public static SQLiteConnection TransConn
        {
            get
            {
                if (_trans_conn == null) 
                {
                    _trans_conn = new SQLiteConnection(ConnString);
                }

                return _trans_conn;
            }

            set 
            {
                _trans_conn = new SQLiteConnection(ConnString);
            }
        }

        public static string ConnString
        {
            get
            {
                if (string.IsNullOrEmpty(_conn_string))
                {
                    _conn_string = Common.DB.DB_PATH;
                }
                return string.Format(@"Data Source = {0}", _conn_string);

            }
            set
            {
                _conn_string = value;
            }
        }

        public static void CreateTable(out string error_msg, Common.DB.Tables table)
        {
            error_msg = string.Empty;

            try
            {
                string sql = _CreateTableSql(table);
                if (string.IsNullOrEmpty(sql))
                {
                    throw new Exception("table name is not valid.");
                }
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                error_msg = ex.Message;
            }

        }

        public static void DeleteTable(out string error_msg, Common.DB.Tables table)
        {
            error_msg = string.Empty;
            string sql = string.Empty;

            try
            {
                switch (table)
                {
                    case Common.DB.Tables.CLIENT_DAILY_BALANCE:

                        sql = "drop table " + Common.DB.CLIENT_DAILY_BALANCE + ";";
                        break;

                    case Common.DB.Tables.STAFF_CLIENT_INFO:

                        sql = "drop table " + Common.DB.STUFF_CLIENT_INFO + ";";
                        break;

                    default:
                        break;
                }

                if (string.IsNullOrEmpty(sql))
                {
                    throw new Exception("table name is not valid.");
                }
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
            }

        }

        public static bool TransInsert(out string error_msg, string str_sql)
        {
            error_msg = string.Empty;
            int result = 0; 

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(TransConn);
                cmd.CommandText = str_sql;
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message; 
            }

            return result > 0; 
        }

        public static DataTable ExecuteQuery(out string error_msg, string str_sql)
        {
            DataTable tmp_table = null;
            error_msg = string.Empty;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = str_sql;
                cmd.Connection = conn;
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                tmp_table = new DataTable();
                adapter.Fill(tmp_table);
                conn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
            }

            return tmp_table;
        }

        public static Int32 GetMaxValue(out string error_msg, string key, string table_name)
        {
            DataTable tmp_table = ExecuteQuery(out error_msg, "select ifnull(max([" + key + "]),0) as MaxID from [" + table_name + "]");
            if (tmp_table != null && tmp_table.Rows.Count > 0)
            {
                return Convert.ToInt32(tmp_table.Rows[0][0].ToString());
            }
            return 0;
        }

        public static bool UpdateData(out string error_msg, string sql)
        {
            int result = 0;
            error_msg = string.Empty;

            try
            {
                SQLiteConnection conn = new SQLiteConnection(ConnString);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                error_msg = ex.Message;
                result = -1;
            }
            return result > 0;
        }
    }
}
