//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Query QTipoFactura, solicitud de Ingrid Gomez - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Query QTipoFacturaParticipantes: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.CamposQueries.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCTWebComun.Queries.FAC
{
    public class FACQTipoFactura
    {
        public string Mensaje;

        public DataTable ConsultarTipoFactDistri(ConexionBD oConexion, FACCQTipoFactura CamposQuerieTipofactura)
        {
            DataTable dtConsulta = new DataTable();

            string sentencia = "SELECT COD_TIPO, TIP_FAC FROM TIPO_FACTURA  " +
                "UNION SELECT -1 COD_TIPO, 'Intereses de Capital' TIP_FAC FROM DUAL " +
                "UNION SELECT -2 COD_TIPO, 'Intereses por Mora' FROM DUAL ";

            sentencia += "ORDER BY TIP_FAC";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }

        public DataTable ConsultarTipoFactcons(ConexionBD oConexion, FACCQTipoFactura CamposQuerieTipofacturacons)
        {
            DataTable dtConsulta = new DataTable();

            string sentencia = "SELECT TIP_FAC, COD_TIPO FROM TIPO_FACTURA  " +
                "WHERE COD_TIPO NOT IN (0,4) ";

            sentencia += "ORDER BY COD_TIPO";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }

    }
}
