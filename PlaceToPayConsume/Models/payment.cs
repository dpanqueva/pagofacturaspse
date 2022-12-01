using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Models
{
    public class payment
    {
        public string reference { get; set; }
        public string description { get; set; }
        public amount amount { get; set; }
    }
}