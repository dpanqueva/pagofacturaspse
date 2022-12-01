using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlContClaseFlujoEfectivo
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public DataTable ctrlConsultarContClaseFlujoEfectivo()
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsContClaseFlujoEfectivo comConsContClaseFlujoEfectivo = new ComConsContClaseFlujoEfectivo();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsContClaseFlujoEfectivo.ConsConsultarContClaseFlujoEfectivo(oconexion);
                Mensaje = oconexion.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
