using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Configuration
{
    public class AppConfiguration
    {
        public string vigencia;
        public string esquema;
        public readonly string ConnectionString;
        public readonly string provider;
        public readonly string baseDatos;
        public AppConfiguration()
        {
            var usuario = ConfigurationManager.AppSettings["usuario"];
            var nomUsuario = ConfigurationManager.AppSettings["usuario"];
            this.esquema = ConfigurationManager.AppSettings["esquema"];
            var clave = ConfigurationManager.AppSettings["clave"];
            this.provider = ConfigurationManager.AppSettings["provider"];
             this.baseDatos = ConfigurationManager.AppSettings["baseDatos"];
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["vigencia"]))
            {
                this.vigencia = "PCT" + DateTime.Now.Year.ToString();
            }
            else
            {
                this.vigencia = ConfigurationManager.AppSettings["vigencia"];
            }
            var baseDatos = ConfigurationManager.AppSettings["baseDatos"];

            System.Web.HttpContext.Current.Session["_USUARIO_"] = usuario;
            System.Web.HttpContext.Current.Session["_NOMUSUARIO_"] = nomUsuario;
            System.Web.HttpContext.Current.Session["_VIGENCIA_"] = vigencia;
            System.Web.HttpContext.Current.Session["_ESQUEMA_"] = esquema;
            System.Web.HttpContext.Current.Session["baseDatos"] = baseDatos;
            System.Web.HttpContext.Current.Session["_ALIAS_"] = baseDatos;
            System.Web.HttpContext.Current.Session["_CLAVE_"] = clave;
            System.Web.HttpContext.Current.Session["_SERVIDOR_"] = "";
            // Connection string 
            switch (this.provider)
            {
                case "System.Data.OracleClient":
                    //ConnectionString = "Data Source = " + baseDatos + "; User ID = " + usuario + ";Password = " + clave + ";";
                    ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=190.146.38.51)(PORT=15254))(CONNECT_DATA=(SERVICE_NAME=S4PCTG0)));User Id=Pctuser;Password=pctgkey;persist security info=false;";
                    break;
                default:
                    throw new Exception("Provider no soportado");
            }

        }
    }
}