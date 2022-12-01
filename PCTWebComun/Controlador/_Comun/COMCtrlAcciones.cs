//PCT.NET_NVO_0000_20200604 - Fecha Inicio 04/06/2020 - Ticket Nº 037564 - Caso: se crea el controlador de consulta de la tabla ACCIONES- Participantes: Maribel Pedroza
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlAcciones
    {
        public string Mensaje;

        public Boolean CtrlConsultarAcciones(ComAcciones EntidadAcciones)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsAcciones comConsAcciones = new ComConsAcciones();

            if (oConexion.Conectar())
            {
                Consulta = comConsAcciones.ConsConsultarAcciones(EntidadAcciones, oConexion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public DataTable CtrlConsultarNombreAcciones(ComAcciones EntidadAcciones)
        {
            ConexionBD oConexion = new ConexionBD();
            ComConsAcciones comConsAcciones = new ComConsAcciones();
            DataTable dtConsulta = new DataTable();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsAcciones.ConsConsultarNombreAcciones(oConexion, EntidadAcciones);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            } else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
