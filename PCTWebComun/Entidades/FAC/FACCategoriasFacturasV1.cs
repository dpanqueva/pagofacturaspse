//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase entidad CATEGORIAS_FACTURAS_V1, solicitud de Ingrid Gomez - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la entidad de CATEGORIAS_FACTURAS_V1 - Participantes: Ingrid GOmez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PCTWebComun.Entidades.FAC
{
    public class FACCategoriasFacturasV1
    {
        public string NIT { get; set; }
        public string COD_TIPOING { get; set; }
        public string NIVEL { get; set; }
        public string COD_CATEGORIA { get; set; }
        public string NOM_CATEGORIA { get; set; }

    }
}
