namespace MilkotronicSystem.Desktop.WinFormsClient
{
    partial class ReportByOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportByOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Search = new System.Windows.Forms.TextBox();
            this.btn_GenReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order Number:";
            // 
            // tb_Search
            // 
            this.tb_Search.Location = new System.Drawing.Point(127, 47);
            this.tb_Search.Name = "tb_Search";
            this.tb_Search.Size = new System.Drawing.Size(83, 20);
            this.tb_Search.TabIndex = 1;
            // 
            // btn_GenReport
            // 
            this.btn_GenReport.Location = new System.Drawing.Point(70, 93);
            this.btn_GenReport.Name = "btn_GenReport";
            this.btn_GenReport.Size = new System.Drawing.Size(103, 23);
            this.btn_GenReport.TabIndex = 2;
            this.btn_GenReport.Text = "Generate Report";
            this.btn_GenReport.UseVisualStyleBackColor = true;
            this.btn_GenReport.Click += new System.EventHandler(this.btn_GenReport_Click);
            // 
            // ReportByOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 151);
            this.Controls.Add(this.btn_GenReport);
            this.Controls.Add(this.tb_Search);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportByOrder";
            this.Text = "Report By Order";
            this.Load += new System.EventHandler(this.ReportByOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Search;
        private System.Windows.Forms.Button btn_GenReport;
    }
}