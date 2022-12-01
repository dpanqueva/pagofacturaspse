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
    public class COMConsCtrlPresupuesto
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        //PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/03/2021 - Ticket Nº 038738  - Caso: se  crea consulta de ctrl Presupuesto - Participantes: Wendy Simbaqueba
        public DataTable consConsultarCtrlPresupuesto(ConexionBD oConexion, COMCtrlPresupuesto EntidadCtrlPresupuesto, ComCtrlEntidad EntidadCtrlEntidad)
        {
            string sentencia = "";

            if (!string.IsNullOrEmpty(EntidadCtrlEntidad.SCHEMA_OLD))
            {
                sentencia += "SELECT * FROM " + EntidadCtrlEntidad.SCHEMA_OLD + ".CTRL_PRESUPUESTO";
            }
            else
            {
                sentencia += "SELECT * FROM CTRL_PRESUPUESTO";
            }

            DataTable dtConsulta;
            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
