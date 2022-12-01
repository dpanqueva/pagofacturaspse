/* PCT.NET_NVO_0000_20190521 - Fecha Inicio 24/04/2021 - Ticket Nº 0000 - Caso: se añade Clase Consulta para CTRL_REGIMEN - Participantes: Oscar Ramos*/
// PCT.NET_NVO_0000_20200521 - Fecha Inicio 26/04/2021 - Ticket Nº 040070 - Caso: Se agregan el metodo para cargar los datos de la tabla CTR_REGIMEN - Participantes: Jaime Zuleta

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsCtrlRegimen
    {
        private string Mensaje;

        public DataTable ConsConsultarCtrlRegimen(ConexionBD oconexion, COMCtrlRegimen EntidadCtrlRegimen)
        {
            DataTable dtsConsulta;
            string sentencia = "SELECT FACTURA_I, NUMERO_FACTURAS, RESOLUCION, DECODE(ESTADO,'A','Activo','I', 'Inactivo') ESTADO, REGIMEN, DECODE(COD_TIPO, -1, 'Documento Equivalente') TIPO_FACTURA, RELLENAR_CEROS, COD_TIPO, PREFIJO, FECHA_INICIO, FECHA_FIN, CLTEC, CONSECUTIVO, DESCRIPCION, FECHA_CONSECUTIVO, RESOLUCION||'-'||PREFIJO SELECCION FROM CTRL_REGIMEN";

            sentencia += " WHERE 1 = 1";

            if (!string.IsNullOrEmpty(EntidadCtrlRegimen.COD_TIPO))
            {
                sentencia = sentencia + " AND COD_TIPO = '" + EntidadCtrlRegimen.COD_TIPO + "'";
            }
            if (!string.IsNullOrEmpty(EntidadCtrlRegimen.RESOLUCION))
            {
                sentencia = sentencia + " AND RESOLUCION = '" + EntidadCtrlRegimen.RESOLUCION + "'";
            }
            if (!string.IsNullOrEmpty(EntidadCtrlRegimen.PREFIJO))
            {
                sentencia = sentencia + " AND PREFIJO = '" + EntidadCtrlRegimen.PREFIJO + "'";
            }            
            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
