//PCT.NET_NVO_0000_20200430 - Fecha Inicio 10/02/2021 - Ticket N° 039274 - Caso: Se agrega el metodo para incrementar el consucutivo de CTRL_MODULO - Participantes: Jaime Zuleta
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlModulo
    {
        public string Mensaje;

        public DataTable CtrlConsultarCtrlModulo(COMCtrlModulo EntidadCtrlModulo)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtrlModulo comConsCtrlModulo = new COMConsCtrlModulo();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtrlModulo.ConsConsultarCtrlModulo(oConexion, EntidadCtrlModulo);
                oConexion.Desconectar();
            }
            else
            {
                oConexion.Desconectar();
            }

            Mensaje = comConsCtrlModulo.Mensaje;
            return dtConsulta;
        }

        public Boolean CtrlUpdateConsecutivoCtrlModulo(COMCtrlModulo EntidadCtrlModulo)
        {
            Boolean res = false;
            ConexionBD oConexion = new ConexionBD();
            COMConsCtrlModulo comConsCtrlModulo = new COMConsCtrlModulo();

            if (oConexion.Conectar())
            {
                res = comConsCtrlModulo.ConsUpdateConsecutivoCtrlModulo(oConexion, EntidadCtrlModulo);
            }

            oConexion.Desconectar();

            Mensaje = comConsCtrlModulo.Mensaje;
            return res;
        }
    }
}
