using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsComNitIngresos
    {
        public string Mensaje;
        public DataTable ConsConsultarNitIngresos(ConexionBD oConexion, ComComNitIngresos EntidadComNitIngresos)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            if (!string.IsNullOrEmpty(EntidadComNitIngresos.CONSOLIDADO))
            {
                consulta = "SELECT  A.ID_COM_ENTIDAD, A.VIGENCIA, A.NIT, SUM(A.VALOR_INGRESOS)VALOR_INGRESOS, SUM(A.VALOR_APORTES_SALUD)VALOR_APORTES_SALUD, SUM(A.VALOR_APORTES_PENSION)VALOR_APORTES_PENSION,SUM(A.OTROS_APORTES)OTROS_APORTES, MIN(B.NOMBRE) NOMBRE "+
                    "FROM COM_NIT_INGRESOS A, NIT B";
            } else
            {
                consulta = "SELECT A.*, B.NOMBRE FROM COM_NIT_INGRESOS A, NIT B ";                    
            }

            consulta += " WHERE A.NIT = B.NIT";

            if (!string.IsNullOrEmpty(EntidadComNitIngresos.NIT))
            {
                consulta += " AND A.NIT = '" + EntidadComNitIngresos.NIT + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadComNitIngresos.CONSOLIDADO))
            {
                consulta += " GROUP BY A.ID_COM_ENTIDAD, A.VIGENCIA, A.NIT "+
                    "ORDER BY A.ID_COM_ENTIDAD, A.VIGENCIA, A.NIT ";
            }
            else
            {
                consulta += " ORDER BY A.VIGENCIA, A.NIT, A.MES ";
            }


            dtResultado = oConexion.Consulta(consulta);
            dtResultado.TableName = "Xls Nit Ingresos";
            Mensaje = oConexion.Mensaje;

            return dtResultado;
        }

        public bool ConsInsertarVariosNitIngresos(ConexionBD oconexion, ComComNitIngresos EntidadComNitIngresos, List<ComComNitIngresos> ItemsNuevos)
        {

            bool valido;
            string sentencia = "INSERT INTO COM_NIT_INGRESOS(VIGENCIA, NIT, MES, VALOR_INGRESOS, VALOR_APORTES_SALUD,VALOR_APORTES_PENSION) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComComNitIngresos itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? "'" + itemNuevo.VIGENCIA + "'" : "null") + ",'"
                            + EntidadComNitIngresos.NIT + "','"
                            + (!string.IsNullOrEmpty(itemNuevo.MES) ? "" + itemNuevo.MES + "'" : "null") + ",'"
                            + itemNuevo.VALOR_INGRESOS + "','"
                            + itemNuevo.VALOR_APORTES_SALUD + "','"
                            + itemNuevo.VALOR_APORTES_PENSION + "'";

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
        public bool ConsActualizarVariosNitIngresos(ConexionBD oconexion, ComComNitIngresos EntidadComNitIngresos, List<ComComNitIngresos> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE COM_NIT_INGRESOS SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComComNitIngresos itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.VIGENCIA))
                            actualizaciones.Add("VIGENCIA ='" + itemNuevo.VIGENCIA + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.MES))
                            actualizaciones.Add("MES ='" + itemNuevo.MES + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.VALOR_INGRESOS))
                            actualizaciones.Add("VALOR_INGRESOS ='" + itemNuevo.VALOR_INGRESOS + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.VALOR_APORTES_SALUD))
                            actualizaciones.Add("VALOR_APORTES_SALUD ='" + itemNuevo.VALOR_APORTES_SALUD + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.MES))
                            actualizaciones.Add("VALOR_APORTES_PENSION ='" + itemNuevo.VALOR_APORTES_PENSION + "'");


                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE VIGENCIA = '" + itemNuevo.VIGENCIA + "'";
                            nuevaSentencia += " AND NIT = '" + itemNuevo.NIT + "'";
                            nuevaSentencia += " AND MES = '" + itemNuevo.MES + "'";
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

        public bool ConsEliminarVariosNitIngresos(ConexionBD oconexion, ComComNitIngresos EntidadComNitIngresos, List<ComComNitIngresos> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = " delete from COM_NIT_INGRESOS where VIGENCIA= '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComComNitIngresos itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) && !string.IsNullOrEmpty(itemNuevo.MES))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.VIGENCIA);
                            nuevaSentencia += " AND NIT = '" + itemNuevo.NIT + "'";
                            nuevaSentencia += " AND MES = '" + itemNuevo.MES + "'";
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
