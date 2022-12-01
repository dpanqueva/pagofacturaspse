using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsClaseBancos
    {
        public string Mensaje;

        public DataTable ConsCargarBancos(ConexionBD oconexion, ComClaseBancos EntidadClaseBancos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CLASE_BANCOS WHERE 1 = 1";

            if (!string.IsNullOrEmpty(EntidadClaseBancos.COD_BANCO))
            {
                sentencia += " AND COD_BANCO="+EntidadClaseBancos.COD_BANCO;
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

    }
}
