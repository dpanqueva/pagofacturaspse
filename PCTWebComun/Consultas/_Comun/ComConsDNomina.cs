using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsDNomina
    {
        
       public string Mensaje;
       
        public DataTable ConsCountDNomina(ConexionBD oconexion, ComDNomina entidadDNomina)
        {
            string sentencia = " SELECT * FROM DNOMINA WHERE 1=1";
            DataTable dtsConsulta;

            if (!string.IsNullOrEmpty(entidadDNomina.VIGENCIA))
            {
                sentencia = sentencia + " AND VIGENCIA='" + entidadDNomina.VIGENCIA + "'";
            }

            if (!string.IsNullOrEmpty(entidadDNomina.NUM_CERTIFICADO))
            {
                sentencia = sentencia + " AND NUM_CERTIFICADO='" + entidadDNomina.NUM_CERTIFICADO + "'";
            }

            if (!string.IsNullOrEmpty(entidadDNomina.NUM_ORDEN))
            {
                sentencia = sentencia + " AND NUM_ORDEN='" + entidadDNomina.NUM_ORDEN +"'";
            }
            
            if (!string.IsNullOrEmpty(entidadDNomina.TIPO))
            {
                sentencia = sentencia + " AND TIPO='" + entidadDNomina.TIPO + "'";
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
