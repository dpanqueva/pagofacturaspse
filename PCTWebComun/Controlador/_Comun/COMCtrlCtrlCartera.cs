//PCT.NET_NVO_0000_20200430 - Fecha Inicio 17/12/2020 - Ticket N° 00000 - Caso: Se agrega clase Controlador de CTRL_CARTERA, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlCartera
    {
        public string Mensaje;
        public DataTable CtrlConsultarCtrlCartera(COMCtrlCartera EntidadCtrlCartera)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtrlCartera comConsCtrlCartera = new COMConsCtrlCartera();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtrlCartera.ConsConsultarCtrlCartera(oConexion, EntidadCtrlCartera);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
