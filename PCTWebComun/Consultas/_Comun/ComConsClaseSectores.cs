//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz*@

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
    public class ComConsClaseSectores
    {
       private string lmensaje;

       //Función que permite consultar datos de la tabla COM_CLASE_SECTORES
        public DataTable ConsConsultarClaseSectores(ConexionBD oconexion, ComClaseSectores entidadClaseSectores)
        {
            string sentencia="SELECT COD_SECTOR, NOM_SECTOR, VIGENCIA FROM COM_CLASE_SECTORES";
            DataTable dtsConsulta = new DataTable();

            sentencia += " WHERE 1 = 1 ";            

            if ((!string.IsNullOrEmpty(entidadClaseSectores.COD_SECTOR)) && (!string.IsNullOrEmpty(entidadClaseSectores.NOM_SECTOR)))
            {
                sentencia = sentencia + " AND UPPER(COD_SECTOR) LIKE UPPER('" + entidadClaseSectores.COD_SECTOR + "') OR UPPER(NOM_SECTOR) LIKE UPPER('%" + entidadClaseSectores.NOM_SECTOR + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadClaseSectores.COD_SECTOR))
                {
                    sentencia = sentencia + " AND UPPER(COD_SECTOR) LIKE UPPER('" + entidadClaseSectores.COD_SECTOR + "')";
                }

                if (!string.IsNullOrEmpty(entidadClaseSectores.NOM_SECTOR))
                {
                    sentencia = sentencia + " AND UPPER(NOM_SECTOR) LIKE UPPER('%" + entidadClaseSectores.NOM_SECTOR + "%')";
                }
            }

            //PCT.NET_NVO_0000_20190423 - Fecha Inicio 30/10/2019 - Ticket Nº 37123 - Caso: Se añade el campo vigencia para filtro en creación de Clase Sectores - Participantes: Maribel Pedroza
            if (!string.IsNullOrEmpty(entidadClaseSectores.VIGENCIA))
            {
                sentencia = sentencia + " AND VIGENCIA = '" + entidadClaseSectores.VIGENCIA+ "' ";
            }

            sentencia = sentencia + " ORDER BY COD_SECTOR "; 

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        //Insertar, Modificar, Eliminar COM_CLASE_SECTORES Creado por: Maribel Pedroza
        public bool ConsInsertarVariosComClaseSectores(ConexionBD oconexion, ComClaseSectores EntidadComClaseSectores, List<ComClaseSectores> ItemsNuevos)
        {
            bool valido;
            string sentencia = "INSERT INTO COM_CLASE_SECTORES(VIGENCIA, COD_SECTOR, NOM_SECTOR) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComClaseSectores itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(EntidadComClaseSectores.VIGENCIA) ? "'" + EntidadComClaseSectores.VIGENCIA + "'" : "null") + ",'"
                            + (!string.IsNullOrEmpty(itemNuevo.COD_SECTOR) ? "" + itemNuevo.COD_SECTOR + "'" : "null") + ",'"
                            + itemNuevo.NOM_SECTOR + "'";

                        string nuevasentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevasentencia);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }
        public bool ConsActualizarVariosComClaseSectores(ConexionBD oconexion, ComClaseSectores EntidadComClaseSectores, List<ComClaseSectores> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE COM_CLASE_SECTORES SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComClaseSectores itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(EntidadComClaseSectores.VIGENCIA))
                            actualizaciones.Add("VIGENCIA =" + EntidadComClaseSectores.VIGENCIA + "");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_SECTOR))
                            actualizaciones.Add("COD_SECTOR ='" + itemNuevo.COD_SECTOR + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_SECTOR))
                            actualizaciones.Add("NOM_SECTOR ='" + itemNuevo.NOM_SECTOR + "'");
                        
                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE VIGENCIA = " + EntidadComClaseSectores.VIGENCIA + "";
                            nuevaSentencia += " AND COD_SECTOR = '" + itemNuevo.COD_SECTOR + "'";
                            nuevaSentencia += " AND NOM_SECTOR = '" + itemNuevo.NOM_SECTOR + "'";
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;

            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        public bool ConsEliminarVariosComClaseSectores(ConexionBD oconexion, ComClaseSectores EntidadComClaseSectores, List<ComClaseSectores> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = " DELETE FROM COM_CLASE_SECTORES where VIGENCIA= '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComClaseSectores itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(EntidadComClaseSectores.VIGENCIA) && !string.IsNullOrEmpty(itemNuevo.COD_SECTOR))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", EntidadComClaseSectores.VIGENCIA);
                            nuevaSentencia += " AND COD_SECTOR = '" + itemNuevo.COD_SECTOR + "'";
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }
            return valido;
        }

    }
}