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
    public class COMCtrlFormatosGirosElectronicos
    {
        public string Mensaje;
        public DataTable CtrlConsultarFormatosGirosElectronicos()
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsFormatosGirosElectronicos comConsClaseConceptos = new COMConsFormatosGirosElectronicos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseConceptos.ConsConsultarFormatosGirosElectronicos(oConexion);
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
