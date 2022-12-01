//PCT.NET_NVO_0000_20190521 - Fecha Inicio 09/03/2021 - Ticket Nº 038738- Caso: se agrega Clase consulta de CTRL_APP - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsCtrlApp
    {
        public string Mensaje;
        public DataTable consConsultarCtrlApp(ConexionBD oConexion, COMCtrlApp EntidadCtrlApp)
        {
            DataTable dtsConsulta = new DataTable();
            string sentencia = "SELECT * FROM CTRL_APP WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadCtrlApp.NOM_APP))
            {
                sentencia += " AND NOM_APP='"+EntidadCtrlApp.NOM_APP+"'";
            }

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
    }
}
