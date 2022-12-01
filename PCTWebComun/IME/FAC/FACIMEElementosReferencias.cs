using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Oracle.DataAccess.Client;
using System.Data;

namespace PCTWebComun.IME.FAC
{
   public class FACIMEElementosReferencias
    {
        public List<DbParameter> ProcedimientoST_CLASE_ELEMENTOSSERVICIO(FACElementosReferencias entidadReferenciaFacOcasional)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();
            //VNOM_ELEMENTO CLASE_ELEMENTOSSERVICIO.NOM_ELEMENTO % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNOM_ELEMENTO";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.NOM_ELEMENTO;
            Parametros.Add(Parametro);
            //VCOD_ELEMENTO CLASE_ELEMENTOSSERVICIO.COD_ELEMENTO % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_ELEMENTO";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.COD_ELEMENTO);
            Parametros.Add(Parametro);
            //VCOD_CATEGORIA CLASE_ELEMENTOSSERVICIO.COD_CATEGORIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_CATEGORIA";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.COD_CATEGORIA;
            Parametros.Add(Parametro);
            //VIVA CLASE_ELEMENTOSSERVICIO.IVA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VIVA";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.IVA);
            Parametros.Add(Parametro);
            //VVIGENCIA CLASE_ELEMENTOSSERVICIO.VIGENCIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VVIGENCIA";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.VIGENCIA);
            Parametros.Add(Parametro);
            //VNOTA CLASE_ELEMENTOSSERVICIO.NOTA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNOTA";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.NOTA;
            Parametros.Add(Parametro);
            //VESTADOREG SMALLINT)
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VESTADOREG";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.ESTADOREG);
            Parametros.Add(Parametro);
            return Parametros;
        }
        public List<DbParameter> ProcedimientoST_REFSERVICIO(FACElementosReferencias entidadReferenciaFacOcasional)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();
            //VCOD_CATEGORIA REFERENCIASSERVICIO.COD_CATEGORIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_CATEGORIA";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.COD_CATEGORIA;
            Parametros.Add(Parametro);
            //VCOD_ELEMENTO REFERENCIASSERVICIO.COD_ELEMENTO % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_ELEMENTO";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.COD_ELEMENTO);
            Parametros.Add(Parametro);
            //VCOD_REFERENCIA REFERENCIASSERVICIO.COD_REFERENCIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_REFERENCIA";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.COD_REFERENCIA);
            Parametros.Add(Parametro);
            //VREFERENCIA REFERENCIASSERVICIO.REFERENCIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VREFERENCIA";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.REFERENCIA;
            Parametros.Add(Parametro);
            //VDETALLE REFERENCIASSERVICIO.DETALLE % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VDETALLE";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.DETALLE;
            Parametros.Add(Parametro);
            //VCOD_UNIDAD REFERENCIASSERVICIO.COD_UNIDAD % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_UNIDAD";
            Parametro.DbType = DbType.String;
            Parametro.Value = entidadReferenciaFacOcasional.COD_UNIDAD;
            Parametros.Add(Parametro);
            //VVALOR REFERENCIASSERVICIO.VALOR % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VVALOR";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.VALOR);
            Parametros.Add(Parametro);
            //VVIGENCIA REFERENCIASSERVICIO.VIGENCIA % TYPE,
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VVIGENCIA";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.VIGENCIA);
            Parametros.Add(Parametro);
            //VESTADOREG SMALLINT)
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VESTADOREG";
            Parametro.DbType = DbType.Int32;
            Parametro.Value = Convert.ToInt32(entidadReferenciaFacOcasional.ESTADOREG);
            Parametros.Add(Parametro);
            return Parametros;
        }
    }
}
