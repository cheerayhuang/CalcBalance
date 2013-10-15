using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcBalance_0_2_beta
{
    public enum QueryType
    {
        CLIENT_DAILY_BALANCE_ONLY,
        STAFF_CLIENT_INFO_ONLY,
        COMPUTE_AVERAGE_DAILY_BALANCE
    }

    abstract class Common
    {
        public static char[] DELIMITERS = {',', '|', ':', '\\'};

        public static string Goal_INFO_FILE = @"goal.conf";

        public static Dictionary<string, string> COLUMN_HEADER_TRANSFORM = new Dictionary<string, string>()
        {
            /*
            dt.Columns.Add("stuff_name", typeof(string));
            dt.Columns.Add("total_balance", typeof(decimal));
            dt.Columns.Add("avg_balance", typeof(decimal));
            dt.Columns.Add("goal_balance", typeof(decimal));
            dt.Columns.Add("task_ratio", typeof(string));
            dt.Columns.Add("bonus", typeof(decimal));
            dt.Columns.Add("deserved_bonus", typeof(decimal));
             */
            {"stuff_name", @"员工姓名"},
            {"total_balance", @"总结余"},
            {"avg_balance", @"日均余额"}, 
            {"goal_balance", @"目标日均余额"},
            {"task_ratio", @"目标完成度"},
            {"bonus", @"全额绩效"},
            {"deserved_bonus", @"应得绩效"},
            {"name", @"员工姓名"},
            {"account", @"客户账户"},
            {"client", @"客户姓名"},
            {"ratio", @"该员工对此客户占比"},
            {"date", @"日期"},
            {"balance", @"当日余额"},
            {"id", @"序号"}
        };

        public struct Prompts
        {
            public static string LOAD_DATA_SUCCESS = @"载入数据成功.";
            public static string UNLOAD_DATA_SUCCESS = @"清除数据成功.";
            public static string DATA_TOO_BIG = @"数据过大，是否需要显示结果?";
            public static string DATE_LACKING = @"请指定要查询的时段. 因未指定查询时段，将直接显示每天日均余额";
            public static string STUFF_LACKING = @"请指定员工名字.因未指定查询时段，将直接显示每天日均余额";
            public static string GOAL_INFO_NOT_NUMBER = @"员工目标日均应该是数字，输入信息错误，不会保存.";
        }

        public struct DB
        {
            public static string DB_PATH = @"database.db";
            public static string CLIENT_DAILY_BALANCE = "ClientDailyBalance";
            public static string STUFF_CLIENT_INFO = "StuffClientInfo";

            public enum Tables
            {
                CLIENT_DAILY_BALANCE,
                STAFF_CLIENT_INFO
            }
        }

        public static int CalcDaysAmoungMounths(DateTime from, DateTime to)
        {
            TimeSpan ts_from = new TimeSpan(from.Ticks); 
            TimeSpan ts_to = new TimeSpan(to.Ticks);
            TimeSpan ts_dur; 

            if (to < from)
            {
                return 0; 
            }

            ts_dur = ts_to.Subtract(ts_from).Duration();

            return Convert.ToInt32(ts_dur.Days.ToString());
        }

        public static DialogResult DisplayMsg(string msg, string caption)
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.OKCancel);
        }
    }
}
