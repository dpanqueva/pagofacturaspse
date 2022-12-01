//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/01/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador de QProductos, Solicitud deJheisone Padilla- Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.CamposQueries.FAC;
using PCTWebComun.Queries.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlQProductos
    {
        public string Mensaje;
        public DataTable CtrlConsultarReferenciaProducto(FACCQProductos CamposQuerieProductos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACQProductos facQProductos = new FACQProductos();

            if (oConexion.Conectar())
            {
                dtConsulta = facQProductos.ConsultarReferenciaProducto(oConexion, CamposQuerieProductos);
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
