//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Consulta CATEGORIAS_FACTURAS_V1, solicitud de Ingrid Gomez - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Consulta CATEGORIAS_FACTURAS_V1 - Participantes: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;



namespace PCTWebComun.Consultas.FAC
{
    public class FACConsCategoriasFacturasV1
    {
        public string Mensaje;
        public DataTable ConsConsultarFacConsCategorias(ConexionBD oconexion, FACCategoriasFacturasV1 EntidadConsultaCategoria)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT COD_CATEGORIA, NOM_CATEGORIA, NIVEL FROM CATEGORIAS_FACTURAS_V1 " +
                               " WHERE VIGENCIA IN (SELECT DISTINCT VIGENCIA FROM MFACTURA UNION SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD)  ";
           

            if (!string.IsNullOrEmpty(EntidadConsultaCategoria.COD_CATEGORIA))
            {
                sentencia += " AND COD_CATEGORIA LIKE ('" + EntidadConsultaCategoria.COD_CATEGORIA + "')";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaCategoria.NOM_CATEGORIA))
            {
                sentencia += " AND UPPER(NOM_CATEGORIA) LIKE UPPER('%" + EntidadConsultaCategoria.NOM_CATEGORIA + "%')";

            }

            sentencia += " ORDER BY COD_CATEGORIA ";


            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
