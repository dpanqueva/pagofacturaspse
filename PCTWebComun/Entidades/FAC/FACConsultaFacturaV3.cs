//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase entidad de FACTURA_V3, Solicitud de Maribel pedroza- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 23/12/2020 - Ticket N° 039275 - Caso: Se crea la entidad de CONSULTAFACTURA_V3 -  Participantes: Maribel Pedroza

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACConsultaFacturaV3
    {
        public string NIT { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_TIPOING { get; set; }
    }
}
