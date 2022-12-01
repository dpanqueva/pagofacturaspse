//PCT.NET_NVO_0000_20200430 - Fecha Inicio 14/08/2020 - Ticket N° 037563 - Caso: Se agrega consulta de MYP_PREVIO_BANCO_PRY - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsMypPrevioBancoPry
    {
        private string Mensaje;

        public DataTable ConsConsultarConsultaPrevioV2(ConexionBD oconexion, COMMypPrevioBancoPry EntidadMypPrevioBancoPry)
        {
            string sentencia = " SELECT * FROM MYP_PREVIO_BANCO_PRY ";
            DataTable dtsConsulta;

            sentencia += " WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(EntidadMypPrevioBancoPry.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + EntidadMypPrevioBancoPry.VIGENCIA;
            }

            if (!string.IsNullOrEmpty(EntidadMypPrevioBancoPry.NUM_PREVIO))
            {
                sentencia += " AND NUM_PREVIO=" + EntidadMypPrevioBancoPry.NUM_PREVIO;
            }

            if (!string.IsNullOrEmpty(EntidadMypPrevioBancoPry.ID_COM_ENTIDAD))
            {
                sentencia += " AND ID_COM_ENTIDAD=" + EntidadMypPrevioBancoPry.ID_COM_ENTIDAD;
            }

            sentencia += " ORDER BY VIGENCIA, NUM_PREVIO";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
