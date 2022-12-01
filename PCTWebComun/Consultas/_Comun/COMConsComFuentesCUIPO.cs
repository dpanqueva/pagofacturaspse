//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/07/2021 - Ticket Nº 00000 - Caso: Se agrega Clase Consulta FuentesCUIPO, Solicitud de Maribel Pedroza - Participantes: Oscar Ramos

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
    class COMConsComFuentesCUIPO
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla COM_FUENTES_CUIPO
        public DataTable ConsConsultarComFuentesCUIPO(ConexionBD oconexion, COMComFuentesCUIPO EntidadCOMComFuentesCUIPO)
        {
            string sentencia = "SELECT * FROM COM_FUENTES_CUIPO";
            DataTable dtsConsulta = new DataTable();

            if ((!string.IsNullOrEmpty(EntidadCOMComFuentesCUIPO.COD_COM_FUENTES_CUIPO)) && (!string.IsNullOrEmpty(EntidadCOMComFuentesCUIPO.NOM_COM_FUENTES_CUIPO)))
            {
                sentencia = sentencia + " AND UPPER(COD_COM_FUENTES_CUIPO) LIKE UPPER('%" + EntidadCOMComFuentesCUIPO.COD_COM_FUENTES_CUIPO + "%') " +
                    "OR UPPER(NOM_COM_FUENTES_CUIPO) LIKE UPPER('%" + EntidadCOMComFuentesCUIPO.NOM_COM_FUENTES_CUIPO + "%')";
            }

            sentencia = sentencia + " ORDER BY COD_COM_FUENTES_CUIPO ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
