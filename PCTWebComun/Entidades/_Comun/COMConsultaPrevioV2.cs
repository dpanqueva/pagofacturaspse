//PCT.NET_NVO_0000_20191031 - Fecha Inicio 24/03/2021 - Ticket Nº 0000 - Caso: Se agrega js de Planeacion Precontra - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20191031 - Fecha Inicio 07/03/2021 - Ticket N° 039764 - Caso: Se adiciona campos  consulta Planeacion precontractual - Participantes: Milena Leon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMConsultaPrevioV2
    {
        public string VIGENCIA { get; set; }

        public string NUM_PREVIO{ get; set; }

        //PCT.NET_NVO_0000_20191031 - Fecha Inicio 07/03/2021
        public string NIT_DESIGNADO { get; set; }
        public string FECHA_ELABORACION { get; set; }
        public string NIT_SUPERVISOR { get; set; }
        public string VALOR_PRESUPUESTADO { get; set; }
        public string COD_CENTRO { get; set; }
        public string ESTADO { get; set; }

    }
}
