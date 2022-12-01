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
    public class COMCtrlNivel
    {
        public string Mensaje;

        public DataTable CtrlConsultarNivelArbol(COMNivel EntidadNivel)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsNivel comConsNivel = new ComConsNivel();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsNivel.ConsConsultarNivelArbol(oconexion, EntidadNivel);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlConsultarNivel(ComCuentas EntidadCuentas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsNivel consultaCuentas = new ComConsNivel();

            if (oconexion.Conectar())
            {
                dtConsulta = consultaCuentas.ConsConsultarNivel(oconexion, EntidadCuentas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
