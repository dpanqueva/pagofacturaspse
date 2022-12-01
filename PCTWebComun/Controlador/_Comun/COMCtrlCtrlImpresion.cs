//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/03/2021 - Ticket Nº 0000 - Caso: se agrega la Clase para CTRL_IMPRESION, Solicitud de Karen Gaviria - Participantes: Oscar Ramos

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
    public class COMCtrlCtrlImpresion
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        public Boolean CtrlEjecutarStCtrlImpresion(COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            COMConsCtrlImpresion comConsCtrlImpresion = new COMConsCtrlImpresion();

            if (oConexion.Conectar())
            {
                Consulta = comConsCtrlImpresion.ConsEjecutarStCtrlImpresion(oConexion, EntidadCtrlImpresion, NumIni, NumFin);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }
            lmensaje = comConsCtrlImpresion.Mensaje;
            return Consulta;
        }

        public Boolean CtrlEjecutarStCtrlImpresionFirma(COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            COMConsCtrlImpresion comConsCtrlImpresion = new COMConsCtrlImpresion();

            if (oConexion.Conectar())
            {
                Consulta = comConsCtrlImpresion.ConsEjecutarStCtrlImpresionFirma(oConexion, EntidadCtrlImpresion, NumIni, NumFin);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }
            lmensaje = comConsCtrlImpresion.Mensaje;
            return Consulta;
        }
    }
}
