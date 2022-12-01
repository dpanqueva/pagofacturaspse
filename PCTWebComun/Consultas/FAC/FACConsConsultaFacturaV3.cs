//PCT.NET_NVO_0000_20190521 - Fecha Inicio 23/12/2020 - Ticket Nº 0000  - Caso: se agrega clase consulta FACTURA_V3, Solicitud de Maribel pedroza- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 23/12/2020 - Ticket N° 039275 - Caso: Se crea la consulta de CONSULTAFACTURA_V3 -  Participantes: Maribel Pedroza

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
    public class FACConsConsultaFacturaV3
    {
        public string Mensaje;
        public DataTable ConsConsultarConsultaFacturaV3(ConexionBD oconexion, FACConsultaFacturaV3 EntidadConsultaFacturaV3, string CodFactIni, string CodFactFin)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CONSULTAFACTURA_V3 WHERE COD_FACTURA <> '-1'";

            if (!string.IsNullOrEmpty(EntidadConsultaFacturaV3.NIT))
            {
                sentencia += " AND NIT = '" + EntidadConsultaFacturaV3.NIT + "'";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturaV3.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = '" + EntidadConsultaFacturaV3.VIGENCIA + "'";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturaV3.COD_TIPOING))
            {
                sentencia += " AND COD_TIPOING = '" + EntidadConsultaFacturaV3.COD_TIPOING + "'";
            }
            if (!string.IsNullOrEmpty(CodFactIni) && !string.IsNullOrEmpty(CodFactFin))
            {
                sentencia += " AND COD_FACTURA BETWEEN '" + CodFactIni + "' AND '" + CodFactFin + "' ";
            }

            sentencia += " ORDER BY VIGENCIA, COD_FACTURA ASC";



            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
