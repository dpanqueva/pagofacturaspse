//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta ProgramaticoMGA, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    class COMConsComProgramaticoMGA
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_PROGRAMATICO_MGA
        public DataTable ConsConsultarComProgramaticoMGA(ConexionBD oconexion, COMComProgramaticoMGA EntidadCOMComProgramaticoMGA)
        {
            string sentencia = "SELECT * FROM COM_PROGRAMATICO_MGA";
            DataTable dtsConsulta = new DataTable();
                        
            if ((!string.IsNullOrEmpty(EntidadCOMComProgramaticoMGA.COD_COM_PROGRAMATICO_MGA)) && (!string.IsNullOrEmpty(EntidadCOMComProgramaticoMGA.COD_COM_PROGRAMATICO_MGA)))
            {
                sentencia = sentencia + " AND UPPER(COD_COM_PROGRAMATICO_MGA) LIKE UPPER('%" + EntidadCOMComProgramaticoMGA.COD_COM_PROGRAMATICO_MGA + "%') " +
                    "OR UPPER(NOM_COM_PROGRAMATICO_MGA) LIKE UPPER('%" + EntidadCOMComProgramaticoMGA.NOM_COM_PROGRAMATICO_MGA + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_COM_PROGRAMATICO_MGA ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
