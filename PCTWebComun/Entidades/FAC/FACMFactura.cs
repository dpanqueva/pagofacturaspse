//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase entidad de MFACTURA, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACMFactura
    {
        public string NIT { get; set; }
        public string ESTADO { get; set; }
        public string VIGENCIA { get; set; }
        public string COD_FACTURA { get; set; }
        public string COD_TIPO { get; set; }
    }
}
