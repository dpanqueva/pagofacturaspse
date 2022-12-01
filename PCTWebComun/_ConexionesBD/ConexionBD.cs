using Oracle.DataAccess.Client;
using PCTWebComun.Utilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Web;

namespace PCTWebComun._ConexionesBD
{
    public class ConexionBD
    {

        private string sgbd;                       /// Inidca cual es el sistema gestionador de base de datos se esta utilizando
        private string lmensaje;                   /// Almacena los mensaje de errores de la clase
        //private DbProviderFactory factoria;        /// Obtiene la factoria del proveedor de bd que se este utilizando
        private DbConnection conexion;             /// Objeto que contiene la conexion
        public DbTransaction transaccion;         /// Objeto que permite crear transacciones
        private string servidorBD;                 /// Continee la direccion IP o nombre del servidor de base de datos
        private string cadenaConexion;             //  Cadena de Conexion
        private string esquemaBd;                  //  Esquema de la base de datos
        private DbCommand oSalida;                 //  Para el manejo de Variables de Salida en Procedimientos Almacenados

        public string usuariodb;
        public string vigenciadb;



        public string tipoBaseDatos
        {
            get
            {
                return sgbd;
            }
        }



        public string ServidorBaseDatos
        {
            get
            {
                return servidorBD;
            }
        }

        public string Mensaje
        {
            get
            {
                return lmensaje;
            }
        }

        public DbCommand VariableSalida
        {
            get
            {
                return oSalida;
            }
        }

        public DbTransaction Transaccion
        {
            get
            {
                return transaccion;
            }
        }
        public ConexionBD()
        {
            HttpContext context = HttpContext.Current;
            string usuario = Convert.ToString(ConfigurationManager.AppSettings["usuario"]);
            string esquema = Convert.ToString(ConfigurationManager.AppSettings["esquema"]);
            string clave = Convert.ToString(ConfigurationManager.AppSettings["clave"]);
            string basedatos = Convert.ToString(ConfigurationManager.AppSettings["baseDatos"]);

            esquemaBd = esquema;
            servidorBD = "";

            UtilidadesComun Utilidad = new UtilidadesComun();

            Utilidad.EscribirLog("Usuario: " + usuario + ", base: " + basedatos);

            CrearConexion(basedatos, usuario, clave);
        }

        private void CrearConexion(string basedatos, string usuario, string clave)
        {

            UtilidadesComun Utilidad = new UtilidadesComun();

            try
            {


                Utilidad.EscribirLog("Inicia CrearConexion");

                sgbd = ConfigurationManager.AppSettings["provider"];
                sgbd = sgbd.Trim();

                switch (sgbd)
                {
                    case "Oracle.DataAccess.Client":
                        cadenaConexion = "Data Source = " + basedatos + "; User ID = " + usuario + ";Password = " + clave + ";";
                        break;
                    case "System.Data.OracleClient":
                        cadenaConexion = "Data Source = " + basedatos + "; User ID = " + usuario + ";Password = " + clave + ";";
                        break;
                    case "System.Data.SqlClient":
                        cadenaConexion = "Data Source = " + servidorBD + "; initial catalog = " + basedatos + "; user id = " + usuario + "; password = " + clave + ";";

                        break;
                    default:
                        Utilidad.EscribirLog("Base de Datos no soportada");
                        lmensaje = "Base de Datos no soportada";
                        break;
                }

                Utilidad.EscribirLog("Cadena de Conexion: " + cadenaConexion);

                if (!String.IsNullOrEmpty(sgbd))
                {
                    Utilidad.EscribirLog("Inicializa Conexion");
                    //factoria = DbProviderFactories.GetFactory(sgbd);
                    conexion = new OracleConnection();
                    conexion.ConnectionString = cadenaConexion;
                }
                else
                {
                    lmensaje = "Debe especificar el Proveedor en el WebConfig";
                }
            }
            catch (Exception ex)
            {
                Utilidad.EscribirLog("NO Inicializa Conexion. " + ex.Message);
                lmensaje = ex.Message;

            }
        }

