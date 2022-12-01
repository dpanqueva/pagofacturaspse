//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACControlPago, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 21/09/2021 - Ticket Nº 0000 - Caso: Se agrega la entidad de CONTROL_PAGO  - Participantes: Ingrid GOmez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACControlPago
    {
        public string VIGENCIA { get; set; }
        public string COD_FACTURA { get; set; }
        public string CLS_FACTURA { get; set; }
        public string COD_PAGO { get; set; }
        public string FECHA_LIMITE { get; set; }
        public string VAL_A_PAGAR { get; set; }
        public string VAL_PORCIENTO { get; set; }
        public string ESTADO { get; set; }
        public string VAL_FPAGO { get; set; }
        public string VAL_INTERES { get; set; }
        public string VAL_PINTERES { get; set; }
        public string VAL_PAGO { get; set; }
        public string VAL_INTERES_ACUMULADO { get; set; }
        public string FECHA_MAX_INTERESES { get; set; }
        public string COD_TIPO { get; set; }
        public string ID_COM_ESTADO_ANT { get; set; }
        public string VAL_INTERESCORRIENTE { get; set; }
    }
}
