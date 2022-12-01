//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Controlador CATEGORIAS_FACTURAS_V1, solicitud de Ingrid Gomez - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Controlador CATEGORIAS_FACTURAS_V1 - Participantes: Ingrid Gomez

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
    public class FACCtrlCategoriasFacturasV1
    {
        public string Mensaje;
        public DataTable CtrlConsultarFacConsCategorias(FACCategoriasFacturasV1 EntidadConsultaCategoria)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsCategoriasFacturasV1 fACConsCategoriasFacturasV1 = new FACConsCategoriasFacturasV1();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsCategoriasFacturasV1.ConsConsultarFacConsCategorias(oConexion, EntidadConsultaCategoria);
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
