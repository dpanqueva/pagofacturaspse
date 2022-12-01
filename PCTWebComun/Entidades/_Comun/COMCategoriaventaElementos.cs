//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se entidad de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCategoriaventaElementos
    {
        public string VIGENCIA { get;  set; }
        public string COD_CATEGORIA { get; set; }
        public string NOM_CATEGORIA { get; set; }
        public string COD_PADRE { get; set; }
        public string NIVEL { get; set; }
        public string NRO_NIVEL { get; set; }
        public string TIPO { get; set; }
        public string FORMULA_DEPRECIA { get; set; }
        public string COD_CTA { get; set; }
        public string DB_CR { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string COD_TIPO_CALCULO { get; set; }
        public string ACTIVO { get; set; }
    }
}
