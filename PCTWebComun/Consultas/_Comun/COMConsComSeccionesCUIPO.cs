//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta SeccionesCUIPO, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    class COMConsComSeccionesCUIPO
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_SECCIONES_CUIPO
        public DataTable ConsConsultarComSeccionesCUIPO(ConexionBD oconexion, COMComSeccionesCUIPO EntidadCOMComSeccionesCUIPO)
        {
            string sentencia = "SELECT * FROM COM_SECCIONES_CUIPO";
            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(EntidadCOMComSeccionesCUIPO.COD_COM_SECCIONES_CUIPO)) && (!string.IsNullOrEmpty(EntidadCOMComSeccionesCUIPO.NOM_COM_SECCIONES_CUIPO)))
            {
                sentencia = sentencia + " AND UPPER(COD_COM_SECCIONES_CUIPO) LIKE UPPER('%" + EntidadCOMComSeccionesCUIPO.COD_COM_SECCIONES_CUIPO + "%') OR UPPER(NOM_COM_SECCIONES_CUIPO) LIKE UPPER('%" + EntidadCOMComSeccionesCUIPO.NOM_COM_SECCIONES_CUIPO + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_COM_SECCIONES_CUIPO ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
