using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Models
{
    public class Response
    {
        public Status status { get; set; }
        public string requestId { get; set; }
        public string processUrl { get; set; }
    }
}