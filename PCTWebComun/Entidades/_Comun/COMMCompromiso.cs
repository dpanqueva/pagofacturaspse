//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2021 - Ticket Nº 35554  - Caso: se crea clase Entidad de la tabla MCOMPROMISO - Participantes: Oscar Ramos.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMMCompromiso
    {
        public string VIGENCIA { get; set; }
        public string NUM_COMPROMISO { get; set; }
        public string FEC_COMPROMISO { get; set; }
        public string OBJ_COMPROMISO { get; set; }
        public string NUM_CERTIFICADO { get; set; }
        public string TIPO_COMPROMISO { get; set; }
        public string NRO_DOCUMENTO { get; set; }
        public string CLASE_DOCUMENTO { get; set; }
        public string FEC_DOCUMENTO { get; set; }
        public string FEC_VENCE_DOCUMENTO { get; set; }
        public string FORMALIDADES_PLENAS { get; set; }
        public string NIT { get; set; }
        public string COD_CENTRO { get; set; }
        public string COD_REGION { get; set; }
        public string ESTADO { get; set; }
        public string FEC_ANULADO { get; set; }
        public string CONTRIBUCION { get; set; }
        public string RP_CONTRIBUCION { get; set; }
        public string CASTIGO { get; set; }
        public string NUM_COMPROMISO_VA { get; set; }
        public string COD_DEPTO { get; set; }
        public string COD_MUNIC { get; set; }
        public string VALOR_CAMBIO { get; set; }
        public string CTA_BANCO { get; set; }
        public string COD_BANCO { get; set; }
        public string TIPO_CTA { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string RP_NOMINA { get; set; }
        public string VIGENCIA_VA { get; set; }
        public string CTRL_PASIVO_EXIGIBLE { get; set; }
        public string INT_CONTRATO { get; set; }
        public string COD_APRUEBA_DOC { get; set; }
        public string USER_APRUEBA_DOC { get; set; }
        public string FEC_APRUEBA_DOC { get; set; }
        public string ID_PDG_PROCESOS_PPTO { get; set; }
        public string REPORTADO_APP { get; set; }
        public string FEC_REPORTADO_APP { get; set; }
    }
}
