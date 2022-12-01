//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCategoriaVentaElementos, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/10/2021 - Ticket N° 040676 - Caso: Se agrega entidad de la tabla CATEGORIAVENTA_ELEMENTOS, Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACCategoriaVentaElementos	
    {
		public string VIGENCIA{ get; set; }
		public string COD_CATEGORIA{ get; set; }
		public string NOM_CATEGORIA{ get; set; }
		public string COD_PADRE{ get; set; }
		public string NIVEL{ get; set; }
		public string NRO_NIVEL{ get; set; }
		public string TIPO{ get; set; }
		public string FORMULA_DEPRECIA{ get; set; }
		public string COD_CTA{ get; set; }
        public string DB_CR{ get; set; }
		public string ID_COM_ENTIDAD{ get; set; }
		public string USUARIO{ get; set; }
		public string COD_TIPO_CALCULO{ get; set; }
		public string ACTIVO{ get; set; }
    }
}
