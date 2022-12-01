//PCT.NET_NVO_0000_20190521 - Fecha Inicio 09/03/2021 - Ticket Nº 038738- Caso: se agrega Clase controlador de CTRL_APP - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlApp
    {
        public string Mensaje;
        public DataTable CtrlConsultarCtrlApp(COMCtrlApp EntidadCtrlApp)
        {
            DataTable respuesta = new DataTable();
            ConexionBD oConexion = new ConexionBD();
            COMConsCtrlApp comConsCtrlApp = new COMConsCtrlApp();

            if (oConexion.Conectar())
            {
                respuesta = comConsCtrlApp.consConsultarCtrlApp(oConexion,EntidadCtrlApp);

                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return respuesta;

        }
    }
}
