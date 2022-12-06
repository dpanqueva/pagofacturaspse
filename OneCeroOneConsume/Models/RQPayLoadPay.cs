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
        private decimal Total { get; }
        private string CodigoEntidad { get; }
        private int IDImpuesto { get; }
        private int FuentePago { get; }
        private int TipoImplementacion { get; }
        private RQPagador Pagador { get; }

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
        }
    }
}