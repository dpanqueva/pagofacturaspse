using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsControlCierres
    {
        public string Mensaje;
        public DataTable ConsConsultarControlCierres(ConexionBD oConexion , ComControlCierres EntidadControlCierres)
        {
            string sentencia = "SELECT * FROM CONTROL_CIERRES WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadControlCierres.MES))
            {
                sentencia += " AND MES='"+EntidadControlCierres.MES+"'";
            }

            sentencia += " ORDER BY MES";

            DataTable dtsConsulta = new DataTable();
            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }


        //Función que Inserta varios datos de la tabla ControlCierres
        public bool InsertarVariosControlCierres(ConexionBD oconexion, List<ComControlCierres> ItemsNuevos)
        {

            bool valido;
            string sentencia = "INSERT INTO CONTROL_CIERRES(MES, CERRADO, CAMBIO, PAAG, PUBLICAR_CGN01, PUBLICAR_CGN02) VALUES({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComControlCierres itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.MES) ? "'" + itemNuevo.MES + "'" : "null") + ",'"
                            + itemNuevo.CERRADO + "','"
                            + itemNuevo.CAMBIO + "','"
                            + itemNuevo.PAAG + "','"
                            + itemNuevo.PUBLICAR_CGN01 + "','"
                            + itemNuevo.PUBLICAR_CGN02 + "'";

                        string nuevasentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevasentencia);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }

                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        //Función que Actualiza varios datos de la tabla CONTROL_CIERRES
        public bool ActualizarVariosControlCierres(ConexionBD oconexion, List<ComControlCierres> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE CONTROL_CIERRES SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComControlCierres itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.MES))
                            actualizaciones.Add("MES =" + itemNuevo.MES);

                        if (!string.IsNullOrEmpty(itemNuevo.CERRADO))
                            actualizaciones.Add("CERRADO ='" + itemNuevo.CERRADO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.CAMBIO))
                            actualizaciones.Add("CAMBIO ='" + itemNuevo.CAMBIO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.PAAG))
                            actualizaciones.Add("PAAG ='" + itemNuevo.PAAG + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.PUBLICAR_CGN01))
                            actualizaciones.Add("PUBLICAR_CGN01 ='" + itemNuevo.PUBLICAR_CGN01 + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.PUBLICAR_CGN02))
                            actualizaciones.Add("PUBLICAR_CGN02 ='" + itemNuevo.PUBLICAR_CGN02+"'");


                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE MES =" + itemNuevo.MES;
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        //Función que Elimina varios datos de la tabla CONTROL_CIERRES
        public bool EliminarVariosControlCierres(ConexionBD oconexion, List<ComControlCierres> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM CONTROL_CIERRES WHERE MES = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComControlCierres itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.MES))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.MES);
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }
    }
}
