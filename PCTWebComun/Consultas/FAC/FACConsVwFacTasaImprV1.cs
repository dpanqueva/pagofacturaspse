using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComunNet.Consultas.FAC
{
    public class FACConsVwFacTasaImprV1
    {
        public string Mensaje;
        public DataTable ConsVwFacTasaImprV1(ConexionBD oconexion, string Codigofactura)
        {
            DataTable dtConsulta = new DataTable();

            string sentencia = "";

            if (!string.IsNullOrEmpty(Codigofactura))
            {
                sentencia = "SELECT * FROM VW_FACTTASA_IMPR_V2 where COD_FACTURA = '"+ Codigofactura + "' ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}
