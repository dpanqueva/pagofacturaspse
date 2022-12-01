//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase consulta de FORMA_PAGO_V1, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    class FACConsFormaPagoV1
    {
        public string Mensaje;
        public DataTable ConsConsultarFormaPagoV1(ConexionBD oconexion, FACFormaPagoV1 EntidadFormaPagoV1)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT FECHA_FACTURA, VIGENCIA, COD_FACTURA, COD_PAGO, COD_TIPO, TIPO, VAL_TOTAL, VAL_X_PAGAR, NIT, VAL_A_PAGAR, ESTADO, VALXDISTRIBUIR, " +
                "VALDISTRIBUIDO, 0 VALRETENCIONES, CODIGO, 'N' NOTA, 0 VALOR_NOTA, COD_TIPOING " +
                "FROM FORMA_PAGO_V1 WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadFormaPagoV1.NIT))
            {
                sentencia += " AND NIT = '" + EntidadFormaPagoV1.NIT + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadFormaPagoV1.COD_TIPOING))
            {
                sentencia += " AND COD_TIPOING = " + EntidadFormaPagoV1.COD_TIPOING + " ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
