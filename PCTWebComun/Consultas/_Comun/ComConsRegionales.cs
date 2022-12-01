//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade la consulta- Participantes: Maribel Pedroza

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsRegionales
    {

        public string Mensaje;
        
        public DataTable ConsConsultarRegionales(ComRegionales EntidadRegionales, ConexionBD oConexion)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT * FROM REGIONES WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadRegionales.COD_REGION) && !string.IsNullOrEmpty(EntidadRegionales.NOM_REGION))
            {
                sentencia += " AND COD_REGION LIKE '%" + EntidadRegionales.COD_REGION + "%' OR UPPER(NOM_REGION) LIKE UPPER('%" + EntidadRegionales.NOM_REGION.ToUpper() + "%')";

            } else {
                if (!string.IsNullOrEmpty(EntidadRegionales.COD_REGION))
                {
                    sentencia = sentencia + "  AND UPPER(COD_REGION) LIKE UPPER('" + EntidadRegionales.COD_REGION + "')";
                }

                if (!string.IsNullOrEmpty(EntidadRegionales.NOM_REGION))
                {
                    sentencia = sentencia + " AND UPPER(NOM_REGION) LIKE UPPER('%" + EntidadRegionales.NOM_REGION + "%')";
                }
            }

            sentencia = sentencia + " ORDER BY COD_REGION ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }



        public bool InertarVariosRegionales(ConexionBD oconexion, List<ComRegionales> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentencia = "INSERT INTO REGIONES(COD_PADRE,COD_REGION,NOM_REGION,NIVEL,NRO_NIVEL,CORPES) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComRegionales itemNuevo in ItemsNuevos)
                    {
                        itemNuevo.CORPES = "0".ToString();
                        string valores = (!string.IsNullOrEmpty(itemNuevo.COD_PADRE) ? "'" + itemNuevo.COD_PADRE + "'" : "null") + ",'"+ 
                            itemNuevo.COD_REGION + "','"+
                            itemNuevo.NOM_REGION + "','"+ 
                            itemNuevo.NIVEL + "',"+ 
                            itemNuevo.NRO_NIVEL + ",'"+ 
                            itemNuevo.CORPES + "'";
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

        public bool ActualizarVariosRegionales(ConexionBD oconexion, List<ComRegionales> ItemsActualizados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE REGIONES SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComRegionales itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_REGION))
                        {
                            actualizaciones.Add("NOM_REGION = '" + itemNuevo.NOM_REGION + "'");
                        }

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                        {
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");
                        }

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_REGION = '" + itemNuevo.COD_REGION + "'";
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


        public bool EliminarVariosRegionales(ConexionBD oconexion, List<ComRegionales> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM REGIONES WHERE COD_REGION = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComRegionales itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_REGION))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_REGION);
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