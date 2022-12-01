//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACConsCategoriaVentaElementos, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/10/2021 - Ticket N° 040676 - Caso: Se agrega la consulta de la tabla  CLASE_ELEMENTOSSERVICIO  - Participantes:Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas.FAC
{
    public class FACConsCategoriaVentaElementos
    {
        public string Mensaje;
        public DataTable ConsConsultarFACCategoriaelem(ConexionBD oconexion, FACCategoriaVentaElementos EntidadCategoriaelementos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT VIGENCIA, COD_CATEGORIA, NOM_CATEGORIA,MAX(VIGENCIA||COD_CATEGORIA)ID  ";
            sentencia += "FROM CATEGORIAVENTA_ELEMENTOS WHERE 1= 1  ";

            if (!string.IsNullOrEmpty(EntidadCategoriaelementos.VIGENCIA))
            {
                sentencia = sentencia + " AND VIGENCIA = '" + EntidadCategoriaelementos.VIGENCIA + "' ";
            }
            
            if ((!string.IsNullOrEmpty(EntidadCategoriaelementos.COD_CATEGORIA)) && (!string.IsNullOrEmpty(EntidadCategoriaelementos.NOM_CATEGORIA)))
             {
                  sentencia = sentencia + " AND UPPER(COD_CATEGORIA) LIKE '%" + EntidadCategoriaelementos.COD_CATEGORIA + "%' OR UPPER(NOM_CATEGORIA) LIKE UPPER('%" + EntidadCategoriaelementos.NOM_CATEGORIA + "%')";
             }
            

            



            //if (!string.IsNullOrEmpty(EntidadCategoriaelementos.NOM_CATEGORIA))
            //{
            //    sentencia += " AND UPPER(NOM_CATEGORIA) LIKE '%" + EntidadCategoriaelementos.NOM_CATEGORIA.ToUpper() + "%'";
            //}

            //if (!string.IsNullOrEmpty(EntidadCategoriaelementos.COD_CATEGORIA))
            //{
            //    sentencia = sentencia + " AND COD_CATEGORIA = '" + EntidadCategoriaelementos.COD_CATEGORIA + "' ";
            //}

            sentencia += "GROUP BY VIGENCIA, COD_CATEGORIA,NOM_CATEGORIA ";
            sentencia += "ORDER BY COD_CATEGORIA";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}
