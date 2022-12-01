using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Models
{
    public class auth
    {
        public string login { get; set; }
        public string tranKey { get; set; }
        public string nonce { get; set; }
        public string seed { get; set; }
    }
}