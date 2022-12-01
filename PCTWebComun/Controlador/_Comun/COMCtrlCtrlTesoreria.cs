//PCT.NET_NVO_0000_20200430 - Fecha Inicio 08/10/2020 - Ticket N° 038350 - Caso: Se agrega pagina para la Controlador de CTRL_TESORERIA - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComun._ConexionesBD;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlTesoreria
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        //PCT.NET_NVO_0000_20200430 - Fecha Inicio 08/10/2020 - Ticket N° 038350 - Caso: Metodo Controlador de CTRL_TESORERIA- Participantes: Oscar Ramos
        public DataTable ctrlConsultarCtrlTesoreria(COMCtrlTesoreria EntidadCtrlTesoreria, ComCtrlEntidad EntidadCtrlEntidad)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtrlTesoreria comConsCtrlTesoreria = new COMConsCtrlTesoreria();

            if (oConexion.Conectar())
            {
                 dtConsulta =  comConsCtrlTesoreria.consConsultarCtrlTesoreria(oConexion, EntidadCtrlTesoreria, EntidadCtrlEntidad);
                oConexion.Desconectar();
            }

            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
