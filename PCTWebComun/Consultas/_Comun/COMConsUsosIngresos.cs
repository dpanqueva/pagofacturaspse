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
    public class COMConsUsosIngresos
    {
        private string lmensaje;

        //Función que permite consultar datos de la tabla USOS_IMNGRESOS
        public DataTable ConsConsultarUsosIngresos(ConexionBD oconexion, COMUsosIngresos entidadCOMUsosIngresos)
        {
            string sentencia = "SELECT COD_USOING, NOM_USOING, TIPO, ID_COM_ENTIDAD, USUARIO, ES_DESCUENTO FROM USOS_INGRESOS";
            DataTable dtsConsulta = new DataTable();

            sentencia += " WHERE 1 = 1 ";

            if ((!string.IsNullOrEmpty(entidadCOMUsosIngresos.COD_USOING)) && (!string.IsNullOrEmpty(entidadCOMUsosIngresos.NOM_USOING)))
            {
                sentencia = sentencia + " AND UPPER(COD_USOING) LIKE UPPER('" + entidadCOMUsosIngresos.COD_USOING + "') OR UPPER(NOM_USOING) LIKE UPPER('%" + entidadCOMUsosIngresos.NOM_USOING + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadCOMUsosIngresos.COD_USOING))
                {
                    sentencia = sentencia + " AND UPPER(COD_USOING) LIKE UPPER('" + entidadCOMUsosIngresos.COD_USOING + "')";
                }

                if (!string.IsNullOrEmpty(entidadCOMUsosIngresos.NOM_USOING))
                {
                    sentencia = sentencia + " AND UPPER(NOM_USOING) LIKE UPPER('%" + entidadCOMUsosIngresos.NOM_USOING + "%')";
                }
            }

            
            sentencia = sentencia + " ORDER BY COD_USOING ";

            dtsConsulta = oconexion.Consulta(sentencia);
            lmensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

    }
}
