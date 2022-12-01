// PCT.NET_NVO_0000_20190531 - Fecha Inicio 21/05 / 2019 - Ticket Nº 35554 - Caso: Implementación página de consulta y creación de actividades cree - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using PCTWebComun._ConexionesBD;
using System.Data;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsComActividadesCree
    {
        private string Mensaje;

        //Función que permite consultar en la tabla COM_ACTIVIDADES_CREE
        public DataTable ConsConsultarActividadesCree(ConexionBD oconexion, ComActividadesCree entidadActividadesCree)
        {
            string sentencia = "SELECT VIGENCIA, COD_ACTIVIDAD, NOM_ACTIVIDAD, TARIFA, APROX FROM COM_ACTIVIDADES_CREE";
            DataTable dtsConsulta = new DataTable();

            sentencia += " WHERE 1 = 1 ";

            if ((!string.IsNullOrEmpty(entidadActividadesCree.COD_ACTIVIDAD)) && (!string.IsNullOrEmpty(entidadActividadesCree.NOM_ACTIVIDAD)))
            {
                sentencia = sentencia + " AND UPPER(COD_ACTIVIDAD) LIKE UPPER('" + entidadActividadesCree.COD_ACTIVIDAD + "') OR UPPER(NOM_ACTIVIDAD) LIKE UPPER('%" + entidadActividadesCree.NOM_ACTIVIDAD + "%') ";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadActividadesCree.COD_ACTIVIDAD))
                {
                    sentencia = sentencia + " AND UPPER(COD_ACTIVIDAD) LIKE UPPER('" + entidadActividadesCree.COD_ACTIVIDAD + "')";
                }

                if (!string.IsNullOrEmpty(entidadActividadesCree.NOM_ACTIVIDAD))
                {
                    sentencia = sentencia +" AND UPPER(NOM_ACTIVIDAD) LIKE UPPER('%" + entidadActividadesCree.NOM_ACTIVIDAD + "%')";
                }
            }

            sentencia = sentencia + " ORDER BY COD_ACTIVIDAD"; 

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;    
            return dtsConsulta;
        }

        //Función que permite Insertar varios registros COM_ACTIVIDADES_CREE
        public bool InsertarVariosActividadesCree(ConexionBD oconexion, List<ComActividadesCree> ItemsNuevos)
        {
            bool valido;
            string sentencia = "INSERT INTO COM_ACTIVIDADES_CREE (COD_ACTIVIDAD,NOM_ACTIVIDAD,VIGENCIA,TARIFA,APROX) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComActividadesCree itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.COD_ACTIVIDAD) ? "'" + itemNuevo.COD_ACTIVIDAD + "'" : "null") + ",'"
                                        + itemNuevo.NOM_ACTIVIDAD + "',"
                                        + itemNuevo.VIGENCIA + ","
                                        + itemNuevo.TARIFA + ","
                                        + itemNuevo.APROX;

                        string nuevaSentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevaSentencia);
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

        //Función que permite Actualizar varios registros COM_ACTIVIDADES_CREE
        public bool ActualizarVariosActividadesCree(ConexionBD oconexion, List<ComActividadesCree> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE COM_ACTIVIDADES_CREE SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComActividadesCree itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_ACTIVIDAD))
                            actualizaciones.Add("NOM_ACTIVIDAD = '" + itemNuevo.NOM_ACTIVIDAD + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.VIGENCIA))
                            actualizaciones.Add("VIGENCIA = " + itemNuevo.VIGENCIA);

                        if (!string.IsNullOrEmpty(itemNuevo.TARIFA))
                            actualizaciones.Add("TARIFA = " + itemNuevo.TARIFA);

                        if (!string.IsNullOrEmpty(itemNuevo.APROX))
                            actualizaciones.Add("APROX = " + itemNuevo.APROX);

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_ACTIVIDAD = '" + itemNuevo.COD_ACTIVIDAD + "' AND VIGENCIA ='"+ itemNuevo.VIGENCIA +"'";                            
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

        //Función que permite Eliminar varios registros COM_ACTIVIDADES_CREE
        public bool EliminarVariosActividadesCree(ConexionBD oconexion, List<ComActividadesCree> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM COM_ACTIVIDADES_CREE WHERE COD_ACTIVIDAD = '{valuecodigo}' AND VIGENCIA ='{valuevigencia}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComActividadesCree itemNuevo in ItemEliminados)
                    {
                        string unoSentencia;
                        string NuevoSentencia;

                        if (!string.IsNullOrEmpty(itemNuevo.COD_ACTIVIDAD)&& (!string.IsNullOrEmpty(itemNuevo.VIGENCIA))) 
                        {
                            unoSentencia = sentenciaBase.Replace("{valuecodigo}", itemNuevo.COD_ACTIVIDAD);
                            NuevoSentencia = unoSentencia.Replace("{valuevigencia}", itemNuevo.VIGENCIA);                            
                            valido = oconexion.EjecutarSQL(NuevoSentencia);
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
