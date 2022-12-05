using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCTWebFactura.Classes;
using PlaceToPayConsume.Controllers;
using PlaceToPayConsume.Models;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades.FAC;
using PCTWebComun.Controlador.FAC;
using System.Data;
using PCTWebFactura.Models;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using PCTWebComun.Controlador.COM;
using PCTWebComun.Entidades.COM;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;
using PCTWebComun.Utilidades;
using System.Configuration;

namespace PCTWebFactura.Controllers
{
    public class PagoFacturasController : Controller
    {

        public ActionResult Index()
        {
            var context = System.Web.HttpContext.Current;
            if (string.IsNullOrEmpty((string)(context.Session["NIT"])))
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            else
            {
                ViewData["Entidad"] = (string)(context.Session["NOMBRE"]);
                return View();
            }
        }

        public ActionResult RedirectLogin()
        {
            return RedirectToAction("Index", "Login", new { area = "" });
        }

        /*
         * Metodo para cargar el listado de facturas y la pasarela asignada a mostrar
         */
        public ActionResult cargarFacturasAPI(string idPago)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.CargarFacturas(idPago);
            respuesta.codPasarela = pfp.ConsultarPasarelaAsignadaAsync().Result;
            return Content(respuesta.GetResponse());
        }

        /*
         * Metodo para identificar que facturas estan iniciadas o pendientes para actualizar la informacion del pago
         */
        public ActionResult ActualizarEstadosFacturas()
        {

            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            var res = pfp.ActualizarEstadosGeneralAsync().Result;
            return Content(res.GetResponse());
        }

        /*
         * Metodo que consume Place To Pay para actualizar el estado de las facturas en estado pendiente
         */
        public ActionResult notificationServicePTP(NotificationPTP obj)
        {
            ResponsePTP res = new ResponsePTP();
            try
            {
                PagoFacturasProvider pfp = new PagoFacturasProvider();
                res = pfp.notificationServicePTPAsync(obj).Result;
                res.Message = res.IsException == false ? "OK" : res.Message;
                return Content(res.GetResponse());
            }
            catch (Exception ex)
            {
                res.IsException = true;
                res.Message = "La sintaxis en el modelo no es correcta";
                res.Exception = ex.Message;
                return Content(res.GetResponse());
            }

        }

        /*
         * Metodo para validar que la parametrizacion de la factura esta lista para permitir el pago
         */
        public ActionResult PagarValidation(DetalleFactura facSelected)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ValidationFacturaAsync(facSelected).Result;
            return Content(respuesta.GetResponse());
        }

        /*
         * Metodo para validar que la factura no tenga un intento de pago que este en estado abierto en la bitacora
         */
        public ActionResult IniciarTransaccion(DetalleFactura facSelected)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.IniciarTransaccion(facSelected);
            return Content(respuesta.GetResponse());
        }

        /*
         * Metodo realizar el consumo del dll de zona pagos que devuelve la URL a redireccionar el usuario
         */
        public ActionResult ConsumoZpagos(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ConsumoZpagos(obj);
            return Content(respuesta.GetResponse());
        }

        /*
         * Metodo para actualizar la bitacora de los pagos hechos desde la pasarela Wompi
         */
        public ActionResult ConsumoWompi(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.RegistrarBitacora(obj, false, "");
            return Content(respuesta.GetResponse());
        }

        /*
         * Metodo para realizar el consumo del dll de Place To Pay que devuelve la URL a redireccionar el usuario
         */
        public ActionResult ConsumoPlaceToPay(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ConsumoPlaceToPay(obj);
            return Content(respuesta.GetResponse());

        }

        /*
         * Metodo para realizar el consumo del dll de 1Cero1 que devuelve la URL a redireccionar el usuario
         */
        public ActionResult Consumo1Cero1(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.Consumo1Cero1(obj);
            return Content(respuesta.GetResponse());

        }

        /*
         * Metodo para actualizar el estado en la bitacora cuando el usuario retorna al comercio desde Wompi
         */
        public ActionResult ActualizarEstadoWompi(ResponseWompi obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ActualizarEstadoWompi(obj);
            return Content(respuesta.GetResponse());

        }

        /*
         * Metodo para generar report de Cristal Report
         */
        public ActionResult GenerarRptFactura(string codFactura)
        {
            try
            {
                RespuestaNet respuesta = new RespuestaNet();
                var ConsClsEntidades = new ComCtrlCtrlEntidad();
                var dtctrlentidad = ConsClsEntidades.ctrlConsCtrlEntidad();

                var ConsEntidad = JsonConvert.SerializeObject(dtctrlentidad);
                string jsonEntidad = ConsEntidad.Replace("[", "").Replace("]", "");
                PCTWebComunNet.Entidades._Comun.ComCtrlEntidad entidad = JsonConvert.DeserializeObject<PCTWebComunNet.Entidades._Comun.ComCtrlEntidad>(jsonEntidad);

                /// 

                FACCtrlVwFacTasaImprV1 facCtrlVwFacTasaImprV1 = new FACCtrlVwFacTasaImprV1();
                respuesta = facCtrlVwFacTasaImprV1.CtrlVwFacTasaImprV1(codFactura);
                PagoFacturasProvider pfp = new PagoFacturasProvider();
                var nomReporte = pfp.ConsultarReporteAsignadoAsync(codFactura).Result;
                ReportDocument Reporte = new ReportDocument();
                Reporte.Load(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Views/Reportes"), nomReporte));
                Reporte.SetDataSource(respuesta.Data);

                Reporte.DataDefinition.FormulaFields["NomEntidad"].Text = "'" + entidad.NOM_SECPRINCIPAL + "'";
                Reporte.DataDefinition.FormulaFields["Nit"].Text = "'" + entidad.NIT + "'";
                Reporte.DataDefinition.FormulaFields["Nit"].Text = "'" + entidad.DIRECCION + "'";
                Reporte.DataDefinition.FormulaFields["TituloReporte"].Text = "'Factura'";

                CrystalDecisions.Shared.ConnectionInfo connInfo = new CrystalDecisions.Shared.ConnectionInfo();

                connInfo.ServerName = Convert.ToString(ConfigurationManager.AppSettings["baseDatos"]); ;
                connInfo.DatabaseName = "";
                connInfo.UserID = Convert.ToString(ConfigurationManager.AppSettings["esquema"]);
                connInfo.Password = Convert.ToString(ConfigurationManager.AppSettings["clave"]);

                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = Reporte.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                System.Web.HttpContext.Current.Response.Buffer = false;
                System.Web.HttpContext.Current.Response.ClearContent();
                System.Web.HttpContext.Current.Response.ClearHeaders();

                Reporte.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                Reporte.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                Stream stream = Reporte.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "Factura_" + codFactura + ".pdf");
            }
            catch (Exception ex)
            {
                throw new Exception("PagoFacturasController :: GenerarRptFactura", ex);
            }

        }
        
    }
}