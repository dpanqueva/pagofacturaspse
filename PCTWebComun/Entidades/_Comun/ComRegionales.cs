//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade la clase - Participantes: Maribel Pedroza

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class ComRegionales
    {
        public string COD_REGION { get; set; }
        public string NOM_REGION { get; set; }
        public string COD_PADRE { get; set; }
        public string NRO_NIVEL { get; set; }
        public string NIVEL { get; set; }
        public string CORPES { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }

    }
}
