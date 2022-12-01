using System;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsLogin
    {
        private string lmensaje;

        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        public DataTable ConsVerifUsuario(ComLogin entidad, ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "SELECT * FROM DBA_USERS WHERE USERNAME ='" + entidad.Usuario + "'";

            dtResultado = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;

            return dtResultado;
        }

        public DataTable ConsVerifUsuarioPct(ComLogin entidad, ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "SELECT * FROM USUARIOS_PCT WHERE USUARIO ='" + entidad.Usuario + "'";

            dtResultado = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;

            return dtResultado;
        }

        public DataTable ConsNombreEntidad(ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "select NOM_SECCION,VIGENCIA_ACTUAL,NIT from ctrl_entidad";

            dtResultado = oconexion.Consulta(sentencia);

            return dtResultado;
        }

        public DataTable ConsObtenerLogo(ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "select logo_rpt,NOM_SECCION,NIT from ctrl_entidad";

            dtResultado = oconexion.Consulta(sentencia);

            return dtResultado;
        }

        public DataTable ConsPrivilegiosConsulta(ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "select cod_accion, nom_accion from acciones where nom_accion like '%CONSULTA%' and cod_accion between 7000 and 7016 order by cod_accion";

            dtResultado = oconexion.Consulta(sentencia);

            return dtResultado;
        }

        public DataTable ConsPrivilegiosUsuario(ComLogin entidad, ConexionBD oconexion)
        {

            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "SELECT A.USUARIO, A.COD_ACCION, 'S' OTORGADO, 'U' TIPO, 'S' EST_ANTERIOR ";
            sentencia = sentencia + "FROM USUARIOS_PRIVS A where upper(A.USUARIO)=upper('" + entidad.Usuario + "') and cod_accion between 7000 and 7016 order by cod_accion";

            dtResultado = oconexion.Consulta(sentencia);

            return dtResultado;

        }

        public bool ConsVerifiPermiso(ComLogin entidad, ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;
            bool encontrado;

            encontrado = false;

            sentencia = "select * from USUARIOS_PRIVS where usuario='" + entidad.Usuario + "'";

            if (!String.IsNullOrEmpty(entidad.CodAccion))
            {
                sentencia = sentencia + " and cod_Accion='" + entidad.CodAccion + "'";
            }
            if (!String.IsNullOrEmpty(entidad.CodAccionIni))
            {
                sentencia = sentencia + " and cod_Accion BETWEEN '" + entidad.CodAccionIni + "' AND '" + entidad.CodAccionFin + "'";
            }
            dtResultado = oconexion.Consulta(sentencia);


            if (dtResultado != null)
            {

                if (dtResultado.Rows.Count > 0)
                {
                    encontrado = true;
                }//fin if (dtResultado.Rows.Count>0)

            }//fin if(dtResultado<>nil)

            return encontrado;

        }

        public DataTable ConsObtenerListaPermisos(ComLogin entidad, ConexionBD oconexion)
        {
            string sentencia;
            DataTable dtResultado = new DataTable();

            sentencia = "select COD_ACCION from USUARIOS_PRIVS where usuario='" + entidad.Usuario + "'";

            if (!String.IsNullOrEmpty(entidad.CodAccion))
            {
                sentencia = sentencia + " and cod_Accion='" + entidad.CodAccion + "'";
            }

            if (!String.IsNullOrEmpty(entidad.CodAccionIni))
            {
                sentencia = sentencia + " and cod_Accion BETWEEN '" + entidad.CodAccionIni + "' AND '" + entidad.CodAccionFin + "'";
            }

            dtResultado = oconexion.Consulta(sentencia);
            return dtResultado;
        }

        public bool ConsCambiarClave(ComLogin entidad, ConexionBD oconexion)
        {
            string sentencia;
            bool bResultado = false;

            sentencia = "ALTER USER " + entidad.Usuario + " IDENTIFIED BY " + entidad.NuevaClave;

            bResultado = oconexion.EjecutarSQL(sentencia);

            return bResultado;
        }

        public bool ConsCambiarClavePct(ComLogin entidad, ConexionBD oconexion)
        {
            string sentencia;
            bool bResultado = false;

            sentencia = "UPDATE USUARIOS_PCT SET CLAVE = '" + entidad.NuevaClave + "' WHERE USUARIO = '" + entidad.Usuario + "'";

            bResultado = oconexion.EjecutarSQL(sentencia);

            return bResultado;
        }

        //PCTWebFTPDescargas_NVO_0000_20200513 - 13/05/2020 - Se añade metodo para consultas de usuarios FTP - Karol Romero 
        public DataTable ConsVerifUsuarioFtp(ComLogin entidad, ConexionBD oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "SELECT * FROM FTP_CLIENTES WHERE NOM_FTP_CLIENTE LIKE '%" + entidad.Usuario + "%'";

            dtResultado = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;

            return dtResultado;
        }

        //PCTWebFTPDescargas_MOD_0001_20200914 - 14/09/2020 - Se añade metodo para consultas de usuarios FTP en MySql- Karol Romero 
        public DataTable ConsVerifUsuarioFtpMySql(ComLogin entidad, ConexionBDMySQL oconexion)
        {
            DataTable dtResultado = new DataTable();
            string sentencia;

            sentencia = "SELECT * FROM FTP_CLIENTES WHERE NOM_FTP_CLIENTE LIKE '%" + entidad.Usuario + "%'";

            dtResultado = oconexion.ConsultaMySql(sentencia);
            lmensaje = oconexion.Mensaje;

            return dtResultado;
        }
    }
}