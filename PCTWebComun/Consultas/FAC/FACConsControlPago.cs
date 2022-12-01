//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACConsControlPago, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase CONTROL_PAGO: Ingrid Gomez

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
    public class FACConsControlPago
    {
        public string Mensaje;

        public DataTable ConsultarConsControlPago(ConexionBD oConexion, FACControlPago EntidadConsultaControlPago)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT VIGENCIA,COD_FACTURA,COD_PAGO,FECHA_LIMITE,VAL_A_PAGAR,VAL_PORCIENTO, " +
                "DECODE(ESTADO, 10,'Vencida',11,'No Vencida',12,'Vencida', 13,'Total Paga',  14,'Tot Cuota,Par Interes ', 15,'Par Cuota,Tot Interes', 16,'Par Cuota, Par Interes', 17,'Tot Cuota,No Interes',18,'No Cuota,Tot Interes', 19,'Cuota  en proceso adiccionar a Prorrogada',20,'en prooceso de prrroga' , 21,'creada por prorroga prorroga', 22, 'prorrogada', 23,'anulada cuota por factura  anulada')ESTADO_FACTURA, " +
                "VAL_FPAGO,VAL_INTERES,VAL_PINTERES,VAL_PAGO,VAL_INTERES_ACUMULADO,FECHA_MAX_INTERESES,VAL_INTERESCORRIENTE " +
                "FROM CONTROL_PAGO WHERE COD_FACTURA <> '0' " +
                "AND COD_FACTURA = '" + EntidadConsultaControlPago.COD_FACTURA + "' " +
                "AND VIGENCIA = " + EntidadConsultaControlPago.VIGENCIA + " ";          
            
            sentencia += "ORDER BY COD_FACTURA";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
