//PCT.NET_NVO_0000_20190521 - Fecha Inicio 15/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Web;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsUsuariosPCT
    {
        public string Mensaje;

        public DataTable ConsConsultarUsuariosPCT(ConexionBD oConexion, ComUsuariosPCT EntidadUsuariosPCT)
        {
            string sentencia = "";
            DataTable dtConsulta = new DataTable();

            sentencia = " SELECT * FROM USUARIOS_PCT WHERE USUARIO <> '0'";

            if ((!string.IsNullOrEmpty(EntidadUsuariosPCT.NOMBRE)) && (!string.IsNullOrEmpty(EntidadUsuariosPCT.USUARIO)))
            {
                sentencia = sentencia + " AND (UPPER(USUARIO) LIKE '%" + EntidadUsuariosPCT.USUARIO.ToUpper() + "%' OR UPPER(NOMBRE) LIKE '%" + EntidadUsuariosPCT.NOMBRE.ToUpper() + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(EntidadUsuariosPCT.NOMBRE))
                {
                    sentencia = sentencia + " AND UPPER(NOMBRE) LIKE '%" + EntidadUsuariosPCT.NOMBRE.ToUpper() + "%'";
                }

                if (!string.IsNullOrEmpty(EntidadUsuariosPCT.USUARIO))
                {
                    sentencia = sentencia + " AND UPPER(USUARIO) LIKE '%" + EntidadUsuariosPCT.USUARIO.ToUpper() + "%'";
                }

            }
            sentencia = sentencia + " ORDER BY USUARIO, NOMBRE";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
