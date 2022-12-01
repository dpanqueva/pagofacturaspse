//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/09/2020 - Ticket N° 000000 - Caso: Se agrega pagina al proyecto, por solicitud de Maribel - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsClaseDctos
    {
        private string Mensaje;

        public DataTable ConsConsultarClaseDctos(ConexionBD oconexion, COMClaseDctos EntidadClaseDctos)
        {
            string sentencia = "SELECT * FROM CLASE_DCTOS";

            sentencia += " WHERE 1 = 1";

            DataTable dtsConsulta = new DataTable();

            //if ((!string.IsNullOrEmpty(entidadClaseDesResRecV1.COD_DESREC)) && (!string.IsNullOrEmpty(entidadClaseDesResRecV1.NOM_DESREC)))
            //{
            //    sentencia = sentencia + " AND UPPER (COD_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.COD_DESREC + "%') OR UPPER (NOM_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.NOM_DESREC + "%')";
            //}
            //else
            //{
            //    if (!string.IsNullOrEmpty(entidadClaseDesResRecV1.COD_DESREC))
            //    {
            //        sentencia = sentencia + " AND UPPER COD_DESREC LIKE '%" + entidadClaseDesResRecV1.COD_DESREC + "%'";
            //    }

            //    if (!string.IsNullOrEmpty(entidadClaseDesResRecV1.NOM_DESREC))
            //    {
            //        sentencia = sentencia + " AND UPPER(NOM_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.NOM_DESREC + "%')";
            //    }
            //}
            if (!string.IsNullOrEmpty(EntidadClaseDctos.COD_DCTO))
            {
                sentencia = sentencia + " AND COD_DCTO NOT IN (" + EntidadClaseDctos.COD_DCTO + ") ";
            }

            sentencia = sentencia + " ORDER BY NOM_DCTO";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
