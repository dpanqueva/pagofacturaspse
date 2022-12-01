using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;


namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlAprClaseRecursos
    {
        public string Mensaje;
        public DataTable CtrlConsultarAprClaseRecursos(ComAprClaseRecursos entidadAprClaseRecursos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            AprConsClaseRecursos aprConsClaseRecursos = new AprConsClaseRecursos();

            if (oConexion.Conectar())
            {
                dtConsulta = aprConsClaseRecursos.ConsConsultarAprClaseRecursos(oConexion, entidadAprClaseRecursos);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
