//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACClaseElementosServicios, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/10/2021 - Ticket N° 040676 - Caso: Se agrega entidad de la tabla CLASE_ELEMENTOSSERVICIO , Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACClaseElementosServicios
    {
        public string COD_ELEMENTO { get; set; }
        public string NOM_ELEMENTO { get; set; }
        public string COD_CATEGORIA { get; set; }
        public string VIGENCIA { get; set; }
        public string PERECEDERO { get; set; }
        public string IVA { get; set; }
        public string NOTA { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
    }
}
