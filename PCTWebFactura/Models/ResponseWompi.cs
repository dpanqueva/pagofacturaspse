using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class ResponseWompi
    {
        public string idpago { get; set; }
        public string status { get; set; }
        public string valor { get; set; }
        public string fepago { get; set; }
        public string idrequeswompi { get; set; }
        public string payment { get; set; }

    }
}