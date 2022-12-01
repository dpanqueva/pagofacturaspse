//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea cpagina de la tabla CTAS_BANCARIAS- Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCtasBancarias
    {
        public string NRO_CTABANCARIA { get; set; }
        public string COD_BANCO { get; set; }
        public string NOM_CTABANCARIA { get; set; }
        public string SUC_BANCO { get; set; }
        public string SUC_DIRECCION { get; set; }
        public string SUC_TELEFONO { get; set; }
        public string SUC_CIUDAD { get; set; }
        public string SUC_GERENTE { get; set; }
        public string ACTIVA { get; set; }
        public string RECURSO_NACION { get; set; }
        public string COD_CONCEPTO { get; set; }
        public string COD_MONEDA { get; set; }
        public string LIBRETA { get; set; }
        public string SALDO_DISPONIBLE { get; set; }
        public string SALDO_CONGELADO { get; set; }
        public string COD_CTA { get; set; }
        public string NRO_CHEQUES { get; set; }
        public string PRIMER_CHEQUE { get; set; }
        public string ULTIMO_CHEQUE { get; set; }
        public string FORMATO_CHEQUE { get; set; }
        public string COD_COMP { get; set; }
        public string SOBREGIRO { get; set; }
        public string VAL_SOBREGIRO { get; set; }
        public string COD_GASTOCTA { get; set; }
        public string TIPO_CTABANCARIA { get; set; }
        public string COD_FORMATO { get; set; }
        public string USUARIO { get; set; }
        public string FEC_CREACION { get; set; }
        public string SALDADA { get; set; }
        public string FEC_SALDADA { get; set; }
        public string USU_SALDADA { get; set; }
        public string SUC_DEPTO { get; set; }
        public string COD_RECURSO { get; set; }
        public string REC_EDUCACION { get; set; }
        public string INDICADOR_SGP { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
    }
}
