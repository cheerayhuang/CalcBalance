namespace CalcBalance_0_2_beta
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnLoadClientBalance = new System.Windows.Forms.Button();
            this.btnUnloadClientBalance = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadStaffInfo = new System.Windows.Forms.Button();
            this.btnUnloadStaffInfo = new System.Windows.Forms.Button();
            this.BtnBeginQuery = new System.Windows.Forms.Button();
            this.PrgMain = new System.Windows.Forms.ProgressBar();
            this.BtnUnloadGoal = new System.Windows.Forms.Button();
            this.BtnLoadGoal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(12, 25);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(797, 287);
            this.dgvResult.TabIndex = 0;
            // 
            // btnLoadClientBalance
            // 
            this.btnLoadClientBalance.Location = new System.Drawing.Point(21, 331);
            this.btnLoadClientBalance.Name = "btnLoadClientBalance";
            this.btnLoadClientBalance.Size = new System.Drawing.Size(115, 23);
            this.btnLoadClientBalance.TabIndex = 1;
            this.btnLoadClientBalance.Text = "载入客户日余额";
            this.btnLoadClientBalance.UseVisualStyleBackColor = true;
            this.btnLoadClientBalance.Click += new System.EventHandler(this.btnLoadClientBalance_Click);
            // 
            // btnUnloadClientBalance
            // 
            this.btnUnloadClientBalance.Location = new System.Drawing.Point(21, 369);
            this.btnUnloadClientBalance.Name = "btnUnloadClientBalance";
            this.btnUnloadClientBalance.Size = new System.Drawing.Size(115, 23);
            this.btnUnloadClientBalance.TabIndex = 2;
            this.btnUnloadClientBalance.Text = "清除客户日余额";
            this.btnUnloadClientBalance.UseVisualStyleBackColor = true;
            this.btnUnloadClientBalance.Click += new System.EventHandler(this.btnUnloadClientBalance_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前结果";
            // 
            // btnLoadStaffInfo
            // 
            this.btnLoadStaffInfo.Location = new System.Drawing.Point(170, 331);
            this.btnLoadStaffInfo.Name = "btnLoadStaffInfo";
            this.btnLoadStaffInfo.Size = new System.Drawing.Size(119, 23);
            this.btnLoadStaffInfo.TabIndex = 4;
            this.btnLoadStaffInfo.Text = "载入员工信息";
            this.btnLoadStaffInfo.UseVisualStyleBackColor = true;
            this.btnLoadStaffInfo.Click += new System.EventHandler(this.btnLoadStaffInfo_Click);
            // 
            // btnUnloadStaffInfo
            // 
            this.btnUnloadStaffInfo.Location = new System.Drawing.Point(170, 369);
            this.btnUnloadStaffInfo.Name = "btnUnloadStaffInfo";
            this.btnUnloadStaffInfo.Size = new System.Drawing.Size(119, 23);
            this.btnUnloadStaffInfo.TabIndex = 5;
            this.btnUnloadStaffInfo.Text = "清除员工信息";
            this.btnUnloadStaffInfo.UseVisualStyleBackColor = true;
            this.btnUnloadStaffInfo.Click += new System.EventHandler(this.btnUnloadStaffInfo_Click);
            // 
            // BtnBeginQuery
            // 
            this.BtnBeginQuery.Location = new System.Drawing.Point(706, 331);
            this.BtnBeginQuery.Name = "BtnBeginQuery";
            this.BtnBeginQuery.Size = new System.Drawing.Size(103, 61);
            this.BtnBeginQuery.TabIndex = 6;
            this.BtnBeginQuery.Text = "开始查询";
            this.BtnBeginQuery.UseVisualStyleBackColor = true;
            this.BtnBeginQuery.Click += new System.EventHandler(this.BtnBeginQuery_Click);
            // 
            // PrgMain
            // 
            this.PrgMain.Location = new System.Drawing.Point(69, 9);
            this.PrgMain.Name = "PrgMain";
            this.PrgMain.Size = new System.Drawing.Size(740, 12);
            this.PrgMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PrgMain.TabIndex = 7;
            this.PrgMain.Visible = false;
            // 
            // BtnUnloadGoal
            // 
            this.BtnUnloadGoal.Location = new System.Drawing.Point(323, 369);
            this.BtnUnloadGoal.Name = "BtnUnloadGoal";
            this.BtnUnloadGoal.Size = new System.Drawing.Size(119, 23);
            this.BtnUnloadGoal.TabIndex = 8;
            this.BtnUnloadGoal.Text = "删除所有员工绩效信息";
            this.BtnUnloadGoal.UseVisualStyleBackColor = true;
            this.BtnUnloadGoal.Click += new System.EventHandler(this.BtnUnloadGoal_Click);
            // 
            // BtnLoadGoal
            // 
            this.BtnLoadGoal.Location = new System.Drawing.Point(323, 331);
            this.BtnLoadGoal.Name = "BtnLoadGoal";
            this.BtnLoadGoal.Size = new System.Drawing.Size(119, 23);
            this.BtnLoadGoal.TabIndex = 9;
            this.BtnLoadGoal.Text = "输入员工绩效信息";
            this.BtnLoadGoal.UseVisualStyleBackColor = true;
            this.BtnLoadGoal.Click += new System.EventHandler(this.BtnLoadGoal_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 404);
            this.Controls.Add(this.BtnLoadGoal);
            this.Controls.Add(this.BtnUnloadGoal);
            this.Controls.Add(this.PrgMain);
            this.Controls.Add(this.BtnBeginQuery);
            this.Controls.Add(this.btnUnloadStaffInfo);
            this.Controls.Add(this.btnLoadStaffInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnloadClientBalance);
            this.Controls.Add(this.btnLoadClientBalance);
            this.Controls.Add(this.dgvResult);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "日均余额计算器 v0.3 beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnLoadClientBalance;
        private System.Windows.Forms.Button btnUnloadClientBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadStaffInfo;
        private System.Windows.Forms.Button btnUnloadStaffInfo;
        private System.Windows.Forms.Button BtnBeginQuery;
        private System.Windows.Forms.ProgressBar PrgMain;
        private System.Windows.Forms.Button BtnUnloadGoal;
        private System.Windows.Forms.Button BtnLoadGoal;
    }
}

