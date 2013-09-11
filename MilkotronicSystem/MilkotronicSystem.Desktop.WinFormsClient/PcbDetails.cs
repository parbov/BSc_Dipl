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
using Newtonsoft.Json;

namespace MilkotronicSystem.Desktop.WinFormsClient
{
    public partial class PcbDetails : Form
    {
        public string sessionKey { get; set; }
        public PcbDetails(string sessionKey)
        {
            InitializeComponent();
            this.sessionKey = sessionKey;
        }

        public PcbDetails()
        {
            InitializeComponent();
        }

        private void PcbDetails_Load(object sender, EventArgs e)
        {

        }

        private void btn_ShowInfo_Click(object sender, EventArgs e)
        {
            string pcbNumber = tb_Search.Text;
            string url = "http://localhost:63494/api/pcbs/get-by-pcb?sessionKey=";
            url = url + sessionKey;
            url = url + "&searchNumber=";
            url = url + pcbNumber;

            var client = new WebClient();
            var pcbs = client.DownloadString(url);

            IList<PcbModel> des = JsonConvert.DeserializeObject<IList<PcbModel>>(pcbs);

            if (des.Count != 0)
            {
                var desSensorData = des[0].Sensor;
                if (desSensorData.Count() != 0)
                {
                    var sensorData = desSensorData.First();
                    tb_Sensor.Text = sensorData.ToString();
                }

                var desPcbData = des[0].PcbData;
                if (desPcbData.Count() != 0)
                {
                    var pcbData = desPcbData.First();
                    tb_Cal1.Text = pcbData.Cal1;
                    tb_Cal2.Text = pcbData.Cal2;
                    tb_Cal3.Text = pcbData.Cal3;
                    tb_Client.Text = pcbData.ClientName;
                    tb_Country.Text = pcbData.Country;
                    tb_Date.Text = pcbData.Date;
                    tb_Model.Text = pcbData.Model;
                    tb_Options.Text = pcbData.Options;
                    tb_Order.Text = pcbData.OrderNumber;
                    tb_Speed.Text = pcbData.Speed;
                }

                var desThermoData = des[0].ThermoData;
                if (desThermoData.Count() != 0)
                {
                    var thermoData = desThermoData.First();
                    tb_P60.Text = thermoData.P60.ToString();
                    tb_N40.Text = thermoData.N40.ToString();
                    tb_Ad623.Text = thermoData.Ad623.ToString();
                    tb_Amplitude.Text = thermoData.Amplitude.ToString();
                    tb_Box.Text = thermoData.BoxNumber.ToString();
                    tb_Sensor.Text = thermoData.PcbSensor.ToString();
                }
            }
            else
            {
                MessageBox.Show("No Information Found about this PCB");
            }

            
            
             // MessageBox.Show(pcbs);
        }
    }
}
