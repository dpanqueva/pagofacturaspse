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
    public class COMCtrlCtrlPresupuesto
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        //PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/03/2021 - Ticket Nº 038738  - Caso: se crea metodo Controlador ctrl Presupuesto - Participantes: Wendy Simbaqueba
        public DataTable ctrlConsultarCtrlPresupuesto(COMCtrlPresupuesto EntidadCtrlPresupuesto, ComCtrlEntidad EntidadCtrlEntidad)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtrlPresupuesto comConsCtrlPresupuesto = new COMConsCtrlPresupuesto();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtrlPresupuesto.consConsultarCtrlPresupuesto(oConexion, EntidadCtrlPresupuesto, EntidadCtrlEntidad);
                oConexion.Desconectar();
            }

            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }

}
