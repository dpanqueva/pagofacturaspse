//PCT.NET_NVO_0000_20190521 - Fecha Inicio 30/08/2021 - Ticket Nº 00000 - Caso: Se agrega Controlador de clase_conceptos, Solicitud de Jheisone Padilla - Participantes: Oscar Ramos

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
    public class COMCtrlClaseConceptos
    {
        public string Mensaje;
        public DataTable CtrlConsultarClaseConceptos(COMClaseConceptos entidadClaseConceptos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsClaseConceptos comConsClaseConceptos = new COMConsClaseConceptos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseConceptos.ConsConsultarClaseConceptos(oConexion, entidadClaseConceptos);
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