        public bool Conectar()
        {
            bool valido = false;
            try
            {
                if (conexion != null)
                {
                    conexion.Open();
                    if (sgbd == "Oracle.DataAccess.Client")
                    {
                        if (EspecificarSchema(esquemaBd))
                        {
                            valido = true;
                        }
                        else
                        {
                            conexion.Close();
                            lmensaje = "La vigencia no existe";
                        }
                    }
                    else if (sgbd == "System.Data.OracleClient")
                    {
                        if (EspecificarSchema(esquemaBd))
                        {
                            valido = true;
                        }
                        else
                        {
                            conexion.Close();
                            lmensaje = "La vigencia no existe";
                        }
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

        public bool EspecificarSchema(string esquema)
        {
            return EjecutarSQL("ALTER SESSION SET CURRENT_SCHEMA= " + esquemaBd);
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

        public bool IniciarTransaccion()
        {
            try
            {
                if (conexion != null)
                {
                    Conectar();
                    transaccion = conexion.BeginTransaction();
                    HttpContext.Current.Session["transaccion"] = transaccion;
                    return true;
                }
                else
                {
                    lmensaje = "Debe especificar el Proveedor en el WebConfig o la Base de Datos no es soportada";
                    return false;
                }

            }
            catch (Exception ex)
            {
                lmensaje = "Error al iniciar la transaccion " + ex.Message;
                return false;
            }
        }

        public bool CommitTransaccion()
        {
            try
            {
                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                lmensaje = "Error al confirmar la transaccion " + ex.Message;
                return false;
            }
        }

        public bool RollbackTransaccion()
        {
            try
            {
                transaccion.Rollback();
                return true;
            }
            catch (Exception ex)
            {
                lmensaje = "Error al rollback transaccion " + ex.Message;
                return false;
            }
        }

        public bool CommitTransaccion(DbTransaction transaccion)
        {
            try
            {
                transaccion.Commit();
                return true;
            }
            catch (Exception ex)
            {
                lmensaje = "Error al confirmar la transaccion " + ex.Message;
                return false;
            }
        }

        public bool RollbackTransaccion(DbTransaction transaccion)
        {
            try
            {
                transaccion.Rollback();
                return true;
            }
            catch (Exception ex)
            {
                lmensaje = "Error al rollback transaccion " + ex.Message;
                return false;
            }
        }

        public DataTable Consulta(string sentencia)
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

        public DataTable ConsultaPaginada(string sentencia, int paginaActual, int filasMostrar)
        {
            DbCommand comando;
            DbDataReader dr;
            DataTable dt = new DataTable();

            sentencia = sentencia.Trim();
            sentencia = "SELECT ROWNUM oFILA, AAA.* FROM ( " + sentencia + ") AAA ";
            sentencia = "SELECT TTT.* FROM (" + sentencia + ") TTT WHERE TTT.oFILA >((" + paginaActual.ToString() + " - 1 ) * " + filasMostrar.ToString() + " ) and TTT.oFILA <= ( " + paginaActual.ToString() + " * " + filasMostrar.ToString() + " )";

            try
            {
                comando = conexion.CreateCommand();
                comando.CommandTimeout = Int32.MaxValue;
                comando.CommandText = sentencia;
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }
                dr = comando.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return dt;
            }
        }
        public bool EjecutarProcedimieto(string nomProcedure, List<DbParameter> parametros)
        {
            DbCommand comando;


            bool valido = false;
            try
            {
                comando = conexion.CreateCommand();
                comando.CommandText = nomProcedure;
                comando.Connection = conexion;

                foreach (var parametro in parametros)
                {
                    //DbParameter parametro = factoria.CreateParameter();
                    //parametro.ParameterName = i.ParameterName;
                    //parametro.Value = i.Value;
                    //parametro.DbType = i.DbType;
                    //parametro.Size = i.Size;
                    //parametro.Direction = i.Direction;
                    comando.Parameters.Add(parametro);
                }

                comando.CommandText = nomProcedure;
                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = Int32.MaxValue;
                comando.ExecuteNonQuery();
                oSalida = conexion.CreateCommand();
                oSalida = comando;
                valido = true;
                return valido;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                //throw new Exception(lmensaje);
                return valido;
            }
        }

        public bool EjecutarProcedimietoTransaccion(string nomProcedure, List<DbParameter> parametros, DbTransaction transaccion)
        {
            DbCommand comando;
            bool valido = false;
            try
            {
                comando = conexion.CreateCommand();
                comando.CommandText = nomProcedure;
                comando.Connection = conexion;

                foreach (var parametro in parametros)
                {
                    //DbParameter parametro = factoria.CreateParameter();
                    //parametro.ParameterName = i.ParameterName;
                    //parametro.Value = i.Value;
                    //parametro.DbType = i.DbType;
                    //parametro.Size = i.Size;
                    //parametro.Direction = i.Direction;
                    comando.Parameters.Add(parametro);
                }

                comando.CommandText = nomProcedure;
                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandTimeout = Int32.MaxValue;
                comando.ExecuteNonQuery();
                oSalida = conexion.CreateCommand();
                oSalida = comando;
                valido = true;
                return valido;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                //throw new Exception(lmensaje);
                return valido;
            }


        }


        public DataTable ExtraerTabla(string nomTabla)
        {
            DbCommand comando;
            DbDataReader dr;
            DataTable dt = new DataTable();
            string sentencia = "SELECT * FROM " + nomTabla;
            try
            {
                comando = conexion.CreateCommand();
                comando.CommandTimeout = Int32.MaxValue;
                comando.CommandText = sentencia;
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }

                dr = comando.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return dt;
            }
        }

        public Object EjecutarEscalar(string sentencia)
        {
            DbCommand comando;
            try
            {
                comando = conexion.CreateCommand();
                comando.Connection = conexion;
                comando.CommandTimeout = Int32.MaxValue;
                comando.CommandText = sentencia;
                comando.CommandType = CommandType.Text;

                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }

                return comando.ExecuteScalar();

            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return new Object();
            }
        }

        public DataTable EjecutarProcedimiento_ConRetorno(string nomProcedure, List<DbParameter> parametros)
        {
            DbCommand comando;
            DataTable dt = new DataTable();
            try
            {
                comando = conexion.CreateCommand();
                comando.CommandTimeout = Int32.MaxValue;
                comando.CommandText = nomProcedure;
                comando.Connection = conexion;

                foreach (var parametro in parametros)
                {
                    //DbParameter parametro = factoria.CreateParameter();
                    //parametro.ParameterName = i.ParameterName;
                    //parametro.Value = i.Value;
                    //parametro.DbType = i.DbType;
                    //parametro.Size = i.Size;
                    //parametro.Direction = i.Direction;
                    comando.Parameters.Add(parametro);
                }

                if (transaccion != null)
                {
                    comando.Transaction = transaccion;
                }
                comando.CommandType = CommandType.StoredProcedure;

                dt.Columns.Add("Resultado");
                dt.Rows.Add(Convert.ToString(comando.ExecuteScalar()));
                oSalida = conexion.CreateCommand();
                oSalida = comando;
                return dt;
            }
            catch (Exception ex)
            {
                lmensaje = ex.Message;
                return dt;
            }
        }
    }
}
