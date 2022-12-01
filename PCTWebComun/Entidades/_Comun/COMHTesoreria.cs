//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/10/2020 - Ticket N° 037563 - Caso: Se crea entidad para HTESORERIA - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMHTesoreria
    {
        public string SEC_OPERACION { get; set; }
        public string COD_TRANSACCION { get; set; }
        public string FEC_TRANSACCION { get; set; }
        public string TIP_OPERACION { get; set; }
        public string NRO_CTABANCARIA { get; set; }
        public string COD_BANCO { get; set; }
        public string CONCEPTO { get; set; }
        public string BENEFICIARIO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string VAL_TRANSACCION { get; set; }
        public string COD_UNIDAD { get; set; }
        public string COD_CAJA { get; set; }
        public string USUARIO { get; set; }
        public string FEC_CONCILIACION { get; set; }
        public string FEC_OPERACION { get; set; }
        public string NUM_REGISTRO { get; set; }
        public string VALOR_CAMBIO { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
    }
}
