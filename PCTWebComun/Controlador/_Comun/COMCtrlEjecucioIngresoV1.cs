using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Utilidades;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlEjecucioIngresoV1
    {
        public string Mensaje;
        public DataTable CtrlConsultarEjecucionIngresosV1(ComEjecucionIngresosV1 entidadEjecucionIngresosV1)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsEjecucionIngresosV1 comConsEjecucionIngresosV1 = new ComConsEjecucionIngresosV1();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsEjecucionIngresosV1.ConsConsultarEjecucionIngresosV1(oConexion, entidadEjecucionIngresosV1);
                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
