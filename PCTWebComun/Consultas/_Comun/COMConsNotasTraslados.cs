//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/12/2020 - Ticket Nº 0000  - Caso: Se agrega pagina Clase Consulta de la entidad NOTAS_TRASLADOS, solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 07/12/2020 - Ticket Nº 039019 - Caso: Se agrega  Consulta de NOTAS_TRASLADOS - Participantes:Milena Leon 

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
    public class COMConsNotasTraslados
    {
        public string Mensaje;

        public DataTable ConsConsultaComNotasTraslados(ConexionBD oConexion, COMNotasTraslados EntidadComNotasTraslados)
        {
            string sentencia = " SELECT * FROM NOTAS_TRASLADOS  WHERE  1=1";


            if (!string.IsNullOrEmpty(EntidadComNotasTraslados.NUM_TRASLADO))
            {
                sentencia += " AND NUM_TRASLADO = " + EntidadComNotasTraslados.NUM_TRASLADO;
            }

            if (!string.IsNullOrEmpty(EntidadComNotasTraslados.NUM_INGRESO))
            {
                sentencia += " AND NUM_INGRESO = " + EntidadComNotasTraslados.NUM_INGRESO;
            }
            if (!string.IsNullOrEmpty(EntidadComNotasTraslados.NUM_EGRESO))
            {
                sentencia += " AND NUM_EGRESO = " + EntidadComNotasTraslados.NUM_EGRESO;
            }

            sentencia += " ORDER BY NUM_TRASLADO";

            DataTable dtsConsulta;

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
    }
}
