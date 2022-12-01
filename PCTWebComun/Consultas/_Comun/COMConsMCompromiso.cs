//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2021 - Ticket Nº 35554  - Caso: se crea clase Consulta de la tabla MCOMPROMISO - Participantes: Oscar Ramos.

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
    public class COMConsMCompromiso
    {
        private string Mensaje;

        public DataTable consConsultarMCompromiso(ConexionBD oconexion, COMMCompromiso EntidadMCompromiso)
        {
            DataTable dtsConsulta;
            string sentencia = "SELECT * FROM MCOMPROMISO WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadMCompromiso.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadMCompromiso.VIGENCIA;
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.NUM_COMPROMISO))
            {
                sentencia += " AND NUM_COMPROMISO = " + EntidadMCompromiso.NUM_COMPROMISO;
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.NUM_CERTIFICADO))
            {
                sentencia += " AND NUM_CERTIFICADO = " + EntidadMCompromiso.NUM_CERTIFICADO;
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.COD_CENTRO))
            {
                sentencia += " AND COD_CENTRO = '" + EntidadMCompromiso.COD_CENTRO+"'";
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.COD_REGION))
            {
                sentencia += " AND COD_REGION = '" + EntidadMCompromiso.COD_REGION +"'";
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.CTA_BANCO))
            {
                sentencia += " AND CTA_BANCO = '" + EntidadMCompromiso.CTA_BANCO + "'";
            }

            if (!string.IsNullOrEmpty(EntidadMCompromiso.NIT))
            {
                sentencia += " AND NIT = '" + EntidadMCompromiso.NIT + "'";
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
