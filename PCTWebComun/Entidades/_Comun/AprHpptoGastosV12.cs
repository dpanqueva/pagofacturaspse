//PCT.NET_NVO_0000_20190521 - Fecha Inicio 12/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class AprHpptoGastosV12
    {
        public string ID_COM_ENTIDAD { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_UNIDAD { get; set; }
        public string COD_GASTO { get; set; }
        public string COD_RECURSO { get; set; }
        public string NOM_GASTO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string RUBRO { get; set; }
        public string RUBRO_AUX { get; set; }
        public string GASTO { get; set; }
        public string GASTO_AUX { get; set; }
        public string VAL_TRANSACCION { get; set; }
        public string COD_TRANSACCION { get; set; }
        public string DES_TRANSACCION { get; set; }
        public string FEC_DOCUMENTO { get; set; }
        public string FEC_OPERACION { get; set; }
        public string USUARIO { get; set; }
        public string VALOR_CAMBIO { get; set; }
    }
}
