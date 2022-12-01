//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/12/2020 - Ticket Nº 0000  - Caso: Se agrega pagina la entidad NOTAS_TRASLADOS, solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 07/12/2020 - Ticket Nº 039019 - Caso: Se agrega entidad NOTAS_TRASLADOS - Participantes: Milena Leon 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMNotasTraslados
    {
        public string NUM_TRASLADO { get; set; }
        public string NUM_INGRESO { get; set; }
        public string NUM_EGRESO { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
    }
}
