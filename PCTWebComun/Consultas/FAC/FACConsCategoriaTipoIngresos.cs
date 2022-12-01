//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase consulta de CATEGORIA_TIPO_INGRESOS, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    class FACConsCategoriaTipoIngresos
    {
        public string Mensaje;
        public DataTable ConsConsultarCategoriaTipoIngresos(ConexionBD oconexion, FACCategoriaTipoIngresos EntidadCategoriaTipoIngresos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CATEGORIA_TIPO_INGRESOS WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadCategoriaTipoIngresos.COD_TIPOING))
            {
                sentencia += " AND COD_TIPOING = " + EntidadCategoriaTipoIngresos.COD_TIPOING + " ";
            }

            sentencia += " AND (VIGENCIA,COD_CATEGORIA) IN (SELECT VIGENCIA,COD_CATEGORIA FROM DFACTURA " +
                "WHERE (VIGENCIA,COD_FACTURA,COD_TIPO) IN (SELECT VIGENCIA,COD_FACTURA,COD_TIPO " +
                "FROM MFACTURA WHERE NIT='" + EntidadCategoriaTipoIngresos.NIT + "' " +
                "AND ESTADO NOT IN (14,16)) GROUP BY VIGENCIA,COD_CATEGORIA)";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
