//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/06/2021 - Ticket N° 00000 - Caso: Se agrega Clase controlador CTRL_TIPO_FACTURA, Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

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
    public class FACCtrlCtrlTipoFactura
    {
        public string Mensaje;
        public DataTable CtrlConsultarFACCtrlCtrlTipoFactura(FACCtrlTipoFactura EntidadFACCtrlTipoFactura)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsCtrlTipoFactura facCtrlTipoFactura = new FACConsCtrlTipoFactura();

            if (oConexion.Conectar())
            {
                dtConsulta = facCtrlTipoFactura.ConsConsultarFACConsCtrlTipoFactura(oConexion, EntidadFACCtrlTipoFactura);
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