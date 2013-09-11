﻿using MilkotronicSystem.Web.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using MilkotronicSystem.Web.WebAPI;
using MilkotronicSystem.Web.WebAPI.Controllers;
using MilkotronicSystem.Data;

namespace MilkotronicSystem.Web.WebAPI.Controllers
{
    public class PcbsController : BaseApiController
    {
        public PcbsController()
        {
        }

        [HttpGet]
        [ActionName("get-all")]
       public IQueryable<PcbModel> GetAll(string sessionKey)
       {
           var responseMsg = this.PerformOperationAndHandleExceptions(() =>
           {
               MilkotronicSystemEntities context = new MilkotronicSystemEntities();

               var user = context.Users.FirstOrDefault(usr => usr.sessionKey == sessionKey);
               if (user == null)
               {
                   throw new InvalidOperationException("Invalid username or password");
               }

               var pcbEntities = context.PCBs;
               var models =
                   (from pcbEntity in pcbEntities
                    select new PcbModel()
                    {
                        Id = pcbEntity.id,
                        PcbNumber = pcbEntity.pcbNumber,
                        Sensor = (from sensorEntity in pcbEntity.Sensors
                                  select sensorEntity.number),
                        PcbData = (from pcbDataEntity in pcbEntity.PCB_Data
                                   select new PcbDataModel()
                                   {
                                       Id = pcbDataEntity.id,
                                       Date = pcbDataEntity.date,
                                       Time = pcbDataEntity.time,
                                       Operation = pcbDataEntity.operation,
                                       Model = pcbDataEntity.model,
                                       BoxNumber = pcbDataEntity.boxNumber,
                                       Speed = pcbDataEntity.speed,
                                       Cal1 = pcbDataEntity.Cal1,
                                       Cal2 = pcbDataEntity.Cal2,
                                       Cal3 = pcbDataEntity.Cal3,
                                       program = pcbDataEntity.program,
                                       Data = pcbDataEntity.data,
                                       OrderNumber = pcbDataEntity.orderNumber,
                                       ClientName = pcbDataEntity.ClientName,
                                       Country = pcbDataEntity.country,
                                       Operator = pcbDataEntity.@operator,
                                       ProgramVersion = pcbDataEntity.programVersion,
                                       Options = pcbDataEntity.options,
                                       PcbNumber = pcbDataEntity.numberPcb,
                                       SensorNumber = pcbDataEntity.numberSensor

                                   }),
                        ThermoData = (from thermoDataEntity in pcbEntity.Thermo_Data
                                      select new PcbThermoModel()
                                      {
                                          Id = thermoDataEntity.id,
                                          Date = thermoDataEntity.date,
                                          Time = thermoDataEntity.time,
                                          BoxNumber = thermoDataEntity.box,
                                          PcbSensor = thermoDataEntity.sensor,
                                          N40 = thermoDataEntity.N40,
                                          P60 = thermoDataEntity.P60,
                                          Workplace = thermoDataEntity.workplace,
                                          ProgramVersion = thermoDataEntity.programVersion,
                                          Ad623 = thermoDataEntity.ad623,
                                          Amplitude = thermoDataEntity.amplitude,
                                          PcbNumber = thermoDataEntity.numberPcb

                                      })
                    });
               return models.OrderByDescending(thr => thr.PcbNumber);
           });

           return responseMsg;
       }

        [HttpGet]
        [ActionName("get-by-pcb")]
        public IQueryable<PcbModel> GetByPcbNumber(string sessionKey, int searchNumber)
        {
            var models = this.GetAll(sessionKey)
                .Where(pcb=>pcb.PcbNumber.Equals(searchNumber));
            return models;
        }

        [HttpGet]
        [ActionName("get-by-date")]
        public IQueryable<PcbModel> GetByDate(string sessionKey, string date)
        {
            var models = this.GetAll(sessionKey)
                .Where(pcb => pcb.PcbData.Any(d => d.Date == date));
            return models;
                
        }

        [HttpGet]
        [ActionName("get-by-date-operator")]
        public IQueryable<PcbModel> GetByDateAndOperator(string sessionkey, string date, string placeOperator)
        {
            var models = this.GetAll(sessionkey)
                .Where(pcb => pcb.PcbData.Any(d => d.Date == date && d.Operator == placeOperator));
            return models;
        }

        [HttpGet]
        [ActionName("get-by-order")]
        public IQueryable<PcbModel> GetByOrderNumber(string sessionKey, string orderNumber)
        {
            var models = this.GetAll(sessionKey)
                .Where(pcb => pcb.PcbData.Any(order => order.OrderNumber == orderNumber));
            return models;
        }

