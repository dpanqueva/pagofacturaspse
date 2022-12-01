// PCT.NET_NVO_0000_20190521 - Fecha Inicio 19/04/2020 - Ticket Nº 0000 - Caso: Se crea clase Consulta para NIVEL, Solicitud de Jaime Zuleta - Participantes: Oscar Ramos   

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsNivel
    {
        public string Mensaje;
        public DataTable ConsConsultarNivelArbol(ConexionBD oconexion, COMNivel EntidadNivel)
        {
            string sentencia ="";
            DataTable dtsConsulta;

            if (!string.IsNullOrEmpty(EntidadNivel.ARBOL))
            {
                sentencia = "SELECT * FROM NIVEL WHERE ARBOL = '" + EntidadNivel.ARBOL + "'";

                if (!string.IsNullOrEmpty(EntidadNivel.TAMANO))
                {
                    sentencia += " AND TAMANO = '" + EntidadNivel.TAMANO + "'";
                }

                if (!string.IsNullOrEmpty(EntidadNivel.NIVEL))
                {
                    sentencia += " AND NIVEL = '" + EntidadNivel.NIVEL + "'";
                }
            } 

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable ConsConsultarNivel(ConexionBD oconexion, ComCuentas EntidadCuentas)
        {
            string sentencia = "";
            DataTable dtsConsulta;

            if (!string.IsNullOrEmpty(EntidadCuentas.NOMBRE)) {
                sentencia = "SELECT * FROM NIVEL WHERE ARBOL = '" + EntidadCuentas.NOMBRE + "' ";

                if (!string.IsNullOrEmpty(EntidadCuentas.TAMAÑO))
                {
                    sentencia += " AND TAMANO = '" + EntidadCuentas.TAMAÑO + "'";
                }

                if (!string.IsNullOrEmpty(EntidadCuentas.NIVEL))
                {
                    sentencia += " AND NIVEL = '" + EntidadCuentas.NIVEL + "'";
                }
            }
            
            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
