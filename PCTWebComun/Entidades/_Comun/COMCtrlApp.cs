//PCT.NET_NVO_0000_20190521 - Fecha Inicio 09/03/2021 - Ticket Nº 038738- Caso: se agrega Clase Entidad de CTRL_APP - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCtrlApp
    {
        public string NOM_APP { get; set; }
        public string VER_APP { get; set; }
        public string FEC_APP { get; set; }
        public string NOTAS_APP { get; set; }
        public string WEB_INDEX { get; set; }
        public string NOM_EXE { get; set; }
        public string ACTIVAR { get; set; }
        public string ORDEN { get; set; }
        public string AUTH { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
    }
}
