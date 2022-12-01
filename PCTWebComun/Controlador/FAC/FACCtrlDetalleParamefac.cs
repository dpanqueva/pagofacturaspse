//PCT.NET_NVO_0000_20200430 - Fecha Inicio 20/09/2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCtrlDetalleParamefac, Solicitud de Ingrid Gomez - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/09/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador de  DETALLE_PARAMEFAC  - Participantes: Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using PCTWebComun.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlDetalleParamefac
    {
        public string Mensaje;
        public DataTable CtrlConsultarDetallaparamefac(FACDetalleParamefac EntidadConsultaDetallaparamefac)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsDetalleParamefac fACConsDetalleParamefac = new FACConsDetalleParamefac();

            if (oConexion.Conectar())
            {
                dtConsulta = fACConsDetalleParamefac.ConsultarDetallaparamefac(oConexion, EntidadConsultaDetallaparamefac);
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
