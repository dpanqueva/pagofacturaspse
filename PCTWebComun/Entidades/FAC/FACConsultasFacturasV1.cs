//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de PgFACElementosReferencias, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 21/09/2021 - Ticket Nº 0000 - Caso: Se agrega la entidad de CONSULTASFACTURAS_V1  - Participantes: Ingrid GOmez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACConsultasFacturasV1
    {
        public string ID_MFACTURA { get; set; }
        public string COD_TIPO { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_FACTURA { get; set; }
        public string NUM_FACTURA { get; set; }
        public string COD_TASA { get; set; }
        public string NIT { get; set; }
        public string NOMBRE { get; set; }
        public string FECHA_FACTURA { get; set; }
        public string FECHA_FACTURADESDE { get; set; }
        public string ESTADO { get; set; }
        public string ESTADO_FACTURA { get; set; }
        public string VAL_SUBTOTALFAC { get; set; }
        public string VAL_TOTALFAC { get; set; }
        public string VAL_IVAFAC { get; set; }
        public string VAL_RECARGOFAC { get; set; }
        public string VAL_DESCUENTOFAC { get; set; }
        public string VAL_CUENTASCOBRAR { get; set; }
        public string VAL_INTERESCOBRAR { get; set; }
        public string VAL_FPAGO { get; set; }
        public string FECHA_REGISTRO { get; set; }
        public string TIPO_FACTURA { get; set; }
        public string COD_LOCALIZA { get; set; }
        public string DOC_TASA { get; set; }
        public string OBSERVAC { get; set; }
        public string COD_CENTRO { get; set; }
        public string OBS_ANULACION { get; set; }
        public string FEC_ANULA { get; set; }
        public string FECHA_LIMITE { get; set; }
        public string NIT_DIRIGIDO { get; set; }
        public string COD_PROCESO { get; set; }
        public string NOM_PROCESO { get; set; }
        public string CTRL_FAC_ELECTRONICA { get; set; }
        public string NOMBRE_DIRIGIDO { get; set; }
        public string NOM_LOCALIZA { get; set; }
        public string NOTA { get; set; }
		public string COD_CATEGORIA { get; set; }
		public string COD_ELEMENTO { get; set; }
		public string COD_REFERENCIA { get; set; }
        public string COD_CENTRO_USO { get; set; }
        public string PREFIJO { get; set; }
        public string NOM_CATEGORIA { get; set; }
    }
}
