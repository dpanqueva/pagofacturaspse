//PCT.NET_NVO_0000_20190521 - Fecha Inicio 18/12/2020 - Ticket Nº 0000  - Caso: se agrega clase  de CATEGORIA_TIPO_INGRESOS, Solicitud de Maribel pedroza- Participantes: Oscar Ramos

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
    public class FACCtrlCategoriaTipoIngresos
    {
        public string Mensaje;
        public DataTable CtrlConsultarCategoriaTipoIngresos(FACCategoriaTipoIngresos EntidadCategoriaTipoIngresos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsCategoriaTipoIngresos facConsCategoriaTipoIngresos = new FACConsCategoriaTipoIngresos();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsCategoriaTipoIngresos.ConsConsultarCategoriaTipoIngresos(oConexion, EntidadCategoriaTipoIngresos);
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
