namespace CalcBalance_0_2_beta
{
    partial class InputStuffGoalForm
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtStuffName = new System.Windows.Forms.TextBox();
            this.TxtGoalBalance = new System.Windows.Forms.TextBox();
            this.TxtGoalBonus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(197, 201);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Enabled = false;
            this.BtnOK.Location = new System.Drawing.Point(105, 201);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "确定";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "员工姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "员工目标日均";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "员工最高绩效奖";
            // 
            // TxtStuffName
            // 
            this.TxtStuffName.Location = new System.Drawing.Point(136, 22);
            this.TxtStuffName.Name = "TxtStuffName";
            this.TxtStuffName.Size = new System.Drawing.Size(93, 21);
            this.TxtStuffName.TabIndex = 5;
            this.TxtStuffName.TextChanged += new System.EventHandler(this.TxtStuffName_TextChanged);
            // 
            // TxtGoalBalance
            // 
            this.TxtGoalBalance.Location = new System.Drawing.Point(136, 64);
            this.TxtGoalBalance.Name = "TxtGoalBalance";
            this.TxtGoalBalance.Size = new System.Drawing.Size(93, 21);
            this.TxtGoalBalance.TabIndex = 6;
            this.TxtGoalBalance.TextChanged += new System.EventHandler(this.TxtGoalBalance_TextChanged);
            // 
            // TxtGoalBonus
            // 
            this.TxtGoalBonus.Location = new System.Drawing.Point(136, 109);
            this.TxtGoalBonus.Name = "TxtGoalBonus";
            this.TxtGoalBonus.Size = new System.Drawing.Size(93, 21);
            this.TxtGoalBonus.TabIndex = 7;
            this.TxtGoalBonus.TextChanged += new System.EventHandler(this.TxtGoalBonus_TextChanged);
            // 
            // InputStuffGoalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.TxtGoalBonus);
            this.Controls.Add(this.TxtGoalBalance);
            this.Controls.Add(this.TxtStuffName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.BtnCancel);
            this.Name = "InputStuffGoalForm";
            this.Text = "输入员工绩效";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtStuffName;
        private System.Windows.Forms.TextBox TxtGoalBalance;
        private System.Windows.Forms.TextBox TxtGoalBonus;
    }
}