        [HttpGet]
        [ActionName("get-pcbdata")]
        public IQueryable<PcbDataModel> GetAllPcbData(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                MilkotronicSystemEntities context = new MilkotronicSystemEntities();

                var user = context.Users.FirstOrDefault(usr => usr.sessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid username or password");
                }

                var pcbEntities = context.PCB_Data;
                var models =
                    (from pcbDataEntity in pcbEntities
                     select new PcbDataModel()
                     {
                         
                                        Id = pcbDataEntity.id,
                                        Date = pcbDataEntity.date,
                                        Time = pcbDataEntity.time,
                                        Operation = pcbDataEntity.operation,
                                        Model = pcbDataEntity.model,
                                        BoxNumber = pcbDataEntity.boxNumber,
                                        Speed = pcbDataEntity.speed,
                                        Cal1 = pcbDataEntity.Cal1,
                                        Cal2 = pcbDataEntity.Cal2,
                                        Cal3 = pcbDataEntity.Cal3,
                                        program = pcbDataEntity.program,
                                        Data = pcbDataEntity.data,
                                        OrderNumber = pcbDataEntity.orderNumber,
                                        ClientName = pcbDataEntity.ClientName,
                                        Country = pcbDataEntity.country,
                                        Operator = pcbDataEntity.@operator,
                                        ProgramVersion = pcbDataEntity.programVersion,
                                        Options = pcbDataEntity.options,
                                        PcbNumber = pcbDataEntity.numberPcb,
                                        SensorNumber=pcbDataEntity.numberSensor

                                  
                     });
                return models.OrderByDescending(thr => thr.PcbNumber);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-pcbdata-bynumber")]
        public IQueryable<PcbDataModel> GetPcbDataByNumber(string sessionKey, int searchNumber)
        {
            var models = this.GetAllPcbData(sessionKey)
                .Where(pcb => pcb.PcbNumber.Equals(searchNumber));
            return models;
        }

        [HttpGet]
        [ActionName("get-pcbdata-bydate")]
        public IQueryable<PcbDataModel> GetPcbDataByDate(string sessionKey,string date)
        {
            var models = this.GetAllPcbData(sessionKey)
                .Where(pcb => pcb.Date.Equals(date));
            return models;
        }

        [HttpGet]
        [ActionName("get-pcbdata-bydateoperator")]
        public IQueryable<PcbDataModel> GetPcbDataByDateOperator(string sessionKey, string date, string placeOperator)
        {
            var models = this.GetAllPcbData(sessionKey)
              .Where(pcb => pcb.Date.Equals(date) && pcb.Operator.Equals(placeOperator));
            return models;
        }

        [HttpGet]
        [ActionName("get-pcbdata-byorder")]
        public IQueryable<PcbDataModel> GetPcbDataByOrder(string sessionKey, string orderNumber)
        {
            var models = this.GetAllPcbData(sessionKey)
                .Where(pcb => pcb.OrderNumber.Equals(orderNumber))
                .OrderBy(pcb => pcb.PcbNumber);
            return models;
        }

        [HttpGet]
        [ActionName("get-thermodata")]
        public IQueryable<PcbThermoModel> GetAllThermoData(string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                MilkotronicSystemEntities context = new MilkotronicSystemEntities();

                 var user = context.Users.FirstOrDefault(usr => usr.sessionKey == sessionKey);
                 if (user == null)
                 {
                     throw new InvalidOperationException("Invalid username or password");
                 }

                var pcbEntities = context.Thermo_Data;
                var models =
                    (from thermoDataEntity in pcbEntities
                     select new PcbThermoModel()
                     {
                         Id = thermoDataEntity.id,
                         Date = thermoDataEntity.date,
                         Time = thermoDataEntity.time,
                         BoxNumber = thermoDataEntity.box,
                         PcbSensor = thermoDataEntity.sensor,
                         N40 = thermoDataEntity.N40,
                         P60 = thermoDataEntity.P60,
                         Workplace = thermoDataEntity.workplace,
                         ProgramVersion = thermoDataEntity.programVersion,
                         Ad623 = thermoDataEntity.ad623,
                         Amplitude = thermoDataEntity.amplitude,
                         PcbNumber = thermoDataEntity.numberPcb
                     });
                return models.OrderByDescending(thr => thr.PcbNumber);
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("get-thermodata-bynumber")]
        public IQueryable<PcbThermoModel> GetThermoDataByNumber(string sessionKey, int searchNumber)
        {
            var models = this.GetAllThermoData(sessionKey)
                .Where(pcb => pcb.PcbNumber.Equals(searchNumber));
            return models;
        }

        [HttpGet]
        [ActionName("get-thermodata-bydate")]
        public IQueryable<PcbThermoModel> GetThermoDataByDate(string sessionKey, string date)
        {
            var models = this.GetAllThermoData(sessionKey)
                .Where(pcb => pcb.Date.Equals(date));
            return models;
        }

       
    }
}
