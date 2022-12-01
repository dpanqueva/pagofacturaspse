//PCT.NET_NVO_0000_20200604 - Fecha Inicio 04/06/2020 - Ticket Nº 037564 - Caso: se crea la consulta de la tabla ACCIONES- Participantes: Maribel Pedroza
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
    public class ComConsAcciones
    {
        public string Mensaje;
        public Boolean ConsConsultarAcciones(ComAcciones EntidadAcciones, ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            Boolean respuesta = new Boolean();
            string sentencia = "SELECT * FROM ACCIONES WHERE COD_ACCION ='" + EntidadAcciones.COD_ACCION + "' ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            if (dtConsulta != null)
            {
                if (dtConsulta.Rows.Count > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }


        public DataTable ConsConsultarNombreAcciones(ConexionBD oConexion, ComAcciones EntidadAcciones)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT NOM_ACCION FROM ACCIONES WHERE COD_ACCION='" + EntidadAcciones.COD_ACCION+"'";
            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
