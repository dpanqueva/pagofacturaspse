using Oracle.ManagedDataAccess.Client;
using PCTWebFactura.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PCTWebFactura.Classes
{
    public class ConectionFactory
    {
        private static AppConfiguration appConfig = new AppConfiguration();
        public string message = "";
        public static DbProviderFactory fact;
        

        public static async Task<DbConnection> DefaultConnectionAsync()
        {
            try
            {
                var factory = DbProviderFactories.GetFactory(appConfig.provider);
                fact = factory;
                var conexion = factory.CreateConnection();
                conexion.ConnectionString = appConfig.ConnectionString.ToString();
                //conexion.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=190.146.38.51)(PORT=15254))(CONNECT_DATA=(SERVICE_NAME=S4PCTG0)));User Id=Pctuser;Password=pctgkey;persist security info=false;";
                conexion.Open();
                DbCommand command = conexion.CreateCommand();
                command.CommandText = "ALTER SESSION SET CURRENT_SCHEMA = " + appConfig.esquema.ToString(); ;
                command.Connection = conexion;
                command.CommandType = CommandType.Text;
                _ = await command.ExecuteScalarAsync();
                return conexion;
            }
            catch (Exception e)
            {

                throw new Exception("Error en la conexion ", e);
            }
        }

        public static  OracleConnection Connect()
        {
            OracleConnection con = new OracleConnection();
            con.ConnectionString = appConfig.ConnectionString.ToString();
            con.Open();
            return con;
            Console.WriteLine("Connected to Oracle" + con.ServerVersion);
        }


    }
}