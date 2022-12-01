//PCT.NET_NVO_0000_20190521 - Fecha Inicio 14/10/2020 - Ticket Nº 038738- Caso: se crea Consulta para la función de compara ppto (Ingresos) se llama desde Modificaciones de Apropiacion - Participantes: Wendy Simbaqueba
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsPptoIngresos
    {
        public string Mensaje;
        public DataTable ConsComparaPptoIngresos(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            try
            {

                string Sentencia = " SELECT SUM(A.ING_INICIAL + A.ING_ADICION - A.ING_REDUCCION) TOTAL_INGRESOS";
                Sentencia = Sentencia + " FROM PPTO_INGRESOS A ";
                Sentencia = Sentencia + " WHERE A.VIGENCIA = (SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD) ";

                dtConsulta = oconexion.Consulta(Sentencia);
                Mensaje = oconexion.Mensaje;

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtConsulta;
        } 
        
        public DataTable ConsConsultarPptoIngresos(ConexionBD oconexion, COMPptoIngresos EntidadPptoIngresos)
        {
            DataTable dtConsulta = new DataTable();
            try
            {

                string Sentencia = " SELECT * FROM PPTO_INGRESOS WHERE 1=1 ";

                if (!string.IsNullOrEmpty(EntidadPptoIngresos.COD_INGRESO))
                {
                    Sentencia += " AND COD_INGRESO="+ EntidadPptoIngresos.COD_INGRESO;
                }


                if (!string.IsNullOrEmpty(EntidadPptoIngresos.COD_UNIDAD))
                {
                    Sentencia += " AND COD_UNIDAD="+ EntidadPptoIngresos.COD_UNIDAD;
                }

                if (!string.IsNullOrEmpty(EntidadPptoIngresos.VIGENCIA))
                {
                    Sentencia += " AND VIGENCIA="+ EntidadPptoIngresos.VIGENCIA;
                }

                dtConsulta = oconexion.Consulta(Sentencia);
                Mensaje = oconexion.Mensaje;

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtConsulta;
        }
    }
}
