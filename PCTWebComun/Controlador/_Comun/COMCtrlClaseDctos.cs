
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/09/2020 - Ticket N° 000000 - Caso: Se agrega pagina al proyecto, por solicitud de Maribel - Participantes: Oscar Ramos

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
    public class COMCtrlClaseDctos
    {
        public string Mensaje;
        public DataTable CtrlConsultarClaseDctos(COMClaseDctos EntidadClaseDctos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsClaseDctos comConsClaseDctos = new COMConsClaseDctos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseDctos.ConsConsultarClaseDctos(oConexion, EntidadClaseDctos);
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
