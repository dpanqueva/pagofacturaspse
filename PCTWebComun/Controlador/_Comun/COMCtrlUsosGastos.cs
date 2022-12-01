using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Controlador._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlUsosGastos
    {
        public string Mensaje;
        public DataTable CtrlConsultarUsosGastos(ComUsosGastos EntidadUsosGastos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsUsosGastos comConsUsosGastos = new ComConsUsosGastos();           

            if (oConexion.Conectar())
            {
                dtConsulta = comConsUsosGastos.ConsConsultarUsosGastos(oConexion, EntidadUsosGastos);
                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        public DataTable CtrlConsultarTotalCountUsosGastos(ComUsosGastos EntidadUsosGastos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsUsosGastos comConsUsosGastos = new ComConsUsosGastos();           

            if (oConexion.Conectar())
            {
                dtConsulta = comConsUsosGastos.ConsConsultarTotalCountUsosGastos(oConexion, EntidadUsosGastos);
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
