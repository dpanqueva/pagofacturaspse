//PCT.NET_NVO_0000_2019using System.Collections.Generic;0521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se añaden los campos Query- Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021 - Ticket Nº 39019 - Caso: se añaden los campos Query QNitsEgresoMB - Participantes: Milena Leon 

using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.CamposQueries._Comun
{
    public class ComCQNit
    {
        public string COD_MUNICIPIO { get; set; }
        public string NOM_MUNICIPIO { get; set; }
        public string NIT { get; set; }
        public string CLASE_NIT { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
        public string TIPO_NIT { get; set; }
        public string COD_NATURALEZA { get; set; }
        public string NOMBRE { get; set; }
        public string COD_DEPTO { get; set; }
        public string COD_MUNIC { get; set; }
        public string COLUMNAR { get; set; }

        //PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021 
        public string NUM_ORDEN { get; set; }

    }
}
