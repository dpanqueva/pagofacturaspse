using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsDepartamentos
    {
        public string Mensaje;

        public DataTable ConsCargarDepartamentos(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM DEPARTAMENTOS ";

            sentencia += " ORDER BY NOM_DEPTO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
