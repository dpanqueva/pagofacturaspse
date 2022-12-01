using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseMonedas
    {
        public string Mensaje;

        public DataTable CtrlConsultarClaseMonedas(COMClaseMonedas EntidadClaseMonedas)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsClaseMonedas comConsClaseMonedas = new COMConsClaseMonedas();  

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseMonedas.ConsConsultarClaseMonedas(oConexion, EntidadClaseMonedas);
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
