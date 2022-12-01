//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase Controlador de TOTALES_FACTURA_V2, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    public class FACCtrlTotalesFacturaV2
    {
        public string Mensaje;
        public DataTable CtrlConsultarTotalesFacturaV2(FACTotalesFacturaV2 EntidadTotalesFacturaV2)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsTotalesFacturaV2 facConsTotalesFacturaV2 = new FACConsTotalesFacturaV2();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsTotalesFacturaV2.ConsConsultarTotalesFacturaV2(oConexion, EntidadTotalesFacturaV2);
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
