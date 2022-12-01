using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
   public class ComCambiosEntidades<T>
    {
        public List<T> ItemsNuevos { get; set; }
        public List<T> ItemsActualizados { get; set; }
        public List<T> ItemsEliminados { get; set; }
        
    }
}
