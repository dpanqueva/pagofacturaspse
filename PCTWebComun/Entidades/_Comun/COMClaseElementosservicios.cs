//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se entidad de CLASE_ELEMENTOSSERVICIOS - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMClaseElementosservicios
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
