using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilkotronicSystem.Data;
using System.IO;
using System.Net;
using System.Net.Http;

namespace MilkotronicSystem.Desktop.ConsoleClient
{
    class Program
    {
        static void Main()
        {
            UpdateMainPcbData();
            UpdateThermoData();
            
        }


        private static void UpdateThermoData()
        {
            StreamReader reader = new StreamReader("LSSetup-Thermo-NK1.log");
            using (reader)
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] attributes = line.Split('\t');
                    

                    if (attributes.Length >= 2)
                    {
                        string date = attributes[0];
                        string time = attributes[1];
                        string box = attributes[2];
                        string pcb = attributes[3];
                        string sensor = attributes[4];
                        string newBox = attributes[5];
                        string newPcb = attributes[6];
                        string newSensor = attributes[7];
                        string N40 = attributes[8];
                        string P60 = attributes[9];
                        string workplace = attributes[10];
                        string progVersion = attributes[11];
                        string ad623 = attributes[12];
                        string amplitude = attributes[13];

                        PcbDAL.AddThermoData(date, time, box, pcb, sensor, newBox, newPcb, newSensor, N40,
                            P60, workplace, progVersion, ad623, amplitude);
                    }
                }
            }
        }

        private static void UpdateMainPcbData()
        {
            StreamReader reader = new StreamReader("LSProd-MainPCB.log");
            using (reader)
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine();
                    string[] attributes = line.Split('\t');

                    if (attributes.Length >= 2)
                    {
                        string date = attributes[0];
                        string time = attributes[1];
                        string operation = attributes[2];
                        string model = attributes[3];
                        string pcb = attributes[4];
                        string box = attributes[5];
                        string sensor = attributes[6];
                        string speed = attributes[7];
                        string cal1 = attributes[8];
                        string cal2 = attributes[9];
                        string cal3 = attributes[10];
                        string program = attributes[11];
                        string data = attributes[12];
                        string orderNumber = attributes[13];
                        string clientName = attributes[14];
                        string country = attributes[15];
                        string operatorInitials = attributes[16];
                        string programVersion = attributes[17];
                        string options = attributes[18];

                        PcbDAL.AddPcbData(date, time, operation, model, pcb, box, sensor, speed, cal1, cal2, cal3, program, data,
                            orderNumber, clientName, country, operatorInitials, programVersion, options);
                        // TestParser(date, time, operation, model, pcb, box, sensor, speed, cal1, cal2, cal3, program, data,
                        //     orderNumber, clientName, country, operatorInitials, programVersion, options);
                    }
                }
            }
        }

        private static void TestParser(string date, string time, string operation, string model, string pcb, string box,
            string sensor, string speed, string cal1, string cal2, string cal3, string program, string data, string orderNumber,
            string clientName, string country, string operatorInitials, string programVersion, string options)
        {
            Console.WriteLine(date);
            Console.WriteLine(time);
            Console.WriteLine(operation);
            Console.WriteLine(model);
            Console.WriteLine(pcb);
            Console.WriteLine(box);
            Console.WriteLine(sensor);
            Console.WriteLine(speed);
            Console.WriteLine(cal1);
            Console.WriteLine(cal2);
            Console.WriteLine(cal3);
            Console.WriteLine(program);
            Console.WriteLine(data);
            Console.WriteLine(orderNumber);
            Console.WriteLine(clientName);
            Console.WriteLine(country);
            Console.WriteLine(operatorInitials);
            Console.WriteLine(programVersion);
            Console.WriteLine(options);
            Console.WriteLine("------------------------");
            Console.WriteLine();
        }
    }
}
