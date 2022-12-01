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
    public class COMCtrlMunicipios
    {
        public string Mensaje;
        public DataTable CtrlCargarMunicipios(ComMunicipios EntidadMunicipios)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsMunicipios comConsMunicipios = new ComConsMunicipios();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsMunicipios.ConsCargarMunicipios(oConexion, EntidadMunicipios);
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
