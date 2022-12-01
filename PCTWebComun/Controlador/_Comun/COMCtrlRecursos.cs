using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Collections.Generic;
using System;
using System.Data;
using PCTWebComun.Utilidades;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlRecursos
    {
        public string Mensaje;
        public DataTable CtrlConsultarRecursos(ComRecursos entidadRecursos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta  = new DataTable();
            ComConsRecursos comConsRecursos = new ComConsRecursos();

            if (oConexion.Conectar()) {
                dtConsulta = comConsRecursos.ConsConsultarRecursos(oConexion, entidadRecursos);
                Mensaje = oConexion.Mensaje;
            }
            else {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsRecursos(ComRecursos EntidadRecursos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsRecursos comConsRecursos = new ComConsRecursos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsRecursos.ConsConsRecursos(oConexion, EntidadRecursos);
                //Mensaje = comConsRecursos.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
