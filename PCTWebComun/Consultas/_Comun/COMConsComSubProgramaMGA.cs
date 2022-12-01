//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta SubProgramaMGA, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    class COMConsComSubProgramaMGA
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_SUBPROGRAMA_MGA
        public DataTable ConsConsultarComSubProgramaMGA(ConexionBD oconexion, COMComSubProgramaMGA EntidadCOMComSubProgramaMGA)
        {
            string sentencia = "SELECT * FROM COM_SUBPROGRAMA_MGA";
            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(EntidadCOMComSubProgramaMGA.COD_COM_SUBPROGRAMA_MGA)) && (!string.IsNullOrEmpty(EntidadCOMComSubProgramaMGA.NOM_COM_SUBPROGRAMA_MGA)))
            {
                sentencia = sentencia + " AND UPPER(COD_COM_SUBPROGRAMA_MGA) LIKE UPPER('%" + EntidadCOMComSubProgramaMGA.COD_COM_SUBPROGRAMA_MGA + "%') " +
                    "OR UPPER(NOM_COM_SUBPROGRAMA_MGA) LIKE UPPER('%" + EntidadCOMComSubProgramaMGA.NOM_COM_SUBPROGRAMA_MGA + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_COM_SUBPROGRAMA_MGA ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
