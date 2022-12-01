//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/12/2020 - Ticket Nº 0000  - Caso: Se agrega pagina Clase entidad COM_TASAS_CAMBIO, solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 04/12/2020 - Ticket Nº 039019 - Caso: Se agrega pagina entidad COM_TASAS_CAMBIO - Participantes: Milena Leon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMComTasasCambio
    {
        public string ID_COM_TASAS_CAMBIO { get; set; }
        public string COD_MONEDA { get; set; }
        public string VALOR_CAMBIO { get; set; }
        public string FECHA_CAMBIO { get; set; }
        public string USUARIO { get; set; }
        public string FEC_OPERACION { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
    }
}
