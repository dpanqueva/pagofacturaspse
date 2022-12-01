//PCT.NET_NVO_0000_20200430 - Fecha Inicio 10/02/2021 - Ticket N° 039274 - Caso: Se agrega el metodo para incrementar el consucutivo de CTRL_MODULO - Participantes: Jaime Zuleta
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsCtrlModulo
    {
        public string Mensaje;

        public DataTable ConsConsultarCtrlModulo(ConexionBD oconexion, COMCtrlModulo EntidadCtrlModulo)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM CTRL_MODULO WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadCtrlModulo.MODULO))
            {
                sentencia += " AND MODULO = '" + EntidadCtrlModulo.MODULO + "'";
            }
            if (!string.IsNullOrEmpty(EntidadCtrlModulo.SUBMODULO))
            {
                sentencia += " AND SUBMODULO = '" + EntidadCtrlModulo.SUBMODULO + "'";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public Boolean ConsUpdateConsecutivoCtrlModulo(ConexionBD oconexion, COMCtrlModulo EntidadCtrlModulo)
        {
            Boolean res;
            String Sentencia = "UPDATE CTRL_MODULO SET CONSECUTIVO = CONSECUTIVO + 1 WHERE MODULO = '" + EntidadCtrlModulo.MODULO + "' AND SUBMODULO = '" + EntidadCtrlModulo.SUBMODULO + "'";

            res = oconexion.EjecutarSQL(Sentencia);
            Mensaje = oconexion.Mensaje;

            return res;
        }
    }
}
