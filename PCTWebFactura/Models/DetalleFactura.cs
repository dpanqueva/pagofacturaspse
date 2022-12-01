using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class DetalleFactura
    {
        public int VIGENCIA { get; set; }
        public string COD_FACTURA { get; set; }
        public string FECHA_FACTURADESDE { get; set; }
        public string FECHA_FACTURA { get; set; }
        public string ESTADO_FACTURA { get; set; }
        public string TIPO_FACTURA { get; set; }
        public int COD_COT { get; set; }
        public int COD_VENDEDOR { get; set; }
        public string IMPRESO { get; set; }
        public string FECHA_LIMITE { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public int COD_TASA { get; set; }
        public string OBSERVAC { get; set; }
        public int COD_TIPO { get; set; }
        public string COD_CATEGORIA { get; set; }
        public string NOM_CATEGORIA { get; set; }
        public string ESTADO { get; set; }
        public string ID_MFACTURA { get; set; }
        public string TOTAL_PAGO { get; set; }
        public string BTN_SELECTED { get; set; }


    }
}