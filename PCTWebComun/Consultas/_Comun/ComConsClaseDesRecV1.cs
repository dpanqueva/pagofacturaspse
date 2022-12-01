using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsClaseDesRecV1
    {
        private string Mensaje;

        public DataTable ConsConsultarClaseDesResRecV1(ConexionBD oconexion, ComClaseDesRecV1 entidadClaseDesResRecV1)
        {
            string sentencia = "SELECT COD_DESREC,NOM_DESREC, TIP_DESREC, POR_DESREC,APROX,CTRL_LEY_1450,NIT,NOMBRE FROM COM_CLASE_DESREC_V1";

            sentencia += " WHERE 1 = 1";

            DataTable dtsConsulta = new DataTable();

            if((!string.IsNullOrEmpty(entidadClaseDesResRecV1.COD_DESREC))&&(!string.IsNullOrEmpty(entidadClaseDesResRecV1.NOM_DESREC)))
            {
                sentencia = sentencia + " AND UPPER (COD_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.COD_DESREC + "%') OR UPPER (NOM_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.NOM_DESREC + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadClaseDesResRecV1.COD_DESREC))
                {
                    sentencia = sentencia + " AND UPPER COD_DESREC LIKE '%" + entidadClaseDesResRecV1.COD_DESREC + "%'";
                }

                if (!string.IsNullOrEmpty(entidadClaseDesResRecV1.NOM_DESREC))
                {
                    sentencia = sentencia + " AND UPPER(NOM_DESREC) LIKE UPPER('%" + entidadClaseDesResRecV1.NOM_DESREC + "%')";
                }
            }        
         
            sentencia = sentencia + " ORDER BY COD_DESREC";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
