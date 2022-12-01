//PCT.NET_NVO_0000_20200605 - Fecha Inicio 05/06/2020 - Ticket Nº 037564 - Caso: se añade la clase IME para ST_PERMISO - Participantes: Maribel Pedroza
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
    public class ComIMEAutorizacionUsuario
    {
        public List<DbParameter> ProcedimientoComStPermiso(ComUsuariosPrivs EntidadUsuariosPrivs)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VUSUARIO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadUsuariosPrivs.USUARIO))
            {
                Parametro.Value = EntidadUsuariosPrivs.USUARIO;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VCOD_ACCION";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadUsuariosPrivs.COD_ACCION))
            {
                Parametro.Value = EntidadUsuariosPrivs.COD_ACCION;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VPERMISO";
            Parametro.DbType = DbType.String;
            if (!string.IsNullOrEmpty(EntidadUsuariosPrivs.PERMISOS))
            {
                Parametro.Value = EntidadUsuariosPrivs.PERMISOS;
            }
            else
            {
                Parametro.Value = null;
            }
            Parametro.Direction = ParameterDirection.InputOutput;
            Parametros.Add(Parametro);
                      

            return Parametros;
        }
    }
}
