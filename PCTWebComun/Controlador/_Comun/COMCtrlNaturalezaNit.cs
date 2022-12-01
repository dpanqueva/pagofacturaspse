using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlNaturalezaNit
    {
        public string Mensaje;
        public DataTable CtrlCargarNaturalezaNit()
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsNaturalezaNit comConsNaturalezaNit = new ComConsNaturalezaNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsNaturalezaNit.ConsCargarNaturalezaNit(oConexion);
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
