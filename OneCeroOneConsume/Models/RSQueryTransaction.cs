using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RSQueryTransaction
    {
        private int CodigoBanco { get; set; }
        private decimal Total { get; set; }
        private DateTime FechaTransaccion { get; set; }
        private DateTime FechaRespuestaBanco { get; set; }
        private string Identificacion { get; set; }
        private string CUS { get; set; }
        private string CicloTransaccion { get; set; }
        private char EstadoTransaccion { get; set; }
        private string IP { get; set; }
        private string Factura { get; set; }
        private string MedioPago { get; set; }
    }
}