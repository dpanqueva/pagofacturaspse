using Newtonsoft.Json;
using System.Data;

namespace PCTWebComun.Utilidades
{
    public class RespuestaNet
    {
        private int codigoRespuesta;
        private string mensajeRespuesta;
        private DataTable dtResultado;
        public int Codigo
        {
            get { return codigoRespuesta; }
            set { codigoRespuesta = value; }
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

    public class RespuestaPaginada
    {
        private int codigoRespuesta;
        private string mensajeRespuesta;
        private DataTable dtResultado;
        public int Codigo
        {
            get { return codigoRespuesta; }
            set { codigoRespuesta = value; }
        }

        public string Mensaje
        {
            get { return mensajeRespuesta; }
            set { mensajeRespuesta = value; }
        }

        public DataTable data
        {
            get { return dtResultado; }
            set { dtResultado = value; }
        }

        public int last_page
        {
            get;
            set;
        }

        public string GetResponse()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}