using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NativeApps2WindowsPlaneBackend_2.Models.Domain
{
    public class Medium
    {
        public int MediumId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public List<String> Tags { get; set; }
    }
}