﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkotronicSystem.Web.WebAPI.Models
{
    public class LoggedUserModel
    {
        public string SessionKey { get; set; }

        public string Username { get; set; }
    }
}