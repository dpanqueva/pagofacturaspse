//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACConsDetalleParamefac, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase DETALLE_PARAMEFAC: Ingrid Gomez

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
    public class FACConsDetalleParamefac
    {
        public string Mensaje;

        public DataTable ConsultarDetallaparamefac(ConexionBD oConexion, FACDetalleParamefac EntidadConsultaDetallaparamefac)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT COD_FACTURA, NIT, COD_CENTRO_USO, COD_REFERENCIA, COD_PARAMETRO, VAL_PARAMETRO," +
                "DECODE(ESTADO, 10,'Vencida',11,'No Vencida',12,'Vencida', 13,'Total Paga',  14,'Tot Cuota,Par Interes ', 15,'Par Cuota,Tot Interes', 16,'Par Cuota, Par Interes', 17,'Tot Cuota,No Interes',18,'No Cuota,Tot Interes', 19,'Cuota  en proceso adiccionar a Prorrogada',20,'en prooceso de prrroga' , 21,'creada por prorroga prorroga', 22, 'prorrogada', 23,'anulada cuota por factura  anulada')ESTADO_FACTURA, " +
                "VAL_SUBFORMULA,VAL_FORMULA,TIPO,FORMULA " +
                "FROM DETALLE_PARAMEFAC WHERE COD_FACTURA <> '0' " +
                "AND COD_FACTURA = " + EntidadConsultaDetallaparamefac.COD_FACTURA + " ";

            sentencia += "ORDER BY TIPO, COD_PARAMETRO";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }
    }
}
