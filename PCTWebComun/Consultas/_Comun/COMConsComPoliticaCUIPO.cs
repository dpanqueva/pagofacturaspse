//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta PoliticaCUIPO, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    class COMConsComPoliticaCUIPO
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_POLITICA_CUIPO
        public DataTable ConsConsultarComPoliticaCUIPO(ConexionBD oconexion, COMComPoliticaCUIPO EntidadCOMComPoliticaCUIPO)
        {
            string sentencia = "SELECT * FROM COM_POLITICA_CUIPO";
            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(EntidadCOMComPoliticaCUIPO.COD_COM_POLITICA_CUIPO)) && (!string.IsNullOrEmpty(EntidadCOMComPoliticaCUIPO.NOM_COM_POLITICA_CUIPO)))
            {
                sentencia = sentencia + " AND UPPER(COD_COM_POLITICA_CUIPO) LIKE UPPER('%" + EntidadCOMComPoliticaCUIPO.COD_COM_POLITICA_CUIPO + "%') OR UPPER(NOM_COM_POLITICA_CUIPO) LIKE UPPER('%" + EntidadCOMComPoliticaCUIPO.NOM_COM_POLITICA_CUIPO + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_COM_POLITICA_CUIPO ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
