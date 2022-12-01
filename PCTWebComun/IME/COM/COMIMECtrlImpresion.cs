//PCT.NET_NVO_0000_20190521 - Fecha Inicio 15/03/2021 - Ticket Nº 0000 - Caso: se agrega la Clase IME para CTRL_IMPRESION, Solicitud de MAribel Pedroza- Participantes: Oscar Ramos

using Oracle.DataAccess.Client;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.IME.COM
{
    class COMIMECtrlImpresion
    {
        public List<DbParameter> ProcedimientoComCtrlImpresion(COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VMODULO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.MODULO))
            {
                Parametro.Value = EntidadCtrlImpresion.MODULO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VSUBMODULO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.SUBMODULO))
            {
                Parametro.Value = EntidadCtrlImpresion.SUBMODULO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VVIGENCIA";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.VIGENCIA))
            {
                Parametro.Value = Convert.ToInt32(EntidadCtrlImpresion.VIGENCIA);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNUM_INI";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(NumIni))
            {
                Parametro.Value = Convert.ToInt32(NumIni);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            Parametro = new OracleParameter();

            Parametro.ParameterName = "VNUM_FIN";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(NumFin))
            {
                Parametro.Value = Convert.ToInt32(NumFin);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCLS_DOCUMENTO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.CLS_DOCUMENTO))
            {
                Parametro.Value = EntidadCtrlImpresion.CLS_DOCUMENTO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            return Parametros;
        }
        public List<DbParameter> ProcedimientoComCtrlImpresionFirma(COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VMODULO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.MODULO))
            {
                Parametro.Value = EntidadCtrlImpresion.MODULO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VSUBMODULO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.SUBMODULO))
            {
                Parametro.Value = EntidadCtrlImpresion.SUBMODULO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VVIGENCIA";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.VIGENCIA))
            {
                Parametro.Value = Convert.ToInt32(EntidadCtrlImpresion.VIGENCIA);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            
            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNUM_INI";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(NumIni))
            {
                Parametro.Value = Convert.ToInt32(NumIni);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);
            Parametro = new OracleParameter();

            Parametro.ParameterName = "VNUM_FIN";
            Parametro.DbType = DbType.Int32;
            if (!string.IsNullOrEmpty(NumFin))
            {
                Parametro.Value = Convert.ToInt32(NumFin);
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCLS_DOCUMENTO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.CLS_DOCUMENTO))
            {
                Parametro.Value = EntidadCtrlImpresion.CLS_DOCUMENTO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCON_FIRMA";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadCtrlImpresion.CON_FIRMA))
            {
                Parametro.Value = EntidadCtrlImpresion.CON_FIRMA;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            return Parametros;
        }
    }
}
