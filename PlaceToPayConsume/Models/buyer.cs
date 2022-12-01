using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Models
{
    public class buyer
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string documentType { get; set; }
        public long mobile { get; set; }
    }
}