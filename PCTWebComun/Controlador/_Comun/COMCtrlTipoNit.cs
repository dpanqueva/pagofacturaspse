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
    public class COMCtrlTipoNit
    {
        public string Mensaje;
        public DataTable CtrlCargarTipoNit(ComTipoNit EntidadTipoNit)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsTipoNit comConsTipoNit = new ComConsTipoNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsTipoNit.ConsCargarTipoNit(oConexion, EntidadTipoNit);
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
