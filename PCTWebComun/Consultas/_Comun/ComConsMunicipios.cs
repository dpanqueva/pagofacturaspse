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
    public class ComConsMunicipios
    {
        public string Mensaje;
        public DataTable ConsCargarMunicipios(ConexionBD oconexion, ComMunicipios EntidadMunicipios)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM MUNICIPIOS ";

            if (!string.IsNullOrEmpty(EntidadMunicipios.COD_DEPTO))
            {
                sentencia = sentencia + " WHERE COD_DEPTO = " + EntidadMunicipios.COD_DEPTO + "";
            }

            sentencia += " ORDER BY NOM_MUNICIPIO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
