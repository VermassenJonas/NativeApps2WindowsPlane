﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Steward
    {
        public string PersonnelNumber { get; set; }
        public String FirstName { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Hash { get; set; }
    }
}