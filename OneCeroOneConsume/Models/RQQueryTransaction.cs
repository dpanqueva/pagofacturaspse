using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RQQueryTransaction
    {
        public string CodigoEntidad { get; set; }
        public string Factura { get; set; }
        public int IDImpuesto { get; set; }

        public RQQueryTransaction(){}
    }
}