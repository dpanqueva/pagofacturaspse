using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    class COMConsFormatosGirosElectronicos
    {
        public string Mensaje;
        public DataTable ConsConsultarFormatosGirosElectronicos(ConexionBD oconexion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT COD_FORMATO, NOM_FORMATO,COD_REGISTRO,(FC_EGR_FORMATO_ACH(COD_FORMATO,COD_REGISTRO))SENTENCIA,EJEMPLO_FORMATO "+
                "FROM FORMATOS_GIROS_ELECTRONICOS  " +
                "ORDER BY NOM_FORMATO,COD_FORMATO,COD_REGISTRO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}
