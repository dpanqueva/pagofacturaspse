using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlLogin
    {
        public string Mensaje;

        public DataTable CtrlVerfUsuario(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar())
            {
                dtResultado=consulta.ConsVerifUsuario(entidad,oconexion);
                Mensaje=consulta.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
            }

            return dtResultado;
        }

        public DataTable CtrlVerfUsuarioPct(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar())
            {
                dtResultado=consulta.ConsVerifUsuarioPct(entidad,oconexion);
                Mensaje=consulta.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
            }
            return dtResultado;
        }

        public string CtrlVerifAcceso()
        {
            //este metodo verifica la conexion a la bd
            ConexionBD oconexion = new ConexionBD();
            string respuesta;

            if (oconexion.Conectar()) {
                respuesta = "Conectado";
                oconexion.Desconectar();
            } else {
                respuesta="Desconectado";
            }

            return respuesta;

        }

        public DataTable CtrlObtenerEntidad()
        {
            ConexionBD oconexion= new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {

                dtResultado=consulta.ConsNombreEntidad(oconexion);
                Mensaje=consulta.Mensaje;
                oconexion.Desconectar();

            } else {
                Mensaje=oconexion.Mensaje;
            };
            
            return dtResultado;
            
        }

        public DataTable CtrlObtenerLogo()
        {


            ConexionBD oconexion= new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {
                dtResultado=consulta.ConsObtenerLogo(oconexion);
                Mensaje=consulta.Mensaje;

                oconexion.Desconectar();
            } else {
                Mensaje=oconexion.Mensaje;
            };

    
            return dtResultado;


        }

        public DataTable CtrlPrivConsulta()
        {
            ConexionBD oconexion= new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {
                dtResultado=consulta.ConsPrivilegiosConsulta(oconexion);
                Mensaje=consulta.Mensaje;
                oconexion.Desconectar();
            } else {
                Mensaje=oconexion.Mensaje;
            };

            return dtResultado;
        }

        public DataTable CtrlPrivUsuario(ComLogin entidad)
        { 
            ConexionBD oconexion = new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {
                dtResultado=consulta.ConsPrivilegiosUsuario(entidad, oconexion);
                Mensaje=consulta.Mensaje;

                oconexion.Desconectar();
            } else {
                Mensaje=oconexion.Mensaje;
            };
    
            return dtResultado;
        }

        public bool CtrlVerificarAccion(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            bool verificacion;
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {

                verificacion = consulta.ConsVerifiPermiso(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();

            } else {
                Mensaje=oconexion.Mensaje;
                    verificacion = false;
            }
            return verificacion;
        }

        public DataTable CtrlObtenerListaPermisos(ComLogin entidad)
        {

            ConexionBD oconexion = new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {

                dtResultado = consulta.ConsObtenerListaPermisos(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();
            } 
            else
            {
                Mensaje =oconexion.Mensaje;
            }
            return dtResultado;
        }

        public bool CtrlCambiarClave(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            bool verificacion;
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar()) {
                verificacion = consulta.ConsCambiarClave(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();

            } else {
                Mensaje = oconexion.Mensaje;
                verificacion = false;
            };

            return verificacion;

        }

        public bool CtrlCambiarClavePct(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            bool verificacion;
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar())
            {
                verificacion = consulta.ConsCambiarClavePct(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
                verificacion = false;
            };

            return verificacion;

        }

        //PCTWebFTPDescargas_NVO_0000_20200513 - 13/05/2020 - Se añade metodo para consultas de usuarios FTP - Karol Romero 
        public DataTable CtrlVerfUsuarioFtp(ComLogin entidad)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.Conectar())
            {
                dtResultado = consulta.ConsVerifUsuarioFtp(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
            }
            return dtResultado;
        }

        //PCTWebFTPDescargas_MOD_0001_20200914 - 14/09/2020 - Se añade metodo para consultas de usuarios FTP en MySql- Karol Romero 
        public DataTable CtrlVerfUsuarioFtpMySQL(ComLogin entidad)
        {
            ConexionBDMySQL oconexion = new ConexionBDMySQL();
            DataTable dtResultado = new DataTable();
            ComConsLogin consulta = new ComConsLogin();

            if (oconexion.ConectarMysql())
            {
                dtResultado = consulta.ConsVerifUsuarioFtpMySql(entidad, oconexion);
                Mensaje = consulta.Mensaje;
                oconexion.Desconectar();
            }
            else
            {
                Mensaje = oconexion.Mensaje;
            }
            return dtResultado;
        }

    }
}


