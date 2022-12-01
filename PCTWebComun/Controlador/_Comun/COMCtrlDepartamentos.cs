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
    public class COMCtrlDepartamentos
    {
        public string Mensaje;

        public DataTable CtrlCargarDepartamentos()
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsDepartamentos comConsDepartamentos = new ComConsDepartamentos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsDepartamentos.ConsCargarDepartamentos(oConexion);
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
