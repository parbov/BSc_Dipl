using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MilkotronicSystem.Desktop.WinFormsClient
{
    public partial class ReportByDateOperator : Form
    {
        protected string sessionKey { get; set; }

        public ReportByDateOperator()
        {
            InitializeComponent();
        }

        public ReportByDateOperator(string sessionKey)
        {
            InitializeComponent();
            this.sessionKey = sessionKey;
        }

        private void btn_reportByDate_Click(object sender, EventArgs e)
        {
            //28-01-13
            string day = string.Empty;
            string readDay = tb_Day.Text;
            int checkDay = int.Parse(readDay);
            if (checkDay < 10)
            {
                day = "0" + checkDay.ToString();
            }
            else
            {
                day = readDay;
            }

            string month = string.Empty;
            string readMonth = tb_Month.Text;
            int checkMonth = int.Parse(readMonth);
            if (checkMonth < 10)
            {
                month = "0" + readMonth;
            }
            else
            {
                month = readMonth;
            }

            string year = string.Empty;
            string readYear = tb_Year.Text;
            int checkYear = int.Parse(readYear);
            if (checkYear > 99)
            {
                year = readYear[2].ToString() + readYear[3].ToString();
            }
            else
            {
                year = readYear;
            }

            string date = day + "-" + month + "-" + year;
            string stationOperator = tb_Operator.Text;

            string url = "http://localhost:63494/api/pcbs/get-pcbdata-bydateoperator?sessionKey=";
            url = url + sessionKey;
            url += "&date=";
            url += date;
            url += "&placeOperator=";
            url += stationOperator;

            var client = new WebClient();
            var pcbs = client.DownloadString(url);

            IList<PcbDataModel> des = JsonConvert.DeserializeObject<IList<PcbDataModel>>(pcbs);

            XmlDocument doc = new XmlDocument();// Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);// Create the root element
            XmlElement root = doc.CreateElement("report");
            root.SetAttribute("date", date);
            root.SetAttribute("operator", stationOperator);
            doc.AppendChild(root);

            foreach (var item in des)
            {
                XmlElement analyzer = doc.CreateElement("analyzer");
                XmlElement pcb = doc.CreateElement("pcb");
                pcb.InnerText = item.PcbNumber.ToString();
                XmlElement sensor = doc.CreateElement("sensor");
                sensor.InnerText = item.SensorNumber.ToString();
                XmlElement model = doc.CreateElement("model");
                model.InnerText = item.Model;
                XmlElement speed = doc.CreateElement("speed");
                speed.InnerText = item.Speed;
                XmlElement order = doc.CreateElement("order");
                order.InnerText = item.OrderNumber;

                analyzer.AppendChild(pcb);
                analyzer.AppendChild(sensor);
                analyzer.AppendChild(model);
                analyzer.AppendChild(speed);
                analyzer.AppendChild(order);
                root.AppendChild(analyzer);
            }

            string reportName = "../report-from-" + date +"-operator-"+stationOperator+ ".xml";
            doc.Save(reportName);

            MessageBox.Show("Report Generated");
        }
    }
}
