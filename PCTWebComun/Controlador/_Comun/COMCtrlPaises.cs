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
    public class COMCtrlPaises
    {
        public string Mensaje;
        public DataTable CtrlCargarPaises()
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsPaises comConsPaises = new ComConsPaises();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsPaises.ConsCargarPaises(oConexion);
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
