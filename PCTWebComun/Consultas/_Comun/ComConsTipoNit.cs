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
    public class ComConsTipoNit
    {
        public string Mensaje;
        public DataTable ConsCargarTipoNit(ConexionBD oconexion, ComTipoNit EntidadTipoNit)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT TIPO_DOCUMENTO,NOM_TIPO, CTRL_ALFA,CALCULAR_DV, TAMANO FROM TIPO_NIT WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadTipoNit.TIPO_DOCUMENTO))
            {
                sentencia = sentencia + " AND TIPO_DOCUMENTO = '" + EntidadTipoNit.TIPO_DOCUMENTO + "' ";
            }

            sentencia += " ORDER BY NOM_TIPO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }        
    }
}
