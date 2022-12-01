// PCT.NET_NVO_0000_20190521 - Fecha Inicio 19/04/2020 - Ticket Nº 0000 - Caso: Se crea clase entidad para NIVEL - Participantes: Oscar Ramos    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMNivel
    {
        public string ARBOL { get; set; }
        public string NIVEL { get; set; }
        public string NOM_NIVEL { get; set; }
        public string TAMANO { get; set; }
        public string NIVEL_MIN { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string TAMANO_NIVEL { get; set; }
        public string TAMANO_PRINT { get; set; }
        public string CARACTER_PRINT { get; set; }
    }
}
