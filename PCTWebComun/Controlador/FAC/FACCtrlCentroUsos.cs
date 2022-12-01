//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCtrlCentroUsos, Solicitud de Ingrid - Participantes: Maribel Pedroza

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlCentroUsos
    {
        public string Mensaje;
        public DataTable CtrlConsultarCentrosdeusocons(FACCentroUsos EntidadCentrosdeuso)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsCentroUsos fACConsCentroUsos = new FACConsCentroUsos();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsCentroUsos.ConsConsultaCentrosdeusocon(oConexion, EntidadCentrosdeuso);
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
