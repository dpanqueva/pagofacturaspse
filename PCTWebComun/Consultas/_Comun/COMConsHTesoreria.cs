//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/11/2020 - Ticket N° 0000 - Caso: Se agrega clase consulta de HTESORERIA a solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/12/2020 - Ticket N° 039019 - Caso: Se agrega  consulta de HTESORERIA - Participantes: Milena Leon

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
    public class COMConsHTesoreria
    {
        public string Mensaje;

        public DataTable ConsConsultaHTesoreria(ConexionBD oConexion, COMHTesoreria EntidadHTesoreria)
        {
            string sentencia = " SELECT * FROM  HTESORERIA WHERE  1=1";


            if (!string.IsNullOrEmpty(EntidadHTesoreria.FEC_CONCILIACION))
            {
                sentencia += " AND FEC_CONCILIACION  = " + EntidadHTesoreria.FEC_CONCILIACION;
            }
            else
            {
                sentencia += " AND FEC_CONCILIACION IS NOT NULL";
            }

            if (!string.IsNullOrEmpty(EntidadHTesoreria.NRO_DOCUMENTO))
            {
                sentencia += " AND NRO_DOCUMENTO ='" + EntidadHTesoreria.NRO_DOCUMENTO + "'";
            }
            if (!string.IsNullOrEmpty(EntidadHTesoreria.COD_TRANSACCION))
            {
                sentencia += " AND COD_TRANSACCION ='" + EntidadHTesoreria.COD_TRANSACCION + "'";
            }

            sentencia += " ORDER BY NRO_DOCUMENTO";

            DataTable dtsConsulta;

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
        public bool ConsInsertarHTesoreria(ConexionBD oConexion, COMHTesoreria EntidadHTesoreria)
        {
            DataTable dtsConsulta;
            bool resultado;

            string sentenciaMaxFecha = " SELECT TO_DATE(MAX(FECHA), 'DD/MM/YY')FECHA FROM CTRL_MODULO WHERE MODULO = 'TESORERIA' AND SUBMODULO NOT IN ('CHEQUES')";
            dtsConsulta = oConexion.Consulta(sentenciaMaxFecha);

            string sentencia = "INSERT INTO HTESORERIA (SEC_OPERACION, COD_TRANSACCION, FEC_TRANSACCION, TIP_OPERACION, NRO_CTABANCARIA, COD_BANCO, CONCEPTO, VAL_TRANSACCION, USUARIO, FEC_OPERACION)" +
                " VALUES (0, 71, '" + EntidadHTesoreria.FEC_TRANSACCION + "' , 'V', '" + EntidadHTesoreria.NRO_CTABANCARIA + "','" + EntidadHTesoreria.COD_BANCO + "', '" + EntidadHTesoreria.CONCEPTO + "', 0, USER, SYSDATE)";

            resultado = oConexion.EjecutarSQL(sentencia);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }
    }
}
