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
    public class ComConsMeses
    {
        public string Mensaje;
        public DataTable ConsConsultarMeses (ConexionBD oConexcion, ComMeses EntidadMeses)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            consulta = "SELECT MES, NOM_MES FROM MESES ";
            
            if (!string.IsNullOrEmpty(EntidadMeses.MES) && !string.IsNullOrEmpty(EntidadMeses.NOM_MES))
            {
                consulta += " WHERE MES LIKE '%" + EntidadMeses.NOM_MES + "%' OR UPPER(NOM_MES) LIKE '%" + EntidadMeses.NOM_MES.ToUpper() + "%' ";
            } else {
                //Se añade consulta de MES - Ingrid
                if (!string.IsNullOrEmpty(EntidadMeses.MES))
                {
                    consulta += " WHERE MES = '" + EntidadMeses.MES + "' ";
                }
            }
            //Se añade filtro de mes superiores al mes de la fecha de radicacion en la forma de Mes de Causacion
            if (!string.IsNullOrEmpty(EntidadMeses.MES_CAUSACION) && !string.IsNullOrEmpty(EntidadMeses.MES_CAUSACION)) {
                consulta += "WHERE MES NOT IN(0,13) " +
                "AND MES >= " + EntidadMeses.MES_CAUSACION + " " +
                "ORDER BY MES ";
            }

            dtResultado = oConexcion.Consulta(consulta);
            Mensaje = oConexcion.Mensaje;

            return dtResultado;
        }
    


    }
}