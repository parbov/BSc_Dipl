using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkotronicSystem.Data
{
    /// <summary>
    /// Class with functions for data manipulation
    /// </summary>
   public class PcbDAL
    {
       /// <summary>
       /// Method for creating database context and sending data for manipulation
       /// </summary>
       public static void AddPcbData(string date, string time, string operation, string model, string pcb, string box,
            string sensor, string speed, string cal1, string cal2, string cal3, string program, string data, string orderNumber,
            string clientName, string country, string operatorInitials, string programVersion, string options)
       {
           MilkotronicSystemEntities context = new MilkotronicSystemEntities();

           CreateOrLoadPcbData(context, date, time, operation, model, pcb, box, sensor, speed, cal1, cal2, cal3, program, data,
                            orderNumber, clientName, country, operatorInitials, programVersion, options);
           
       }

       /// <summary>
       /// Method for creating database context and sending data for manipulation
       /// </summary>
       public static void AddThermoData(string date, string time, string box, string pcb, string sensor, string newbox,
           string newPcb, string newSensor, string n40, string p60, string workplace, string programversion,
           string ad623, string amplitude)
       {
           MilkotronicSystemEntities context = new MilkotronicSystemEntities();

           CreateOrLoadThermoData(context,date,time,box,pcb,sensor,newbox,newPcb,newSensor,n40,p60,workplace,programversion,ad623,amplitude);

       }

       private static Thermo_Data CreateOrLoadThermoData(MilkotronicSystemEntities context, string date, string time, string box, string pcb, string sensor, string newbox, string newPcb, string newSensor, string n40, string p60, string workplace, string programversion, string ad623, string amplitude)
       {
           int enteredPcbNumber = int.Parse(pcb);
           Thermo_Data existingThermoData =
               (from d in context.Thermo_Data
                where d.numberPcb == enteredPcbNumber
                select d).FirstOrDefault();
           if (existingThermoData != null)
           {
               return existingThermoData;
           }
           Sensor createSensor = CreateOrLoadSensor(context, sensor, pcb);
           Thermo_Data newThermoData = new Thermo_Data();

           if (pcb == newPcb)
           {
               if (sensor == newSensor)
               {
                   newThermoData.PCB = CreateOrLoadPcb(context, pcb, sensor);
               }
               else
               {
                   newThermoData.PCB = CreateOrLoadPcb(context, pcb, newSensor);
               }
           }
           else
           {
               if (sensor == newSensor)
               {
                   newThermoData.PCB = CreateOrLoadPcb(context, newPcb, sensor);
               }
               else
               {
                   newThermoData.PCB = CreateOrLoadPcb(context, newPcb, newSensor);
               }
           }
           newThermoData.date = date;
           newThermoData.time = time;
           newThermoData.workplace = workplace;
           newThermoData.programVersion =double.Parse(programversion);
           newThermoData.P60 =int.Parse(p60);
           newThermoData.N40 = int.Parse(n40);
           newThermoData.numberPcb = int.Parse(newPcb);
           newThermoData.ad623 = int.Parse(ad623);
           newThermoData.box = int.Parse(box);
           newThermoData.sensor = int.Parse(newSensor);
           if (amplitude == "")
           {
               newThermoData.amplitude = 0;
           }
           else
           {
               newThermoData.amplitude = int.Parse(amplitude);
           }

           context.Thermo_Data.Add(newThermoData);
           context.SaveChanges();

           return newThermoData;

       }


       private static PCB_Data CreateOrLoadPcbData(MilkotronicSystemEntities context, string date, string time, string operation, string model, string pcb, string box,
            string sensor, string speed, string cal1, string cal2, string cal3, string program, string data, string orderNumber,
            string clientName, string country, string operatorInitials, string programVersion, string options)
       {
           int pcbNum = int.Parse(pcb);
           PCB_Data existingPcbData =
               (from d in context.PCB_Data
                where d.numberPcb == pcbNum
                select d).FirstOrDefault();
           if (existingPcbData != null)
           {
               return existingPcbData;
           }

           Sensor createSensor = CreateOrLoadSensor(context, sensor, pcb);

           PCB_Data newPcbData = new PCB_Data();

           newPcbData.PCB = CreateOrLoadPcb(context, pcb, sensor);
           newPcbData.date = date;
           newPcbData.time = time;
           newPcbData.operation = operation;
           newPcbData.model = model;
           newPcbData.boxNumber = int.Parse(box);
           newPcbData.speed = speed;
           newPcbData.Cal1 = cal1;
           newPcbData.Cal2 = cal2;
           newPcbData.Cal3 = cal3;
           newPcbData.program = program;
           newPcbData.data = data;
           newPcbData.orderNumber = orderNumber;
           newPcbData.ClientName = clientName;
           newPcbData.country = country;
           newPcbData.@operator = operatorInitials;
           newPcbData.programVersion = double.Parse(programVersion);
           newPcbData.options = options;
           newPcbData.numberPcb = int.Parse(pcb);
           newPcbData.numberSensor = int.Parse(sensor);

           context.PCB_Data.Add(newPcbData);
           context.SaveChanges();

           return newPcbData;
       }

       private static Sensor CreateOrLoadSensor(MilkotronicSystemEntities context, string sensor,string pcb)
       {
           int sensorNum=int.Parse(sensor);
           Sensor existingSensor =
               (from s in context.Sensors
                where s.number == sensorNum
                select s).FirstOrDefault();
           if (existingSensor != null)
           {
               return existingSensor;
           }

           Sensor newSensor = new Sensor();
           newSensor.number = int.Parse(sensor);
           newSensor.PCB = CreateOrLoadPcb(context, pcb, sensor);
           context.Sensors.Add(newSensor);
           context.SaveChanges();

           return newSensor;
       }

       private static PCB CreateOrLoadPcb(MilkotronicSystemEntities context, string pcb,string sensor)
       {
           int pcbNum = int.Parse(pcb);
           PCB existingPcb =
               (from p in context.PCBs
                where p.pcbNumber == pcbNum
                select p).FirstOrDefault();
           if (existingPcb != null)
           {
               return existingPcb;
           }

           PCB newPcb = new PCB();
           newPcb.pcbNumber = int.Parse(pcb);
           context.PCBs.Add(newPcb);
           context.SaveChanges();

           return newPcb;
       }

    }
}
