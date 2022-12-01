//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2021 - Ticket Nº 35554  - Caso: se crea clase Controlador de la tabla MCOMPROMISO - Participantes: Oscar Ramos.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlMCompromiso
    {
        public string Mensaje;

        public DataTable ctrlConsultarMCompromiso(COMMCompromiso EntidadMCompromiso)
        {
            DataTable dtConsulta = new DataTable();
            ConexionBD oConexion = new ConexionBD();            
            COMConsMCompromiso comConsMCompromiso = new COMConsMCompromiso();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsMCompromiso.consConsultarMCompromiso(oConexion, EntidadMCompromiso);
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
