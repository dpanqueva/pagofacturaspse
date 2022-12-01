//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se crea clase consulta de CLASE_ELEMENTOSSERVICIOS - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsClaseElementosservicios
    {
        public string Mensaje;

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 08/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la consulta de CLASE_ELEMENTOSSERVICIO - Participantes: Oscar Ramos.
        public DataTable ConsConsultarClaseElementosservicio(ConexionBD oConexion, COMClaseElementosservicios EntidadClaseElementosservicio)
        {
            DataTable dtsResultado = new DataTable();
            string sentencia = " SELECT * FROM CLASE_ELEMENTOSSERVICIO WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadClaseElementosservicio.COD_CATEGORIA))
            {
                sentencia += " AND COD_CATEGORIA='" + EntidadClaseElementosservicio.COD_CATEGORIA + "'";
            }

            if (!string.IsNullOrEmpty(EntidadClaseElementosservicio.COD_ELEMENTO))
            {
                sentencia += " AND COD_ELEMENTO=" + EntidadClaseElementosservicio.COD_ELEMENTO;
            }

            if (!string.IsNullOrEmpty(EntidadClaseElementosservicio.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + EntidadClaseElementosservicio.VIGENCIA;
            }

            dtsResultado = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsResultado;
        }
    }
}
