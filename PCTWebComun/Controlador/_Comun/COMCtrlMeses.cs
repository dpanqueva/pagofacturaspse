using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlMeses
    {
        public string Mensaje;
        public DataTable CtrlConsultarMeses(ComMeses EntidadMeses)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsMeses comConsMeses = new ComConsMeses();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsMeses.ConsConsultarMeses(oConexion, EntidadMeses);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}