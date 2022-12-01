//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se crea controlador de consulta de la tabla CTRL_ENTIDAD- Participantes: Maribel Pedroza
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlEntidad
    {
        
        private string lmensaje;

        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        public RespuestaNet CtrlConsultarCtrlEntidad()
        {
            RespuestaNet respuesta = new RespuestaNet();
            ComConsCtrlEntidad comConsCtrlEntidad = new ComConsCtrlEntidad();
            ConexionBD oConexion = new ConexionBD();

            if (oConexion.Conectar())
            {
                respuesta.Data = comConsCtrlEntidad.ConsConsultarCtrlEntidad(oConexion);
                oConexion.Desconectar();
            }

            respuesta.Mensaje = comConsCtrlEntidad.Mensaje;
            return respuesta;
        }
    }
}
