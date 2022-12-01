//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea controlador de la tabla FIRMAS- Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComun._ConexionesBD;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlFirmas
    {
        public string Mensaje;

        public DataTable CtrlConsultarFirmas(COMFirmas EntidadClaseFirmas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsFirmas comConsFirmas = new COMConsFirmas();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsFirmas.ConsConsultarFirmas(oconexion, EntidadClaseFirmas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
    }
}
