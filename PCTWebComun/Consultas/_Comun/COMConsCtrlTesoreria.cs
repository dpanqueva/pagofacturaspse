//PCT.NET_NVO_0000_20200430 - Fecha Inicio 08/10/2020 - Ticket N° 038350 - Caso: Se agrega pagina para la consulta de CTRL_TESORERIA - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsCtrlTesoreria
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        //PCT.NET_NVO_0000_20200430 - Fecha Inicio 08/10/2020 - Ticket N° 038350 - Caso: Método para consulta de CTRL_TESORERIA - Participantes: Oscar Ramos
        public DataTable consConsultarCtrlTesoreria(ConexionBD oConexion, COMCtrlTesoreria EntidadCtrlTesoreria, ComCtrlEntidad EntidadCtrlEntidad)
        {
            string sentencia = "";

            if (!string.IsNullOrEmpty(EntidadCtrlEntidad.SCHEMA_OLD))
            {
                sentencia += "SELECT * FROM "+ EntidadCtrlEntidad.SCHEMA_OLD + ".CTRL_TESORERIA";
            } 
            else
            {
                sentencia += "SELECT * FROM CTRL_TESORERIA";
            }
           
            DataTable dtConsulta;
            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
