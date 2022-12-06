using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RQPayLoadPay
    {
        public string Referencia { get; set; }
        public string Factura { get; set; }
        public decimal Total { get; set; }
        public string CodigoEntidad { get; set; }
        public int IDImpuesto { get; set; }
        public int FuentePago { get; set; }
        public int TipoImplementacion { get; set; }
        public RQPagador Pagador { get; set; }

        /*
        public RQPayLoadPay() { }

        public RQPayLoadPay(string Referencia, string Factura, decimal Total, string CodigoEntidad
            ,int IDImpuesto, int FuentePago, int TipoImplementacion, RQPagador Pagador) {
            this.Referencia = Referencia;
            this.Factura = Factura;
            this.Total = Total;
            this.CodigoEntidad = CodigoEntidad;
            this.IDImpuesto = IDImpuesto;
            this.FuentePago = FuentePago;
            this.TipoImplementacion = TipoImplementacion;
            this.Pagador = Pagador;
        }*/
    }
}