using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMHpptoGastos
    {
        public string COD_SECUENCIA { get; set; }
        public string COD_TRANSACCION { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string FEC_DOCUMENTO { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_UNIDAD { get; set; }
        public string COD_GASTO { get; set; }
        public string COD_RECURSO { get; set; }
        public string VAL_TRANSACCION { get; set; }       

        public string VAL_MODIFICACION { get; set; }
        public string USUARIO { get; set; }
        public string FEC_OPERACION { get; set; }
        public string COD_USO { get; set; }
        public string TIP_OPERACION { get; set; }
        public string NUM_EGRESO { get; set; }
        public string CLS_EGRESO { get; set; }
        public string REG_AUTOMATICO { get; set; }
        public string VALOR_CAMBIO { get; set; }
        public string VIG_FUTURA { get; set; }
        public string CTRL_BIENAL_VA { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string ID_MYP_PERIODO_ADM { get; set; }
        public string VIG_PROYECTO { get; set; }
        public string ID_MYP_PROYECTO { get; set; }
        public string COD_APRUEBA_DOC { get; set; }
        public string USER_APRUEBA_DOC { get; set; }
        public string FEC_APRUEBA_DOC { get; set; }
        public string NRO_MODIFICACION { get; set; }
        public string FEC_DOCUM_APROB { get; set; }

        public int ESTADOREG { get; set; }
    }
}
