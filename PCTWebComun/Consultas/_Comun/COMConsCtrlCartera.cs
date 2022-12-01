//PCT.NET_NVO_0000_20200430 - Fecha Inicio 17/12/2020 - Ticket N° 00000 - Caso: Se agrega clase Consulta de CTRL_CARTERA, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    public class COMConsCtrlCartera
    {
        public string Mensaje;
        public DataTable ConsConsultarCtrlCartera(ConexionBD oconexion, COMCtrlCartera EntidadCtrlCartera)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CTRL_CARTERA";


            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
