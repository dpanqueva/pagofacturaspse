//PCT.NET_NVO_0000_20190521 - Fecha Inicio 28/10/2020 - Ticket Nº 0000 - Caso: Se agrega clase de consulta de Facturas V1, solicitada por Jorge Valega- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Query CONSULTASFACTURAS_V1: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas.FAC
{
    public class FACConsConsultasFacturasV1
    {
        public string Mensaje;

        public DataTable ConsultarConsulFacturasV1(ConexionBD oConexion, FACConsultasFacturasV1 EntidadConsultaFacturasV1, string NoFacturaIni, string NoFacturaFin, string ValorfacIni,
                                                            string ValorfacFin, string FecfacturaIni, string FecfacturaFin, string FecVecfacIni, string FecVenfacFin, string FecanulafacIni,
                                                            string FecanulafacFin, string FecregisfacIni, string FecregisfacFin, string RefepagoIni,
                                                            string RefepagoFin, string DoctasaIni, string DoctasaFin, string CodigotasaIni, string CodigotasaFin,
                                                            string SaldocapIni, string SaldocapFin)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT ID_MFACTURA,NUM_FACTURA, COD_TIPO,VIGENCIA, COD_FACTURA, NIT,NOMBRE, FECHA_FACTURA,FECHA_FACTURADESDE, ESTADO, ESTADO_FACTURA, " +
                "VAL_SUBTOTALFAC, VAL_TOTALFAC, VAL_IVAFAC, VAL_RECARGOFAC, VAL_DESCUENTOFAC, VAL_CUENTASCOBRAR, VAL_INTERESCOBRAR, VAL_FPAGO, " +
                "FECHA_REGISTRO,TIPO_FACTURA,COD_LOCALIZA,DOC_TASA,OBSERVAC,COD_CENTRO,OBS_ANULACION,FEC_ANULA,FECHA_LIMITE,NVL(NIT_DIRIGIDO,'0')NIT_DIRIGIDO, " +
                "COD_PROCESO,NOM_PROCESO,CTRL_FAC_ELECTRONICA,NOMBRE_DIRIGIDO, NOM_LOCALIZA,COD_TASA,COD_COT, COD_CATEGORIA, COD_ELEMENTO, COD_REFERENCIA, COD_VENDEDOR,IMPRESO ,NOTA ";
              sentencia += "FROM CONSULTASFACTURAS_V1 WHERE COD_FACTURA <> '0' ";

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = '" + EntidadConsultaFacturasV1.VIGENCIA + "' ";
            }

            if (!string.IsNullOrEmpty(NoFacturaIni) && !string.IsNullOrEmpty(NoFacturaFin))
            {
                sentencia += " AND  NUM_FACTURA BETWEEN '" + NoFacturaIni + "' AND '" + NoFacturaFin + "'";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.NUM_FACTURA))
            {
                sentencia += " AND NUM_FACTURA = '" + EntidadConsultaFacturasV1.NUM_FACTURA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.ESTADO_FACTURA))
            {
                sentencia += " AND ESTADO_FACTURA = '" + EntidadConsultaFacturasV1.ESTADO_FACTURA + "' ";
            }

            if (!string.IsNullOrEmpty(ValorfacIni) && !string.IsNullOrEmpty(ValorfacFin))
            {
                sentencia += " AND  VAL_TOTALFAC BETWEEN '" + ValorfacIni + "' AND '" + ValorfacFin + "'";
            }

            if (!string.IsNullOrEmpty(RefepagoIni) && !string.IsNullOrEmpty(RefepagoFin))
            {
                sentencia += " AND  ID_MFACTURA BETWEEN '" + RefepagoIni + "' AND '" + RefepagoFin + "'";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.ID_MFACTURA))
            {
                sentencia += " AND ID_MFACTURA = '" + EntidadConsultaFacturasV1.ID_MFACTURA + "' ";
            }

            if (!string.IsNullOrEmpty(DoctasaIni) && !string.IsNullOrEmpty(DoctasaFin))
            {
                sentencia += " AND  DOC_TASA BETWEEN '" + DoctasaIni + "' AND '" + DoctasaFin + "'";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.DOC_TASA))
            {
                sentencia += " AND DOC_TASA = '" + EntidadConsultaFacturasV1.DOC_TASA + "' ";
            }

            if (!string.IsNullOrEmpty(DoctasaIni) && !string.IsNullOrEmpty(DoctasaFin))
            {
                sentencia += " AND  COD_TASA BETWEEN '" + DoctasaIni + "' AND '" + DoctasaFin + "'";
            }

            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_TASA))
            {
                sentencia += " AND COD_TASA = '" + EntidadConsultaFacturasV1.COD_TASA + "' ";
            }

            if (!string.IsNullOrEmpty(SaldocapIni) && !string.IsNullOrEmpty(SaldocapFin))
            {
                sentencia += " AND  VAL_FPAGO BETWEEN '" + SaldocapIni + "' AND '" + SaldocapFin + "'";
            }
			
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.OBSERVAC))
            {
                sentencia += " AND UPPER(OBSERVAC) LIKE '%" + EntidadConsultaFacturasV1.OBSERVAC.ToUpper() + "%'";
            }
			
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.NOTA))
            {
                sentencia += " AND UPPER(NOTA) LIKE '%" + EntidadConsultaFacturasV1.NOTA.ToUpper() + "%'";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.NIT))
            {
                sentencia += " AND  NIT = '" + EntidadConsultaFacturasV1.NIT + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_CATEGORIA))
            {
                sentencia += " AND COD_CATEGORIA= '" + EntidadConsultaFacturasV1.COD_CATEGORIA + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_ELEMENTO))
            {
                sentencia += " AND  COD_ELEMENTO = '" + EntidadConsultaFacturasV1.COD_ELEMENTO + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_REFERENCIA))
            {
                sentencia += " AND  COD_REFERENCIA = '" + EntidadConsultaFacturasV1.COD_REFERENCIA + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_LOCALIZA))
            {
                sentencia += " AND  COD_LOCALIZA = '" + EntidadConsultaFacturasV1.COD_LOCALIZA + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_CENTRO))
            {
                sentencia += " AND  COD_CENTRO = '" + EntidadConsultaFacturasV1.COD_CENTRO + "' ";
            }
			if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.NIT_DIRIGIDO))
            {
                sentencia += " AND  NIT_DIRIGIDO = '" + EntidadConsultaFacturasV1.NIT_DIRIGIDO + "' ";
            }

            if (!string.IsNullOrEmpty(FecfacturaIni) && !string.IsNullOrEmpty(FecfacturaFin))
            {
                sentencia += " AND  FECHA_FACTURA BETWEEN '" + FecfacturaIni + "' AND '" + FecfacturaFin + "'";
            }
            if (!string.IsNullOrEmpty(FecregisfacIni) && !string.IsNullOrEmpty(FecregisfacFin))
            {
                sentencia += " AND  FECHA_REGISTRO BETWEEN '" + FecregisfacIni + "' AND '" + FecregisfacFin + "'";
            }
            if (!string.IsNullOrEmpty(FecVecfacIni) && !string.IsNullOrEmpty(FecVenfacFin))
            {
                sentencia += " AND  FECHA_LIMITE BETWEEN '" + FecVecfacIni + "' AND '" + FecVenfacFin + "'";
            }
            if (!string.IsNullOrEmpty(FecanulafacIni) && !string.IsNullOrEmpty(FecanulafacFin))
            {
                sentencia += " AND  FEC_ANULA BETWEEN '" + FecanulafacIni + "' AND '" + FecanulafacFin + "'";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.FECHA_FACTURA))
            {
                sentencia += " AND TRUNC(FECHA_FACTURA)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.FECHA_REGISTRO))
            {
                sentencia += " AND TRUNC(FECHA_REGISTRO)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.FECHA_LIMITE))
            {
                sentencia += " AND TRUNC(FECHA_LIMITE)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.FEC_ANULA))
            {
                sentencia += " AND TRUNC(FEC_ANULA)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_TIPO))
            {
                sentencia += " AND COD_TIPO = '" + EntidadConsultaFacturasV1.COD_TIPO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_CENTRO_USO))
            {
                sentencia += " AND COD_CENTRO_USO = '" + EntidadConsultaFacturasV1.COD_CENTRO_USO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_PROCESO))
            {
                sentencia += " AND COD_PROCESO = '" + EntidadConsultaFacturasV1.COD_PROCESO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.CTRL_FAC_ELECTRONICA))
            {
                sentencia += " AND CTRL_FAC_ELECTRONICA = '" + EntidadConsultaFacturasV1.CTRL_FAC_ELECTRONICA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.COD_FACTURA))
            {
                sentencia += " AND COD_FACTURA = '" + EntidadConsultaFacturasV1.COD_FACTURA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.PREFIJO))
            {
                sentencia += " AND UPPER(COD_FACTURA) LIKE '%" + EntidadConsultaFacturasV1.PREFIJO.ToUpper() + "%'";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaFacturasV1.TIPO_FACTURA))
            {
                sentencia += " AND UPPER(TIPO_FACTURA) LIKE '%" + EntidadConsultaFacturasV1.TIPO_FACTURA.ToUpper() + "%'";
            }

           

            sentencia += "ORDER BY NUM_FACTURA";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            dtConsulta.TableName = "Xls Nit Columnar";
            return dtConsulta;
        }



        //reporte

        public DataTable ConsultarptConsultafacturasV1(ConexionBD oConexion, FACConsultasFacturasV1 EntidadRptConsultaFacturasV1)
        {
            DataTable dtConsulta = new DataTable();
            //string sentencia = "SELECT DISTINCT ID_MFACTURA,NUM_FACTURA, COD_TIPO,VIGENCIA, COD_FACTURA, NIT,NOMBRE, FECHA_FACTURA,FECHA_FACTURADESDE, ESTADO, ESTADO_FACTURA, " +
            //    "VAL_SUBTOTALFAC, VAL_TOTALFAC, VAL_IVAFAC, VAL_RECARGOFAC, VAL_DESCUENTOFAC, VAL_CUENTASCOBRAR, VAL_INTERESCOBRAR, VAL_FPAGO, " +
            //    "FECHA_REGISTRO,TIPO_FACTURA,COD_LOCALIZA,DOC_TASA,OBSERVAC,COD_CENTRO,OBS_ANULACION,FEC_ANULA,FECHA_LIMITE,NVL(NIT_DIRIGIDO,'0')NIT_DIRIGIDO, " +
            //    "COD_PROCESO,NOM_PROCESO,CTRL_FAC_ELECTRONICA,NOMBRE_DIRIGIDO, NOM_LOCALIZA,COD_TASA,COD_COT, COD_CATEGORIA, COD_ELEMENTO, COD_REFERENCIA, COD_VENDEDOR,IMPRESO ,NOTA ";
            //sentencia += "FROM CONSULTASFACTURAS_V1 WHERE COD_FACTURA <> '0' ";

            string sentencia = "SELECT NIT, NOMBRE, COD_FACTURA, FECHA_FACTURA, FECHA_FACTURADESDE, ESTADO_FACTURA, FECHA_LIMITE, VAL_IVAFAC, " +
                 "VIGENCIA, FECHA_REGISTRO, VAL_CUENTASCOBRAR, VAL_INTERESCORRIENTE, VAL_TOTALFAC, VAL_SUBTOTALFAC, REFERENCIA, " +
                 "VAL_RECARGOFAC, VAL_DESCUENTOFAC, VAL_TOTAL, VAL_FPAGO, COD_LOCALIZA, VAL_PAGOS, FEC_ANULA, OBSERVAC, NOM_LOCALIZA ";
            sentencia += "FROM CONSULTASFACTURAS_V1 WHERE COD_FACTURA <> '0' ";

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = '" + EntidadRptConsultaFacturasV1.VIGENCIA + "' ";
            }

            //if (!string.IsNullOrEmpty(NoFacturaIni) && !string.IsNullOrEmpty(NoFacturaFin))
            //{
            //    sentencia += " AND  NUM_FACTURA BETWEEN '" + NoFacturaIni + "' AND '" + NoFacturaFin " "'";
            //}

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.NUM_FACTURA))
            {
                sentencia += " AND NUM_FACTURA = '" + EntidadRptConsultaFacturasV1.NUM_FACTURA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.ESTADO_FACTURA))
            {
                sentencia += " AND ESTADO_FACTURA = '" + EntidadRptConsultaFacturasV1.ESTADO_FACTURA + "' ";
            }

            //if (!string.IsNullOrEmpty(ValorfacIni) && !string.IsNullOrEmpty(ValorfacFin))
            //{
            //    sentencia += " AND  VAL_TOTALFAC BETWEEN '" + ValorfacIni + "' AND '" + ValorfacFin + "'";
            //}

            //if (!string.IsNullOrEmpty(RefepagoIni) && !string.IsNullOrEmpty(RefepagoFin))
            //{
            //    sentencia += " AND  ID_MFACTURA BETWEEN '" + RefepagoIni + "' AND '" + RefepagoFin + "'";
            //}

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.ID_MFACTURA))
            {
                sentencia += " AND ID_MFACTURA = '" + EntidadRptConsultaFacturasV1.ID_MFACTURA + "' ";
            }

            //if (!string.IsNullOrEmpty(DoctasaIni) && !string.IsNullOrEmpty(DoctasaFin))
            //{
            //    sentencia += " AND  DOC_TASA BETWEEN '" + DoctasaIni + "' AND '" + DoctasaFin + "'";
            //}

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.DOC_TASA))
            {
                sentencia += " AND DOC_TASA = '" + EntidadRptConsultaFacturasV1.DOC_TASA + "' ";
            }

            //if (!string.IsNullOrEmpty(DoctasaIni) && !string.IsNullOrEmpty(DoctasaFin))
            //{
            //    sentencia += " AND  COD_TASA BETWEEN '" + DoctasaIni + "' AND '" + DoctasaFin + "'";
            //}

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_TASA))
            {
                sentencia += " AND COD_TASA = '" + EntidadRptConsultaFacturasV1.COD_TASA + "' ";
            }

            //if (!string.IsNullOrEmpty(SaldocapIni) && !string.IsNullOrEmpty(SaldocapFin))
            //{
            //    sentencia += " AND  VAL_FPAGO BETWEEN '" + SaldocapIni + "' AND '" + SaldocapFin + "'";
            //}

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.OBSERVAC))
            {
                sentencia += " AND UPPER(OBSERVAC) LIKE '%" + EntidadRptConsultaFacturasV1.OBSERVAC.ToUpper() + "%'";
            }

            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.NOTA))
            {
                sentencia += " AND UPPER(NOTA) LIKE '%" + EntidadRptConsultaFacturasV1.NOTA.ToUpper() + "%'";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.NIT))
            {
                sentencia += " AND  NIT = '" + EntidadRptConsultaFacturasV1.NIT + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_CATEGORIA))
            {
                sentencia += " AND COD_CATEGORIA= '" + EntidadRptConsultaFacturasV1.COD_CATEGORIA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_ELEMENTO))
            {
                sentencia += " AND  COD_ELEMENTO = '" + EntidadRptConsultaFacturasV1.COD_ELEMENTO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_REFERENCIA))
            {
                sentencia += " AND  COD_REFERENCIA = '" + EntidadRptConsultaFacturasV1.COD_REFERENCIA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_LOCALIZA))
            {
                sentencia += " AND  COD_LOCALIZA = '" + EntidadRptConsultaFacturasV1.COD_LOCALIZA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_CENTRO))
            {
                sentencia += " AND  COD_CENTRO = '" + EntidadRptConsultaFacturasV1.COD_CENTRO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.NIT_DIRIGIDO))
            {
                sentencia += " AND  NIT_DIRIGIDO = '" + EntidadRptConsultaFacturasV1.NIT_DIRIGIDO + "' ";
            }

            //if (!string.IsNullOrEmpty(FecfacturaIni) && !string.IsNullOrEmpty(FecfacturaFin))
            //{
            //    sentencia += " AND  FECHA_FACTURA BETWEEN '" + FecfacturaIni + "' AND '" + FecfacturaFin + "'";
            //}
            //if (!string.IsNullOrEmpty(FecregisfacIni) && !string.IsNullOrEmpty(FecregisfacFin))
            //{
            //    sentencia += " AND  FECHA_REGISTRO BETWEEN '" + FecregisfacIni + "' AND '" + FecregisfacFin + "'";
            //}
            //if (!string.IsNullOrEmpty(FecVecfacIni) && !string.IsNullOrEmpty(FecVenfacFin))
            //{
            //    sentencia += " AND  FECHA_LIMITE BETWEEN '" + FecVecfacIni + "' AND '" + FecVenfacFin + "'";
            //}
            //if (!string.IsNullOrEmpty(FecanulafacIni) && !string.IsNullOrEmpty(FecanulafacFin))
            //{
            //    sentencia += " AND  FEC_ANULA BETWEEN '" + FecanulafacIni + "' AND '" + FecanulafacFin + "'";
            //}
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.FECHA_FACTURA))
            {
                sentencia += " AND TRUNC(FECHA_FACTURA)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.FECHA_REGISTRO))
            {
                sentencia += " AND TRUNC(FECHA_REGISTRO)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.FECHA_LIMITE))
            {
                sentencia += " AND TRUNC(FECHA_LIMITE)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.FEC_ANULA))
            {
                sentencia += " AND TRUNC(FEC_ANULA)<TRUNC(SYSDATE)";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_TIPO))
            {
                sentencia += " AND COD_TIPO = '" + EntidadRptConsultaFacturasV1.COD_TIPO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_CENTRO_USO))
            {
                sentencia += " AND COD_CENTRO_USO = '" + EntidadRptConsultaFacturasV1.COD_CENTRO_USO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_PROCESO))
            {
                sentencia += " AND COD_PROCESO = '" + EntidadRptConsultaFacturasV1.COD_PROCESO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.CTRL_FAC_ELECTRONICA))
            {
                sentencia += " AND CTRL_FAC_ELECTRONICA = '" + EntidadRptConsultaFacturasV1.CTRL_FAC_ELECTRONICA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.COD_FACTURA))
            {
                sentencia += " AND COD_FACTURA = '" + EntidadRptConsultaFacturasV1.COD_FACTURA + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.PREFIJO))
            {
                sentencia += " AND UPPER(COD_FACTURA) LIKE '%" + EntidadRptConsultaFacturasV1.PREFIJO.ToUpper() + "%'";
            }
            if (!string.IsNullOrEmpty(EntidadRptConsultaFacturasV1.TIPO_FACTURA))
            {
                sentencia += " AND UPPER(TIPO_FACTURA) LIKE '%" + EntidadRptConsultaFacturasV1.TIPO_FACTURA.ToUpper() + "%'";
            }

            //sentencia += "GROUP BY COD_CENTRO_USO, VIGENCIA, COD_FACTURA, NUM_FACTURA, RESOLUCION,NIT,FECHA_FACTURA, ESTADO,ESTADO_FACTURA,VAL_SUBTOTALFAC, VAL_TOTAL, VAL_TOTALFAC,  " +
            //"VAL_IVAFAC, VAL_RECARGOFAC, VAL_DESCUENTOFAC, VAL_CUENTASCOBRAR, VAL_INTERESCOBRAR, VAL_FPAGO,COD_TIPO,NIT_DIRIGIDO,COD_PROCESO,NOM_PROCESO, " +
            //"COD_COT, COD_VENDEDOR,FECHA_FACTURADESDE,ID_MFACTURA, NOTA,VAL_INTERESCORRIENTE, IMPRESO,NOMBRE, COD_CATEGORIA, NOM_CATEGORIA,COD_ELEMENTO, " +
            //"COD_TIPO, NOM_ELEMENTO,COD_REFERENCIA,REFERENCIA, FECHA_LIMITE,FECHA_REGISTRO,FEC_ANULA, OBS_ANULACION, COD_LOCALIZA, " +
            //"VAL_RECARGO,VAL_TODO,COD_TASA, NUMERO_DOC,OBSERVAC,VAL_A_PAGAR,VAL_FPAGO,COD_CENTRO,VAL_INTERES,TIPO_TASA,VIGENCIA,VAL_TOTALFAC,NIT, " +
            //"CTRL_FAC_ELECTRONICA, FEC_FAC_ELECTRONICA, NOMBRE_XML,NOMBRE_DIRIGIDO,NOM_LOCALIZA ";


            sentencia += " ORDER BY VIGENCIA, COD_FACTURA, NIT";

            DataTable dtsConsulta;

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }

    }
}
