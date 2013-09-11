namespace MilkotronicSystem.Desktop.WinFormsClient
{
    partial class ReportByDate
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Day = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Month = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Year = new System.Windows.Forms.TextBox();
            this.btn_reportByDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Day";
            // 
            // tb_Day
            // 
            this.tb_Day.Location = new System.Drawing.Point(55, 12);
            this.tb_Day.Name = "tb_Day";
            this.tb_Day.Size = new System.Drawing.Size(79, 20);
            this.tb_Day.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month";
            // 
            // tb_Month
            // 
            this.tb_Month.Location = new System.Drawing.Point(55, 51);
            this.tb_Month.Name = "tb_Month";
            this.tb_Month.Size = new System.Drawing.Size(79, 20);
            this.tb_Month.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Year";
            // 
            // tb_Year
            // 
            this.tb_Year.Location = new System.Drawing.Point(55, 89);
            this.tb_Year.Name = "tb_Year";
            this.tb_Year.Size = new System.Drawing.Size(79, 20);
            this.tb_Year.TabIndex = 5;
            // 
            // btn_reportByDate
            // 
            this.btn_reportByDate.Location = new System.Drawing.Point(30, 127);
            this.btn_reportByDate.Name = "btn_reportByDate";
            this.btn_reportByDate.Size = new System.Drawing.Size(104, 23);
            this.btn_reportByDate.TabIndex = 6;
            this.btn_reportByDate.Text = "Generate Report";
            this.btn_reportByDate.UseVisualStyleBackColor = true;
            this.btn_reportByDate.Click += new System.EventHandler(this.btn_reportByDate_Click);
            // 
            // ReportByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 160);
            this.Controls.Add(this.btn_reportByDate);
            this.Controls.Add(this.tb_Year);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Month);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Day);
            this.Controls.Add(this.label1);
            this.Name = "ReportByDate";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportByDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Day;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Year;
        private System.Windows.Forms.Button btn_reportByDate;
    }
}