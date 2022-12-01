//PCT.NET_NVO_0000_20200430 - Fecha Inicio 08/10/2020 - Ticket N° 038350 - Caso: Se agrega pagina para la Entidad CTRL_TESORERIA - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCtrlTesoreria
    {
        public string SEC_OPERACION { get; set; }
        public string COD_TIPOING_TRAS { get; set; }
        public string COD_PAGOT_TRAS { get; set; }
        public string NIT_TRAS { get; set; }
        public string DOCS_TESORALES { get; set; }
        public string N_TIPO_NIT { get; set; }
        public string N_CLASE_NIT { get; set; }
        public string N_COD_DEPTO { get; set; }
        public string N_TIPO_DOCUMENTO { get; set; }
        public string VIGENCIA_CERRADA { get; set; }
        public string TRAS_CHEQUES { get; set; }
        public string TRAS_ACREEDORES { get; set; }
        public string TRAS_RC_EFECTIVO { get; set; }
        public string TRAS_RC_CHEQUES { get; set; }
        public string TRAS_CONCILIA { get; set; }
        public string CTRL_PAC { get; set; }
        public string CTRL_MB_MO { get; set; }
        public string COD_CHE_DEV_ING { get; set; }
        public string SHOW_CTAS_EGRES { get; set; }
        public string CTRL_FEC_FAC_ING { get; set; }
        public string CTRL_FECHAS_IMP { get; set; }
        public string DXC_RENTAS { get; set; }
        public string CHK_PARTIALPAY { get; set; }
        public string CTRL_CTA_TRANSFER { get; set; }
        public string HOJA_NVA_MB { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string RPT_RECIBOCAJA { get; set; }
        public string CTRL_NIT_REINTEGRO { get; set; }
        public string SHOW_DETALLE_LIQ { get; set; }
        public string SHOW_DISTRI_DEV { get; set; }
    }
}
