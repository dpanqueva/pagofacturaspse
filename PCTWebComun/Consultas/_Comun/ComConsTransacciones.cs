//PCT.NET_NVO_0000_20190521 - Fecha Inicio 12/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

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
    public class ComConsTransacciones
    {
        public string Mensaje;

        public DataTable ConsConsultarTransacciones(ConexionBD oConexion, ComTransacciones EntidadTransacciones)
        {
            string sentencia = "";
            DataTable dtConsulta = new DataTable();

            sentencia = " SELECT * FROM TRANSACCIONES WHERE MODULO <> '0' ";

            if (!string.IsNullOrEmpty(EntidadTransacciones.MODULO))
            {
                sentencia = sentencia + " AND UPPER(MODULO) = '" + EntidadTransacciones.MODULO.ToUpper() + "'";
            }

            if (!string.IsNullOrEmpty(EntidadTransacciones.SUBMODULO))
            {
                sentencia = sentencia + " AND UPPER(SUBMODULO) = '" + EntidadTransacciones.SUBMODULO.ToUpper() + "'";
            }

            if (!string.IsNullOrEmpty(EntidadTransacciones.COD_TRANSACCION))
            {
                sentencia = sentencia + " AND COD_TRANSACCION  IN (" + EntidadTransacciones.COD_TRANSACCION + ")";
            }

            sentencia = sentencia + " ORDER BY MODULO, SUBMODULO, COD_TRANSACCION";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }



    }
}
