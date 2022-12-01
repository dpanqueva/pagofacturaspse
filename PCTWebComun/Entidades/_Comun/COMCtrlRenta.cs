//PCT.NET_NVO_0000_20190521 - Fecha Inicio 17/12/2020 - Ticket Nº 0000  - Caso: se agrega clase entidad de CTRL_RENTA, Solicitud de Jaime Zuleta- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 17/12/2020 - Ticket N° 039274 - Caso: Se agregan los campos de la tabla CTRL_RENTA - Participantes: Jaime Zuleta

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Entidades._Comun
{
    public class COMCtrlRenta
    {
        public string VIGENCIA { get; set; }
        public string DESC_MOROSOS { get; set; }
        public string COD_IMPTO { get; set; }
        public string NOM_IMPTO { get; set; }
        public string COD_SUBIMPTO { get; set; }
        public string NOM_SUBIMPTO { get; set; }
        public string RPT_PREDIAL { get; set; }
        public string PORC_DEPTO { get; set; }
        public string PORC_MUN { get; set; }
        public string TIPO_VENCIMIENTO { get; set; }
        public string INTEGRADO { get; set; }
        public string FEC_ULTIMA { get; set; }
        public string FORMULACION { get; set; }
        public string VIGENCIA_INICIAL { get; set; }
        public string FORMULA { get; set; }
        public string NOM_FORMULA { get; set; }
        public string FEC_INI { get; set; }
        public string FEC_FIN { get; set; }
        public string VENCIMIENTO { get; set; }
        public string PERIODO { get; set; }
        public string FEC_LEY_1069 { get; set; }
        public string CTRL_CIERRE { get; set; }
        public string FEC_CIERRE { get; set; }
        public string CTRL_TRAS_BASICOS { get; set; }
        public string FEC_TRAS_BASICOS { get; set; }
        public string COD_UNIDAD { get; set; }
        public string COD_TIPOING { get; set; }
        public string CON_TIPOING { get; set; }
        public string COD_CENTRO { get; set; }
        public string COD_FORMULA { get; set; }
        public string INTERES_ACUERDO_PAG { get; set; }
        public string TIPO_INTERES { get; set; }
        public string COD_BANCO { get; set; }
        public string NOM_BANCO { get; set; }
        public string TEXTO1_APAGO { get; set; }
        public string TEXTO2_APAGO { get; set; }
        public string TEXTO3_APAGO { get; set; }
        public string TEXTO4_APAGO { get; set; }
        public string TEXTO5_APAGO { get; set; }
        public string TEXTO6_APAGO { get; set; }
        public string REDONDEO { get; set; }
        public string VIGENCIA_CERRADA { get; set; }
        public string DESCUENTOS_INTERES { get; set; }
        public string VIGENCIA_DESC_INT { get; set; }
        public string DESCUENTOS_MATRICULA { get; set; }
        public string SALARIO_MINIMO { get; set; }
        public string DESC_X_PRONTO_VERI { get; set; }
        public string VALOR_FORMULARIO { get; set; }
        public string JEFE_JURIDICA { get; set; }
        public string NJEFE_JURIDICA { get; set; }
        public string JEFE_LIQUIDACION { get; set; }
        public string NJEFE_LIQUIDACION { get; set; }
        public string JEFE_FISCALIZACION { get; set; }
        public string NJEFE_FISCALIZACION { get; set; }
        public string DIRECTOR_INGRESOS { get; set; }
        public string NDIRECTOR_INGRESOS { get; set; }
        public string ELABORADO_POR { get; set; }
        public string NELABORADO_POR { get; set; }
        public string CODIGO_SANCION { get; set; }
        public string CODIGO_REGISTRO { get; set; }
        public string TEXTO_PAZYSALVO { get; set; }
        public string FACTOR_AVALUO { get; set; }
        public string FACTOR_AVALUO_VEH_CLASICO { get; set; }
        public string VLR_SEMAFORIZACION { get; set; }
        public string PORC_MORA_NUEVOS { get; set; }
        public string PORC_VEH_CLASICO { get; set; }
        public string PORC_BLINDAJE_CARGA { get; set; }
        public string PORC_BLINDAJE_VEHIC { get; set; }
        public string PORC_BLINDAJE_PASAJ { get; set; }
        public string PORC_DESC_ESPECIALES { get; set; }
        public string PORC_SANCION { get; set; }
        public string PORC_DCTO_SANCION { get; set; }
        public string PORC_SEMAFORIZACION { get; set; }
        public string BLINDAJE_CARGA { get; set; }
        public string BLINDAJE_VEHIC { get; set; }
        public string BLINDAJE_PASAJ { get; set; }
        public string FEC_PRESCRIPCION { get; set; }
        public string COD_VIG_ANTERIOR { get; set; }
        public string VEH_NOMFECOMPRA { get; set; }
        public string AREA_ENCARGADA { get; set; }
        public string ORIGEN { get; set; }
        public string NRO_CTABANCARIA { get; set; }
        public string COPIA_REPORTE { get; set; }
        public string VEH_FORMULARIO { get; set; }
        public string COBRAR_VAL_FORMUL_X_WEB { get; set; }
        public string CODIGO_INTERES { get; set; }
        public string TIPO_REDONDEO { get; set; }
        public string CODIGO_FORMULARIO { get; set; }
        public string NOTA_RPT { get; set; }
        public string COD_BARRA { get; set; }
        public string CAUINT_RENTAS { get; set; }
        public string DESCUENTOS_ESPECIALES { get; set; }
        public string CODIGO_DESCUENTOS { get; set; }
        public string COD_BANCO_ARCHIVO { get; set; }
        public string VALIDA_AREA_CONSTR { get; set; }
        public string LIQ_TOTDESCUENTO { get; set; }
        public string AFECTACION_CONTABLE { get; set; }
        public string AFECTACION_PRESUPUESTAL { get; set; }
        public string VALOR_UVT { get; set; }
        public string PORCENTAJE_SANCION { get; set; }
        public string NUMERO_UVT { get; set; }
        public string CAMBIA_TARIFA { get; set; }
        public string POR_CAMBIA_TARIFA { get; set; }
        public string CAMBIA_AVALUO { get; set; }
        public string POR_CAMBIA_AVALUO { get; set; }
        public string CTRL_MUNICIPIO_WEB { get; set; }
        public string ID_COM_ENTIDAD { get; set; }
        public string USUARIO { get; set; }
        public string VALIDA_PAZ_SALVO { get; set; }
        public string CTRL_MUNICIPIO_OTIP { get; set; }
        public string POR_IPC { get; set; }
        public string TEXTO_LIQUIDACION { get; set; }
        public string ACTIVA_ENTEOFICIAL { get; set; }
        public string VIGENCIA_PRESCRIPCION { get; set; }
        public string CTRL_CANT_CEDULA { get; set; }
    }
}
