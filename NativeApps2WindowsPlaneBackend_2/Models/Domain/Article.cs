﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Article
    {
        public int ArticleId { get; set; }
        public String Name { get; set; }
        public decimal price { get; set; }
        public int Stock { get; set; }
    }
}