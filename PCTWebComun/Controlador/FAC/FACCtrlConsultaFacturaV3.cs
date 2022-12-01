//PCT.NET_NVO_0000_20190521 - Fecha Inicio 23/12/2020 - Ticket Nº 0000  - Caso: se agrega clase controlador FACTURA_V3, Solicitud de Maribel pedroza- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 23/12/2020 - Ticket N° 039275 - Caso: Se crea el controlador de CONSULTAFACTURA_V3 -  Participantes: Maribel Pedroza

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
    public class FACCtrlConsultaFacturaV3
    {
        public string Mensaje;
        public DataTable CtrlConsultarConsultaFacturaV3(FACConsultaFacturaV3 EntidadConsultaFacturaV3, string CodFactIni, string CodFactFin)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsConsultaFacturaV3 facConsConsultaFacturaV3 = new FACConsConsultaFacturaV3();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsConsultaFacturaV3.ConsConsultarConsultaFacturaV3(oConexion, EntidadConsultaFacturaV3, CodFactIni, CodFactFin);
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
