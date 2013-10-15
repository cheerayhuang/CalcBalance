using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CalcBalance_0_2_beta
{
    public delegate void _Dele_ReturnStuffGoal(string name, string balance, string bonus);

    public partial class InputStuffGoalForm : Form
    {
        public event _Dele_ReturnStuffGoal _Event_ReturnStuffGoal;

        public InputStuffGoalForm()
        {
            InitializeComponent();
        }

        private bool _IsFloatDigit(string str)
        {
            string pattern = @"^[0-9]+[\.]?[0-9]+$";

            if (Regex.IsMatch(str, pattern))
            {
                return true;
            }
            return false;
        }

        private void TxtStuffName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtStuffName.Text) &&
                !String.IsNullOrEmpty(TxtGoalBonus.Text) &&
                !String.IsNullOrEmpty(TxtGoalBalance.Text))
            {
                BtnOK.Enabled = true;
            }
        }

        private void TxtGoalBalance_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtStuffName.Text) &&
                !String.IsNullOrEmpty(TxtGoalBonus.Text) &&
                !String.IsNullOrEmpty(TxtGoalBalance.Text))
            {
                BtnOK.Enabled = true;
            }
        }

        private void TxtGoalBonus_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TxtStuffName.Text) &&
                !String.IsNullOrEmpty(TxtGoalBonus.Text) &&
                !String.IsNullOrEmpty(TxtGoalBalance.Text))
            {
                BtnOK.Enabled = true;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (_IsFloatDigit(TxtGoalBalance.Text) && _IsFloatDigit(TxtGoalBonus.Text))
            {
                _Event_ReturnStuffGoal(TxtStuffName.Text, TxtGoalBalance.Text, TxtGoalBonus.Text);
            }
            else
            {
                Common.DisplayMsg(Common.Prompts.GOAL_INFO_NOT_NUMBER, this.Text);
            }
        }
    }
}
