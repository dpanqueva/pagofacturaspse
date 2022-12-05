using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RSQueryTransaction
    {
        private int CodigoBanco { get; }
        private float total { get; }
        private DateTime FechaTransaccion { get; }
        private DateTime FechaRespuestaBanco { get; }
        private string Identificacion { get; }
        private string CUS { get; }
        private string CicloTransaccion { get; }
        private char EstadoTransaccion { get; }
        private string IP { get; }
        private string Factura { get; }
        private string MedioPago { get; }
    }
}