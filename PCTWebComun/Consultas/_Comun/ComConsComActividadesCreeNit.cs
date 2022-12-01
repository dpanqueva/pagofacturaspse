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
    public class ComConsComActividadesCreeNit
    {
        public string Mensaje;
        public DataTable ConsConsultarActividadesCreeNit(ConexionBD oConexcion, ComComActividadesCreeNit EntidadComActividadesCreeNit)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            if (!string.IsNullOrEmpty(EntidadComActividadesCreeNit.NIT))
            {
                consulta = "SELECT A.VIGENCIA, A.COD_ACTIVIDAD, A.NIT, A.ACT_PRINCIPAL, B.NOM_ACTIVIDAD, A.ID_COM_ENTIDAD ";
                consulta += " FROM COM_ACTIVIDADES_CREE_NIT A, COM_ACTIVIDADES_CREE B, NIT C ";
                consulta += " WHERE A.VIGENCIA=B.VIGENCIA ";
                consulta += " AND A.COD_ACTIVIDAD=B.COD_ACTIVIDAD ";
                consulta += " AND A.NIT=C.NIT ";
                consulta += " AND A.ID_COM_ENTIDAD = B.ID_COM_ENTIDAD ";
                consulta += " AND A.ID_COM_ENTIDAD = C.ID_COM_ENTIDAD ";
                consulta += " AND B.ID_COM_ENTIDAD = C.ID_COM_ENTIDAD ";
                consulta += " AND A.NIT = '" + EntidadComActividadesCreeNit.NIT + "' ";

                if (!string.IsNullOrEmpty(EntidadComActividadesCreeNit.ACT_PRINCIPAL))
                {
                    consulta += " AND ACT_PRINCIPAL = '" + EntidadComActividadesCreeNit.ACT_PRINCIPAL + "' ";
                }

                consulta += " ORDER BY VIGENCIA, COD_ACTIVIDAD";
                             

                dtResultado = oConexcion.Consulta(consulta);
            }

            Mensaje = oConexcion.Mensaje;

            return dtResultado;
        }

        public bool ConsInsertarVariosActividadesCreeNit(ConexionBD oconexion, ComComActividadesCreeNit EntidadComActividadesCreeNit, List<ComComActividadesCreeNit> ItemsNuevos)
        {

            bool valido;
            string sentencia = "INSERT INTO COM_ACTIVIDADES_CREE_NIT(COD_ACTIVIDAD, NIT, VIGENCIA, ACT_PRINCIPAL) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComComActividadesCreeNit itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.COD_ACTIVIDAD) ? "'" + itemNuevo.COD_ACTIVIDAD + "'" : "null") + ",'"
                            + EntidadComActividadesCreeNit.NIT + "','"
                            + (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? "" + itemNuevo.VIGENCIA + "'" : "null") + ",'"
                            + itemNuevo.ACT_PRINCIPAL + "'";

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
        public bool ConsActualizarVariosActividadesCreeNit(ConexionBD oconexion, ComComActividadesCreeNit EntidadComActividadesCreeNit, List<ComComActividadesCreeNit> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE COM_ACTIVIDADES_CREE_NIT SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComComActividadesCreeNit itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.VIGENCIA))
                            actualizaciones.Add("VIGENCIA ='" + itemNuevo.VIGENCIA + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_ACTIVIDAD))
                            actualizaciones.Add("COD_ACTIVIDAD ='" + itemNuevo.COD_ACTIVIDAD + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.NIT))
                            actualizaciones.Add("NIT ='" + itemNuevo.NIT + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.ACT_PRINCIPAL))
                            actualizaciones.Add("ACT_PRINCIPAL ='" + itemNuevo.ACT_PRINCIPAL + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.ID_COM_ENTIDAD))
                            actualizaciones.Add("ID_COM_ENTIDAD ='" + itemNuevo.ID_COM_ENTIDAD + "'");


                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE VIGENCIA = '" + itemNuevo.VIGENCIA + "'";
                            nuevaSentencia += " AND NIT = '" + itemNuevo.NIT + "'";
                            nuevaSentencia += " AND COD_ACTIVIDAD = '" + itemNuevo.COD_ACTIVIDAD + "'";
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

        public bool ConsEliminarVariosActividadesCreeNit(ConexionBD oconexion, ComComActividadesCreeNit EntidadComActividadesCreeNit, List<ComComActividadesCreeNit> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = " delete from COM_ACTIVIDADES_CREE_NIT where VIGENCIA= '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComComActividadesCreeNit itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) && !string.IsNullOrEmpty(itemNuevo.COD_ACTIVIDAD))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.VIGENCIA);
                            nuevaSentencia += " AND NIT = '" + itemNuevo.NIT + "'";
                            nuevaSentencia += " AND COD_ACTIVIDAD = '" + itemNuevo.COD_ACTIVIDAD + "'";
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
