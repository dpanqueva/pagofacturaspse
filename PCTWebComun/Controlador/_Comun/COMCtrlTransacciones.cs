//PCT.NET_NVO_0000_20190521 - Fecha Inicio 12/07/2019 - Ticket Nº 35862 - Caso: Implementacion pagina Consulta Histórico de Presupuesto de Gastos - Participantes: Sonia Cruz

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
    public class COMCtrlTransacciones
    {
        public string Mensaje;
        public DataTable CtrlConsultarTransacciones(ComTransacciones entidadTransacciones)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsTransacciones comConsTransacciones = new ComConsTransacciones();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsTransacciones.ConsConsultarTransacciones(oConexion, entidadTransacciones);
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
