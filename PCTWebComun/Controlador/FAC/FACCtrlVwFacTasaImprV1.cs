using PCTWebComun._ConexionesBD;
using PCTWebComun.Utilidades;
using PCTWebComunNet.Consultas.FAC;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlVwFacTasaImprV1
    {
        private string lmensaje;

        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        public RespuestaNet CtrlVwFacTasaImprV1(string Codigofactura)
        {
            RespuestaNet respuesta = new RespuestaNet();
            FACConsVwFacTasaImprV1 facConsVwFacTasaImprV1 = new FACConsVwFacTasaImprV1();
            ConexionBD oConexion = new ConexionBD();

            if (oConexion.Conectar())
            {
                respuesta.Data = facConsVwFacTasaImprV1.ConsVwFacTasaImprV1(oConexion, Codigofactura);
                oConexion.Desconectar();
            }

            respuesta.Mensaje = facConsVwFacTasaImprV1.Mensaje;
            return respuesta;
        }
    }
}
