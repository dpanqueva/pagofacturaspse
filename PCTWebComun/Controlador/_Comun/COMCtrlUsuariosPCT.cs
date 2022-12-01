//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/07/2019 - Ticket Nº 35935 - Caso: Implementacion pagina Consulta Usarios PCT - Participantes: Sonia Cruz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;


namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlUsuariosPCT
    {
        public string Mensaje;
        public DataTable CtrlConsultarUsuariosPCT(ComUsuariosPCT EntidadUsuariosPCT)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsUsuariosPCT comConsUsuariosPCT = new ComConsUsuariosPCT();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsUsuariosPCT.ConsConsultarUsuariosPCT(oConexion, EntidadUsuariosPCT);
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
