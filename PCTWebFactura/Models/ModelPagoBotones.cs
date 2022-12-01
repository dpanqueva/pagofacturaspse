using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class ModelPagoBotones
    {
        public string email { get; set; }
        public string telefono { get; set; }
        public string ip { get; set; }
        public string agent { get; set; }
        public DetalleFactura itemSelected { get; set; }
    }
}