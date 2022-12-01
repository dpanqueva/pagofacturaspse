//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACConsCentroUsos, Solicitud de Ingrid - Participantes: Maribel Pedroza
// PCT.NET_NVO_0000_20200430 - Fecha Inicio 25 / 01 / 2021 - Ticket N° 039442 - Caso: Se crea CLASE_CENTRO_USOS_V1 - Participantes: Karen Gaviria

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
    public class FACConsCentroUsos
    {
        public string Mensaje;
        public DataTable ConsConsultaCentrosdeusocon(ConexionBD oconexion, FACCentroUsos EntidadCentrosdeuso)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT  A.*, B.CENTRO_USO,C.NOMBRE,B.NUM_CENTRO " +
                                "FROM CENTRO_USOS A,CENTRO B,NIT C " +
                                "WHERE B.COD_CENTRO_USO=A.COD_CENTRO_USO " +
                                "AND C.NIT=A.NIT ";

            sentencia += " ORDER BY A. NIT,B.CENTRO_USO ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
