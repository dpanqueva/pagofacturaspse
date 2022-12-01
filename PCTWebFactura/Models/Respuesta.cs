using Newtonsoft.Json;
using PlaceToPayConsume.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class Respuesta
    {
        private int codigoRespuesta;
        private string mensajeRespuesta;
        private DataTable dtResultado;
        private object obj;
        private string ruta;
        private bool actuaizoEstados;
        private string facturaActualizada;
        private List<int> codigoPasarela;
        private ResponseCheckStatus resPLaceToPay;

        public string FacturaActualizadaMessage
        {
            get { return facturaActualizada; }
            set { facturaActualizada = value; }
        }

        public bool ActualizoEstadoFacturas
        {
            get { return actuaizoEstados; }
            set { actuaizoEstados = value; }
        }
        public string Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }

        public object Object
        {
            get { return obj; }
            set { obj = value; }
        }
        public ResponseCheckStatus ResPTP
        {
            get { return resPLaceToPay; }
            set { resPLaceToPay = value; }
        }
        public int Codigo
        {
            get { return codigoRespuesta; }
            set { codigoRespuesta = value; }
        }
        public List<int> codPasarela
        {
            get { return codigoPasarela; }
            set { codigoPasarela = value; }
        }
        public string Mensaje
        {
            get { return mensajeRespuesta; }
            set { mensajeRespuesta = value; }
        }

        public DataTable Data
        {
            get { return dtResultado; }
            set { dtResultado = value; }
        }

        public string GetResponse()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}