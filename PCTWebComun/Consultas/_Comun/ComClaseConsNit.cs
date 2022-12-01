using System;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComClaseConsNit
    {
        private string lmensaje;
        public DataTable consultarNit(ConexionBD oconexion, ComNit entidad)
        {
            string sentencia;
            DataTable dtsConsulta = new DataTable();

            sentencia = "select NIT, NOMBRE from NIT WHERE 1 = 1 '" + entidad.NIT + "' ";

            if (!String.IsNullOrEmpty(entidad.NIT))
            {
                sentencia = "AND NIT = '" + entidad.NIT + "'";
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;

        }

    }
}

