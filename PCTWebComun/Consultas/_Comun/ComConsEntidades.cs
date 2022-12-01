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
    public class ComConsEntidades
    {
        public string Mensaje;

        public DataTable ConsConsultarEntidades(ConexionBD oConexcion, ComEntidades EntidadEntidades)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            consulta = "SELECT COD_UNI,NOMBRE FROM ENTIDADES ";

            if (!string.IsNullOrEmpty(EntidadEntidades.COD_UNI) && !string.IsNullOrEmpty(EntidadEntidades.NOMBRE))
            {
                consulta += " WHERE COD_UNI LIKE '%" + EntidadEntidades.COD_UNI + "%' OR UPPER(NOMBRE) LIKE '%" + EntidadEntidades.NOMBRE.ToUpper() + "%' ";
            }

            dtResultado = oConexcion.Consulta(consulta);
            Mensaje = oConexcion.Mensaje;

            return dtResultado;
        }
    }
}
