//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/01/2021 - Ticket Nº 0000  - Caso: se agrega clase Consulta REFERENCIASSERVICIO, Solicitud deJheisone Padilla- Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas.FAC
{
    class FACConsReferenciasservicio
    {
        public string Mensaje;
        public DataTable ConsConsultarReferenciasServicio(ConexionBD oconexion, FACReferenciasservicio EntidadReferenciasservicio)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM REFERENCIASSERVICIO WHERE VIGENCIA = (SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD) ";

            if (!string.IsNullOrEmpty(EntidadReferenciasservicio.COD_REFERENCIA) && !string.IsNullOrEmpty(EntidadReferenciasservicio.NOM_REFERENCIA))
            {
                sentencia += " AND COD_REFERENCIA= " + EntidadReferenciasservicio.COD_REFERENCIA + "  OR UPPER(NOM_REFERENCIA) LIKE UPPER('%" + EntidadReferenciasservicio.NOM_REFERENCIA + "%') ";
            }
            
            sentencia += " ORDER BY COD_REFERENCIA ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }



        public DataTable ConsConsultaConsReferenciaserv(ConexionBD oconexion, FACReferenciasservicio EntidadReferenciasservicio)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT COD_REFERENCIA,REFERENCIA FROM REFERENCIASSERVICIO ";

            if (!string.IsNullOrEmpty(EntidadReferenciasservicio.COD_REFERENCIA) && !string.IsNullOrEmpty(EntidadReferenciasservicio.REFERENCIA))
            {
                sentencia += " WHERE COD_REFERENCIA= " + EntidadReferenciasservicio.COD_REFERENCIA + "  OR UPPER(REFERENCIA) LIKE UPPER('%" + EntidadReferenciasservicio.REFERENCIA + "%') ";
            }

            sentencia += " ORDER BY COD_REFERENCIA ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

    }
}
