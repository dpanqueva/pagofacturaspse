using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using PCTWebFactura.Models;
using PCTWebComun.Entidades.COM;
using System.Web;
using PCTWebFactura.Configuration;
using PCTWebComun.Controlador.COM;

namespace PCTWebFactura.Classes
{
    public class LoginProvider
    {

        private DbTransaction transaction;
        public string message;
        public async Task<bool> EjectSentenceSQLAsync(string sentence)
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
                    await command.ExecuteScalarAsync();
                    return true;
                }
                catch (DbException ex)
                {
                    throw new Exception("LoginProvider :: EjectSentenceSQLAsync", ex);
                }
            }

        }
        public async Task<Entidad> ConsultarNombreEntidadAsync(string sentence)
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

                    var entidad = new Entidad();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        entidad.entidad = SqlReaderUtilities.SafeGet<string>(reader, "NOM_SECCION");
                        entidad.vigencia = SqlReaderUtilities.SafeGet<decimal>(reader, "VIGENCIA_ACTUAL");
                    }
                    return entidad;
                }
                catch (DbException ex)
                {
                    throw new Exception("LoginProvider :: ConsultarNombreEntidad", ex);
                }
            }

        }
        public async Task<bool> ConsultarNitAsync(string sentence, ComNit entidad)
        {
            var isSuccess = false;
            try
            {
                
                using (var conn = await ConectionFactory.DefaultConnectionAsync())
                {

                    if (conn.State == 0)
                    {
                        this.message = "Error de Conexión";
                    }
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
                        //if (VerificarPermiso("2000"))
                        if (true)
                        {
                            HttpContext context = HttpContext.Current;
                            System.Web.HttpContext.Current.Session["_NomApp_"] = "Loglb";
                            System.Web.HttpContext.Current.Session["AU"] = "AU";
                            var temp = (string)(context.Session["_ENTIDAD_"]);
                            System.Web.HttpContext.Current.Session["NIT"] = entidad.nit;
                            System.Web.HttpContext.Current.Session["NOMBRE"] = SqlReaderUtilities.SafeGet<string>(reader, "NOMBRE");
                            if (!string.IsNullOrEmpty(SqlReaderUtilities.SafeGet<string>(reader, "PRIMER_NOMBRE")))
                            {

                                
                                System.Web.HttpContext.Current.Session["NOMBRE_CLIENTE"] = SqlReaderUtilities.SafeGet<string>(reader, "PRIMER_NOMBRE");
                                System.Web.HttpContext.Current.Session["APELLIDO_CLIENTE"] = SqlReaderUtilities.SafeGet<string>(reader, "PRIMER_APELLIDO");

                            }
                            System.Web.HttpContext.Current.Session["TIPOD"] = SqlReaderUtilities.SafeGet<string>(reader, "TIPO_DOCUMENTO");
                            this.message = "OK";
                        }
                        else
                        {
                            this.message = "Usuario no cuenta con permisos";
                            System.Web.HttpContext.Current.Session["AU"] = "UA";

                        }

                        isSuccess = true;
                        return isSuccess;
                    }
                    this.message = "Usuario no existe, por favor verifique el usuario y contraseña";
                    return isSuccess;

                }

            }
            catch (Exception ex)
            {
                this.message = ex.Message;
                //throw new Exception("LoginProvider :: ConsultarNombreEntidad", ex);
                return isSuccess;
            }


        }
        public bool VerificarPermiso(string accion)
        {
            var tienePermiso = false;
            var login = new ComClaseLogin();
            HttpContext context = HttpContext.Current;
            if (!string.IsNullOrEmpty((string)(context.Session["_USUARIO_"])))
            {
                login.usuario = (string)(context.Session["_USUARIO_"]);
                login.cod_accion = accion;
                var controlador = new ComCtrlClaseLogin();
                tienePermiso = controlador.ctrVerificarAccion(login);
            }

            return tienePermiso;

        }
    }
}