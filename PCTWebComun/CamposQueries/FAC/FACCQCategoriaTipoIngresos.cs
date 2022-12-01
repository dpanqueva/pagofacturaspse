//PCT.NET_NVO_0000_20200521 - Fecha Inicio 17 / 09 / 2021 - Ticket Nº 0000 - Caso: Se agrega FACCQCategoriaTipoIngresos, solicitud de Alveiro - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 17/09/2021 - Ticket Nº 0000  - Caso: se agregra query para la tabla  CATEGORIA_TIPO_INGRESOS - Participantes: Ingrid Gomez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.CamposQueries.FAC
{
    public class FACCQCategoriaTipoIngresos
    {
        public string VIGENCIA { get; set; }
        public string COD_CATEGORIA { get; set; }

        public string NOM_CATEGORIA { get; set; }
        public string COD_TIPOING { get; set; }
        public string NOM_TIPOING { get; set; }
        public string COD_TIPO { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
    }
}
