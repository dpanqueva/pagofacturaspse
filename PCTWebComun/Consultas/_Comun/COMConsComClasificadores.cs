using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    class COMConsComClasificadores
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_CLASIFICADORES
        public DataTable ConsConsultarComClasificadores(ConexionBD oconexion)
        {
            string sentencia = "SELECT * FROM COM_CLASIFICADORES";
            DataTable dtsConsulta = new DataTable();

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
