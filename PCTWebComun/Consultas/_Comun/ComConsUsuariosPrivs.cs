using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.IME.COM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsUsuariosPrivs
    {
        private DbParameterCollection oPermiso;
        public DbParameterCollection Valores
        {
            get { return oPermiso; }
            set { oPermiso = value; }
        }

        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public Boolean ConsConsultarPermisosNit(ComUsuariosPrivs EntidadUsuariosPrivs, ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            Boolean respuesta = new Boolean();
            string sentencia = "SELECT * FROM USUARIOS_PRIVS  WHERE COD_ACCION ='" + EntidadUsuariosPrivs.PERMISOS + "' AND USUARIO ='" + EntidadUsuariosPrivs.USUARIO + "'";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            if (dtConsulta != null)
            {
                if (dtConsulta.Rows.Count > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }

        public Boolean ConsStPermiso(ComUsuariosPrivs EntidadUsuariosPrivs, ConexionBD oconexion)
        {
            bool resultado;

            List<DbParameter> listaParametro = new List<DbParameter>();
            ComIMEAutorizacionUsuario comIMEAutorizacionUsuario = new ComIMEAutorizacionUsuario();

            listaParametro = comIMEAutorizacionUsuario.ProcedimientoComStPermiso(EntidadUsuariosPrivs);

            resultado = oconexion.EjecutarProcedimieto("ST_PERMISO", listaParametro);

            Mensaje = oconexion.Mensaje;


            if (oconexion.VariableSalida != null)
            {
                oPermiso = oconexion.VariableSalida.Parameters;
            }
            lmensaje = oconexion.Mensaje;

            return resultado;
        }

        public DataTable ConsConsultarUsuariosPrivs(ConexionBD oConexion, ComUsuariosPrivs EntidadUsuariosPrivs)
        {
            string sentencia = "SELECT * FROM USUARIOS_PRIVS WHERE 1=1";
            DataTable dtsConsulta = new DataTable();

            if (!string.IsNullOrEmpty(EntidadUsuariosPrivs.COD_ACCION))
            {
                sentencia +=" AND COD_ACCION='"+ EntidadUsuariosPrivs.COD_ACCION + "'";
            }

            if (!string.IsNullOrEmpty(EntidadUsuariosPrivs.USUARIO))
            {
                sentencia += " AND USUARIO='" + EntidadUsuariosPrivs.USUARIO + "'";
            }

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
    }
}
