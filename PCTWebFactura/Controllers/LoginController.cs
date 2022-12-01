using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCTWebFactura.Classes;
using System.Web.Mvc;
using System.Threading.Tasks;
using PCTWebFactura.Configuration;
using PCTWebFactura.Models;
using System.Configuration;
using PCTWebComun.Entidades.COM;

namespace PCTWebFactura.Controllers
{
    public class LoginController : Controller
    {
        LoginProvider LoginProvider = new LoginProvider();
        private static AppConfiguration appConfig = new AppConfiguration();


        // GET: Login
        public ActionResult Index()
        {
            _ = ConsultarNombreEntidadAsync();
            ViewData["baseDatos"] = appConfig.baseDatos;
            return View();
        }
        public ActionResult cargarForm()
        {
            Respuesta res = new Respuesta();
            ComNit data = new ComNit();
            res.Object = data;
            data.CodPostal = appConfig.esquema;
            return Content(res.GetResponse());
        }
        public async Task<bool> ConsultarNombreEntidadAsync()
        {
            var entidad = await this.LoginProvider.ConsultarNombreEntidadAsync("SELECT NOM_SECCION, VIGENCIA_ACTUAL, NIT FROM ctrl_entidad");
            if (entidad != null)
            {
                ConfigurationManager.AppSettings["entidad"] = entidad.entidad;
                ConfigurationManager.AppSettings["vigencia"] = entidad.vigencia.ToString();
                appConfig.vigencia = entidad.vigencia.ToString();
                System.Web.HttpContext.Current.Session["_VIGENCIA_"] = entidad.vigencia.ToString(); ;
                System.Web.HttpContext.Current.Session["_ENTIDAD_"] = entidad.entidad;
            }
            return true;
        }
        public ActionResult Ingresar(ComNit login)
        {
            Respuesta res = new Respuesta();
            appConfig.esquema = login.CodPostal;
            var sentencia = "SELECT * FROM NIT WHERE 4 >3 ";
            if (!String.IsNullOrEmpty(login.nit))
            {
                sentencia = sentencia + "AND NIT = '" + login.nit + "'";
            }
            if (!String.IsNullOrEmpty(login.cod_usuario))
            {
                sentencia = sentencia + " AND COD_USUARIO = '" + login.cod_usuario + "'";
            }
            if (!String.IsNullOrEmpty(login.nombre))
            {
                sentencia = sentencia + " AND UPPER(NOMBRE) LIKE '%" + login.nombre + "%'";
            }
            System.Web.HttpContext.Current.Session["NIT"] = login.nit;
             var result = this.LoginProvider.ConsultarNitAsync(sentencia, login);
            
                res.Mensaje = this.LoginProvider.message;
                if (result.Result)
                {
                    res.Codigo = 1;
                    return Content(res.GetResponse());
                }
                else
                {
                    res.Codigo = 0;
                    return Content(res.GetResponse());
                }
            
        }


    }
}