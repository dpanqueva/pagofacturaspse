//PCT.NET_NVO_0000_20190531 - Fecha Inicio 21/05/2019 - Ticket Nº 35358 - Caso: Se Crea Metodo para Consultar Centro Costos -> ConsConsultarCentroCostos - Participantes: Oscar Ramos 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsCentroCostos
    {
        private string Mensaje;
         
        //Método que realiza la consulta en la tabla CENTRO_COSTOS.
        public DataTable ConsConsultarCentroCostos(ConexionBD oconexion,  ComCentroCostos entidadCentroCostos)
        {
            string sentencia="SELECT * FROM CENTRO_COSTOS";
            DataTable dtsConsulta;

            sentencia += " WHERE 1 = 1 ";

            if ((!string.IsNullOrEmpty(entidadCentroCostos.COD_CENTRO)) && (!string.IsNullOrEmpty(entidadCentroCostos.NOM_CENTRO)))
            {
                sentencia = sentencia + " AND UPPER(COD_CENTRO) LIKE '%" + entidadCentroCostos.COD_CENTRO + "%' OR UPPER(NOM_CENTRO) LIKE UPPER('%" + entidadCentroCostos.NOM_CENTRO + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadCentroCostos.COD_CENTRO))
                {
                    sentencia = sentencia + " AND UPPER(COD_CENTRO) LIKE UPPER('" + entidadCentroCostos.COD_CENTRO + "')";
                }

                if (!string.IsNullOrEmpty(entidadCentroCostos.NOM_CENTRO))
                {
                    sentencia = sentencia +" AND UPPER(NOM_CENTRO) LIKE UPPER('%" + entidadCentroCostos.NOM_CENTRO + "%')";
                }
            }         

            sentencia = sentencia + " ORDER BY COD_CENTRO";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        internal bool InertarVariosCentroCostos(ConexionBD oconexion, List<ComCentroCostos> itemsNuevos, ComCtrlEntidad entidadCtrlEntidad)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarVariosCentroCostos(ConexionBD oconexion, List<ComCentroCostos> ItemsActualizados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE CENTRO_COSTOS SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComCentroCostos itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_CENTRO))
                            actualizaciones.Add("NOM_CENTRO = '" + itemNuevo.NOM_CENTRO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_CENTRO = '" + itemNuevo.COD_CENTRO + "'";
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

        public bool EliminarVariosCentroCostos(ConexionBD oconexion, List<ComCentroCostos> ItemEliminados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM CENTRO_COSTOS WHERE COD_CENTRO = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComCentroCostos itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_CENTRO))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_CENTRO);
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

