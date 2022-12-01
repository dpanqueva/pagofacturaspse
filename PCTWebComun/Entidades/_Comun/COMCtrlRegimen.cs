/* PCT.NET_NVO_0000_20190521 - Fecha Inicio 24/04/2021 - Ticket Nº 0000 - Caso: se añade Clase Entidad para CTRL_REGIMEN - Participantes: Oscar Ramos*/
// PCT.NET_NVO_0000_20200521 - Fecha Inicio 26/04/2021 - Ticket Nº 040070 - Caso: Se agregan los parametros de la clase entidad CTR_REGIMEN - Participantes: Jaime Zuleta

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCtrlRegimen
    {
        public string FACTURA_I { get; set; }
        public string NUMERO_FACTURAS { get; set; }
        public string RESOLUCION { get; set; }
        public string ESTADO { get; set; }
        public string COD_TIPO { get; set; }
        public string TIPO_FACTURA { get; set; }
        public string REGIMEN { get; set; }
        public string PREFIJO { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string FECHA_INICIO { get; set; }
        public string FECHA_FIN { get; set; }
        public string CLTEC { get; set; }
        public string CONSECUTIVO { get; set; }
        public string DESCRIPCION { get; set; }
        public string FECHA_CONSECUTIVO { get; set; }
        public string RELLENAR_CEROS { get; set; }
    }
}
