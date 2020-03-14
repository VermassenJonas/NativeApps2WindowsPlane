using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NativeApps2WindowsPlaneBackend.Models.Domain
{
    public class Medium
    {
        [Key]
        public int MediumId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public List<String> Tags { get; set; }
    }
}