//PCT.NET_NVO_0000_20190521 - Fecha Inicio 14/10/2020 - Ticket Nº 038738- Caso: se crea Consulta para la función de compara ppto se llama desde Modificaciones de Apropiacion - Participantes: Wendy Simbaqueba
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsPptoGastos
    {
        public string Mensaje;
        public DataTable ConsConsultarPptoGastos(ConexionBD oconexion,COMPptoGastos EntidadPptoGastos)
        {
            DataTable dtConsulta = new DataTable();
            try
            {
                string Sentencia = " SELECT * FROM  PPTO_GASTOS WHERE 1 = 1";

                if (!string.IsNullOrEmpty(EntidadPptoGastos.COD_GASTO))
                {
                    Sentencia += " AND COD_GASTO="+ EntidadPptoGastos.COD_GASTO;
                }

                if (!string.IsNullOrEmpty(EntidadPptoGastos.COD_UNIDAD))
                {
                    Sentencia += " AND COD_UNIDAD="+ EntidadPptoGastos.COD_UNIDAD;
                }

                if (!string.IsNullOrEmpty(EntidadPptoGastos.VIGENCIA))
                {
                    Sentencia += " AND VIGENCIA="+ EntidadPptoGastos.VIGENCIA;
                }

                if (!string.IsNullOrEmpty(EntidadPptoGastos.TIP_PAC))
                {
                    Sentencia += " AND TIP_PAC='" + EntidadPptoGastos.TIP_PAC+"'";
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
        
        public DataTable ConsComparaPptos(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            try
            {
                string Sentencia = " SELECT SUM(APROP_INICIAL+APROP_ADICIONAL - APROP_REDUCIDA)TOTAL_GASTOS ";
                   Sentencia = Sentencia + "FROM  PPTO_GASTOS B";
                   Sentencia = Sentencia + " WHERE B.VIGENCIA = (SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD)";
                   Sentencia = Sentencia + " WHERE TIP_PAC = (SELECT RECURSOS  FROM PAC_INICIAL_DISP_TMP)";

                dtConsulta = oconexion.Consulta(Sentencia);
            Mensaje = oconexion.Mensaje;

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtConsulta;
        }
        


        public DataTable ConsComparaPptosPacInicial(ConexionBD oconexion, COMPptoGastos EntidadPptoGastos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT * ";                              
            sentencia += " FROM PPTO_GASTOS ";

            if (!string.IsNullOrEmpty(EntidadPptoGastos.VIGENCIA))
            {
                sentencia += " WHERE VIGENCIA = '" + EntidadPptoGastos.VIGENCIA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadPptoGastos.TIP_PAC))
            {
                sentencia += " AND TIP_PAC = '" + EntidadPptoGastos.TIP_PAC + "' ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable ConsConsPptoGastosTipPac(ConexionBD oconexion, COMPptoGastos EntidadPptoGastos)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT * ";
            sentencia += " FROM PPTO_GASTOS ";

            if (!string.IsNullOrEmpty(EntidadPptoGastos.VIGENCIA))
            {
                sentencia += " WHERE VIGENCIA = '" + EntidadPptoGastos.VIGENCIA + "' ";
            }

            if (!string.IsNullOrEmpty(EntidadPptoGastos.TIP_PAC))
            {
                sentencia += " AND TIP_PAC = '" + EntidadPptoGastos.TIP_PAC + "' ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }




    }
    
}
