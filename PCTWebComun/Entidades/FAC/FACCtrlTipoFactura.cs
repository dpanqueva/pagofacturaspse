//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/06/2021 - Ticket N° 00000 - Caso: Se agrega Clase Entidad CTRL_TIPO_FACTURA, Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades.FAC
{
    public class FACCtrlTipoFactura
    {
        public string COD_TIPO { get; set; }
        public string COD_SUBTIPO { get; set; }
        public string NOM_TIPO { get; set; }
        public string COD_BARRA { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string NOTA1 { get; set; }
        public string COD_METODO_ENFIRME { get; set; }
        public string VALOR_CERO { get; set; }
        public string COD_BANCO { get; set; }
        public string COD_BARRA_1 { get; set; }
        public string COD_BANCO_1 { get; set; }
        public string ID_TIENDA_PSE { get; set; }
        public string COD_CLAVE_PSE { get; set; }
        public string USERWS_PSE { get; set; }
        public string PASSWS_PSE { get; set; }
        public string COD_SERVICIO_PSE { get; set; }
        public string NRO_CTABANCARIA { get; set; }
        public string COD_RUTA { get; set; }
    }
}

