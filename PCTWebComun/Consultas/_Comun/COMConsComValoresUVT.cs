

//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/09/2020 - Ticket N° 000000 - Caso: Se agrega pagina al proyecto, por solicitud de Maribel - Participantes: Oscar Ramos

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
    public class COMConsComValoresUVT
    {
        public string Mensaje;
        public DataTable ConsConsultarComValoresUVT(ConexionBD oconexion, COMComValoresUVT EntidadComValoresUVT)
        {
            string sentencia = "SELECT * FROM COM_VALORES_UVT";
            DataTable dtsConsulta;

            sentencia += " WHERE 1 = 1 ";

            if ((!string.IsNullOrEmpty(EntidadComValoresUVT.VIGENCIA)) && (!string.IsNullOrEmpty(EntidadComValoresUVT.VIGENCIA)))
            {
                sentencia = sentencia + " AND VIGENCIA = " + EntidadComValoresUVT.VIGENCIA + " ";
            }

            if ((!string.IsNullOrEmpty(EntidadComValoresUVT.ID_COM_ENTIDAD)) && (!string.IsNullOrEmpty(EntidadComValoresUVT.ID_COM_ENTIDAD)))
            {
                sentencia = sentencia + " AND ID_COM_ENTIDAD = " + EntidadComValoresUVT.ID_COM_ENTIDAD + " ";
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
