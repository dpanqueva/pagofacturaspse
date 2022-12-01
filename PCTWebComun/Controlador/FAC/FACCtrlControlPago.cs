//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCtrlControlPago, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador de  CONTROL_PAGO  - Participantes: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using PCTWebComun.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlControlPago
    {
        public string Mensaje;
        public DataTable CtrlConsultarControlPago(FACControlPago EntidadConsultaControlPago)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsControlPago fACConsControlPago = new FACConsControlPago();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsControlPago.ConsultarConsControlPago(oConexion, EntidadConsultaControlPago);
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
