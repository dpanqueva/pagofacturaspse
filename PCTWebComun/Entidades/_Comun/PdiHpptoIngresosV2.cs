//PCT.NET_NVO_0000_20190521 - Fecha Inicio 12/07/2020 - Ticket Nº 371302 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Ingresos - Participantes: Edwin Sanchez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class PdiHpptoIngresosV2
    {
        public string ID_COM_ENTIDAD { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_UNIDAD { get; set; }
        public string COD_INGRESO { get; set; }
        public string COD_RECURSO { get; set; }
        public string NOM_INGRESO { get; set; }
        public string SEC_OPERACION { get; set; }
        public string RUBRO { get; set; }
        public string RUBRO_AUX { get; set; }
        public string INGRESO { get; set; }
        public string INGRESO_AUX { get; set; }
        public string VAL_TRANSACCION { get; set; }
        public string COD_TRANSACCION { get; set; }
        public string DES_TRANSACCION { get; set; }
        public string FEC_TRANSACCION { get; set; }
        public string FEC_OPERACION { get; set; }
        public string USUARIO { get; set; }
        public string VALOR_CAMBIO { get; set; }
    }
}
