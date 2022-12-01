//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se clase controlador de CLASE_ELEMENTOSSERVICIO - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseElementosservicios
    {
        public string Mensaje;

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 08/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la consulta de CLASE_ELEMENTOSSERVICIO - Participantes: Oscar Ramos.
        public DataTable CtrlConsultarClaseElementosservicio(COMClaseElementosservicios EntidadClaseElementosservicio)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtsResultado = new DataTable();
            COMConsClaseElementosservicios comConsClaseElementosservicios = new COMConsClaseElementosservicios();

            if (oConexion.Conectar())
            {
                dtsResultado = comConsClaseElementosservicios.ConsConsultarClaseElementosservicio(oConexion, EntidadClaseElementosservicio);
                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }
            return dtsResultado;
        }
    }
}
