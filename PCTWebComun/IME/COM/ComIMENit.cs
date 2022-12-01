//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade la clase IME para NIT - Participantes: Maribel Pedroza
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
    public class ComIMENit
    { 
        public List<DbParameter> ProcedimientoComCambioNit(ComNit entidad1, ComNit entidad2)
        {
            OracleParameter Parametro;
            List<DbParameter> Parametros = new List<DbParameter>();

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNIT1";
            Parametro.DbType = DbType.String;
            Parametro.Value = Convert.ToString(entidad1.NIT);
            Parametros.Add(Parametro);

            Parametro = new OracleParameter();
            Parametro.ParameterName = "VNIT2";
            Parametro.DbType = DbType.String;
            Parametro.Value = Convert.ToString(entidad2.NIT);
            Parametros.Add(Parametro);

            return Parametros;
        }
    }
}
