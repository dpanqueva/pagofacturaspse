using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlaceToPayConsume.Models;

namespace PlaceToPayConsume.Models
{
    public class ModelToSend
    {
        public buyer buyer { get; set; }
        public payment payment { get; set; }
        public string expiration { get; set; }
        public string ipAddress { get; set; }
        public string returnUrl { get; set; }
        public string userAgent { get; set; }
        public string paymentMethod { get; set; }
        public auth auth { get; set; }
    }
}