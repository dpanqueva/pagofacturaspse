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
    public class COMConsClaseMonedas
    {
        private string Mensaje;

        public DataTable ConsConsultarClaseMonedas(ConexionBD oconexion, COMClaseMonedas EntidadClaseMonedas)
        {
            string sentencia = "SELECT * FROM CLASE_MONEDAS";
            DataTable dtsConsulta;

            sentencia += " WHERE 1 = 1 ";

          
            if (!string.IsNullOrEmpty(EntidadClaseMonedas.COD_MONEDA))
            {
                sentencia = sentencia + " AND UPPER(COD_MONEDA) LIKE UPPER('" + EntidadClaseMonedas.COD_MONEDA + "')";
            }

            if (!string.IsNullOrEmpty(EntidadClaseMonedas.NOM_MONEDA))
            {
                sentencia = sentencia + " AND UPPER(NOM_MONEDA) LIKE UPPER('%" + EntidadClaseMonedas.NOM_MONEDA + "%')";
            }

            if (!string.IsNullOrEmpty(EntidadClaseMonedas.MONEDA_LOCAL))
            {
                sentencia = sentencia + " AND UPPER(MONEDA_LOCAL) LIKE UPPER('%" + EntidadClaseMonedas.MONEDA_LOCAL + "%')";
            }

            if (!string.IsNullOrEmpty(EntidadClaseMonedas.PAIS_MONEDA))
            {
                sentencia = sentencia + " AND UPPER(PAIS_MONEDA) LIKE UPPER('%" + EntidadClaseMonedas.PAIS_MONEDA + "%')";
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
