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
    public class FACConsMFactura
    {
        public string Mensaje;
        public DataTable ConsConsultarMFactura(ConexionBD oconexion, FACMFactura EntidadMFactura)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM MFACTURA WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadMFactura.NIT))
            {
                sentencia += " AND NIT = '" + EntidadMFactura.NIT + "'";
            }
            if (!string.IsNullOrEmpty(EntidadMFactura.ESTADO))
            {
                sentencia += " AND ESTADO IN (" + EntidadMFactura.ESTADO + ") ";
            }
            if (!string.IsNullOrEmpty(EntidadMFactura.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = '" + EntidadMFactura.VIGENCIA + "'";
            }
            if (!string.IsNullOrEmpty(EntidadMFactura.COD_FACTURA))
            {
                sentencia += " AND COD_FACTURA  = '" + EntidadMFactura.COD_FACTURA + "'";
            }
            if (!string.IsNullOrEmpty(EntidadMFactura.COD_TIPO))
            {
                sentencia += " AND COD_TIPO = '" + EntidadMFactura.COD_TIPO + "'";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
