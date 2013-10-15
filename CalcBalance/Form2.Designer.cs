namespace CalcBalance_0_2_beta
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RdoAllTime = new System.Windows.Forms.RadioButton();
            this.RdoSpecialTime = new System.Windows.Forms.RadioButton();
            this.DtpFrom = new System.Windows.Forms.DateTimePicker();
            this.DtpTo = new System.Windows.Forms.DateTimePicker();
            this.GrpDate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpStuff = new System.Windows.Forms.GroupBox();
            this.TxtStuffName = new System.Windows.Forms.TextBox();
            this.RdoSpecialStaff = new System.Windows.Forms.RadioButton();
            this.RdoAllStaff = new System.Windows.Forms.RadioButton();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.RdoQueryDailyBalance = new System.Windows.Forms.RadioButton();
            this.RdoQueryAverageBalance = new System.Windows.Forms.RadioButton();
            this.RdoQueryClientInfo = new System.Windows.Forms.RadioButton();
            this.GrpDate.SuspendLayout();
            this.GrpStuff.SuspendLayout();
            this.SuspendLayout();
            // 
            // RdoAllTime
            // 
            this.RdoAllTime.AutoSize = true;
            this.RdoAllTime.Location = new System.Drawing.Point(14, 30);
            this.RdoAllTime.Name = "RdoAllTime";
            this.RdoAllTime.Size = new System.Drawing.Size(71, 16);
            this.RdoAllTime.TabIndex = 0;
            this.RdoAllTime.TabStop = true;
            this.RdoAllTime.Text = "所有时间";
            this.RdoAllTime.UseVisualStyleBackColor = true;
            // 
            // RdoSpecialTime
            // 
            this.RdoSpecialTime.AutoSize = true;
            this.RdoSpecialTime.Location = new System.Drawing.Point(14, 52);
            this.RdoSpecialTime.Name = "RdoSpecialTime";
            this.RdoSpecialTime.Size = new System.Drawing.Size(95, 16);
            this.RdoSpecialTime.TabIndex = 1;
            this.RdoSpecialTime.TabStop = true;
            this.RdoSpecialTime.Text = "指定日期时间";
            this.RdoSpecialTime.UseVisualStyleBackColor = true;
            // 
            // DtpFrom
            // 
            this.DtpFrom.Location = new System.Drawing.Point(36, 87);
            this.DtpFrom.Name = "DtpFrom";
            this.DtpFrom.Size = new System.Drawing.Size(200, 21);
            this.DtpFrom.TabIndex = 2;
            // 
            // DtpTo
            // 
            this.DtpTo.Location = new System.Drawing.Point(265, 87);
            this.DtpTo.Name = "DtpTo";
            this.DtpTo.Size = new System.Drawing.Size(200, 21);
            this.DtpTo.TabIndex = 3;
            // 
            // GrpDate
            // 
            this.GrpDate.Controls.Add(this.label1);
            this.GrpDate.Controls.Add(this.DtpFrom);
            this.GrpDate.Controls.Add(this.DtpTo);
            this.GrpDate.Controls.Add(this.RdoSpecialTime);
            this.GrpDate.Controls.Add(this.RdoAllTime);
            this.GrpDate.Enabled = false;
            this.GrpDate.Location = new System.Drawing.Point(4, 119);
            this.GrpDate.Name = "GrpDate";
            this.GrpDate.Size = new System.Drawing.Size(478, 128);
            this.GrpDate.TabIndex = 4;
            this.GrpDate.TabStop = false;
            this.GrpDate.Text = "日期";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "至";
            // 
            // GrpStuff
            // 
            this.GrpStuff.Controls.Add(this.TxtStuffName);
            this.GrpStuff.Controls.Add(this.RdoSpecialStaff);
            this.GrpStuff.Controls.Add(this.RdoAllStaff);
            this.GrpStuff.Enabled = false;
            this.GrpStuff.Location = new System.Drawing.Point(4, 253);
            this.GrpStuff.Name = "GrpStuff";
            this.GrpStuff.Size = new System.Drawing.Size(477, 118);
            this.GrpStuff.TabIndex = 5;
            this.GrpStuff.TabStop = false;
            this.GrpStuff.Text = "员工姓名";
            // 
            // TxtStuffName
            // 
            this.TxtStuffName.Enabled = false;
            this.TxtStuffName.Location = new System.Drawing.Point(36, 81);
            this.TxtStuffName.Name = "TxtStuffName";
            this.TxtStuffName.Size = new System.Drawing.Size(168, 21);
            this.TxtStuffName.TabIndex = 3;
            this.TxtStuffName.Text = "在这里输入员工姓名";
            this.TxtStuffName.Click += new System.EventHandler(this.TxtStuffName_Click);
            // 
            // RdoSpecialStaff
            // 
            this.RdoSpecialStaff.AutoSize = true;
            this.RdoSpecialStaff.Location = new System.Drawing.Point(14, 59);
            this.RdoSpecialStaff.Name = "RdoSpecialStaff";
            this.RdoSpecialStaff.Size = new System.Drawing.Size(71, 16);
            this.RdoSpecialStaff.TabIndex = 2;
            this.RdoSpecialStaff.TabStop = true;
            this.RdoSpecialStaff.Text = "指定员工";
            this.RdoSpecialStaff.UseVisualStyleBackColor = true;
            this.RdoSpecialStaff.CheckedChanged += new System.EventHandler(this.RdoSpecialStaff_CheckedChanged);
            // 
            // RdoAllStaff
            // 
            this.RdoAllStaff.AutoSize = true;
            this.RdoAllStaff.Location = new System.Drawing.Point(14, 37);
            this.RdoAllStaff.Name = "RdoAllStaff";
            this.RdoAllStaff.Size = new System.Drawing.Size(71, 16);
            this.RdoAllStaff.TabIndex = 1;
            this.RdoAllStaff.TabStop = true;
            this.RdoAllStaff.Text = "全体员工";
            this.RdoAllStaff.UseVisualStyleBackColor = true;
            this.RdoAllStaff.CheckedChanged += new System.EventHandler(this.RdoAllStaff_CheckedChanged);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(313, 377);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(407, 377);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 7;
            this.BtnOK.Text = "确定";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // RdoQueryDailyBalance
            // 
            this.RdoQueryDailyBalance.AutoSize = true;
            this.RdoQueryDailyBalance.Checked = true;
            this.RdoQueryDailyBalance.Location = new System.Drawing.Point(4, 21);
            this.RdoQueryDailyBalance.Name = "RdoQueryDailyBalance";
            this.RdoQueryDailyBalance.Size = new System.Drawing.Size(131, 16);
            this.RdoQueryDailyBalance.TabIndex = 8;
            this.RdoQueryDailyBalance.TabStop = true;
            this.RdoQueryDailyBalance.Text = "仅查询客户每日余额";
            this.RdoQueryDailyBalance.UseVisualStyleBackColor = true;
            this.RdoQueryDailyBalance.CheckedChanged += new System.EventHandler(this.RdoQueryDailyBalance_CheckedChanged);
            // 
            // RdoQueryAverageBalance
            // 
            this.RdoQueryAverageBalance.AutoSize = true;
            this.RdoQueryAverageBalance.Location = new System.Drawing.Point(4, 86);
            this.RdoQueryAverageBalance.Name = "RdoQueryAverageBalance";
            this.RdoQueryAverageBalance.Size = new System.Drawing.Size(95, 16);
            this.RdoQueryAverageBalance.TabIndex = 9;
            this.RdoQueryAverageBalance.Text = "计算日均余额";
            this.RdoQueryAverageBalance.UseVisualStyleBackColor = true;
            this.RdoQueryAverageBalance.CheckedChanged += new System.EventHandler(this.RdoQueryAverageBalance_CheckedChanged);
            // 
            // RdoQueryClientInfo
            // 
            this.RdoQueryClientInfo.AutoSize = true;
            this.RdoQueryClientInfo.Location = new System.Drawing.Point(4, 52);
            this.RdoQueryClientInfo.Name = "RdoQueryClientInfo";
            this.RdoQueryClientInfo.Size = new System.Drawing.Size(131, 16);
            this.RdoQueryClientInfo.TabIndex = 10;
            this.RdoQueryClientInfo.Text = "仅查询员工客户信息";
            this.RdoQueryClientInfo.UseVisualStyleBackColor = true;
            this.RdoQueryClientInfo.CheckedChanged += new System.EventHandler(this.RdoQueryClientInfo_CheckedChanged);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 412);
            this.Controls.Add(this.RdoQueryClientInfo);
            this.Controls.Add(this.RdoQueryAverageBalance);
            this.Controls.Add(this.RdoQueryDailyBalance);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrpStuff);
            this.Controls.Add(this.GrpDate);
            this.Name = "QueryForm";
            this.Text = "查询...";
            this.GrpDate.ResumeLayout(false);
            this.GrpDate.PerformLayout();
            this.GrpStuff.ResumeLayout(false);
            this.GrpStuff.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RdoAllTime;
        private System.Windows.Forms.RadioButton RdoSpecialTime;
        private System.Windows.Forms.DateTimePicker DtpFrom;
        private System.Windows.Forms.DateTimePicker DtpTo;
        private System.Windows.Forms.GroupBox GrpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GrpStuff;
        private System.Windows.Forms.RadioButton RdoSpecialStaff;
        private System.Windows.Forms.RadioButton RdoAllStaff;
        private System.Windows.Forms.TextBox TxtStuffName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.RadioButton RdoQueryDailyBalance;
        private System.Windows.Forms.RadioButton RdoQueryAverageBalance;
        private System.Windows.Forms.RadioButton RdoQueryClientInfo;

    }
}