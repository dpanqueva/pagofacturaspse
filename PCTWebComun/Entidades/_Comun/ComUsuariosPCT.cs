//PCT.NET_NVO_0000_20190521 - Fecha Inicio 15/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class ComUsuariosPCT
    {
        public string USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string COD_UNIDAD { get; set; }
        public string FOTO { get; set; }
        public string FEC_OPERACION { get; set; }
        public string ADMINISTRADOR { get; set; }
        public string ID_COM_USUARIO { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string FEC_CLAVE { get; set; }
        public string ACTIVO { get; set; }
        public string CLAVE { get; set; }

    }
}
