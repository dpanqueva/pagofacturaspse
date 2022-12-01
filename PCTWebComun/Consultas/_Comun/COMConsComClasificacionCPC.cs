//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta ClasificacionCPC, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    class COMConsComClasificacionCPC
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_CLASIFICACION_CPC
        public DataTable ConsConsultarComClasificacionCPC(ConexionBD oconexion, COMComClasificacionCPC EntidadCOMComClasificacionCPC)
        {
            string sentencia = "SELECT * FROM COM_CLASIFICACION_CPC";
            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(EntidadCOMComClasificacionCPC.COD_CLASIFICACION)) && (!string.IsNullOrEmpty(EntidadCOMComClasificacionCPC.NOM_CLASIFICACION)))
            {
                sentencia = sentencia + " AND UPPER(COD_CLASIFICACION) LIKE UPPER('%" + EntidadCOMComClasificacionCPC.COD_CLASIFICACION + "%') " +
                    "OR UPPER(NOM_CLASIFICACION) LIKE UPPER('%" + EntidadCOMComClasificacionCPC.NOM_CLASIFICACION + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_CLASIFICACION ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
