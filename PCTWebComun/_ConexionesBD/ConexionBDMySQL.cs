//PCTFTPDescargas_NVO_0000_20200914 - 14/09/2020 - Ticket N° 038178 - Se añade metodo para establecer conexión y realizar procesos con MySql - Karol Romero

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace PCTWebComun._ConexionesBD
{
    public class ConexionBDMySQL
    {

        private string sgbd;                       /// Inidca cual es el sistema gestionador de base de datos se esta utilizando
        private string lmensaje;                   /// Almacena los mensaje de errores de la clase
        private DbConnection conexion;             /// Objeto que contiene la conexion
        private DbTransaction transaccion;         /// Objeto que permite crear transacciones
        private string cadenaConexion;             //  Cadena de Conexion
 

        public string usuariodb;
        public string vigenciadb;

        public string tipoBaseDatos
        {
            get
            {
                return sgbd;
            }
        }
                   

        public string Mensaje
        {
            get
            {
                return lmensaje;
            }
        }

      
        public ConexionBDMySQL()
        {

            string usuario = ConfigurationManager.AppSettings["usuario"];
            string BaseDatosMySql = ConfigurationManager.AppSettings["BaseDatosMySql"];
            string clave = ConfigurationManager.AppSettings["clave"];
            string DataSourseMysql = ConfigurationManager.AppSettings["DataSourseMysql"];
            string Port = ConfigurationManager.AppSettings["Port"];
            string provider2 = ConfigurationManager.AppSettings["provider2"];


            CrearConexionMysql(DataSourseMysql, Port, BaseDatosMySql, usuario, clave, provider2);
        }

        private void CrearConexionMysql(string DataSourseMysql, string Port, string BaseDatosMySql, string usuario, string clave, string provider2)
        {
            try
            {
                sgbd = ConfigurationManager.AppSettings["provider2"];
                sgbd = sgbd.Trim();

                switch (sgbd)
                {
                    case "Mysql.Data.MysqlClient":

                        cadenaConexion = "Data Source = " + DataSourseMysql + "; Database = " + BaseDatosMySql + "; User ID = " + usuario + ";Password = " + clave + "; Port = " + Port + ";";
                    
                        break;
                    default:
                        lmensaje = "Base de Datos no soportada";
                        break;
                }

                if (!String.IsNullOrEmpty(sgbd))
                {

                    conexion = new MySqlConnection();
                    conexion.ConnectionString = cadenaConexion;

                }
                else
                {
                    lmensaje = "Debe especificar el Proveedor en el WebConfig";
                }
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
            }
        }


        public bool ConectarMysql()
        {
            bool valido = false;
            try
            {
                if (conexion != null)
                {
                    conexion.Open();
                    if (sgbd == "Mysql.Data.MysqlClient")
                    {
                        valido = true;

                    }
                }
                else
                {
                    lmensaje = "Debe especificar el Proveedor en el WebConfig o la Base de Datos no es soportada";
                }
                return valido;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return valido;
            }

        }
               

        public bool EjecutarSQL(string sentencia)
        {
            DbCommand comando;
            bool valido = false;
            try
            {
                comando = conexion.CreateCommand();
                comando.CommandText = sentencia;
                comando.Connection = conexion;
                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }
                comando.CommandTimeout = Int32.MaxValue;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                valido = true;
                return valido;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return valido;
            }
        }

        public DataTable ConsultaMySql(string sentencia)
        {
            DbCommand comando;
            DbDataReader dr;
            DataTable dt = new DataTable();
            try
            {
                comando = conexion.CreateCommand();
                comando.Connection = conexion;
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;

                comando.CommandTimeout = Int32.MaxValue;

                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }

                dr = comando.ExecuteReader();
                dt.Load(dr);
                if ((dt.Rows.Count == 0) & (String.IsNullOrEmpty(lmensaje)))
                {
                    lmensaje = "No se encontraron resultados";
                }
                return dt;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return dt;
            }
        }

        public bool Desconectar()
        {

            bool valido = false;
            try
            {
                conexion.Close();
                valido = true;
                return valido;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return valido;
            }
        }
    }
}
