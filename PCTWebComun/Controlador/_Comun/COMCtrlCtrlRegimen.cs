/* PCT.NET_NVO_0000_20190521 - Fecha Inicio 24/04/2021 - Ticket Nº 0000 - Caso: se añade ClaseControlador  para CTRL_REGIMEN - Participantes: Oscar Ramos*/
// PCT.NET_NVO_0000_20200521 - Fecha Inicio 26/04/2021 - Ticket Nº 040070 - Caso: Se agregan el metodo para cargar los datos de la tabla CTR_REGIMEN - Participantes: Jaime Zuleta

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtrlRegimen
    {
        public string Mensaje;

        public DataTable CtrlConsultarCtrlRegimen(COMCtrlRegimen EntidadCtrlRegimen)
        {
            DataTable dtConsulta = new DataTable();
            ConexionBD oConexion = new ConexionBD();
            COMConsCtrlRegimen comConsCtrlRegimen = new COMConsCtrlRegimen();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtrlRegimen.ConsConsultarCtrlRegimen(oConexion, EntidadCtrlRegimen);
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
