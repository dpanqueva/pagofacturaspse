using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    class COMConsCtrlIntegracion
    {
        public string Mensaje;

        public DataTable ConsConsultarCtrlIntegracion(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CTRL_INTEGRACION WHERE 1=1 ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;
        }
    }
}
