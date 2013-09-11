namespace MilkotronicSystem.Desktop.WinFormsClient
{
    partial class MilkotronicSystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcbInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPcbNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportByDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byOrderNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDateAndOperatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.pcbInformationToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(520, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // pcbInformationToolStripMenuItem
            // 
            this.pcbInformationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byPcbNumberToolStripMenuItem});
            this.pcbInformationToolStripMenuItem.Name = "pcbInformationToolStripMenuItem";
            this.pcbInformationToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.pcbInformationToolStripMenuItem.Text = "Pcb Information";
            // 
            // byPcbNumberToolStripMenuItem
            // 
            this.byPcbNumberToolStripMenuItem.Name = "byPcbNumberToolStripMenuItem";
            this.byPcbNumberToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.byPcbNumberToolStripMenuItem.Text = "By Pcb Number";
            this.byPcbNumberToolStripMenuItem.Click += new System.EventHandler(this.byPcbNumberToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportByDateToolStripMenuItem,
            this.byOrderNumberToolStripMenuItem,
            this.byDateAndOperatorToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // reportByDateToolStripMenuItem
            // 
            this.reportByDateToolStripMenuItem.Name = "reportByDateToolStripMenuItem";
            this.reportByDateToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reportByDateToolStripMenuItem.Text = "By Date";
            this.reportByDateToolStripMenuItem.Click += new System.EventHandler(this.reportByDateToolStripMenuItem_Click);
            // 
            // byOrderNumberToolStripMenuItem
            // 
            this.byOrderNumberToolStripMenuItem.Name = "byOrderNumberToolStripMenuItem";
            this.byOrderNumberToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.byOrderNumberToolStripMenuItem.Text = "By Order Number";
            this.byOrderNumberToolStripMenuItem.Click += new System.EventHandler(this.byOrderNumberToolStripMenuItem_Click);
            // 
            // byDateAndOperatorToolStripMenuItem
            // 
            this.byDateAndOperatorToolStripMenuItem.Name = "byDateAndOperatorToolStripMenuItem";
            this.byDateAndOperatorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.byDateAndOperatorToolStripMenuItem.Text = "By Date and Operator";
            this.byDateAndOperatorToolStripMenuItem.Click += new System.EventHandler(this.byDateAndOperatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MilkotronicSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 225);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MilkotronicSystem";
            this.Text = "Milkotronic System";
            this.Load += new System.EventHandler(this.MilkotronicSystem_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pcbInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportByDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byOrderNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPcbNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDateAndOperatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

