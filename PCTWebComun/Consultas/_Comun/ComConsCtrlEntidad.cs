//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se crea controlador de consulta de la tabla CTRL_ENTIDAD- Participantes: Maribel Pedroza
using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsCtrlEntidad
    {
        public string Mensaje;
        public DataTable ConsConsultarCtrlEntidad(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CTRL_ENTIDAD";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
