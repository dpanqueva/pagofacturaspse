using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Models
{
    public class request
    {
        public buyer buyer { get; set; }
        public payment payment { get; set; }
    }
}