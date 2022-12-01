//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase  controlador de Forma_Pago_v1, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    public class FACCtrlFormaPagoV1
    {
        public string Mensaje;
        public DataTable CtrlConsultarFormaPagoV1(FACFormaPagoV1 EntidadFormaPagoV1)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsFormaPagoV1 facConsFormaPagoV1 = new FACConsFormaPagoV1();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsFormaPagoV1.ConsConsultarFormaPagoV1(oConexion, EntidadFormaPagoV1);
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
