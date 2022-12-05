using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RQPayLoadPay
    {
        private string Referencia { get;}
        private string Factura { get; }
        private float Total { get; }
        private string CodigoEntidad { get; }
        private int IDImpuesto { get; }
        private int FuentePago { get; }
        private int TipoImplementacion { get; }
        private RQPagador Pagador { get; }
    }
}