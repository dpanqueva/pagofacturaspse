using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseBancos
    {
        public string Mensaje;
        public DataTable CtrlCargarBancos(ComClaseBancos EntidadClaseBancos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsClaseBancos comConsClaseBancos = new ComConsClaseBancos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseBancos.ConsCargarBancos(oConexion, EntidadClaseBancos);
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
