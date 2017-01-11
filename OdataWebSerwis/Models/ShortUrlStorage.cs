using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdataWebSerwis.Models
{
    public class ShortUrlStorage
    {
        public string FullParameters { get; set; }

        public int Id { get; set; }
        public string Reference { get; set; }
    }
}