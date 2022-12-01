//PCT.NET_NVO_0000_20190521 - Fecha Inicio 12/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class ComTransacciones
    {
        public string COD_TRANSACCION { get; set; }
        public string NOM_TRANSACCION { get; set; }

        public string DES_TRANSACCION { get; set; }

        public string MODULO { get; set; }

        public string SUBMODULO { get; set; }

        public string ID_COM_ENTIDAD { get; set; }

        public string USUARIO { get; set; }

    }
}
