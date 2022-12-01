//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCtrlClaseElementosServicios, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/10/2021 - Ticket N° 040676 - Caso: Se agrega Clase de la tabla CLASE_ELEMENTOSSERVICIO, Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

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
    public class FACCtrlClaseElementosServicios
    {
        public string Mensaje;
        public DataTable CtrlConsultaClseelementos(FACClaseElementosServicios EntidadClseelementos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsClaseElementosServicios fACConsClaseElementosServicios = new FACConsClaseElementosServicios();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsClaseElementosServicios.ConsConsultarClseelementos(oConexion, EntidadClseelementos);
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
