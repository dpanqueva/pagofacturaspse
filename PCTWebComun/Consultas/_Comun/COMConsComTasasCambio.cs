//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/12/2020 - Ticket Nº 0000  - Caso: Se agrega pagina Clase Consulta de la entidad COM_TASAS_CAMBIO, solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 04/12/2020 - Ticket Nº 039019  - Caso: Se agrega Consulta de COM_TASAS_CAMBIO - Participantes: Milena Leon 

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
    public class COMConsComTasasCambio
    {
        public string Mensaje;

        public DataTable ConsConsultaComTasasCambio(ConexionBD oConexion, COMComTasasCambio EntidadComTasasCambio)
        {
            string sentencia = " SELECT * FROM COM_TASAS_CAMBIO  WHERE  1=1";


            if (!string.IsNullOrEmpty(EntidadComTasasCambio.COD_MONEDA))
            {
                sentencia += " AND COD_MONEDA ='" + EntidadComTasasCambio.COD_MONEDA + "'";
            }

            if (!string.IsNullOrEmpty(EntidadComTasasCambio.FECHA_CAMBIO))
            {
                sentencia += " AND FECHA_CAMBIO ='" + EntidadComTasasCambio.FECHA_CAMBIO + "'";
            }

            sentencia += " ORDER BY COD_MONEDA";

            DataTable dtsConsulta;

            dtsConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsConsulta;
        }
    }
}
