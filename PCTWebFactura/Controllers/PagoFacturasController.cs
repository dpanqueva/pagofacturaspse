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
        public ActionResult cargarFacturasAPI(string idPago)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.CargarFacturas(idPago);
            respuesta.codPasarela = pfp.ConsultarPasarelaAsignadaAsync().Result;
            return Content(respuesta.GetResponse());
        }
        public ActionResult ActualizarEstadosFacturas()
        {

            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            //respuesta = pfp.CargarFacturas("");
            var res = pfp.ActualizarEstadosGeneralAsync().Result;
            /* respuesta.ActualizoEstadoFacturas = res2.ActualizoEstadoFacturas;
             respuesta.FacturaActualizadaMessage = res2.FacturaActualizadaMessage;*/
            return Content(res.GetResponse());
        }
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

        public ActionResult PagarValidation(DetalleFactura facSelected)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ValidationZpagos(facSelected);
            return Content(respuesta.GetResponse());
        }
        public ActionResult IniciarTransaccion(DetalleFactura facSelected)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.IniciarTransaccion(facSelected);
            return Content(respuesta.GetResponse());
        }
        public ActionResult ConsumoZpagos(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ConsumoZpagos(obj);
            return Content(respuesta.GetResponse());
        }
        public ActionResult ConsumoWompi(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.RegistrarBitacora(obj, false, "");
            return Content(respuesta.GetResponse());
        }
        public ActionResult ConsumoPlaceToPay(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ConsumoPlaceToPay(obj);
            return Content(respuesta.GetResponse());

        }
        public ActionResult ActualizarEstadoWompi(ResponseWompi obj)
        {
            Respuesta respuesta = new Respuesta();
            PagoFacturasProvider pfp = new PagoFacturasProvider();
            respuesta = pfp.ActualizarEstadoWompi(obj);
            return Content(respuesta.GetResponse());

        }

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
        /*public List<FacConsultasFacturasV1> CargarFacturas()
        {
            var context = System.Web.HttpContext.Current;
            ViewData["Entidad"] = (string)(context.Session["_ENTIDAD_"]);
            var entidadCtrl = new ComCtrlContabilidad();
            entidadCtrl.Mes = Convert.ToString(DateTime.Now.Month);
            var ConsClsCtrlCierres = new ComCtrlCtrlContabilidad();
            var utGv = new utilidadesGV();
            var consulta = new FacCtrlConsultasFacturasV1();
            var dtctrlcierres = ConsClsCtrlCierres.CtrlconsControlCierres(entidadCtrl);

            if (dtctrlcierres.Rows.Count > 0)
            {
                if (dtctrlcierres.Rows[0]["CERRADO"].ToString() != "S")
                {
                    var entidad = new FacConsultasFacturasV1();
                    entidad.Nit = (string)(context.Session["NIT"]);
                    var count = consulta.ctrlContarConsFactura(entidad);
                    ViewData["_Num_Registros_"] = count;
                    if (utGv.calculoPaginasConsSqlPag(count))
                    {
                        ViewData["_Primera_Pag_"] = utGv.numPrimeraPagina.ToString();
                        ViewData["_Ultima_Pag_"] = utGv.numUltimaPagina.ToString();
                        var res = CargarConsFactura(entidad, 1);
                        if (res.Rows.Count > 0)
                        {
                            var consCtrlTesoreria = new ComCtrlCtrlTesoreria();
                            var dtVisibleBoton = consCtrlTesoreria.CtrlConsCtrlTesoreria();
                            var bl = dtVisibleBoton.Rows[0]["CTRL_ACTIVA_PSE"].ToString() == "S";
                            List<FacConsultasFacturasV1> lstFacturas = new List<FacConsultasFacturasV1>();
                            for (int i = 0; i < res.Rows.Count; i++)
                            {
                                FacConsultasFacturasV1 unitFac = new FacConsultasFacturasV1();
                                unitFac.Vigencia = res.Rows[i]["VIGENCIA"].ToString();
                                unitFac.CodFactura = res.Rows[i]["COD_FACTURA"].ToString();
                                unitFac.IdMfactura = res.Rows[i]["ID_MFACTURA"].ToString();
                                unitFac.Referencia = res.Rows[i]["REFERENCIA"].ToString();
                                unitFac.FechaFactura = res.Rows[i]["FEC_ACTUAL"].ToString();
                                unitFac.ValRecargofac = res.Rows[i]["VAL_RECARGOFAC"].ToString();
                                unitFac.ValDescuentofac = res.Rows[i]["VAL_DESCUENTOFAC"].ToString();
                                unitFac.ValInterescobrar = res.Rows[i]["VAL_INTERESCOBRAR"].ToString();
                                unitFac.ValCuentascobrar = res.Rows[i]["VAL_CUENTASCOBRAR"].ToString();
                                unitFac.ValTotal = res.Rows[i]["TOTAL_PAGO"].ToString();
                                lstFacturas.Add(unitFac);

                            }
                            return lstFacturas;
                        }
                    }
                }

            }
            return null;

        }*/


    }
}