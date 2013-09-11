using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkotronicSystem.Desktop.WinFormsClient
{
    public partial class MilkotronicSystem : Form
    {
        public string sessionKey { get; set; }

        public MilkotronicSystem(string sessionKey)
        {
            InitializeComponent();
            this.sessionKey = sessionKey;
        }

        public MilkotronicSystem()
        {
            InitializeComponent();
        }

        private void byPcbNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PcbDetails pcbDetailsForm = new PcbDetails(sessionKey);
            pcbDetailsForm.Show();
        }

        private void reportByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportByDate report = new ReportByDate(sessionKey);
            report.Show();
        }

        private void MilkotronicSystem_Load(object sender, EventArgs e)
        {

        }

        private void byOrderNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportByOrder report = new ReportByOrder(sessionKey);
            report.Show();
        }

        private void byDateAndOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportByDateOperator report = new ReportByDateOperator(sessionKey);
            report.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:63494/api/users/logout?sessionKey=";
            url += sessionKey;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "";

                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            MessageBox.Show("Succesfully Logged out!");
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

       
    }
}
