using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using PCTWebComun.Controlador.COM;
using PCTWebComun.Controlador.FAC;
using PCTWebComun.Controlador.ING;
using PCTWebComun.Entidades.COM;
using PCTWebComun.Entidades.FAC;
using PCTWebComun.Entidades.ING;
using PCTWebComun.Utilidades;
using PCTWebFactura.Configuration;
using PCTWebFactura.Models;
using PlaceToPayConsume.Controllers;
using OneCeroOneConsume.Controllers;
using PlaceToPayConsume.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PCTWebFactura.Classes
{
    public class PagoFacturasProvider
    {
        private static AppConfiguration appConfig = new AppConfiguration();
        private DbTransaction transaction;
        private IngCtrlConsultaMingresos conMing = new IngCtrlConsultaMingresos();
        LoginProvider LoginProvider = new LoginProvider();
        private DbCommand oSalida;
        public async Task<Respuesta> ValidationFacturaAsync(DetalleFactura facSelected)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                try
                {
                    Respuesta res = new Respuesta();
                    var context = System.Web.HttpContext.Current;
                    var entidadIng = new IngMingresos();
                    entidadIng.Vigencia = (string)(context.Session["_VIGENCIA_"]);
                    entidadIng.CodTipo = facSelected.COD_TIPO.ToString();
                    entidadIng.CodCategoria = facSelected.COD_CATEGORIA;
                    var manejadorCtrl = new IngCtrlConsultaMingresos();
                    var dtDistIng = new DataTable();
                    var dtTipoIng = new DataTable();
                    var dtCtrlModulo = new DataTable();
                    var EntidadCtrl = new ComCtrlModulo();
                    var consultactrl = new ComCtrlCtrlModulo();
                    var ConsCom = new ComCtrl();
                    var dtMCaja = new DataTable();
                    var resultado = manejadorCtrl.CtrlConsultaTipoIng(entidadIng);
                    res.Mensaje = "";
                    res.Codigo = 1;
                    if (resultado != null)
                    {
                        if (resultado.Rows.Count > 1 || resultado.Rows.Count == 0)
                        {
                            res.Mensaje = " los parámetros del TIPO DE INGRESO para " + facSelected.NOM_CATEGORIA;
                            res.Codigo = 0;
                        }
                    }
                    else
                    {
                        res.Mensaje = " los parámetros del TIPO DE INGRESO para " + facSelected.NOM_CATEGORIA;
                        res.Codigo = 0;
                    }

                    var ConsClsEntidades = new ComCtrlCtrlEntidad();
                    var dtctrlentidad = ConsClsEntidades.ctrlConsCtrlEntidad();
                    if (dtctrlentidad != null)
                    {
                        if (dtctrlentidad.Rows.Count >= 1)
                        {
                            if (dtctrlentidad.Rows[0]["INT_FACTURA_PPTO"].ToString() == "N")
                            {
                                entidadIng.CodTipoing = resultado.Rows[0]["COD_TIPOING"].ToString();
                                entidadIng.Vigencia = (string)(context.Session["_VIGENCIA_"]);

                                dtDistIng = manejadorCtrl.CtrlConsultaDistIng(entidadIng);  // Consulto la distribucion de ingresos

                                if (dtDistIng != null)
                                {
                                    if (dtDistIng.Rows.Count >= 1)
                                    {
                                    }
                                    else
                                    {
                                        res.Codigo = 0;

                                        if (res.Mensaje == "")
                                        {

                                            res.Mensaje = res.Mensaje + " los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();

                                        }
                                        else
                                        {
                                            res.Mensaje = res.Mensaje + ", los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();

                                        }


                                    } //Fin if (dtDefIng.Rows.Count>=1) then
                                }
                                else
                                {
                                    res.Codigo = 0;
                                    if (res.Mensaje == "")
                                    {
                                        res.Mensaje = res.Mensaje + " los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                    }
                                    else
                                    {
                                        res.Mensaje = res.Mensaje + ", los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                    }
                                } //Fin if  (dtDefIng <> nil)
                            }
                            else
                            {
                                entidadIng.Nit = (string)(context.Session["NIT"]);
                                entidadIng.CodFactura = facSelected.COD_FACTURA.ToString();
                                entidadIng.VigFactura = facSelected.VIGENCIA.ToString();

                                dtDistIng = manejadorCtrl.CtrlConsultaDistPptoIng(entidadIng);

                                if (dtDistIng != null)
                                {

                                    if (dtDistIng.Rows.Count >= 1)
                                    {
                                    }
                                    else
                                    {
                                        res.Codigo = 0;

                                        if (res.Mensaje == "")
                                        {
                                            res.Mensaje = res.Mensaje + " los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                        }
                                        else
                                        {
                                            res.Mensaje = res.Mensaje + ", los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                        }

                                    } //Fin if (dtDefIng.Rows.Count>=1) then

                                }
                                else
                                {
                                    res.Codigo = 0;
                                    if (res.Mensaje == "")
                                    {
                                        res.Mensaje = res.Mensaje + " los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                    }
                                    else
                                    {
                                        res.Mensaje = res.Mensaje + ", los parámetros PRESUPUESTALES para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (res.Mensaje == "")
                            {
                                res.Mensaje = res.Mensaje + " los parámetros de INTEGRACIÓN para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                            }
                            else
                            {
                                res.Mensaje = res.Mensaje + ", los parámetros de INTEGRACIÓN para " + facSelected.NOM_CATEGORIA.ToString().ToUpper();
                            }
                        }
                    }
                    var ConsCtrlTipoFac = new FacCtrlMFactura();
                    var entidadCtrlTipo = new FacMFactura();
                    var dtResDatosWs = new DataTable();


                    entidadCtrlTipo.IdMfactura = facSelected.ID_MFACTURA.ToString();

                    if (facSelected.COD_TIPO.ToString() == "2")
                    {

                        entidadCtrlTipo.CodTipo = "2";
                    }
                    else
                    {
                        entidadCtrlTipo.CodTipo = null;
                    }

                    dtResDatosWs = ConsCtrlTipoFac.CtrlConsCtrlTipoFactura(entidadCtrlTipo);


                    if (dtResDatosWs != null)
                    {

                        if (dtResDatosWs.Rows.Count >= 1)
                        {


                            if (String.IsNullOrEmpty(dtResDatosWs.Rows[0]["COD_CLAVE_PSE"].ToString()) || (String.IsNullOrEmpty(dtResDatosWs.Rows[0]["COD_SERVICIO_PSE"].ToString())) || (String.IsNullOrEmpty(dtResDatosWs.Rows[0]["COD_RUTA"].ToString())) || (String.IsNullOrEmpty(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString())) || (String.IsNullOrEmpty(dtResDatosWs.Rows[0]["NRO_CTABANCARIA"].ToString())))
                            {

                                res.Codigo = 0;
                                if (res.Mensaje == "")
                                {
                                    res.Mensaje = res.Mensaje + " los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                                }
                                else
                                {
                                    res.Mensaje = res.Mensaje + ", los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                                }
                            }


                        }
                        else
                        {
                            res.Codigo = 0;
                            if (res.Mensaje == "")
                            {
                                res.Mensaje = res.Mensaje + " los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                            }
                            else
                            {
                                res.Mensaje = res.Mensaje + ", los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                            }
                        } //FIN if (dtResDatosWs.Rows.Count>=1) then

                    }
                    else
                    {
                        res.Codigo = 0;
                        if (res.Mensaje == "")
                        {
                            res.Mensaje = res.Mensaje + " los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                        }
                        else
                        {
                            res.Mensaje = res.Mensaje + ", los parámetros de CTRL_TIPO_FACTURA en la configuración para " + facSelected.TIPO_FACTURA.ToString();
                        }

                    } // FIN if (dtResDatosWs <> nil) then


                    EntidadCtrl.Modulo = "TESORERIA";
                    EntidadCtrl.SubModulo = "CONSIGNACIONES";

                    dtCtrlModulo = consultactrl.CtrlConsCtrlModulo(EntidadCtrl);
                    var entidading = new IngMingresos();
                    if (dtCtrlModulo != null)
                    {
                        if (dtCtrlModulo.Rows.Count >= 1)
                        {
                            entidading.Vigencia = (string)(context.Session["_VIGENCIA_"]);
                            entidading.ClsIngreso = "C";
                            entidadIng.NumIngreso = (Convert.ToInt32(dtCtrlModulo.Rows[0]["CONSECUTIVO"].ToString()) + 1).ToString();

                            dtMCaja = manejadorCtrl.CtrlConsultaMcaja(entidadIng);

                            if (dtMCaja != null)
                            {
                                if (dtMCaja.Rows.Count >= 1)
                                {
                                    res.Codigo = 0;
                                    if (res.Mensaje == "")
                                    {
                                        res.Mensaje = res.Mensaje + " la parametrización de consecutivos para CONSIGNACIONES ";
                                    }
                                    else
                                    {
                                        res.Mensaje = res.Mensaje + ", la parametrización de consecutivos para CONSIGNACIONES ";
                                    }
                                }
                            }


                        }
                        else
                        {
                            res.Codigo = 0;
                            if (res.Mensaje == "")
                            {
                                res.Mensaje = res.Mensaje + " la parametrización de consecutivos para CONSIGNACIONES ";
                            }
                            else
                            {
                                res.Mensaje = res.Mensaje + ", la parametrización de consecutivos para CONSIGNACIONES ";
                            }
                        }

                    }
                    else
                    {
                        res.Codigo = 0;
                        if (res.Mensaje == "")
                        {
                            res.Mensaje = res.Mensaje + " No existe parametrizacion de consecutivo para CONSIGNACIONES ";
                        }
                        else
                        {
                            res.Mensaje = res.Mensaje + ", No existe parametrizacion de consecutivo para CONSIGNACIONES  ";
                        }
                    }

                    var Str = new StringBuilder();


                    Str.Append("SELECT OWNER,OBJECT_NAME,OBJECT_TYPE,STATUS FROM DBA_OBJECTS");
                    Str.Append(" WHERE OWNER NOT IN ('" + "SYS" + "','" + "SYSTEM" + "') ");
                    Str.Append(" AND STATUS = '" + "INVALID" + "'");
                    Str.Append(" AND OWNER = '" + (string)(context.Session["_ESQUEMA_"]) + "'");
                    Str.Append(" AND OBJECT_NAME = '" + "ST_ING_WEBPSE_FAC" + "'");
                    Str.Append(" ORDER BY OWNER,OBJECT_TYPE,OBJECT_NAME ");

                    var dtObjecto = ConsCom.ctrl_consultaStr(Str.ToString());

                    if (dtObjecto != null)
                    {
                        if (dtObjecto.Rows.Count >= 1)
                        {
                            res.Codigo = 0;
                            if (res.Mensaje == "")
                            {
                                res.Mensaje = res.Mensaje + " el estado del procedimiento ST_ING_WEBPSE_FAC ";
                            }
                            else
                            {
                                res.Mensaje = res.Mensaje + ", el estado del procedimiento ST_ING_WEBPSE_FAC ";
                            }
                        }
                    }
                    /*var message = ValidarParametrizacion("").Result;
                    if (message != "OK")
                    {
                        res.Mensaje = message;
                        res.Codigo = 0;
                    }*/
                    /**/
                    //res.Codigo = 1;
                    return res;
                }


                catch (Exception ex)
                {
                    throw new Exception("PagoFacturaProvider :: ValidationZpagos", ex);
                }


            }
        }

        public Respuesta ConsumoPlaceToPay(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var context = System.Web.HttpContext.Current;
                ModelToSend model = new ModelToSend();
                ConsumoPlaceToPayController cptp = new ConsumoPlaceToPayController();
                var Nombre = "";
                var Apellido = "";
                var tipod = "";
                var Nit = "";
                if (!string.IsNullOrEmpty((string)(context.Session["NIT"])))
                {
                    Nit = (string)(context.Session["NIT"]);
                }
                switch ((string)(context.Session["TIPOD"]))
                {
                    case "C":
                        tipod = "CC";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "E":
                        tipod = "CC";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "N":
                        tipod = "NIT";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NIT-" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    default:
                        tipod = "0";
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        Apellido = "NIT-";
                        break;
                }
                model.buyer = new buyer();
                model.buyer.name = Nombre;
                model.buyer.surname = Apellido;
                model.buyer.email = obj.email;
                model.buyer.document = Nit;
                model.buyer.documentType = tipod;
                model.buyer.mobile = long.Parse(obj.telefono);
                model.payment = new payment();
                model.payment.reference = obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
                model.payment.description = "Pago de Factura N " + obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
                model.payment.amount = new amount();
                model.payment.amount.currency = "COP";
                model.payment.amount.total = double.Parse(obj.itemSelected.TOTAL_PAGO);
                model.ipAddress = "192.168.0.24";
                //model.returnUrl = "http://claro.pctltda.com/PCTWEBFacturaDotNet/PagoFacturas";
                model.returnUrl = "https://localhost:44352/PagoFacturas";
                model.userAgent = "Chrome";
                model.paymentMethod = null;

                Response response = cptp.CrearSesionPlaceToPayAsync(model).Result;
                respuesta.Codigo = response.status.status == "OK" ? 1 : 0;
                if (respuesta.Codigo == 1)
                {
                    RegistrarBitacora(obj, false, response.requestId);
                }
                else
                {
                    RegistrarBitacora(obj, true, "");
                }
                respuesta.Mensaje = response.status.message;
                respuesta.Object = response;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Error: " + e.Message;
                return respuesta;
            }

        }
        public Respuesta Consumo1Cero1(ModelPagoBotones obj)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                var context = System.Web.HttpContext.Current;
                ModelToSend model = new ModelToSend();
                OneCeroOneController ococ = new OneCeroOneController();
                
                ConsumoPlaceToPayController cptp = new ConsumoPlaceToPayController();
                var Nombre = "";
                var Apellido = "";
                var tipod = "";
                var Nit = "";
                if (!string.IsNullOrEmpty((string)(context.Session["NIT"])))
                {
                    Nit = (string)(context.Session["NIT"]);
                }
                switch ((string)(context.Session["TIPOD"]))
                {
                    case "C":
                        tipod = "CC";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "E":
                        tipod = "CC";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "N":
                        tipod = "NIT";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NIT-" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    default:
                        tipod = "0";
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        Apellido = "NIT-";
                        break;
                }
                model.buyer = new buyer();
                model.buyer.name = Nombre;
                model.buyer.surname = Apellido;
                model.buyer.email = obj.email;
                model.buyer.document = Nit;
                model.buyer.documentType = tipod;
                model.buyer.mobile = long.Parse(obj.telefono);
                model.payment = new payment();
                model.payment.reference = obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
                model.payment.description = "Pago de Factura N " + obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
                model.payment.amount = new amount();
                model.payment.amount.currency = "COP";
                model.payment.amount.total = double.Parse(obj.itemSelected.TOTAL_PAGO);
                model.ipAddress = "192.168.0.24";
                //model.returnUrl = "http://claro.pctltda.com/PCTWEBFacturaDotNet/PagoFacturas";
                model.returnUrl = "https://localhost:44352/PagoFacturas";
                model.userAgent = "Chrome";
                model.paymentMethod = null;

                Response response = cptp.CrearSesionPlaceToPayAsync(model).Result;
                respuesta.Codigo = response.status.status == "OK" ? 1 : 0;
                if (respuesta.Codigo == 1)
                {
                    RegistrarBitacora(obj, false, response.requestId);
                }
                else
                {
                    RegistrarBitacora(obj, true, "");
                }
                respuesta.Mensaje = response.status.message;
                respuesta.Object = response;
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Codigo = 0;
                respuesta.Mensaje = "Error: " + e.Message;
                return respuesta;
            }

        }
        public Respuesta ConsumoZpagos(ModelPagoBotones obj)
        {
            Respuesta res = new Respuesta();

            try
            {
                var consumirwszona = new ConsumoZpagos.ConexionAlServicio();
                var context = System.Web.HttpContext.Current;
                var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
                var entidad = new FacMFactura();
                var clavews = "";
                var codservicio = "";
                var codruta = "";
                var idtienda = 0;
                var valor = double.Parse(obj.itemSelected.TOTAL_PAGO);
                var referencia = "Pago de Factura Nº: " + obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
                var arreglo = new string[100];
                var nombre = (string)(context.Session["NOMBRE"]);
                var IdPago = obj.itemSelected.ID_MFACTURA;
                entidad.IdMfactura = obj.itemSelected.ID_MFACTURA;
                var iva = double.Parse("0");
                var Nit = "";
                var Email = obj.email;
                var Telefono = obj.telefono;
                var tipod = "";
                var Nombre = "";
                var Apellido = "";
                if (obj.itemSelected.COD_TIPO == 2)
                {
                    entidad.CodTipo = "2";
                }
                if (!string.IsNullOrEmpty((string)(context.Session["NIT"])))
                {
                    Nit = (string)(context.Session["NIT"]);
                }
                else
                {
                    res.Codigo = 0;
                }
                var manejadorCtrl = new FacCtrlMFactura();

                var dtResultado = manejadorCtrl.CtrlConsCtrlTipoFactura(entidad);
                if (dtResultado != null && dtResultado.Rows.Count >= 1)
                {
                    if (!string.IsNullOrEmpty(dtResultado.Rows[0]["ID_TIENDA_PSE"].ToString()))
                    {
                        clavews = dtResultado.Rows[0]["COD_CLAVE_PSE"].ToString();
                        codservicio = dtResultado.Rows[0]["COD_SERVICIO_PSE"].ToString();
                        codruta = dtResultado.Rows[0]["COD_RUTA"].ToString();
                        idtienda = Convert.ToInt32(dtResultado.Rows[0]["ID_TIENDA_PSE"].ToString());
                    }
                }
                switch ((string)(context.Session["TIPOD"]))
                {
                    case "C":
                        tipod = "1";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "E":
                        tipod = "2";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NN. CC:" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    case "N":
                        tipod = "3";
                        if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                        {
                            Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        }
                        else
                        {
                            Nombre = "NIT-" + Nit;
                        }
                        if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                        {
                            Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                        }
                        else
                        {
                            Apellido = "";
                        }
                        break;
                    default:
                        tipod = "0";
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                        Apellido = "NIT-";
                        break;
                }

                var resultado = consumirwszona.consumeiniciopago(idtienda, clavews, valor, iva, IdPago, referencia, Email, Nit, tipod, Nombre, Apellido, Telefono, codservicio); //"53025260121690220";//
                var separa = new char[1];
                separa[0] = ' ';
                arreglo = resultado.Split(separa);
                var dtBitacora = (DataTable)context.Session["_DTBITACORA_"];
                var intentos = 0;
                if (arreglo[0] == "-1" || arreglo[0] == "No")
                {
                    if (dtBitacora != null && dtBitacora.Rows.Count >= 1)
                    {
                        intentos = int.Parse(dtBitacora.Rows[0]["INTENTOS_TRANSACCION"].ToString()) + 1;
                        oComWeb_Ws_Bitacora_Pse.intentos_transaccion = intentos.ToString();
                        oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                    }
                    else
                    {
                        oComWeb_Ws_Bitacora_Pse.intentos_transaccion = "1";
                        oComWeb_Ws_Bitacora_Pse.estadoreg = "2";
                    }
                    oComWeb_Ws_Bitacora_Pse.ticket_id = IdPago;
                    oComWeb_Ws_Bitacora_Pse.estado_transaccion = "Fallida";
                    oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = "-1"; //Se asigna -1 al primer registro que es transaccion en proceso
                    oComWeb_Ws_Bitacora_Pse.estado_consumows = "-1";
                    oComWeb_Ws_Bitacora_Pse.banco = "SIN SELECCIONAR";
                    oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                    oComWeb_Ws_Bitacora_Pse.num_cxc = IdPago.ToString();  // Numero de Declaracion
                    oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = tipod;
                    oComWeb_Ws_Bitacora_Pse.nit_pagador = Nit;       // Nit
                    oComWeb_Ws_Bitacora_Pse.nombre_pagador = nombre + " " + Apellido;
                    oComWeb_Ws_Bitacora_Pse.desc_referencia = resultado;
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE ZPAGOS";
                    oComWeb_Ws_Bitacora_Pse.ip_pagador = "";//Context.Request.ServerVariables["remote_addr"].ToString();//ip del cliente q solicita la informacion
                    oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                    oComWeb_Ws_Bitacora_Pse.cod_cxc = "2";
                    oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                    oComWeb_Ws_Bitacora_Pse.Num_Ingreso = "0";
                    var oCtrlWsBitacora = new ComCtrlWebWsBitacora();
                    var rta = oCtrlWsBitacora.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);

                }
                else
                {
                    if (dtBitacora != null && dtBitacora.Rows.Count >= 1)
                    {
                        intentos = int.Parse(dtBitacora.Rows[0]["INTENTOS_TRANSACCION"].ToString() + 1);
                        oComWeb_Ws_Bitacora_Pse.intentos_transaccion = intentos.ToString();
                        oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                    }
                    else
                    {
                        oComWeb_Ws_Bitacora_Pse.intentos_transaccion = "1";
                        oComWeb_Ws_Bitacora_Pse.estadoreg = "2";
                    }
                    oComWeb_Ws_Bitacora_Pse.ticket_id = IdPago;
                    oComWeb_Ws_Bitacora_Pse.estado_transaccion = "Iniciada";
                    oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = "1"; //Se asigna -1 al primer registro que es transaccion en proceso
                    oComWeb_Ws_Bitacora_Pse.estado_consumows = "0";
                    oComWeb_Ws_Bitacora_Pse.banco = "SIN SELECCIONAR";
                    oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                    oComWeb_Ws_Bitacora_Pse.num_cxc = IdPago.ToString();  // Numero de Declaracion
                    oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = tipod;
                    oComWeb_Ws_Bitacora_Pse.nit_pagador = Nit;       // Nit
                    oComWeb_Ws_Bitacora_Pse.nombre_pagador = nombre + " " + Apellido;
                    oComWeb_Ws_Bitacora_Pse.desc_referencia = referencia;
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE ZPAGOS";
                    oComWeb_Ws_Bitacora_Pse.ip_pagador = "";//Context.Request.ServerVariables["remote_addr"].ToString();//ip del cliente q solicita la informacion
                    oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                    oComWeb_Ws_Bitacora_Pse.cod_cxc = "2";
                    oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                    oComWeb_Ws_Bitacora_Pse.Num_Ingreso = "0";
                    var oCtrlWsBitacora = new ComCtrlWebWsBitacora();
                    var rta = oCtrlWsBitacora.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);
                    res.Codigo = 1;
                    res.Ruta = "https://www.zonapagos.com/" + codruta + "/pago.asp?estado_pago=iniciar_pago&identificador=" + resultado;
                }
                return res;
            }
            catch (Exception e)
            {
                res.Codigo = 0;
                res.Mensaje = "Error: " + e.Message;
                return res;
            }

        }
        public Respuesta RegistrarBitacora(ModelPagoBotones obj, bool isFallida, string idTransaccion)
        {
            var tipod = "";
            var Nombre = "";
            var Apellido = "";
            var Nit = "";
            var entidad = new FacMFactura();
            Respuesta res = new Respuesta();
            res.Codigo = 1;
            var intentos = 0;
            var IdPago = obj.itemSelected.ID_MFACTURA;
            var context = System.Web.HttpContext.Current;
            var referencia = "Pago de Factura Nº: " + obj.itemSelected.COD_FACTURA + " - " + obj.itemSelected.VIGENCIA;
            var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
            var dtBitacora = (DataTable)context.Session["_DTBITACORA_"];
            var nombre = (string)(context.Session["NOMBRE"]);
            switch ((string)(context.Session["TIPOD"]))
            {
                case "C":
                    tipod = "1";
                    if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                    {
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                    }
                    else
                    {
                        Nombre = "NN. CC:" + Nit;
                    }
                    if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                    {
                        Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                    }
                    else
                    {
                        Apellido = "";
                    }
                    break;
                case "E":
                    tipod = "2";
                    if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                    {
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                    }
                    else
                    {
                        Nombre = "NN. CC:" + Nit;
                    }
                    if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                    {
                        Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                    }
                    else
                    {
                        Apellido = "";
                    }
                    break;
                case "N":
                    tipod = "3";
                    if (!string.IsNullOrEmpty((string)(context.Session["NOMBRE_CLIENTE"])))
                    {
                        Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                    }
                    else
                    {
                        Nombre = "NIT-" + Nit;
                    }
                    if (!string.IsNullOrEmpty((string)(context.Session["APELLIDO_CLIENTE"])))
                    {
                        Apellido = (string)(context.Session["APELLIDO_CLIENTE"]);
                    }
                    else
                    {
                        Apellido = "";
                    }
                    break;
                default:
                    tipod = "0";
                    Nombre = (string)(context.Session["NOMBRE_CLIENTE"]);
                    Apellido = "NIT-";
                    break;
            }
            if (obj.itemSelected.COD_TIPO == 2)
            {
                entidad.CodTipo = "2";
            }
            if (!string.IsNullOrEmpty((string)(context.Session["NIT"])))
            {
                Nit = (string)(context.Session["NIT"]);
            }
            else
            {
                res.Codigo = 0;
            }
            if (!isFallida)
            {
                if (dtBitacora != null && dtBitacora.Rows.Count >= 1)
                {
                    intentos = int.Parse(dtBitacora.Rows[0]["INTENTOS_TRANSACCION"].ToString()) + 1;
                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = intentos.ToString();
                    oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                }
                else
                {
                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = "1";
                    oComWeb_Ws_Bitacora_Pse.estadoreg = "2";
                }
                oComWeb_Ws_Bitacora_Pse.ticket_id = IdPago;
                oComWeb_Ws_Bitacora_Pse.estado_transaccion = "Iniciada";
                oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = "1"; //Se asigna -1 al primer registro que es transaccion en proceso
                oComWeb_Ws_Bitacora_Pse.estado_consumows = "0";
                oComWeb_Ws_Bitacora_Pse.banco = "SIN SELECCIONAR";
                oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                oComWeb_Ws_Bitacora_Pse.num_cxc = IdPago.ToString();  // Numero de Declaracion
                oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = tipod;
                oComWeb_Ws_Bitacora_Pse.nit_pagador = Nit;       // Nit
                oComWeb_Ws_Bitacora_Pse.nombre_pagador = nombre + " " + Apellido;
                oComWeb_Ws_Bitacora_Pse.desc_referencia = idTransaccion == "" ? referencia : idTransaccion;
                oComWeb_Ws_Bitacora_Pse.ip_pagador = "";//Context.Request.ServerVariables["remote_addr"].ToString();//ip del cliente q solicita la informacion
                oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                oComWeb_Ws_Bitacora_Pse.cod_cxc = "2";
                if (obj.itemSelected.BTN_SELECTED == "Wompi")
                {
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE WOMPI";
                }
                else if (obj.itemSelected.BTN_SELECTED == "PlaceToPay")
                {
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE PLACETOPAY";
                }

                oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                oComWeb_Ws_Bitacora_Pse.Num_Ingreso = "0";
                var oCtrlWsBitacora = new ComCtrlWebWsBitacora();
                var response = oCtrlWsBitacora.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);
            }
            else
            {
                if (dtBitacora != null && dtBitacora.Rows.Count >= 1)
                {
                    intentos = int.Parse(dtBitacora.Rows[0]["INTENTOS_TRANSACCION"].ToString()) + 1;
                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = intentos.ToString();
                    oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                }
                else
                {
                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = "1";
                    oComWeb_Ws_Bitacora_Pse.estadoreg = "2";
                }
                oComWeb_Ws_Bitacora_Pse.ticket_id = IdPago;
                oComWeb_Ws_Bitacora_Pse.estado_transaccion = "Fallida";
                oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = "-1"; //Se asigna -1 al primer registro que es transaccion en proceso
                oComWeb_Ws_Bitacora_Pse.estado_consumows = "-1";
                oComWeb_Ws_Bitacora_Pse.banco = "SIN SELECCIONAR";
                oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                oComWeb_Ws_Bitacora_Pse.num_cxc = IdPago.ToString();  // Numero de Declaracion
                oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = tipod;
                oComWeb_Ws_Bitacora_Pse.nit_pagador = Nit;       // Nit
                oComWeb_Ws_Bitacora_Pse.nombre_pagador = nombre + " " + Apellido;
                oComWeb_Ws_Bitacora_Pse.desc_referencia = idTransaccion == "" ? "Fallida" : idTransaccion;
                oComWeb_Ws_Bitacora_Pse.ip_pagador = "";//Context.Request.ServerVariables["remote_addr"].ToString();//ip del cliente q solicita la informacion
                oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                oComWeb_Ws_Bitacora_Pse.cod_cxc = "2";
                if (obj.itemSelected.BTN_SELECTED == "Wompi")
                {
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE WOMPI";
                }
                else if (obj.itemSelected.BTN_SELECTED == "PlaceToPay")
                {
                    oComWeb_Ws_Bitacora_Pse.origen = "PSE PLACETOPAY";
                }
                oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                oComWeb_Ws_Bitacora_Pse.Num_Ingreso = "0";
                var oCtrlWsBitacora = new ComCtrlWebWsBitacora();
                var rta = oCtrlWsBitacora.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);
                if (!rta)
                {
                    res.Codigo = 0;
                }

            }
            return res;
        }
        public Respuesta IniciarTransaccion(DetalleFactura facSelected)
        {
            Respuesta res = new Respuesta();
            if (facSelected.ESTADO != "16")
            {
                var entidadIng = new IngMingresos();
                var dtTipoIng = new DataTable();
                var dtdistIng = new DataTable();
                var manejadorCtrl = new IngCtrlConsultaMingresos();
                var id_pago = facSelected.ID_MFACTURA;
                var context = System.Web.HttpContext.Current;
                entidadIng.Vigencia = (string)(context.Session["_VIGENCIA_"]);
                entidadIng.CodTipo = facSelected.COD_TIPO.ToString();
                entidadIng.CodCategoria = facSelected.COD_CATEGORIA;
                var dtResultado = manejadorCtrl.CtrlConsultaTipoIng(entidadIng);
                var bitacora = VerificaPago(id_pago);
                System.Web.HttpContext.Current.Session["_DTBITACORA_"] = bitacora;
                res.Codigo = 1;
                if (bitacora != null && bitacora.Rows.Count >= 1)
                {
                    if (bitacora.Rows[0]["ORIGEN"].ToString() == "PSE ZPAGOS")
                    {
                        actualizaestado(id_pago);
                    }

                    bitacora = VerificaPago(id_pago);
                    System.Web.HttpContext.Current.Session["_DTBITACORA_"] = bitacora;
                    if (bitacora.Rows[0]["ESTADO_CONSUMOWS"].ToString() == "999")
                    {
                        res.Mensaje = "En este momento su Numero de Referencia o Factura (" + id_pago + ") presenta un proceso de pago cuya transacción se encuentra PENDIENTE de recibir confirmación por parte de su entidad financiera, por favor espere unos minutos y vuelva a consultar más tarde para verificar si su pago fue confirmado de forma exitosa. Si desea mayor información sobre el estado actual de su operación, comunicarse con la entidad y preguntar por el estado de la transacción: " + bitacora.Rows[0]["COD_CONFIRMACION"].ToString();
                        res.Codigo = 0;
                    }
                    else if (bitacora.Rows[0]["ESTADO_CONSUMOWS"].ToString() == "4001")
                    {
                        res.Mensaje = "En este momento su Numero de Referencia o Factura (" + id_pago + ") presenta un proceso de pago cuya transacción se encuentra PENDIENTE de recibir confirmación por parte de su entidad financiera, por favor espere unos minutos y vuelva a consultar más tarde para verificar si su pago fue confirmado de forma exitosa. " + bitacora.Rows[0]["COD_CONFIRMACION"].ToString();
                        res.Codigo = 0;
                    }
                    else if (bitacora.Rows[0]["ESTADO_CONSUMOWS"].ToString() == "888")
                    {
                        res.Mensaje = "En este momento su Numero de Referencia o Factura (" + id_pago + ") presenta un proceso de pago cuya transacción se encuentra PENDIENTE POR INICIAR.";
                        res.Codigo = 0;
                    }
                    else if (bitacora.Rows[0]["ESTADO_CONSUMOWS"].ToString() == "1")
                    {
                        res.Mensaje = "La factura ya se encuentra CANCELADA.";
                        res.Codigo = 0;
                    }
                        
                    
                }
            }
            else
            {
                res.Mensaje = "No se puede realizar pago, esta Factura ya se encuentra CANCELADA.";
                res.Codigo = 0;
            }
            return res;
        }
        public DataTable VerificaPago(string idPago)
        {
            var dtResultado = new DataTable();
            var manejadorCtrl = new ComCtrlWebWsBitacora();
            var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
            oComWeb_Ws_Bitacora_Pse.num_cxc = idPago;
            dtResultado = manejadorCtrl.CtrlBuscaValidador(oComWeb_Ws_Bitacora_Pse);
            return dtResultado;
        }

        public async Task<Respuesta> ActualizarEstadosGeneralAsync()
        {
            
            var result = new Respuesta();
            try
            {
                var sb = new StringBuilder();
                var context = System.Web.HttpContext.Current;
                var nit = (string)(context.Session["NIT"]);
                sb.Append("SELECT TICKET_ID, ESTADO_CONSUMOWS, ESTADO_TRANSACCION, ORIGEN, COD_CONFIRMACION, DESC_REFERENCIA, VALOR_PAGO FROM WEB_WS_BITACORA_PSE WHERE ESTADO_CONSUMOWS not in ('1','1000','-1') AND NIT_PAGADOR ='" + nit + "'");
                var data = await ConsultarBitacoraEntidadAsync(sb.ToString());
                foreach (var i in data)
                {

                    if (i.origen == "PSE WOMPI")
                    {
                        result.FacturaActualizadaMessage += "";
                    }
                    else if (i.origen == "PSE PLACETOPAY")
                    {
                        ConsumoPlaceToPayController cptp = new ConsumoPlaceToPayController();
                        if (i.cod_confirmaccion.ToString() != "")
                        {
                            ResponseCheckStatus status = cptp.ConsultarSesionPlaceToPay(i.desc_referencia.ToString()).Result;
                            ActualizarEstadoPlaceTopay(status, i.ticket_id);
                            result.ResPTP = status;
                            result.ActualizoEstadoFacturas = true;
                        }
                    }
                    else if (i.origen == "PSE ZPAGOS")
                    {
                        actualizaestado(i.ticket_id);
                    }
                    else if (i.origen == "PSE 1Cero1")
                    {
                        actualizaestado(i.ticket_id);
                    }
                }
                result.Codigo = 1;
            }
            catch (Exception ex)
            {
                result.Codigo = 0;
                result.Mensaje = ex.Message;
            }
            return result;
        }

        public async Task<ResponsePTP> notificationServicePTPAsync(NotificationPTP obj)
        {
            ResponsePTP res = new ResponsePTP();
            
            if (obj.key == "{gr&i*[)![RM%Y-8=Md/miF-J3Haxb")
            {
                var sb = new StringBuilder();
                sb.Append("SELECT TICKET_ID, ESTADO_CONSUMOWS, ESTADO_TRANSACCION, ORIGEN, COD_CONFIRMACION, DESC_REFERENCIA, VALOR_PAGO FROM WEB_WS_BITACORA_PSE WHERE DESC_REFERENCIA ='" + obj.response.requestId + "'");
                var data = await ConsultarBitacoraEntidadAsync(sb.ToString());
                if (data.Count > 0)
                {
                    foreach (var i in data)
                    {
                        ActualizarEstadoPlaceTopay(obj.response, i.ticket_id);
                    }
                }
                else
                {
                    res.IsException = true;
                    res.Exception = "No se encontro el requestId";
                }

            }
            else
            {
                res.IsException = true;
                res.Exception = "La llave es incorrecta";
            }
            return res;
        }

        public Respuesta CargarFacturas(string idPago)
        {
            Respuesta res = new Respuesta();
            var context = System.Web.HttpContext.Current;
            if (idPago != "" && idPago != "null")
            {
                var entidad = new FacMFactura();
                var EntidadFac = new FacConsultasFacturasV1();
                FacCtrlConsultasFacturasV1 facCtrlConsultasFacturasV1 = new FacCtrlConsultasFacturasV1();
                var manejadorCtrl = new FacCtrlMFactura();
                EntidadFac.IdMfactura = idPago;
                entidad.IdMfactura = idPago;
                Random rand = new Random();
                var dtResultadoFac = facCtrlConsultasFacturasV1.ctrlCargarConsFactura(EntidadFac, 1);
                if (validarDataTable(dtResultadoFac))
                {
                    System.Web.HttpContext.Current.Session["_DT_DATOSGV_"] = dtResultadoFac;
                    if (dtResultadoFac.Rows[0]["COD_TIPO"].ToString() == "2")
                    {
                        entidad.CodTipo = "2";
                    }
                    else
                    {
                        entidad.CodTipo = null;
                    }
                    var dtResDatosWs = manejadorCtrl.CtrlConsCtrlTipoFactura(entidad);
                    if (validarDataTable(dtResDatosWs))
                    {
                        if (!string.IsNullOrEmpty(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString()))
                        {
                            var res_int_error = 0;
                            var res_det_pago = "";
                            var DtPago = new DataTable();
                            var estado = "";
                            var consumirwszona = new ConsumoZpagos.ConexionAlServicio();

                            var userws = dtResDatosWs.Rows[0]["USERWS_PSE"].ToString();
                            var passws = dtResDatosWs.Rows[0]["PASSWS_PSE"].ToString();
                            var idtienda = Convert.ToInt32(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString());
                            res_int_error = consumirwszona.estadoverificar(idPago, idtienda, passws, userws);
                            if (res_int_error == 0)
                            {
                                res_det_pago = consumirwszona.detalleverificarpago_v4(idPago, idtienda, passws, userws);
                                DtPago = ProcesaDetallePago(res_det_pago);
                                estado = "No definido";
                                switch (DtPago.Rows[0]["ESTADOPAGO"].ToString())
                                {
                                    case "1": estado = "Pago Finalizado"; break;
                                    case "888": estado = "Pendiente Iniciar"; break;
                                    case "999": estado = "Pendiente Finalizar"; break;
                                    case "1000": estado = "Pago Rechazado"; break;
                                    case "4000": estado = "Rechazado CR"; break;
                                    case "4001": estado = "Pendiente CR"; break;
                                    case "4003": estado = "Error CR"; break;
                                }
                                EscribirLog(" Se recibió parámetro id_pago: " + idPago + " Con estado: " + estado + " (" + DtPago.Rows[0]["ESTADOPAGO"].ToString() + "). (" + (rand.Next(100, 399) * 10).ToString() + "ms)");
                                actualizaestado(idPago);
                            }

                        }
                    }
                }
            }
            var entidadCtrl = new ComCtrlContabilidad();
            entidadCtrl.Mes = Convert.ToString(DateTime.Now.Month);
            var ConsClsCtrlCierres = new ComCtrlCtrlContabilidad();
            var dtctrlcierres = ConsClsCtrlCierres.CtrlconsControlCierres(entidadCtrl);

            if (validarDataTable(dtctrlcierres))
            {
                if (dtctrlcierres.Rows[0]["CERRADO"].ToString() != "S")
                {
                    var entidad = new FacConsultasFacturasV1();
                    entidad.Nit = (string)(context.Session["NIT"]);

                    var data = CargarConsFacturaAsync(entidad).Result;

                    if (validarDataTable(data))
                    {
                        res.Data = data;
                    }
                    res.Mensaje = (string)(context.Session["NIT"]);
                    res.Codigo = 1;


                }
                else
                {
                    res.Codigo = 0;
                    res.Mensaje = "No se ha actualizado la tasa de interes para el mes en curso, por favor comuniquese con la entidad";
                }
            }
            else
            {
                res.Codigo = 0;
                res.Mensaje = "No se han parametrizado cierres, por favor comuniquese con la entidad";
            }
            return res;

        }
        public async Task<DataTable> CargarConsFacturaAsync(FacConsultasFacturasV1 entidad)
        {
            /*var manejadorCtrl = new FacCtrlConsultasFacturasV1();

            return manejadorCtrl.ctrlCargarConsFactura(entidad, numPagActual);*/
            using (var conn = await ConectionFactory.DefaultConnectionAsync())
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT DISTINCT ID_MFACTURA, COD_TIPO, VIGENCIA, COD_FACTURA, NIT, NOMBRE, FECHA_FACTURA, FECHA_FACTURADESDE, ESTADO, ESTADO_FACTURA, COD_CATEGORIA, NOM_CATEGORIA, ");
                    sb.Append(" VAL_SUBTOTALFAC, VAL_TOTALFAC, VAL_IVAFAC, VAL_RECARGOFAC, VAL_DESCUENTOFAC, VAL_CUENTASCOBRAR, NVL(VAL_INTERESCOBRAR, 0) AS VAL_INTERESCOBRAR, (VAL_CUENTASCOBRAR + NVL(VAL_INTERESCOBRAR, '0')) AS TOTAL_PAGO, VAL_FPAGO, FECHA_REGISTRO, COD_ELEMENTO, NOM_ELEMENTO, COD_REFERENCIA, REFERENCIA,");
                    sb.Append(" TIPO_FACTURA, COD_LOCALIZA, DOC_TASA, NOTA, OBSERVAC, COD_CENTRO, OBS_ANULACION, FEC_ANULA, FECHA_LIMITE, DECODE(COD_TASA, -1, 0, COD_TASA) AS COD_TASA, COD_COT, COD_VENDEDOR, DECODE(IMPRESO, 'N', 'No', 'Si') AS IMPRESO, TRUNC(SYSDATE) FEC_ACTUAL");
                    sb.Append(" FROM FAC_CONSULTAFAC_WEB_V1 WHERE ESTADO = 11 AND NIT ='" + entidad.Nit + "'");
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = sb.ToString();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    if (this.transaction != null)
                    {
                        command.Transaction = this.transaction;
                    }
                    var reader = await command.ExecuteReaderAsync();
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception("PagoFacturasProvider :: CargarConsFacturaAsync", ex);
                }
            }

        }

        public Respuesta ActualizarEstadoWompi(ResponseWompi objWompi)
        {
            Respuesta res = new Respuesta();
            try
            {

                var dtResultado = new DataTable();
                var manejadorCtrl = new FacCtrlMFactura();
                var manejadorCtrlV1 = new FacCtrlConsultasFacturasV1();
                var EntidadFac = new FacConsultasFacturasV1();
                var dtResultadoFac = new DataTable();
                var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
                var consulta = new ComCtrlWebWsBitacora();
                var EjecOperacion = new ComCtrlWebWsBitacora();
                var idtienda = 0;
                var res_int_error = 0;
                var res_det_pago = "";
                var estado = "";
                var mensaje = "";
                var numing = "";
                var entidad = new FacMFactura();
                var dtResDatosWs = new DataTable();
                var rta = false;
                entidad.IdMfactura = objWompi.idpago;
                EntidadFac.IdMfactura = objWompi.idpago;

                dtResultadoFac = manejadorCtrlV1.ctrlCargarConsFactura(EntidadFac, 1);


                if (dtResultadoFac.Rows[0]["COD_TIPO"].ToString() == "2")
                {

                    entidad.CodTipo = "2";
                }
                else
                {
                    entidad.CodTipo = null;
                };

                dtResDatosWs = manejadorCtrl.CtrlConsCtrlTipoFactura(entidad); //WFAC_MOD_0008_20200616 - Fecha Inicio 16/06/2020 - Ticket Nº 37533 - Caso: se implementa método para consultar datos de control para comunicacion con los web services, desde la tabla CTRL_TIPO_FACTURA. - Jorge Valega

                if (dtResDatosWs.Rows.Count >= 1)
                {
                    if (!string.IsNullOrEmpty(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString()))
                    {

                        var userws = dtResDatosWs.Rows[0]["USERWS_PSE"].ToString();
                        var passws = dtResDatosWs.Rows[0]["PASSWS_PSE"].ToString();
                        idtienda = Convert.ToInt32(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString());



                        oComWeb_Ws_Bitacora_Pse.num_cxc = objWompi.idpago;

                        dtResultado = consulta.CtrlBuscaValidador(oComWeb_Ws_Bitacora_Pse); //Consulto la bitacora del pago donde tengo el estado del pago

                        if (dtResultado.Rows.Count >= 1)
                        {
                            if (dtResultado.Rows[0]["ESTADO_CONSUMOWS"].ToString() != "1")
                            {
                                if (objWompi.status != "DECLINED")
                                {
                                    if (dtResultado.Rows[0]["NUM_INGRESO"].ToString() == "0")
                                    { // Si el estado que trae el WS es "1"(Pago Finalizado) Afecto el financiero(Ingreso, Contabilidad, PptoIngreso, estado y valores de la factura)


                                        if (objWompi.status == "APPROVED")
                                        {
                                            numing = AfectaFinancieroAsync(objWompi.idpago, objWompi.fepago, objWompi.valor).Result;
                                        }
                                        else
                                        {
                                            numing = "0";
                                        }

                                        //numing = "1";
                                        if (numing != "0")
                                        {

                                            EscribirLog("Pago registrado con éxito ID_MFACTURA: " + objWompi.idpago + ", Numero de ingreso: " + numing);     //WFAC_MOD_0003_20181218
                                        }

                                    } // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString="1")
                                    var tempstatus = "";
                                    switch (dtResultado.Rows[0]["ESTADO_CONSUMOWS"].ToString())
                                    {
                                        case "1":
                                            tempstatus = "APPROVED";
                                            break;
                                        /*case "888": estado = "Pendiente Iniciar"; break;
                                        case "999": estado = "Pendiente Finalizar"; break;*/
                                        case "1000":
                                            tempstatus = "DECLINED";
                                            break;
                                        /*case "4000": estado = "Rechazado CR"; break;
                                        case "4001": estado = "Pendiente CR"; break;*/
                                        case "4003 ":
                                            tempstatus = "ERROR";
                                            break;
                                    }
                                    if (objWompi.status != tempstatus)
                                    {  //Si el estado que tengo en la bitacora es diferente al traido por el webservices actualizo el estado
                                        var estado_id = "";
                                        switch (objWompi.status)
                                        {
                                            case "APPROVED":
                                                estado_id = "1";
                                                estado = "Pago Finalizado";
                                                break;
                                            /*case "888": estado = "Pendiente Iniciar"; break;
                                            case "999": estado = "Pendiente Finalizar"; break;*/
                                            case "DECLINED":
                                                estado_id = "1000";
                                                estado = "Pago Rechazado";
                                                break;
                                            /*case "4000": estado = "Rechazado CR"; break;
                                            case "4001": estado = "Pendiente CR"; break;*/
                                            case "ERROR":
                                                estado_id = "4003";
                                                estado = "Error CR"; break;
                                            default:
                                                estado = objWompi.status;
                                                estado_id = "4003"; break;
                                        }






                                        oComWeb_Ws_Bitacora_Pse.ticket_id = objWompi.idpago;
                                        oComWeb_Ws_Bitacora_Pse.estado_transaccion = estado;
                                        oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = objWompi.idrequeswompi;
                                        oComWeb_Ws_Bitacora_Pse.estado_consumows = estado_id;
                                        oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.banco = objWompi.payment;
                                        oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                                        oComWeb_Ws_Bitacora_Pse.num_cxc = objWompi.idpago;
                                        oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                                        oComWeb_Ws_Bitacora_Pse.valor_pago = objWompi.valor;
                                        oComWeb_Ws_Bitacora_Pse.cod_cxc = objWompi.idpago;
                                        //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                                        oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                                        oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                                        oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                                        oComWeb_Ws_Bitacora_Pse.origen = "PSE WOMPI";


                                        rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse); // Actualizo la bitacora con el nuevo estado

                                        if (!rta)
                                        {
                                            var Json = JsonConvert.SerializeObject(oComWeb_Ws_Bitacora_Pse);
                                            EscribirLog("No se afecto la bitacora correctamente para la factura:" + objWompi.idpago + ", Mensaje: " + EjecOperacion.mensaje + ", Objeto enviado JSON: " + Json);
                                        }
                                        // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString = "1") and (numing="0") then

                                    }  // fin  if DtPago.Rows[0].Item["ESTADOPAGO"].ToString <>.....{}

                                }
                                else
                                {


                                    numing = "0";
                                    oComWeb_Ws_Bitacora_Pse.ticket_id = objWompi.idpago;
                                    oComWeb_Ws_Bitacora_Pse.estado_transaccion = dtResultado.Rows[0]["ESTADO_TRANSACCION"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = dtResultado.Rows[0]["COD_CONFIRMACION"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.estado_consumows = "-1";
                                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.banco = dtResultado.Rows[0]["BANCO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nit_banco = dtResultado.Rows[0]["NIT_BANCO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.num_cxc = objWompi.idpago;
                                    oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                                    oComWeb_Ws_Bitacora_Pse.cod_cxc = "-1";                                         //WFAC_MOD_0003_20181218
                                                                                                                    //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                                    oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                                    oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                                    oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                                    oComWeb_Ws_Bitacora_Pse.origen = "PSE WOMPI";
                                    rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);

                                } // fin  if (res_int_error = 0) then

                            } // fin if dtresultado.Rows.Count>=1 then

                        }
                        else
                        {

                            EscribirLog("L1575. No fue posible realizar el ingreso de ID_MFACTURA: " + objWompi.idpago + ", (Datos de control faltantes). ");
                        }      //Fin  if not String.IsNullOrEmpty(dtResDatosWs.

                    }
                    else
                    {

                        EscribirLog("L1579. No fue posible realizar el ingreso de ID_MFACTURA: " + objWompi.idpago + ", (Datos de control faltantes). ");
                    }
                }//Fin dtResDatosWs.Rows.Count >=1) then
                res.Codigo = rta ? 1 : 0;
                return res;
            }
            catch (Exception ex)
            {
                res.Codigo = 0;
                res.Mensaje = ex.Message;
                EscribirLog("No fue posible realizar el ingreso de ID_MFACTURA: " + objWompi.idpago + ", Se ha producido un error. " + ex.Message);
                return res;
            }
        }

        public Respuesta ActualizarEstadoPlaceTopay(ResponseCheckStatus objPlaceToPay, string idpago)
        {
            Respuesta res = new Respuesta();
            try
            {

                var dtResultado = new DataTable();
                var manejadorCtrl = new FacCtrlMFactura();
                var manejadorCtrlV1 = new FacCtrlConsultasFacturasV1();
                var EntidadFac = new FacConsultasFacturasV1();
                var dtResultadoFac = new DataTable();
                var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
                var consulta = new ComCtrlWebWsBitacora();
                var EjecOperacion = new ComCtrlWebWsBitacora();
                var idtienda = 0;
                var estado = "";
                var numing = "";
                var entidad = new FacMFactura();
                var dtResDatosWs = new DataTable();
                var rta = false;
                entidad.IdMfactura = idpago;
                EntidadFac.IdMfactura = idpago;

                dtResultadoFac = manejadorCtrlV1.ctrlCargarConsFactura(EntidadFac, 1);


                if (dtResultadoFac.Rows[0]["COD_TIPO"].ToString() == "2")
                {

                    entidad.CodTipo = "2";
                }
                else
                {
                    entidad.CodTipo = null;
                };

                //dtResDatosWs = manejadorCtrl.CtrlConsCtrlTipoFactura(entidad); //WFAC_MOD_0008_20200616 - Fecha Inicio 16/06/2020 - Ticket Nº 37533 - Caso: se implementa método para consultar datos de control para comunicacion con los web services, desde la tabla CTRL_TIPO_FACTURA. - Jorge Valega

                oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;

                dtResultado = consulta.CtrlBuscaValidador(oComWeb_Ws_Bitacora_Pse); //Consulto la bitacora del pago donde tengo el estado del pago

                if (validarDataTable(dtResultado))
                {
                    if (dtResultado.Rows[0]["ESTADO_CONSUMOWS"].ToString() != "1")
                    {
                        if (objPlaceToPay.status.status != "REJECTED")
                        {
                            if (dtResultado.Rows[0]["NUM_INGRESO"].ToString() == "0")
                            { // Si el estado que trae el WS es "1"(Pago Finalizado) Afecto el financiero(Ingreso, Contabilidad, PptoIngreso, estado y valores de la factura)


                                if (objPlaceToPay.status.status == "APPROVED")
                                {
                                    numing = AfectaFinancieroAsync(idpago, objPlaceToPay.status.date, objPlaceToPay.request.payment.amount.total.ToString()).Result;

                                }
                                else
                                {
                                    numing = "0";
                                }
                                //numing = "1";
                                if (numing != "0")
                                {

                                    EscribirLog("Pago registrado con éxito ID_MFACTURA: " + idpago + ", Numero de ingreso: " + numing);     //WFAC_MOD_0003_20181218
                                }

                            } // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString="1")
                            var tempstatus = "";
                            switch (dtResultado.Rows[0]["ESTADO_CONSUMOWS"].ToString())
                            {
                                case "1":
                                    tempstatus = "APPROVED";
                                    break;
                                /*case "888": estado = "Pendiente Iniciar"; break;
                                case "999": estado = "Pendiente Finalizar"; break;*/
                                case "1000":
                                    tempstatus = "REJECTED";
                                    break;
                                /*case "4000": estado = "Rechazado CR"; break;
                                case "4001": estado = "Pendiente CR"; break;*/
                                case "4003 ":
                                    tempstatus = "ERROR";
                                    break;
                                case "4001 ":
                                    tempstatus = "PENDING";
                                    break;
                            }
                            if (objPlaceToPay.status.status != tempstatus)
                            {  //Si el estado que tengo en la bitacora es diferente al traido por el webservices actualizo el estado
                                var estado_id = "";
                                switch (objPlaceToPay.status.status)
                                {
                                    case "APPROVED":
                                        estado_id = "1";
                                        estado = "Pago Finalizado";
                                        break;
                                    /*case "888": estado = "Pendiente Iniciar"; break;
                                    case "999": estado = "Pendiente Finalizar"; break;*/
                                    case "REJECTED":
                                        estado_id = "1000";
                                        estado = "Pago Rechazado";
                                        break;
                                    /*case "4000": estado = "Rechazado CR"; break;
                                    case "4001": estado = "Pendiente CR"; break;*/
                                    case "ERROR":
                                        estado_id = "4003";
                                        estado = "Error CR"; break;
                                    case "PENDING":
                                        estado_id = "4001";
                                        estado = "Pendiente CR"; break;
                                    default:
                                        estado_id = "4003";
                                        estado = objPlaceToPay.status.status;
                                        break;

                                }






                                oComWeb_Ws_Bitacora_Pse.ticket_id = idpago;
                                oComWeb_Ws_Bitacora_Pse.estado_transaccion = estado;
                                oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = objPlaceToPay.requestId;
                                oComWeb_Ws_Bitacora_Pse.estado_consumows = estado_id;
                                oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                                oComWeb_Ws_Bitacora_Pse.banco = "PSE";
                                oComWeb_Ws_Bitacora_Pse.nit_banco = "1";
                                oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;
                                oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                                oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.valor_pago = objPlaceToPay.request.payment.amount.total.ToString();
                                oComWeb_Ws_Bitacora_Pse.cod_cxc = idpago;
                                //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                                oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                                oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                                oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                                oComWeb_Ws_Bitacora_Pse.origen = "PSE PLACETOPAY";


                                rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse); // Actualizo la bitacora con el nuevo estado
                                if (!rta)
                                {
                                    var Json = JsonConvert.SerializeObject(oComWeb_Ws_Bitacora_Pse);
                                    EscribirLog("No se afecto la bitacora correctamente para la factura:" + idpago + ", Mensaje: " + EjecOperacion.mensaje + ", Objeto enviado JSON: " + Json);
                                }
                                // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString = "1") and (numing="0") then

                            }  // fin  if DtPago.Rows[0].Item["ESTADOPAGO"].ToString <>.....{}

                        }
                        else
                        {


                            numing = "0";
                            oComWeb_Ws_Bitacora_Pse.ticket_id = idpago;
                            oComWeb_Ws_Bitacora_Pse.estado_transaccion = "Pago Rechazado";
                            oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = "1000";
                            oComWeb_Ws_Bitacora_Pse.estado_consumows = "-1";
                            oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                            oComWeb_Ws_Bitacora_Pse.banco = dtResultado.Rows[0]["BANCO"].ToString();
                            oComWeb_Ws_Bitacora_Pse.nit_banco = dtResultado.Rows[0]["NIT_BANCO"].ToString();
                            oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;
                            oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                            oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                            oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                            oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                            oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                            oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                            oComWeb_Ws_Bitacora_Pse.cod_cxc = "-1";                                         //WFAC_MOD_0003_20181218
                                                                                                            //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                            oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                            oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                            oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                            oComWeb_Ws_Bitacora_Pse.origen = "PSE PLACETOPAY";
                            rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);
                            if (!rta)
                            {
                                var Json = JsonConvert.SerializeObject(oComWeb_Ws_Bitacora_Pse);
                                EscribirLog("No se afecto la bitacora correctamente para la factura:" + idpago + ", Mensaje: " + EjecOperacion.mensaje + ", Objeto enviado JSON: " + Json);
                            }
                        } // fin  if (res_int_error = 0) then

                    } // fin if dtresultado.Rows.Count>=1 then

                }
                else
                {

                    EscribirLog("L1575. No fue posible realizar el ingreso de ID_MFACTURA: " + idpago + ", (Datos de control faltantes). ");
                }      //Fin  if not String.IsNullOrEmpty(dtResDatosWs.

                res.Codigo = rta ? 1 : 0;
                return res;
            }
            catch (Exception ex)
            {
                res.Codigo = 0;
                res.Mensaje = ex.Message;
                EscribirLog("No fue posible realizar el ingreso de ID_MFACTURA: " + idpago + ", Se ha producido un error. " + ex.Message);
                return res;
            }
        }
        public void actualizaestado(string idpago)
        {
            try
            {
                var dtResultado = new DataTable();
                var manejadorCtrl = new FacCtrlMFactura();
                var manejadorCtrlV1 = new FacCtrlConsultasFacturasV1();
                var EntidadFac = new FacConsultasFacturasV1();
                var dtResultadoFac = new DataTable();
                var oComWeb_Ws_Bitacora_Pse = new ComWeb_Ws_Bitacora_Pse();
                var consulta = new ComCtrlWebWsBitacora();
                var EjecOperacion = new ComCtrlWebWsBitacora();
                var idtienda = 0;
                var res_int_error = 0;
                var DtPago = new DataTable();
                var res_det_pago = "";
                var estado = "";
                var mensaje = "";
                var numing = "";
                var consumirwszona = new ConsumoZpagos.ConexionAlServicio();
                var entidad = new FacMFactura();
                var dtResDatosWs = new DataTable();

                entidad.IdMfactura = idpago;
                EntidadFac.IdMfactura = idpago;

                dtResultadoFac = manejadorCtrlV1.ctrlCargarConsFactura(EntidadFac, 1);


                if (dtResultadoFac.Rows[0]["COD_TIPO"].ToString() == "2")
                {

                    entidad.CodTipo = "2";
                }
                else
                {
                    entidad.CodTipo = null;
                };

                dtResDatosWs = manejadorCtrl.CtrlConsCtrlTipoFactura(entidad); //WFAC_MOD_0008_20200616 - Fecha Inicio 16/06/2020 - Ticket Nº 37533 - Caso: se implementa método para consultar datos de control para comunicacion con los web services, desde la tabla CTRL_TIPO_FACTURA. - Jorge Valega

                if (dtResDatosWs.Rows.Count >= 1)
                {
                    if (!string.IsNullOrEmpty(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString()))
                    {

                        var userws = dtResDatosWs.Rows[0]["USERWS_PSE"].ToString();
                        var passws = dtResDatosWs.Rows[0]["PASSWS_PSE"].ToString();
                        idtienda = Convert.ToInt32(dtResDatosWs.Rows[0]["ID_TIENDA_PSE"].ToString());

                        var rta = false;

                        oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;

                        dtResultado = consulta.CtrlBuscaValidador(oComWeb_Ws_Bitacora_Pse); //Consulto la bitacora del pago donde tengo el estado del pago

                        if (dtResultado.Rows.Count >= 1)
                        {


                            res_int_error = consumirwszona.estadoverificar(idpago, idtienda, passws, userws); //Consumo el web service "verificar_pago_v4", 0 - Encontro pago, -1 No hay pagos

                            if (res_int_error == 0)
                            {


                                res_det_pago = consumirwszona.detalleverificarpago_v4(idpago, idtienda, passws, userws); // Si hay pagos me traigo los detales del pago desde el Web services verificar_pago_v4 en un string donde cada pago esta separado por (;) y los campos por (|)

                                DtPago = ProcesaDetallePago(res_det_pago);      // Proceso la cadena separando los pago y los campos, obteniendo como resultado una table con N registros(pagos) y 21 columnas(campos)   

                                numing = "0";    ///


                                if (DtPago.Rows[0]["ESTADOPAGO"].ToString() == "1" && dtResultado.Rows[0]["NUM_INGRESO"].ToString() == "0")
                                { // Si el estado que trae el WS es "1"(Pago Finalizado) Afecto el financiero(Ingreso, Contabilidad, PptoIngreso, estado y valores de la factura)



                                    numing = AfectaFinancieroAsync(idpago, DtPago.Rows[0]["FECHA"].ToString(), DtPago.Rows[0]["VALORPAGADO"].ToString()).Result;

                                    if (numing != "0")
                                    {

                                        EscribirLog("Pago registrado con éxito ID_MFACTURA: " + idpago + ", Numero de ingreso: " + numing);     //WFAC_MOD_0003_20181218
                                    }

                                } // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString="1")


                                if (DtPago.Rows[0]["ESTADOPAGO"].ToString() != dtResultado.Rows[0]["ESTADO_CONSUMOWS"].ToString())
                                {  //Si el estado que tengo en la bitacora es diferente al traido por el webservices actualizo el estado



                                    estado = "No definido";

                                    //Posibles estados traidos por el WS
                                    switch (DtPago.Rows[0]["ESTADOPAGO"].ToString())
                                    {
                                        case "1": estado = "Pago Finalizado"; break;
                                        case "888": estado = "Pendiente Iniciar"; break;
                                        case "999": estado = "Pendiente Finalizar"; break;
                                        case "1000": estado = "Pago Rechazado"; break;
                                        case "4000": estado = "Rechazado CR"; break;
                                        case "4001": estado = "Pendiente CR"; break;
                                        case "4003": estado = "Error CR"; break;
                                    }

                                    oComWeb_Ws_Bitacora_Pse.ticket_id = idpago;
                                    oComWeb_Ws_Bitacora_Pse.estado_transaccion = estado;
                                    oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = DtPago.Rows[0]["CODIGOTRANSACCION"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.estado_consumows = DtPago.Rows[0]["ESTADOPAGO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.banco = DtPago.Rows[0]["NOMBREBANCO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nit_banco = DtPago.Rows[0]["CODBANCO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;
                                    oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.valor_pago = DtPago.Rows[0]["VALORPAGADO"].ToString();
                                    oComWeb_Ws_Bitacora_Pse.cod_cxc = DtPago.Rows[0]["TICKETID"].ToString();
                                    //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                                    oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                                    oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                                    oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                                    oComWeb_Ws_Bitacora_Pse.origen = "PSE ZPAGOS";

                                    if (DtPago.Rows[0]["ESTADOPAGO"].ToString() == "1" && numing == "0")
                                    {
                                    }
                                    ///////////////
                                    else
                                    {
                                        rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse); // Actualizo la bitacora con el nuevo estado

                                    } // fin if (DtPago.Rows[0].Item["ESTADOPAGO"].ToString = "1") and (numing="0") then

                                }  // fin  if DtPago.Rows[0].Item["ESTADOPAGO"].ToString <>.....{}

                            }
                            else
                            {



                                oComWeb_Ws_Bitacora_Pse.ticket_id = idpago;
                                oComWeb_Ws_Bitacora_Pse.estado_transaccion = dtResultado.Rows[0]["ESTADO_TRANSACCION"].ToString();
                                oComWeb_Ws_Bitacora_Pse.cod_confirmaccion = dtResultado.Rows[0]["COD_CONFIRMACION"].ToString();
                                oComWeb_Ws_Bitacora_Pse.estado_consumows = "-1";
                                oComWeb_Ws_Bitacora_Pse.intentos_transaccion = dtResultado.Rows[0]["INTENTOS_TRANSACCION"].ToString();
                                oComWeb_Ws_Bitacora_Pse.banco = dtResultado.Rows[0]["BANCO"].ToString();
                                oComWeb_Ws_Bitacora_Pse.nit_banco = dtResultado.Rows[0]["NIT_BANCO"].ToString();
                                oComWeb_Ws_Bitacora_Pse.num_cxc = idpago;
                                oComWeb_Ws_Bitacora_Pse.tipo_doc_pagador = dtResultado.Rows[0]["TIPO_DOC_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.nit_pagador = dtResultado.Rows[0]["NIT_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.nombre_pagador = dtResultado.Rows[0]["NOMBRE_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.desc_referencia = dtResultado.Rows[0]["DESC_REFERENCIA"].ToString();
                                oComWeb_Ws_Bitacora_Pse.ip_pagador = dtResultado.Rows[0]["IP_PAGADOR"].ToString();
                                oComWeb_Ws_Bitacora_Pse.valor_pago = "0";
                                oComWeb_Ws_Bitacora_Pse.cod_cxc = "-1";                                         //WFAC_MOD_0003_20181218
                                                                                                                //oComWeb_Ws_Bitacora_Pse.fecha_transaccion     := DtPago.Rows[0].Item["FECHA"].ToString;
                                oComWeb_Ws_Bitacora_Pse.fecha_transaccion = null;
                                oComWeb_Ws_Bitacora_Pse.Num_Ingreso = numing;
                                oComWeb_Ws_Bitacora_Pse.estadoreg = "1";
                                oComWeb_Ws_Bitacora_Pse.origen = "PSE ZPAGOS";
                                rta = EjecOperacion.CtrlComWebWsBitacoraConSQL(oComWeb_Ws_Bitacora_Pse);

                            } // fin  if (res_int_error = 0) then

                        } // fin if dtresultado.Rows.Count>=1 then

                    }
                    else
                    {

                        EscribirLog("L1575. No fue posible realizar el ingreso de ID_MFACTURA: " + idpago + ", (Datos de control faltantes). ");
                    }      //Fin  if not String.IsNullOrEmpty(dtResDatosWs.

                }
                else
                {

                    EscribirLog("L1579. No fue posible realizar el ingreso de ID_MFACTURA: " + idpago + ", (Datos de control faltantes). ");
                } //Fin dtResDatosWs.Rows.Count >=1) then
            }

            catch (Exception ex)
            {

                EscribirLog("No fue posible realizar el ingreso de ID_MFACTURA: " + idpago + ", Se ha producido un error. " + ex.Message);
            }
        }
        public async Task<string> AfectaFinancieroAsync(string idpago, string fecha, string valor)
        {
            HttpContext context = HttpContext.Current;
            var ExeStIngPse = false;
            var dtFactura = new DataTable();
            var dtResultado = new DataTable();
            var entidad = new FacConsultasFacturasV1();
            var entidadIng = new IngMingresos();
            var consultaing = new IngCtrlConsultaMingresos();
            if (conMing == null)
            {
                conMing = new IngCtrlConsultaMingresos();
            }
            //conMing = new IngCtrlConsultaMingresos();
            var consulta = new FacCtrlConsultasFacturasV1();
            var fechapago = "";

            //if valor.ToString().Contains(".") then
            //begin
            //valor := valor.Replace(".",",");
            //end;  
            //
            //escribirLog("Valor transaccion: " + valor);

            entidad.IdMfactura = idpago;

            dtFactura = consulta.ctrlCargarConsFactura(entidad, 1);
            var mensajeErr = consulta.mensaje;

            if (dtFactura.Rows.Count > 0)
            {


                //fechapago = String.Format("{0:d}", DateTime.Parse(fecha.Replace(".", "")));  //WFAC_MOD_0004_20190327
                fechapago = String.Format("{0:d}", DateTime.Parse(fecha));  //WFAC_MOD_0004_20190327

                entidadIng.Vigencia = (string)(context.Session["_VIGENCIA_"]);
                if (entidadIng.Vigencia == null)
                {
                    _ = await ConsultarNombreEntidadAsync();
                    entidadIng.Vigencia = (string)(context.Session["_VIGENCIA_"]);
                }
                entidadIng.CodCategoria = dtFactura.Rows[0]["COD_CATEGORIA"].ToString();
                entidadIng.CodTipo = dtFactura.Rows[0]["COD_TIPO"].ToString();

                dtResultado = consultaing.CtrlConsultaTipoIng(entidadIng);
                mensajeErr = consultaing.mensaje;

                if (dtResultado.Rows.Count > 0)
                {

                    entidadIng.IdMfactura = idpago;
                    entidadIng.CodFactura = dtFactura.Rows[0]["COD_FACTURA"].ToString();
                    entidadIng.Nit = dtFactura.Rows[0]["NIT"].ToString();
                    entidadIng.VigFactura = dtFactura.Rows[0]["VIGENCIA"].ToString();
                    entidadIng.FecIngreso = fechapago;
                    entidadIng.CodTipoing = dtResultado.Rows[0]["COD_TIPOING"].ToString();
                    entidadIng.ValorPago = valor;
                    entidadIng.NroIngreso = "-1";
                    entidadIng.Esquema = appConfig.esquema.ToString();

                    consultaing.ModTransaccional = true;

                    var json = JsonConvert.SerializeObject(entidadIng);

                    //ExeStIngPse = conMing.CtrlSDOCExecStIngWebPseFac(entidadIng); //WFAC_MOD_0007_20200604 - Fecha Inicio 04/06/2020 - Ticket Nº 37533 - Se implementa metodo para ejecución de ST_ING_WEBPSE_FAC el cual integra todas las afactaciones al sistema finciero por el pago de una Factura. - Jorge Valega
                    ExeStIngPse = await CtrlSDOCExecStIngWebPseFacAsync(entidadIng);
                    mensajeErr = consultaing.mensaje;
                    if (!ExeStIngPse)
                    {
                        var Json = JsonConvert.SerializeObject(entidadIng);
                        EscribirLog("No se afecto el financiero correctamente para la factura:" + idpago + ", Mensaje: " + consultaing.mensaje + ", Objeto enviado JSON: " + Json);
                    }
                    if (ExeStIngPse)
                    { //Se verifica la ejecucion del 

                        /*OracleParameter oDbSecImpto;
                        OracleParameterCollection oCollParadb;


                        oCollParadb = OracleParameterCollection(consultaing.ValoresDevueltosSt);
                        oDbSecImpto = oCollParadb["VNRO_INGRESO"]; //VNUM_INGRESO 
                        System.Web.HttpContext.Current.Session["NRO_INGRESO"] = Convert.ToString(oDbSecImpto.Value);*/
                        //consultaing.CtrlCommitTransODC();
                        return "1";// Convert.ToString(oDbSecImpto.Value);

                    }
                    else
                    {
                        EscribirLog("L1651. No se pudo realizar el ingreso de la factura ID_MFACTURA: " + idpago + ".  " + mensajeErr + ".   Json Enviado: " + json);
                        //consultaing.CtrlRollbackTransODC();

                        return "0";

                    }//fin if (resultado) then //Se verifica la ejecucion del ST_MINGRESOS


                }
                else
                {
                    EscribirLog("L1658. No se ha definido tipo de ingreso para la categoria COD_CATEGORIA: " + dtFactura.Rows[0]["COD_CATEGORIA"].ToString() + " COD_TIPO: " + dtFactura.Rows[0]["COD_TIPO"].ToString() + " VIGENCIA: " + valor + ". " + mensajeErr);
                    return "0";

                } //Fin if(dtResultado.Rows.Count>0)

            }
            else
            {
                EscribirLog("L1573. No se pudo realizar el ingreso de la factura ID_MFACTURA: " + idpago + ".  " + mensajeErr);
                return "0";

            }

        }
        public async Task<bool> CtrlSDOCExecStIngWebPseFacAsync(IngMingresos entidad)
        {

            try
            {
                var lstParam = buildParameters(entidad);
                //ConexionBD con = new ConexionBD(appConfig.ConnectionString.ToString());
                //con.Conectar();

                var schema = appConfig.esquema;
                var res = EjecutarProcedimiento_ConRetornoAsync(schema + ".ST_ING_WEBPSE_FAC", lstParam).Result;
                //var res = await EjecutarProcedimientoAsync(entidad);
                //con.Desconectar();

                return res;

            }
            catch (DbException ex)
            {

                throw new Exception("PagoFacturasProvider :: CtrlSDOCExecStIngWebPseFac", ex);
            }


        }
        public async Task<bool> EjecutarProcedimientoAsync(IngMingresos entidad)
        {
            var script = "";
            try
            {
                using (var conn = await ConectionFactory.DefaultConnectionAsync())
                {

                    script = buildQuery(entidad);
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = script;
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = Int32.MaxValue;

                    var res = command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EscribirLog("Error Oracle Afecatando Financiero codFactura:" + entidad.CodFactura + ".  Error:" + ex.Message);
                return false;
            }
        }

        public async Task<bool> EjecutarProcedimiento_ConRetornoAsync(string nomProcedure, List<OracleParameter> parametros)
        {
            OracleCommand comando;
            DataTable dt = new DataTable();
            try
            {
                using (var conexion = ConectionFactory.Connect())
                {
                    comando = new OracleCommand();//conexion.CreateCommand();
                    comando.CommandTimeout = Int32.MaxValue;
                    comando.CommandText = nomProcedure;
                    comando.Connection = conexion;
                    OracleGlobalization sessionGlobalization = conexion.GetSessionInfo();

                    sessionGlobalization.DateFormat = "DD / MM / YYYY";

                    conexion.SetSessionInfo(sessionGlobalization);
                    foreach (var parametro in parametros)
                    {
                        comando.Parameters.Add(parametro);
                    }


                    comando.CommandType = CommandType.StoredProcedure;

                    dt.Columns.Add("Resultado");
                    var test = comando.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                EscribirLog("Error Oracle Afecatando Financiero codFactura:" + ".  Error:" + ex.Message);
                return false;
            }
        }
        public string buildQuery(IngMingresos entidad)
        {
            var stb = new StringBuilder();

            var esquema = appConfig.esquema;
            try
            {
                stb.Append("DECLARE outParameter number; BEGIN " + esquema + ".ST_ING_WEBPSE_FAC (");
                stb.Append("" + entidad.IdMfactura + ",");
                stb.Append("'" + entidad.CodFactura + "',");
                stb.Append("'" + entidad.Nit + "',");
                stb.Append("" + entidad.Vigencia + ",");
                if (entidad.FecIngreso != null)
                {
                    //stb.Append("to_date('" + entidad.FecIngreso + "', 'dd-mm-yyyy'),");
                    stb.Append("TO_DATE('" + entidad.FecIngreso + "', 'DD/MM/YYYY'), ");
                }
                else
                {
                    stb.Append("NULL,");
                }
                stb.Append("'" + entidad.CodTipoing + "',");
                stb.Append("" + entidad.ValorPago + ",");
                stb.Append("outParameter");
                stb.Append(");");
                stb.Append(" END;");

                return stb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("PagoFacturas :: buildQuery", ex);
            }
        }
        public List<OracleParameter> buildParameters(IngMingresos entidad)
        {
            var parametro = new OracleParameter();
            var listaParametro = new List<OracleParameter>();

            parametro = new OracleParameter();
            parametro.ParameterName = "VID_MFACTURA";
            parametro.OracleDbType = OracleDbType.Int32;
            parametro.Size = Int32.MaxValue;
            parametro.Value = Convert.ToInt32(entidad.IdMfactura);
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VCOD_FACTURA";
            parametro.OracleDbType = OracleDbType.Varchar2;
            parametro.Size = Int32.MaxValue;
            parametro.Value = entidad.CodFactura;
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VNIT";
            parametro.OracleDbType = OracleDbType.Varchar2;
            parametro.Size = Int32.MaxValue;
            parametro.Value = entidad.Nit;
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VVIGENCIA";
            parametro.OracleDbType = OracleDbType.Int32;
            parametro.Size = Int32.MaxValue;
            parametro.Value = Convert.ToInt32(entidad.VigFactura);
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VFECHA_PAGO";
            //parametro.Value = entidad.FecIngreso;
            parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(entidad.FecIngreso))
            {
                parametro.Value = entidad.FecIngreso;
            }
            else
            {
                parametro.Value = null;
            }
            // parametro.Value = Convert.ToDateTime(entidad.FecIngreso).ToShortDateString();
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VCOD_TIPOING";
            parametro.OracleDbType = OracleDbType.Varchar2;
            parametro.Size = Int32.MaxValue;
            parametro.Value = entidad.CodTipoing;
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VVAL_PAGO";
            parametro.OracleDbType = OracleDbType.Double;
            //parametro.Size          := Int32.MaxValue;
            parametro.Value = Convert.ToDouble(entidad.ValorPago);
            listaParametro.Add(parametro);

            parametro = new OracleParameter();
            parametro.ParameterName = "VNRO_INGRESO";
            parametro.OracleDbType = OracleDbType.Int32;
            parametro.Size = Int32.MaxValue;
            parametro.Direction = ParameterDirection.InputOutput;
            parametro.Value = Convert.ToInt32(entidad.NroIngreso);
            listaParametro.Add(parametro);
            return listaParametro;
        }
        public async Task<List<ComWeb_Ws_Bitacora_Pse>> ConsultarBitacoraEntidadAsync(string sentence)
        {
            using (var conn = await ConectionFactory.DefaultConnectionAsync())
            {
                try
                {
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = sentence;
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    if (this.transaction != null)
                    {
                        command.Transaction = this.transaction;
                    }

                    var lstfacturas = new List<ComWeb_Ws_Bitacora_Pse>();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var bitacora = new ComWeb_Ws_Bitacora_Pse();
                        bitacora.ticket_id = SqlReaderUtilities.SafeGet<string>(reader, "TICKET_ID");
                        bitacora.estado_consumows = SqlReaderUtilities.SafeGet<string>(reader, "ESTADO_CONSUMOWS");
                        bitacora.estado_transaccion = SqlReaderUtilities.SafeGet<string>(reader, "ESTADO_TRANSACCION");
                        bitacora.desc_referencia = SqlReaderUtilities.SafeGet<string>(reader, "DESC_REFERENCIA");
                        bitacora.origen = SqlReaderUtilities.SafeGet<string>(reader, "ORIGEN");
                        bitacora.cod_confirmaccion = SqlReaderUtilities.SafeGet<string>(reader, "COD_CONFIRMACION");
                        bitacora.valor_pago = SqlReaderUtilities.SafeGet<decimal>(reader, "VALOR_PAGO").ToString();
                        lstfacturas.Add(bitacora);
                    }
                    return lstfacturas;
                }
                catch (DbException ex)
                {
                    throw new Exception("PagoFacturasProvider :: ConsultarBitacoraEntidadAsync", ex);
                }
            }

        }

        public async Task<List<int>> ConsultarPasarelaAsignadaAsync()
        {
            using (var conn = await ConectionFactory.DefaultConnectionAsync())
            {
                try
                {

                    string sentence = "SELECT COD_PASARELA FROM COM_PASARELAS WHERE ACTIVO = 1";
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = sentence;
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    if (this.transaction != null)
                    {
                        command.Transaction = this.transaction;
                    }
                    List<int> codPasarelas = new List<int>();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        codPasarelas.Add((int)SqlReaderUtilities.SafeGet<decimal>(reader, "COD_PASARELA"));
                    }
                    return codPasarelas;
                }
                catch (Exception ex)
                {
                    throw new Exception("PagoFacturasProvider :: ConsultarPasarelaAsignadaAsync", ex);
                }
            }

        }
        public async Task<string> ConsultarReporteAsignadoAsync(string codFactura)
        {
            using (var conn = await ConectionFactory.DefaultConnectionAsync())
            {
                try
                {

                    string sentence = "SELECT FORMATO_REPORTE FROM mfactura A, tipo_factura b WHERE  a.cod_tipo= b.cod_tipo and a.COD_FACTURA = '" + codFactura + "'";
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = sentence;
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    if (this.transaction != null)
                    {
                        command.Transaction = this.transaction;
                    }
                    string nombreReporte = "";
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        nombreReporte = SqlReaderUtilities.SafeGet<string>(reader, "FORMATO_REPORTE");
                    }
                    return nombreReporte;
                }
                catch (Exception ex)
                {
                    throw new Exception("PagoFacturasProvider :: ConsultarPasarelaAsignadaAsync", ex);
                }
            }

        }

        public bool validarDataTable(DataTable dt)
        {
            var control = false;
            if (dt != null)
            {
                if (dt.Rows.Count >= 1)
                {
                    control = true;
                }
            }
            return control;
        }
        public DataTable ProcesaDetallePago(string respago)
        {
            var sep = new char[2];
            string[] arreglo1;
            string[] arreglo2;

            var cadena = "";
            var DtDatosPago = new DataTable();
            var j = 0;

            sep[0] = ';';
            sep[1] = '|';

            DtDatosPago.Columns.Add("NPAGO");
            DtDatosPago.Columns.Add("ESTADOPAGO");
            DtDatosPago.Columns.Add("VALORPAGADO");
            DtDatosPago.Columns.Add("VALORIVA");
            DtDatosPago.Columns.Add("DESCRIPCION");
            DtDatosPago.Columns.Add("IDCLIENTE");
            DtDatosPago.Columns.Add("NOMBRE");
            DtDatosPago.Columns.Add("APELLIDO");
            DtDatosPago.Columns.Add("TELEFONO");
            DtDatosPago.Columns.Add("EMAIL");
            DtDatosPago.Columns.Add("CAMPO1");
            DtDatosPago.Columns.Add("CAMPO2");
            DtDatosPago.Columns.Add("CAMPO3");
            DtDatosPago.Columns.Add("FECHA");
            DtDatosPago.Columns.Add("FORMAPAGO");
            DtDatosPago.Columns.Add("TICKETID");
            DtDatosPago.Columns.Add("CODSERVICIO");
            DtDatosPago.Columns.Add("CODBANCO");
            DtDatosPago.Columns.Add("NOMBREBANCO");
            DtDatosPago.Columns.Add("CODIGOTRANSACCION");
            DtDatosPago.Columns.Add("CICLOTRANSACCION");

            arreglo1 = respago.Split(sep[0]); // separo por (;) la cadena resultado, obteniendo un array de los pagos recibidos

            //for i : Int32 := 0 to length(arreglo1)-1 do 
            //begin

            if (arreglo1.Length == 2)
            {


                j = arreglo1.Length - 2;

                cadena = arreglo1[j]; // obtengo el pago en la posicion j

                arreglo2 = cadena.Split(sep[1]);// separo por (|) el pago, obteniendo un array de los detalles del pago

                if (arreglo2.Length == 22)
                { // Si el tamaño de los detalles obtenidos es 22 el pago se realizo por PSE

                    DtDatosPago.Rows.Add(arreglo2[0].Trim(), arreglo2[1].Trim(), arreglo2[2].Trim(), arreglo2[3].Trim(), arreglo2[4].Trim(), arreglo2[5].Trim(), arreglo2[6].Trim(), arreglo2[7].Trim(), arreglo2[8].Trim(), arreglo2[9].Trim(), arreglo2[10].Trim(), arreglo2[11].Trim(), arreglo2[12].Trim(), arreglo2[13].Trim(), arreglo2[14].Trim(), arreglo2[15].Trim(), arreglo2[16].Trim(), arreglo2[17].Trim(), arreglo2[18].Trim(), arreglo2[19].Trim(), arreglo2[20].Trim());
                }

                if (arreglo2.Length == 21)
                { // Si el tamaño de los detalles obtenidos es 21 el pago se realizo por Tarjeta de credito

                    DtDatosPago.Rows.Add(arreglo2[0].Trim(), arreglo2[1].Trim(), arreglo2[2].Trim(), arreglo2[3].Trim(), arreglo2[4].Trim(), arreglo2[5].Trim(), arreglo2[6].Trim(), arreglo2[7].Trim(), arreglo2[8].Trim(), arreglo2[9].Trim(), arreglo2[10].Trim(), arreglo2[11].Trim(), arreglo2[12].Trim(), arreglo2[13].Trim(), arreglo2[14].Trim(), arreglo2[15].Trim(), arreglo2[16].Trim(), arreglo2[17].Trim(), arreglo2[18].Trim(), arreglo2[19].Trim(), " ");
                }
            }

            if (arreglo1.Length > 2)
            {
                j = (arreglo1.Length) - 2;

                cadena = arreglo1[j]; // obtengo el pago en la posicion j

                arreglo2 = cadena.Split(sep[1]);// separo por (|) el pago, obteniendo un array de los detalles del pago

                if (arreglo2.Length == 23)
                { // Si el tamaño de los detalles obtenidos es 22 el pago se realizo por PSE

                    DtDatosPago.Rows.Add(arreglo2[1].Trim(), arreglo2[2].Trim(), arreglo2[3].Trim(), arreglo2[4].Trim(), arreglo2[5].Trim(), arreglo2[6].Trim(), arreglo2[7].Trim(), arreglo2[8].Trim(), arreglo2[9].Trim(), arreglo2[10].Trim(), arreglo2[11].Trim(), arreglo2[12].Trim(), arreglo2[13].Trim(), arreglo2[14].Trim(), arreglo2[15].Trim(), arreglo2[16].Trim(), arreglo2[17].Trim(), arreglo2[18].Trim(), arreglo2[19].Trim(), arreglo2[20].Trim(), arreglo2[21].Trim());
                }

                if (arreglo2.Length == 22)
                { // Si el tamaño de los detalles obtenidos es 21 el pago se realizo por Tarjeta de credito

                    DtDatosPago.Rows.Add(arreglo2[1].Trim(), arreglo2[2].Trim(), arreglo2[3].Trim(), arreglo2[4].Trim(), arreglo2[5].Trim(), arreglo2[6].Trim(), arreglo2[7].Trim(), arreglo2[8].Trim(), arreglo2[9].Trim(), arreglo2[10].Trim(), arreglo2[11].Trim(), arreglo2[12].Trim(), arreglo2[13].Trim(), arreglo2[14].Trim(), arreglo2[15].Trim(), arreglo2[16].Trim(), arreglo2[17].Trim(), arreglo2[18].Trim(), arreglo2[19].Trim(), arreglo2[20].Trim(), " ");
                }
            }

            //end;

            return DtDatosPago;
        }

        public void EscribirLog(string mensaje)
        {
            var oPath = "";
            //string path = @"e:\PCTLogSonda.txt";
            string path = @"c:\PCTG\Logs\PCTLogSonda.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Creacion de archivo a fecha de : " + DateTime.Now.ToString());

                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(DateTime.Now.ToString() + mensaje);

            }

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
        public async Task<string> ValidarParametrizacion(string sentence)
        {
            using (var conn = await ConectionFactory.DefaultConnectionAsync())
            {
                try
                {
                    DbCommand command = conn.CreateCommand();
                    command.CommandText = sentence;
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    if (this.transaction != null)
                    {
                        command.Transaction = this.transaction;
                    }


                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var mensaje = SqlReaderUtilities.SafeGet<string>(reader, "NOM_SECCION");
                        return mensaje;
                    }
                    return "";
                }
                catch (DbException ex)
                {
                    throw new Exception("LoginProvider :: ConsultarNombreEntidad", ex);
                }
            }

        }

    }
}