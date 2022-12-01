//PCT.NET_NVO_0000_20190521 - Fecha Inicio 30/08/2021 - Ticket Nº 00000 - Caso: Se agrega Consultas de clase_conceptos, Solicitud de Jheisone Padilla - Participantes: Oscar Ramos

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
    class COMConsClaseConceptos
    {
        public string Mensaje;
        public DataTable ConsConsultarClaseConceptos(ConexionBD oconexion, COMClaseConceptos entidadClaseConceptos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CLASE_CONCEPTOS WHERE 1=1 ";

            if (!string.IsNullOrEmpty(entidadClaseConceptos.COD_CONCEPTO))
            {
                sentencia += " AND COD_CONCEPTO ='" + entidadClaseConceptos.COD_CONCEPTO + "' ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}
