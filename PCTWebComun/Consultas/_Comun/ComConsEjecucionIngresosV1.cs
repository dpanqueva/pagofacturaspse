using System;
using PCTWebComun._ConexionesBD;
using System.Data;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsEjecucionIngresosV1
    {
        private string Mensaje;
        public DataTable ConsConsultarEjecucionIngresosV1(ConexionBD oconexion, ComEjecucionIngresosV1 entidadEjecucionIngresosV1)
        {
            string sentencia = "SELECT * FROM EJECUCION_INGRESOS_V1";

            DataTable dtsConsulta = new DataTable();

            var condicion = " WHERE 1 = 1";

            if (!string.IsNullOrEmpty(entidadEjecucionIngresosV1.COD_UNIDAD))
            {
                condicion += " AND COD_UNIDAD LIKE ('" + entidadEjecucionIngresosV1.COD_UNIDAD + "')";
            }

            if (!string.IsNullOrEmpty(entidadEjecucionIngresosV1.COD_RECURSO))
            {
                condicion += " AND COD_RECURSO LIKE ('%" + entidadEjecucionIngresosV1.COD_RECURSO + "%')";
            }

            if (!string.IsNullOrEmpty(entidadEjecucionIngresosV1.COD_INGRESO))
            {
                condicion += " AND COD_INGRESO LIKE ('" + entidadEjecucionIngresosV1.COD_INGRESO + "')";
            }

            if (!string.IsNullOrEmpty(entidadEjecucionIngresosV1.NOM_INGRESO))
            {
                condicion += " AND UPPER(NOM_INGRESO) LIKE UPPER('%" + entidadEjecucionIngresosV1.NOM_INGRESO + "%')";
                
            }

            condicion += "ORDER BY VIGENCIA,COD_UNIDAD,COD_INGRESO,COD_RECURSO"; 
            sentencia += condicion;

            dtsConsulta = oconexion.Consulta(sentencia);
            dtsConsulta.TableName = "Xls Ejecución Ingresos";
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
