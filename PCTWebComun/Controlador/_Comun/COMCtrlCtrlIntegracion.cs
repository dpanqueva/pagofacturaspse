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
    public class COMCtrlCtrlIntegracion
    {
        public string Mensaje;

        public DataTable CtrlConsultarCtrlIntegracion()
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtrlIntegracion comConsCtrlIntegracion = new COMConsCtrlIntegracion();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtrlIntegracion.ConsConsultarCtrlIntegracion(oConexion);
                oConexion.Desconectar();
            }
            else
            {
                oConexion.Desconectar();
            }

            Mensaje = comConsCtrlIntegracion.Mensaje;
            return dtConsulta;
        }
    }
}
