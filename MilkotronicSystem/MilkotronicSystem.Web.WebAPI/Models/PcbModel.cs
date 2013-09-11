using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkotronicSystem.Web.WebAPI.Models
{
    public class PcbModel
    {
        public int Id { get; set; }

        public int PcbNumber { get; set; }

        public IEnumerable<int> Sensor { get; set; }

        public IEnumerable<PcbDataModel> PcbData { get; set; }

        public IEnumerable<PcbThermoModel> ThermoData { get; set; }
    }
}