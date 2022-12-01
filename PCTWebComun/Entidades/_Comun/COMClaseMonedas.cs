//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea controlador de la tabla CLASE_MONEDAS- Participantes: Oscar Ramos


using DocumentFormat.OpenXml.Office.CoverPageProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMClaseMonedas
    {
      public string COD_MONEDA { get; set; }      
      public string NOM_MONEDA { get; set; }      
      public string PAIS_MONEDA { get; set; }      
      public string ID_COM_ENTIDAD { get; set; }
      public string USUARIO { get; set; }
      public string CTA_TRM_MAYOR { get; set; }
      public string CTA_TRM_MENOR { get; set; }
      public string MONEDA_LOCAL { get; set; }
    }
}
