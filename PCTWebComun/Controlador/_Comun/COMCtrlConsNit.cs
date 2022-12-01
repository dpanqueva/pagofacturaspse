//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se crea controlador de consulta de la tabla REGIONES- Participantes: Maribel Pedroza


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlConsNit
    {

        public string Mensaje;
        public DataTable CtrlConsultarNit(ComNit EntidadNit)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsNit comConsNit = new ComConsNit();
     
            if (oConexion.Conectar())
            {
                dtConsulta = comConsNit.ConsConsultarNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
