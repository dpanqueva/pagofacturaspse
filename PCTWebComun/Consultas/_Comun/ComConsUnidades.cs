//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade la consulta- Participantes: Maribel Pedroza

using System;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;
using System.Collections.Generic;
using System.Web;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsUnidades
    {
          public string Mensaje;
        public DataTable ConsConsultarUnidades(ConexionBD oConexion, ComUnidades entidadUnidades, string Vigencia)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT * FROM UNIDADES WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(Vigencia))
            {
                sentencia += " AND VIGENCIA=" + Vigencia;
            }

            if (!string.IsNullOrEmpty(entidadUnidades.VIGENCIA))
            {
                sentencia = sentencia + " AND  VIGENCIA=" + entidadUnidades.VIGENCIA;
            } else {
                sentencia = sentencia + " AND VIGENCIA=(SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD)";
            }

            if (!string.IsNullOrEmpty(entidadUnidades.COD_UNIDAD) && !string.IsNullOrEmpty(entidadUnidades.NOM_UNIDAD))
            {
                sentencia = sentencia + " AND COD_UNIDAD LIKE '%" + entidadUnidades.COD_UNIDAD + "%' OR UPPER(NOM_UNIDAD) LIKE '%" + entidadUnidades.NOM_UNIDAD.ToUpper() + "%'";

            }
            else
            {
                if (!string.IsNullOrEmpty(entidadUnidades.COD_UNIDAD))
                {
                    sentencia = sentencia + "  AND UPPER(COD_UNIDAD) LIKE UPPER('" + entidadUnidades.COD_UNIDAD + "')";
                }

                if (!string.IsNullOrEmpty(entidadUnidades.NOM_UNIDAD))
                {
                    sentencia = sentencia + " AND UPPER(NOM_UNIDAD) LIKE UPPER('%" + entidadUnidades.NOM_UNIDAD + "%')";
                }
            }

            sentencia = sentencia + " ORDER BY COD_UNIDAD ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }


        public bool InsertarVariosUnidades(ConexionBD oconexion, List<ComUnidades> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentencia = "INSERT INTO UNIDADES(COD_PADRE,COD_UNIDAD,NOM_UNIDAD,NIVEL,NRO_NIVEL,VIGENCIA) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComUnidades itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.COD_PADRE) ? "'" + itemNuevo.COD_PADRE + "'" : "null") + ",'"
                                        + itemNuevo.COD_UNIDAD + "','"
                                        + itemNuevo.NOM_UNIDAD + "','"
                                        + itemNuevo.NIVEL + "',"
                                        + itemNuevo.NRO_NIVEL + ",'"
                                        + (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? itemNuevo.VIGENCIA : EntidadCtrlEntidad.VIGENCIA_ACTUAL) + "'";

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

        public bool ActualizarVariosUnidades(ConexionBD oconexion, List<ComUnidades> ItemsActualizados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE UNIDADES SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComUnidades itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_UNIDAD))
                        {
                            actualizaciones.Add("NOM_UNIDAD = '" + itemNuevo.NOM_UNIDAD + "'");
                        }

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                        {
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");
                        }

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_UNIDAD = '" + itemNuevo.COD_UNIDAD + "'";
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

        public bool EliminarVariosUnidades(ConexionBD oconexion, List<ComUnidades> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM UNIDADES WHERE COD_UNIDAD = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComUnidades itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_UNIDAD))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_UNIDAD);
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