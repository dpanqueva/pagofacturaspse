//PCT.NET_NVO_0000_20200430 - Fecha Inicio 21/09/2021 - Ticket Nº 0000 - Caso: Se agrega la entidad de DETALLE_PARAMEFAC  - Participantes: Ingrid GOmez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACDetalleParamefac
    {
        public string COD_PROCESO { get; set; }
        public string COD_CENTRO_USO { get; set; }
        public string NIT { get; set; }
        public string COD_REFERENCIA { get; set; }
        public string COD_PARAMETRO { get; set; }
        public string VAL_PARAMETRO { get; set; }
        public string MES { get; set; }
        public string VAL_MES { get; set; }
        public string COD_FACTURA { get; set; }
        public string FORMULA { get; set; }
        public string SUBFORMULA { get; set; }
        public string VAL_FORMULA { get; set; }
        public string VAL_SUBFORMULA { get; set; }
        public string TIPO { get; set; }
    }
}
