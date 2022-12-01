//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000 - Caso: Se agrega la clase Controlador QTipoFactura, solicitud de Ingrid Gomez - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200521 - Fecha Inicio 14/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador de QTipoFactura - Participantes: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.CamposQueries.FAC;
using PCTWebComun.Queries.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlQTipoFactura
    {
        public string Mensaje;
        public DataTable CtrlConsultarTipoFactDistri(FACCQTipoFactura CamposQuerieTipofactura)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACQTipoFactura fACQTipoFactura = new FACQTipoFactura();

            if (oConexion.Conectar())
            {
                dtConsulta = fACQTipoFactura.ConsultarTipoFactDistri(oConexion, CamposQuerieTipofactura);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        public DataTable CtrlConsultarTipoFactcons(FACCQTipoFactura CamposQuerieTipofacturacons)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACQTipoFactura fACQTipoFactura = new FACQTipoFactura();

            if (oConexion.Conectar())
            {
                dtConsulta = fACQTipoFactura.ConsultarTipoFactcons(oConexion, CamposQuerieTipofacturacons);
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
