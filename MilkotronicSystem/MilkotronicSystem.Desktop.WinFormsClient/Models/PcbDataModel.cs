using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkotronicSystem.Desktop.WinFormsClient
{
   public class PcbDataModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Operation { get; set; }

        public string Model { get; set; }

        public string Speed { get; set; }

        public int? BoxNumber { get; set; }

        public string Cal1 { get; set; }

        public string Cal2 { get; set; }

        public string Cal3 { get; set; }

        public string program { get; set; }

        public string Data { get; set; }

        public string ClientName { get; set; }

        public string OrderNumber { get; set; }

        public string Country { get; set; }

        public string Operator { get; set; }

        public double? ProgramVersion { get; set; }

        public string Options { get; set; }

        public int PcbNumber { get; set; }

        public int SensorNumber { get; set; }

    }
}
