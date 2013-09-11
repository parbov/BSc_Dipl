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
    public partial class ReportByOrder : Form
    {
        protected string sessionKey { get; set; }

        public ReportByOrder()
        {
            InitializeComponent();
        }

        public ReportByOrder(string sessionKey)
        {
            InitializeComponent();
            this.sessionKey = sessionKey;

        }

        private void ReportByOrder_Load(object sender, EventArgs e)
        {

        }

        private void btn_GenReport_Click(object sender, EventArgs e)
        {
            string order = tb_Search.Text.ToUpper();

            string url = "http://localhost:63494/api/pcbs/get-pcbdata-byorder?sessionKey=";
            url = url + sessionKey;
            url += "&orderNumber=";
            url += order;

            var client = new WebClient();
            var pcbs = client.DownloadString(url);

            IList<PcbDataModel> des = JsonConvert.DeserializeObject<IList<PcbDataModel>>(pcbs);

            XmlDocument doc = new XmlDocument();// Create the XML Declaration, and append it to XML document
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);// Create the root element
            XmlElement root = doc.CreateElement("report");
            root.SetAttribute("order", order);
            doc.AppendChild(root);

            foreach (var item in des)
            {
                XmlElement analyzer = doc.CreateElement("analyzer");
                XmlElement pcb = doc.CreateElement("pcb");
                pcb.InnerText = item.PcbNumber.ToString();
                XmlElement sensor = doc.CreateElement("sensor");
                sensor.InnerText = item.SensorNumber.ToString().Trim();
                XmlElement model = doc.CreateElement("model");
                model.InnerText = item.Model.Trim();
                XmlElement speed = doc.CreateElement("speed");
                speed.InnerText = item.Speed.Trim();
                XmlElement stationOperator = doc.CreateElement("operator");
                stationOperator.InnerText = item.Operator.Trim();
                
                analyzer.AppendChild(pcb);
                analyzer.AppendChild(sensor);
                analyzer.AppendChild(model);
                analyzer.AppendChild(speed);
                analyzer.AppendChild(stationOperator);
                root.AppendChild(analyzer);
            }

            string reportName = "../report-order-" + order + ".xml";
            doc.Save(reportName);

            MessageBox.Show("Report Generated");
        }
    }
}
