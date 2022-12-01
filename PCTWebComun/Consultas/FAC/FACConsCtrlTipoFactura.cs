//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/06/2021 - Ticket N° 00000 - Caso: Se agrega Clase Consulta CTRL_TIPO_FACTURA, Solicitud de Edwin Sanchez - Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas.FAC
{
    class FACConsCtrlTipoFactura
    {
        public string Mensaje;
        public DataTable ConsConsultarFACConsCtrlTipoFactura(ConexionBD oconexion, FACCtrlTipoFactura EntidadFACCtrlTipoFactura)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT COD_TIPO, COD_SUBTIPO, NOM_TIPO, COD_BARRA, NOTA1, VALOR_CERO, COD_BANCO, COD_BARRA_1, COD_BANCO_1, ID_TIENDA_PSE, COD_CLAVE_PSE, USERWS_PSE, PASSWS_PSE, COD_SERVICIO_PSE, NRO_CTABANCARIA, COD_RUTA FROM CTRL_TIPO_FACTURA WHERE 1=1 ";
            if (!string.IsNullOrEmpty(EntidadFACCtrlTipoFactura.COD_TIPO))
            {
                sentencia += " AND COD_TIPO ='" + EntidadFACCtrlTipoFactura.COD_TIPO + "' ";
            }

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtConsulta;

        }
    }
}

