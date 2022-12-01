//PCT.NET_NVO_0000_20190521 - Fecha Inicio 15/07/2019 - Ticket Nº 35862 - Caso: Implementacion consulta de Recursos  - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsRecursos
    {
        private object Vigencia = HttpContext.Current.Session["Vigencia"];
        private string Mensaje;

        //Función de consulta de la tabla RECURSOS
        public DataTable ConsConsultarRecursos(ConexionBD oconexion, ComRecursos entidadRecursos)
        {
            string sentencia = "SELECT  VIGENCIA, COD_RECURSO, NOM_RECURSO, DECODE(REC_NACION, 'S', 'Si', 'N', 'No')NACION, " +
                "REC_NACION, DECODE(LIBRE_DEST, 'S', 'Si', 'N', 'No') DESTINACION, LIBRE_DEST, REGALIAS," +
                "ABREVIATURA,CON_SITUACION,DECODE(FIDUCIA, 'S', 'Si', 'N', 'No', 'P', 'No Aplica') NOM_FIDUCIA, FIDUCIA, " +
                "NRO_DOCUMENTO, B.NOM_CLS_RECURSO, B.ID_CLS_RECURSO " +
                "FROM RECURSOS A, APR_CLASE_RECURSOS B ";

            sentencia += " WHERE 1 = 1  AND A.ID_CLS_RECURSO = B.ID_CLS_RECURSO ";

            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(entidadRecursos.COD_RECURSO)) && (!string.IsNullOrEmpty(entidadRecursos.NOM_RECURSO)))
            {
                sentencia = sentencia + "  AND ( UPPER(COD_RECURSO) LIKE UPPER('%" + entidadRecursos.COD_RECURSO + "%') OR UPPER(NOM_RECURSO) LIKE UPPER('%" + entidadRecursos.NOM_RECURSO + "%') ) ";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadRecursos.COD_RECURSO))
                {
                    sentencia = sentencia + "  AND UPPER(COD_RECURSO) LIKE UPPER('" + entidadRecursos.COD_RECURSO + "')";
                }

                if (!string.IsNullOrEmpty(entidadRecursos.NOM_RECURSO))
                {
                    sentencia = sentencia + " AND UPPER(NOM_RECURSO) LIKE UPPER('%" + entidadRecursos.NOM_RECURSO + "%')";
                }
            }

            if (!string.IsNullOrEmpty(entidadRecursos.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + entidadRecursos.VIGENCIA;
            }

            sentencia = sentencia + " ORDER BY COD_RECURSO ";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable ConsConsRecursos(ConexionBD oconexion, ComRecursos EntidadRecursos)
        {
            DataTable dtsConsulta = new DataTable();

            string sentencia = "SELECT * FROM RECURSOS WHERE 1 = 1";

            if (!string.IsNullOrEmpty(EntidadRecursos.COD_RECURSO))
            {
                sentencia = sentencia + " AND UPPER(COD_RECURSO) LIKE UPPER('" + EntidadRecursos.COD_RECURSO + "%')";
            }

            if (!string.IsNullOrEmpty(EntidadRecursos.NOM_RECURSO))
            {
                sentencia = sentencia + " AND UPPER(NOM_RECURSO) LIKE UPPER('%" + EntidadRecursos.NOM_RECURSO + "%')";
            }

            if (!string.IsNullOrEmpty(EntidadRecursos.VIGENCIA))
            {
                sentencia = sentencia + "  AND VIGENCIA = '" + EntidadRecursos.VIGENCIA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadRecursos.REC_NACION))
            {
                sentencia = sentencia + " AND REC_NACION = '" + EntidadRecursos.REC_NACION + "' ";
            }

            sentencia = sentencia + " ORDER BY COD_RECURSO ";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}