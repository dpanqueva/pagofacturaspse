//PCT.NET_NVO_0000_20190521 - Fecha Inicio 14/10/2020 - Ticket Nº 038738- Caso: se crea Controlador para la función de compara ppto (Ingresos) se llama desde Modificaciones de Apropiacion - Participantes: Wendy Simbaqueba
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
    public class COMCtrlPptoIngresos
    {
        public string Mensaje;
        public DataTable CtrlComparaPptoIngresos()
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsPptoIngresos comConsPptoIngresos = new COMConsPptoIngresos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsPptoIngresos.ConsComparaPptoIngresos(oConexion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarPptoIngresos(COMPptoIngresos EntidadPptoIngresos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsPptoIngresos comConsPptoIngresos = new COMConsPptoIngresos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsPptoIngresos.ConsConsultarPptoIngresos(oConexion, EntidadPptoIngresos);
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
