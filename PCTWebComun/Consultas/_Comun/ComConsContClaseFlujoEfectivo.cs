using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsContClaseFlujoEfectivo
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public DataTable ConsConsultarContClaseFlujoEfectivo(ConexionBD conexionBD)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT * FROM CONT_CLASE_FLUJO_EFECTIVO ";

            sentencia += " ORDER BY COD_FLUJO";
            dtConsulta = conexionBD.Consulta(sentencia);
            Mensaje = conexionBD.Mensaje;
            return dtConsulta;
        }
    }
}
