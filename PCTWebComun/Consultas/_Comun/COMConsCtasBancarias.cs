//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea controlador de la tabla CTAS_BANCARIAS- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 24/03/2021 - Ticket Nº 0000  - Caso: se crea consulta de la tabla CTAS_BANCARIAS- Participantes: Maribel Pedroza
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
    class COMConsCtasBancarias
    {
        public string Mensaje;
        public DataTable ConsConsultarCtasBancarias(ConexionBD oconexion, COMCtasBancarias EntidadCtasBancarias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT NRO_CTABANCARIA, COD_BANCO, COD_BANCO|| ' + ' || NRO_CTABANCARIA CTAKEY, "+
                "CAST(SUBSTR((NRO_CTABANCARIA) || ' (' || LTRIM(RTRIM(NOM_CTABANCARIA)) || '),', 1, 250)AS VARCHAR(250)) CUENTA " +
                "FROM CTAS_BANCARIAS WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(EntidadCtasBancarias.ACTIVA))
            {
                sentencia += " AND ACTIVA = '" + EntidadCtasBancarias.ACTIVA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadCtasBancarias.NRO_CTABANCARIA))
            {
                sentencia += " AND NRO_CTABANCARIA = '" + EntidadCtasBancarias.NRO_CTABANCARIA + "' ";
            }

            sentencia += " ORDER BY NRO_CTABANCARIA ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
