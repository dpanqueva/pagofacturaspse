using PlaceToPayConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class NotificationPTP
    {
        public string key { get; set; }
        public ResponseCheckStatus response { get; set; }
    }
}