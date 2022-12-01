//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/01/2021 - Ticket Nº 0000  - Caso: se agrega clase querie Productos,solicitud deJheisone Padilla- Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.CamposQueries.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Queries.FAC
{
    class FACQProductos
    {
        public string Mensaje;
        
        public DataTable ConsultarReferenciaProducto(ConexionBD oConexion, FACCQProductos CamposQuerieProductos)
        {
            DataTable dtConsulta = new DataTable();

            string sentencia = "SELECT B.COD_CATEGORIA,A.COD_ELEMENTO,A.COD_REFERENCIA,NOM_REFERENCIA,COD_UNIDAD,DECODE(D.AJUSTAR_PESO,'S',ROUND(A.PRECIO_VENTA),A.PRECIO_VENTA) PRECIO_VENTA,C.COD_BODEGA,C.CANTIDAD-C.CANT_TRAMITE CANTIDAD " +
                "FROM REFERENCIAS_INV A,CLASE_ELEMENTOS_INV B, KARDEX_INV C, CTRL_INVENTARIO D " +
                "WHERE A.COD_ELEMENTO = B.COD_ELEMENTO " +
                "AND A.COD_REFERENCIA = C.COD_REFERENCIA " +
                "AND C.COD_ELEMENTO = B.COD_ELEMENTO ";

            if (!string.IsNullOrEmpty(CamposQuerieProductos.COD_BODEGA))
            {
                sentencia += " AND C.COD_BODEGA = " + CamposQuerieProductos.COD_BODEGA +" ";
            }
            if (!string.IsNullOrEmpty(CamposQuerieProductos.COD_REFERENCIA) && !string.IsNullOrEmpty(CamposQuerieProductos.NOM_REFERENCIA))
            {
                sentencia += " AND A.COD_REFERENCIA= " + CamposQuerieProductos.COD_REFERENCIA + "  OR UPPER(A.NOM_REFERENCIA) LIKE UPPER('%" + CamposQuerieProductos.NOM_REFERENCIA + "%') ";
            }

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }

    }
}
