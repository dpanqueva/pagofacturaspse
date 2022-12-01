using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlEntidades
    {
        public string Mensaje;
        public DataTable CtrlConsultarEntidades(ComEntidades EntidadEntidades)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsEntidades comConsEntidades = new ComConsEntidades();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsEntidades.ConsConsultarEntidades(oConexion, EntidadEntidades);
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
