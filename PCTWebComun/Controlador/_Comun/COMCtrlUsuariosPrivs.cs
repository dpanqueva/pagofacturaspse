using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlUsuariosPrivs
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

        public Boolean CtrlConsultarPermisosNit(ComUsuariosPrivs EntidadUsuariosPrivs)
        {

            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsUsuariosPrivs comConsUsuariosPrivs = new ComConsUsuariosPrivs();

            if (oConexion.Conectar())
            {
                Consulta = comConsUsuariosPrivs.ConsConsultarPermisosNit(EntidadUsuariosPrivs, oConexion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public Boolean CtrlStPermiso(ComUsuariosPrivs EntidadUsuariosPrivs)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsUsuariosPrivs comConsUsuariosPrivs = new ComConsUsuariosPrivs();

            if (oConexion.Conectar())
            {
                Consulta = comConsUsuariosPrivs.ConsStPermiso(EntidadUsuariosPrivs, oConexion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            if (comConsUsuariosPrivs.Valores != null)
            {
                oPermiso = comConsUsuariosPrivs.Valores;
            }
            lmensaje = comConsUsuariosPrivs.Mensaje;

            return Consulta;
        }

        public DataTable CtrlConsultarUsuariosPrivs(ComUsuariosPrivs EntidadUsuariosPrivs)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtsConsulta = new DataTable();
            ComConsUsuariosPrivs comConsUsuariosPrivs=new ComConsUsuariosPrivs();

            if (oConexion.Conectar())
            {
                dtsConsulta = comConsUsuariosPrivs.ConsConsultarUsuariosPrivs(oConexion, EntidadUsuariosPrivs);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtsConsulta;
        }
    }
}
