using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Utilidades;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlUsosIngresos
    {
        public string Mensaje;
        public DataTable CtrlConsultarUsosIngresos(COMUsosIngresos entidadCOMUsosIngresos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsUsosIngresos comConsUsosIngresos = new COMConsUsosIngresos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsUsosIngresos.ConsConsultarUsosIngresos(oConexion,  entidadCOMUsosIngresos);
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
