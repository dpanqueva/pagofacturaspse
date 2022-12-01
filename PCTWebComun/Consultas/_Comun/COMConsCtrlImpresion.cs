//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/03/2021 - Ticket Nº 0000 - Caso: se agrega la Clase para CTRL_IMPRESION, Solicitud de Karen Gaviria - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.IME.COM;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    class COMConsCtrlImpresion
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public Boolean ConsEjecutarStCtrlImpresion(ConexionBD oConexion, COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            bool resultado;

            List<DbParameter> listaParametro = new List<DbParameter>();
            COMIMECtrlImpresion comIMECtrlImpresion = new COMIMECtrlImpresion();

            listaParametro = comIMECtrlImpresion.ProcedimientoComCtrlImpresion(EntidadCtrlImpresion, NumIni, NumFin);

            resultado = oConexion.EjecutarProcedimieto("ST_CTRL_IMPRESION", listaParametro);
            lmensaje = oConexion.Mensaje;
            return resultado;
        }
        public Boolean ConsEjecutarStCtrlImpresionFirma(ConexionBD oConexion, COMCtrlImpresion EntidadCtrlImpresion, string NumIni, string NumFin)
        {
            bool resultado;

            List<DbParameter> listaParametro = new List<DbParameter>();
            COMIMECtrlImpresion comIMECtrlImpresion = new COMIMECtrlImpresion();

            listaParametro = comIMECtrlImpresion.ProcedimientoComCtrlImpresionFirma(EntidadCtrlImpresion, NumIni, NumFin);

            resultado = oConexion.EjecutarProcedimieto("ST_CTRL_IMPRESION_FIRMA", listaParametro);
            lmensaje = oConexion.Mensaje;
            return resultado;
        }
    }
}
