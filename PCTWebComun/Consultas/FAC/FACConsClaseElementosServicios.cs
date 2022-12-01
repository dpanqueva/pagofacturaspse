//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACConsClaseElementosServicios, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
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
    public class FACConsClaseElementosServicios
    {
        public string Mensaje;
        public DataTable ConsConsultarClseelementos(ConexionBD oconexion, FACClaseElementosServicios EntidadClseelementos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT COD_ELEMENTO, NOM_ELEMENTO, COD_CATEGORIA  ";
            sentencia += "FROM CLASE_ELEMENTOSSERVICIO ";

            if ((!string.IsNullOrEmpty(EntidadClseelementos.COD_ELEMENTO)) && (!string.IsNullOrEmpty(EntidadClseelementos.NOM_ELEMENTO)))
            {
                sentencia = sentencia + " WHERE UPPER(COD_ELEMENTO) LIKE '%" + EntidadClseelementos.COD_ELEMENTO + "%' OR UPPER(NOM_ELEMENTO) LIKE UPPER('%" + EntidadClseelementos.NOM_ELEMENTO + "%')";
            }

            sentencia += " ORDER BY COD_ELEMENTO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}
