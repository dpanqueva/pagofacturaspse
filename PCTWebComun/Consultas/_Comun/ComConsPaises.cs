using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsPaises
    {
        public string Mensaje;
        public DataTable ConsCargarPaises(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM PAISES ";

            sentencia += " ORDER BY NOM_PAIS";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
