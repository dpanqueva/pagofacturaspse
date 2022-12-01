//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase Consulta de TOTALES_FACTURA_V2, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    class FACConsTotalesFacturaV2
    {
        public string Mensaje;
        public DataTable ConsConsultarTotalesFacturaV2(ConexionBD oconexion, FACTotalesFacturaV2 EntidadTotalesFacturaV2)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT SUM((TCxC+TIxC)) TDEUDA, SUM(TCXC) TCXC, SUM(TIXC) TIXC "+
                "FROM TOTALES_FACTURA_V2 WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadTotalesFacturaV2.NIT))
            {
                sentencia += " AND NIT = '" + EntidadTotalesFacturaV2.NIT + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadTotalesFacturaV2.COD_TIPOING))
            {
                sentencia += " AND COD_TIPOING = " + EntidadTotalesFacturaV2.COD_TIPOING + " ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
