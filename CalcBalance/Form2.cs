using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcBalance_0_2_beta
{
    public delegate void Dele_ReturnQueryCondition(QueryType type,
                                                   string name, 
                                                   string from, 
                                                   string to);

    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
        }

        public event Dele_ReturnQueryCondition Event_ReturnQueryCondition;

        private void RdoQueryDailyBalance_CheckedChanged(object sender, EventArgs e)
        {
            GrpDate.Enabled = false;
            GrpStuff.Enabled = false;
        }

        private void RdoQueryClientInfo_CheckedChanged(object sender, EventArgs e)
        {
            GrpDate.Enabled = false;
            GrpStuff.Enabled = false;
        }

        private void RdoQueryAverageBalance_CheckedChanged(object sender, EventArgs e)
        {
            GrpDate.Enabled = true;
            GrpStuff.Enabled = true;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            QueryType type = QueryType.COMPUTE_AVERAGE_DAILY_BALANCE;
            string name = string.Empty;
            string from = string.Empty;
            string to = string.Empty;

            if (RdoQueryDailyBalance.Checked)
            {
                type = QueryType.CLIENT_DAILY_BALANCE_ONLY;
            }
            else if (RdoQueryClientInfo.Checked)
            {
                type = QueryType.STAFF_CLIENT_INFO_ONLY;
            }

            if (type == QueryType.COMPUTE_AVERAGE_DAILY_BALANCE)
            {
                if (RdoAllTime.Checked)
                {
                    from = "ALL";
                }
                else if (RdoSpecialTime.Checked)
                {
                    from = string.Format("{0:yyyy-MM-dd}", DtpFrom.Value);
                    to = string.Format("{0:yyyy-MM-dd}", DtpTo.Value);
                }
                else
                {
                    Common.DisplayMsg(Common.Prompts.DATE_LACKING, this.Text);
                    return;
                }

                if (RdoAllStaff.Checked)
                {
                    name = "ALL";
                }
                else if (RdoSpecialStaff.Checked)
                {
                    if (TxtStuffName.Text == "")
                    {
                        Common.DisplayMsg(Common.Prompts.STUFF_LACKING, this.Text);
                        return;
                    }

                    name = TxtStuffName.Text;
                }
                else
                {
                    Common.DisplayMsg(Common.Prompts.STUFF_LACKING, this.Text);
                    return;
                }
            }
            Event_ReturnQueryCondition(type, name, from, to);
            this.Close();
        }

        private void RdoSpecialStaff_CheckedChanged(object sender, EventArgs e)
        {
            TxtStuffName.Enabled = true;
        }

        private void TxtStuffName_Click(object sender, EventArgs e)
        {
            TxtStuffName.SelectAll();
        }

        private void RdoAllStaff_CheckedChanged(object sender, EventArgs e)
        {
            TxtStuffName.Enabled = false;
        }


    }
}
