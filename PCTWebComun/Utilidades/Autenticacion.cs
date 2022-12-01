using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PCTWebComun.Utilidades
{
    /// <summary>
    /// Clase para verificar si un usuario se encuentra autenticado
    /// </summary>
    public static class Autenticacion
    {
        /// <summary>
        /// Verifica que se encuentre una sesion activa, si se encuentra una sesion activa
        /// se concede acceso a la vista enviada en le parametro NombreVista de lo contrario
        /// se redirige al LogIn
        /// </summary>
        /// <param name="NombreVista">Vista a la que se quiere acceder</param>
        /// <returns>Vista</returns>
        public static ActionResult Verificar(string NombreVista, ViewDataDictionary data = null)
        {
            // Verificamos que la variable de sesion no este nula
            // si es nula  retornamos la vista de ingreso
            if (HttpContext.Current.Session["AU"] == null)
            {
                return VistaLogin();
            }
            else
            {
                // verificamos si esta autenticado o no
                switch (HttpContext.Current.Session["AU"].ToString())
                {
                    case "UA":
                        return VistaLogin(); // Si no esta autenticado retornamos la vista de ingreso
                    case "AU":
                        // Si esta autenticado retornamos la vista que se envio en NombreVista
                        return new ViewResult()
                        {
                            ViewName = NombreVista,
                            ViewData = data
                        };
                    default:
                        return VistaLogin();

                }
            }
        }

        /// <summary>
        /// Verifica que se encuentre una sesion activa y retorna True o False
        /// </summary>
        /// <returns>bool</returns>
        public static bool Verificar()
        {
            bool estaAutenticato;
            // Verificamos que la variable de sesion no este nula
            // si es nula retornamos asignamos false
            if (HttpContext.Current.Session["AU"] == null)
            {
                estaAutenticato = false;
            }
            else
            {
                // verificamos si esta autenticado o no
                switch (HttpContext.Current.Session["AU"].ToString())
                {
                    case "UA":
                        estaAutenticato = false; // Si no esta autenticado asignamos false
                        break;
                    case "AU":
                        estaAutenticato = true; // Si esta autenticado asignamos true
                        break;
                    default:
                        estaAutenticato = false;
                        break;
                }
            }
            return estaAutenticato;
        }

        public static ViewResult VistaLogin()
        {
            ViewDataDictionary data = new ViewDataDictionary();
            data.Add("Vigencia", WebConfigurationManager.AppSettings["vigencia"]);
            data.Add("BaseDeDatos", WebConfigurationManager.AppSettings["baseDatos"]);

            // Vista de ingreso (LogIn)
            ViewResult VistaIngreso = new ViewResult()
            {
                ViewName = "PgCOMIngreso",
                ViewData = data
            };

            return VistaIngreso;
        }
    }
}