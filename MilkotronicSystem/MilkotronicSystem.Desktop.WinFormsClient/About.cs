using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkotronicSystem.Desktop.WinFormsClient
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.labelProduct.Text = "Milkotronic System Desktop Client";
            this.labelVersion.Text = "1.0";
            this.labelCreatedBy.Text = "Petko Arbov";
            this.labelYear.Text = "2013";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
