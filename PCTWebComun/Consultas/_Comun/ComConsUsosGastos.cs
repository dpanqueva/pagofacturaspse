using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsUsosGastos
    {
        private string Mensaje;

        public DataTable ConsConsultarUsosGastos(ConexionBD oConexion, ComUsosGastos EntidadUsosGastos)
        {
            string sentencia= " SELECT * FROM USOS_GASTOS WHERE 1=1";
            DataTable dtsConsulta;

            if (!string.IsNullOrEmpty(EntidadUsosGastos.VIGENCIA))
            {
                sentencia += "  AND VIGENCIA='"+EntidadUsosGastos.VIGENCIA+"'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_UNIDAD))
            {
                sentencia += "  AND COD_UNIDAD='" + EntidadUsosGastos.COD_UNIDAD + "'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_GASTO))
            {
                sentencia += "  AND COD_GASTO='" + EntidadUsosGastos.COD_GASTO + "'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_RECURSO))
            {
                sentencia += "  AND COD_RECURSO='" + EntidadUsosGastos.COD_RECURSO + "'";
            }

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable ConsConsultarTotalCountUsosGastos(ConexionBD oConexion, ComUsosGastos EntidadUsosGastos)
        {
            string sentencia= " SELECT COUNT(*) FROM USOS_GASTOS WHERE 1=1";
            DataTable dtsConsulta;

            if (!string.IsNullOrEmpty(EntidadUsosGastos.VIGENCIA))
            {
                sentencia += "  AND VIGENCIA='"+EntidadUsosGastos.VIGENCIA+"'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_UNIDAD))
            {
                sentencia += "  AND COD_UNIDAD='" + EntidadUsosGastos.COD_UNIDAD + "'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_GASTO))
            {
                sentencia += "  AND COD_GASTO='" + EntidadUsosGastos.COD_GASTO + "'";
            }

            if (!string.IsNullOrEmpty(EntidadUsosGastos.COD_RECURSO))
            {
                sentencia += "  AND COD_RECURSO='" + EntidadUsosGastos.COD_RECURSO + "'";
            }

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
    }
}
