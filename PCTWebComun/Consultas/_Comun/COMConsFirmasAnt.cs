//PCT.NET_NVO_0000_20190521 - Fecha Inicio 05/08/2020 - Ticket Nº 0000  - Caso: se crea controlador de la tabla FIRMAS- Participantes: Oscar Ramos

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
    public class COMConsFirmas
    {
        public string Mensaje;

        public DataTable ConsConsultarFirmas(ConexionBD oConexcion, COMFirmas EntidadFirmas)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            consulta = "SELECT * FIRMAS";


            dtResultado = oConexcion.Consulta(consulta);
            Mensaje = oConexcion.Mensaje;

            return dtResultado;
        }
    }
}
