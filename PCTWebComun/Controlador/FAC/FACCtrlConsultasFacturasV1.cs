//PCT.NET_NVO_0000_20190521 - Fecha Inicio 28/10/2020 - Ticket Nº 0000 - Caso: Se agrega clase de Controlador de Facturas V1, solicitada por Jorge Valega- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador de  CONSULTASFACTURAS_V1  - Participantes: Ingrid Gomez

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
    public class FACCtrlConsultasFacturasV1
    {
        public string Mensaje;
        public DataTable CtrlConsultarConsulFacturasV1(FACConsultasFacturasV1 EntidadConsultaFacturasV1, string NoFacturaIni, string NoFacturaFin, string ValorfacIni,
                                                            string ValorfacFin, string FecfacturaIni, string FecfacturaFin, string FecVecfacIni, string FecVenfacFin, string FecanulafacIni,
                                                            string FecanulafacFin, string FecregisfacIni, string FecregisfacFin, string RefepagoIni,
                                                            string RefepagoFin, string DoctasaIni, string DoctasaFin, string CodigotasaIni, string CodigotasaFin,
                                                            string SaldocapIni, string SaldocapFin)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsConsultasFacturasV1 fACConsConsultasFacturasV1 = new FACConsConsultasFacturasV1();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsConsultasFacturasV1.ConsultarConsulFacturasV1(oConexion, EntidadConsultaFacturasV1, NoFacturaIni, NoFacturaFin, ValorfacIni,
                                                            ValorfacFin, FecfacturaIni, FecfacturaFin, FecVecfacIni, FecVenfacFin, FecanulafacIni,
                                                             FecanulafacFin, FecregisfacIni, FecregisfacFin, RefepagoIni,
                                                             RefepagoFin, DoctasaIni, DoctasaFin, CodigotasaIni, CodigotasaFin,
                                                             SaldocapIni, SaldocapFin);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        //reporte

        public DataTable CtrlConsrptConsultafacturasV1(FACConsultasFacturasV1 EntidadRptConsultaFacturasV1)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsConsultasFacturasV1 fACConsConsultasFacturasV1 = new FACConsConsultasFacturasV1();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsConsultasFacturasV1.ConsultarptConsultafacturasV1(oConexion, EntidadRptConsultaFacturasV1);
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
