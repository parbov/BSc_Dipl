using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkotronicSystem.Desktop.WinFormsClient
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
