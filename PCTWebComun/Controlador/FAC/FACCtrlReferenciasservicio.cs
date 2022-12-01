//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/01/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador REFERENCIASSERVICIO, Solicitud deJheisone Padilla- Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlReferenciasservicio
    {
        public string Mensaje;
        public DataTable CtrlConsultarReferenciasServicio(FACReferenciasservicio EntidadReferenciasservicio)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsReferenciasservicio facConsReferenciasservicio = new FACConsReferenciasservicio();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsReferenciasservicio.ConsConsultarReferenciasServicio(oConexion, EntidadReferenciasservicio);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        public DataTable CtrlConsultarConsReferenciaserv(FACReferenciasservicio EntidadReferenciasservicio)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsReferenciasservicio facConsReferenciasservicio = new FACConsReferenciasservicio();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsReferenciasservicio.ConsConsultaConsReferenciaserv(oConexion, EntidadReferenciasservicio);
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
