using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkotronicSystem.Web.WebAPI.Models
{
    public class PcbThermoModel
    {


        public int Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int? BoxNumber { get; set; }

        public int PcbSensor { get; set; }

        public int? N40 { get; set; }

        public int? P60 { get; set; }

        public string Workplace { get; set; }

        public double? ProgramVersion { get; set; }

        public int? Ad623 { get; set; }

        public int? Amplitude { get; set; }

        public int PcbNumber { get; set; }
    }
}