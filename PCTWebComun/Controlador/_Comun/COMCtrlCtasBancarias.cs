//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea controlador de la tabla CTAS_BANCARIAS- Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 24/03/2021 - Ticket Nº 0000  - Caso: se crea controlador de la tabla CTAS_BANCARIAS- Participantes: Maribel Pedroza
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCtasBancarias
    {
        public string Mensaje;
        public DataTable ctrlConsultarCtasBancarias(COMCtasBancarias EntidadCtasBancarias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsCtasBancarias comConsCtasBancarias = new COMConsCtasBancarias();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCtasBancarias.ConsConsultarCtasBancarias(oConexion, EntidadCtasBancarias);
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
