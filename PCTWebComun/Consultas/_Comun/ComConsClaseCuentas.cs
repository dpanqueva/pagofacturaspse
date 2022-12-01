using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;
using System.Web;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsClaseCuentas
    {
        public string Mensaje;
        public DataTable consultarCuentas(ConexionBD oconexion, ComCuentas entidadCCuentas)
        {
            string sentencia = "SELECT * FROM CUENTAS";
            DataTable dtsConsulta = new DataTable();

            sentencia += " WHERE 1 = 1";

            if (!string.IsNullOrEmpty(entidadCCuentas.COD_CTA) && !string.IsNullOrEmpty(entidadCCuentas.NOM_CTA))
            {
                sentencia += " AND COD_CTA LIKE '%" + entidadCCuentas.COD_CTA + "%' OR UPPER(NOM_CTA) LIKE UPPER('%"+entidadCCuentas.NOM_CTA+"%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadCCuentas.COD_CTA)){
                    sentencia += " AND COD_CTA LIKE '%" + entidadCCuentas.COD_CTA + "%'";
                }

                if (!string.IsNullOrEmpty(entidadCCuentas.NOM_CTA)){
                    sentencia += " AND UPPER(NOM_CTA) LIKE UPPER('%" + entidadCCuentas.NOM_CTA + "%')";
                }
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

    }
}
