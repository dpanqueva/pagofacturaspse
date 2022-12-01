using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades.FAC;
using PCTWebComun.IME.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas.FAC
{
    class FACConsElementosReferencias
    {
        public string Mensaje;
        public DataTable ConsConsultarElementosReferencias(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT * FROM REFERENCIASSERVICIO WHERE 1=1 ";

            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.COD_REFERENCIA) && !string.IsNullOrEmpty(EntidadFACElementosReferencias.NOM_REFERENCIA))
            {
                sentencia += " AND COD_REFERENCIA= " + EntidadFACElementosReferencias.COD_REFERENCIA + "  OR UPPER(NOM_REFERENCIA) LIKE UPPER('%" + EntidadFACElementosReferencias.NOM_REFERENCIA + "%') ";
            }

            sentencia += " ORDER BY COD_REFERENCIA ";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable ConsConsultarQConsultaCategoriaSer(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT COD_CATEGORIA,NOM_CATEGORIA,VIGENCIA" +
            " FROM CATEGORIAVENTA_ELEMENTOS" +
            " WHERE TIPO = 'S'" +
            " AND NIVEL = 'N'";
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            sentencia += " ORDER BY COD_CATEGORIA";

            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQCategoria(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia =
            " SELECT A.VIGENCIA,A. COD_CATEGORIA,A.NOM_CATEGORIA " +
            " FROM CATEGORIAVENTA_ELEMENTOS A" +
            " WHERE A.TIPO = 'S'" +
            " AND A.NIVEL = 'N'";

            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            sentencia += " ORDER BY COD_CATEGORIA";
            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQCategoriaS(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "SELECT * FROM  CATEGORIAVENTA_ELEMENTOS " +
             " WHERE  TIPO='S'";
            //"AND VIGENCIA=:Vigencia" +
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            sentencia += " ORDER BY COD_CATEGORIA";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQCategoriaventaelementos(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "SELECT A.*,B.*,C.* , DECODE(A.NRO_NIVEL,1,A.NOM_CATEGORIA, D.NOM_CATEGORIA ) NOM_PADRE" +
            " FROM CATEGORIAVENTA_ELEMENTOS A,CLASE_ELEMENTOSSERVICIO B, REFERENCIASSERVICIO C, CATEGORIAVENTA_ELEMENTOS D" +
            " WHERE A.COD_CATEGORIA=B.COD_CATEGORIA(+)" + "AND     A.COD_CATEGORIA=C.COD_CATEGORIA(+)" +
            " AND     B.COD_ELEMENTO=C.COD_ELEMENTO" +
            " AND   A.VIGENCIA=B.VIGENCIA" +
            " AND   A.VIGENCIA=C.VIGENCIA" +
            " AND     A.NIVEL = 'N'" +
            " AND  A.COD_PADRE = D.COD_CATEGORIA(+)" +
            " ORDER BY COD_REFERENCIA";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQCentroUtilidad(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT A.COD_CENTRO,  A.COD_PADRE,  A.NOM_CENTRO,  A.NRO_NIVEL,  A.NIVEL" +
            "FROM CENTRO_COSTOS A" +
            "ORDER BY A.COD_CENTRO";

            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQClaseGastos(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT *" +
            " FROM CLASE_GASTOS" +
            " WHERE ";///:Vigencia" +            

            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }

            sentencia += " ORDER BY COD_GASTO";

            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQDistrib(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT *" +
            "FROM CLASE_GASTOS" +
            "WHERE ";//:CodGasto AND VIGENCIA=:'Vig'" +
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.COD_GASTO))
            {
                sentencia += " COD_GASTO LIKE = " + EntidadFACElementosReferencias.COD_GASTO;
            }
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            sentencia += " ORDER BY VIGENCIA, COD_GASTO";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQGauge(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT COUNT (*) TOTAL" +
            "FROM REGIONES";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQNivel(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT *" +
            "FROM NIVEL" +
            "ORDER BY ARBOL, NIVEL";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }

        public DataTable ConsConsultarQCategoriaElemento(ConexionBD oConexion, FACElementosReferencias entidadVigenciaFacOcasional)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia =
                " SELECT A.VIGENCIA, A.COD_CATEGORIA, A.NOM_CATEGORIA, B.COD_ELEMENTO, B.NOM_ELEMENTO " +
                " FROM CATEGORIAVENTA_ELEMENTOS A, CLASE_ELEMENTOSSERVICIO B " +
                " WHERE A.TIPO = 'S' " +
                " AND A.NIVEL = 'N' " +
                " AND A.COD_CATEGORIA = B.COD_CATEGORIA " +
                " AND A.VIGENCIA = B.VIGENCIA ";
            /*          "AND A.COD_CATEGORIA = B.COD_CATEGORIA"+
                     "AND A.VIGENCIA = B.VIGENCIA";*/
            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.COD_CATEGORIA))
            {
                sentencia += " AND A.COD_CATEGORIA = " + entidadVigenciaFacOcasional.COD_CATEGORIA;
            }
            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.VIGENCIA))
            {
                sentencia += " AND A.VIGENCIA = " + entidadVigenciaFacOcasional.VIGENCIA;
            }
            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.COD_UNIDAD))
            {
                sentencia += " AND A.COD_UNIDAD = " + entidadVigenciaFacOcasional.COD_UNIDAD;
            }
            sentencia += " ORDER BY COD_ELEMENTO";
            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje; return dtConsulta;
        }

        public DataTable ConsConsultarQRegiones(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "SELECT A.COD_REGION,  A.COD_PADRE,  A.NOM_REGION,  A.NRO_NIVEL,  A.NIVEL,CORPES" +
            "FROM REGIONES A" +
            "ORDER BY A.COD_REGION";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQRegula(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT MAX(TAMANO) FROM NIVEL" +
            "WHERE ARBOL=:ARBOL" +
            "GROUP BY ARBOL";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQRPTElementos(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT  A.COD_ELEMENTO,A.NOM_ELEMENTO,A.COD_CATEGORIA,A.VIGENCIA,B.NOM_CATEGORIA" +
            " FROM CLASE_ELEMENTOSSERVICIO A ,CATEGORIAVENTA_ELEMENTOS B" +
            " WHERE  B.COD_CATEGORIA=A.COD_CATEGORIA";
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND A.VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            sentencia += " AND B.TIPO = 'S'";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQunidades(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "SELECT *" +
            " FROM SYSDBA.UNIDADES" +
            " WHERE VIGENCIA=:Vigencia" +
            " ORDER BY COD_UNIDAD";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }

        public DataTable ConsConsultarQRCategoriaServicio(ConexionBD oConexion, FACElementosReferencias entidadFACElementosReferencias)
        {
            throw new NotImplementedException();
        }

        public DataTable ConsConsultarQReferenciaServicio(ConexionBD oConexion, FACElementosReferencias entidadVigenciaFacOcasional)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia =
                " SELECT COD_CATEGORIA,COD_ELEMENTO,COD_REFERENCIA,REFERENCIA," +
                " DETALLE,COD_UNIDAD,NVL(VALOR,0) AS NVLVALOR,VIGENCIA " +
                " FROM REFERENCIASSERVICIO ";

            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.COD_CATEGORIA))
            {
                sentencia += " WHERE COD_CATEGORIA = " + entidadVigenciaFacOcasional.COD_CATEGORIA;
            }
            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.COD_ELEMENTO))
            {
                sentencia += " AND COD_ELEMENTO = " + entidadVigenciaFacOcasional.COD_ELEMENTO;
            }
            if (!string.IsNullOrEmpty(entidadVigenciaFacOcasional.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + entidadVigenciaFacOcasional.VIGENCIA;
            }
            sentencia += " ORDER BY COD_CATEGORIA ";
            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }

        public DataTable ConsConsultarQElementosServicio(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT COD_ELEMENTO,NOM_ELEMENTO,COD_CATEGORIA,VIGENCIA,PERECEDERO," +
                " NVL(IVA*100,0) IVA, NOTA" +
                " FROM CLASE_ELEMENTOSSERVICIO";
            //COD_CATEGORIA =' + C + DMFactura.QConsultaCategoriaSerCOD_CATEGORIA.AsString + C + '  AND VIGENCIA
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.COD_CATEGORIA))
            {
                sentencia += " WHERE COD_CATEGORIA = " + EntidadFACElementosReferencias.COD_CATEGORIA;
            }
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA))
            {
                sentencia += " AND VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQDistribBeforeDelete(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQClaseGastosNewRecord(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }
        public DataTable ConsConsultarQClaseGastosBeforeDelete(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias)
        {
            DataTable dtConsulta = new DataTable(); string sentencia = "";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }

        public DataTable ConsConsultarVigenciaActual(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias) {
            DataTable dtConsulta = new DataTable(); string sentencia = " SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD";
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
            
        }
        public DataTable ConsConsultarQSession(ConexionBD oconexion, FACElementosReferencias EntidadFACElementosReferencias, string opcion)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia="";

            if (opcion == "DATOSCATEGORIA_V1") {
                sentencia += " SELECT COD_CATEGORIA, COD_ELEMENTO, NOM_ELEMENTO, " +
                    " NOM_CATEGORIA FROM DATOSCATEGORIA_V1 WHERE ";
            }
            if (opcion == "DATOSCATEGORIA_V3") {
                sentencia += " SELECT COD_REFERENCIA," +
                    " REFERENCIA FROM DATOSCATEGORIA_V3 WHERE ";
            }
            if (!string.IsNullOrEmpty(EntidadFACElementosReferencias.VIGENCIA)) {
                sentencia += " VIGENCIA = " + EntidadFACElementosReferencias.VIGENCIA;
            }
            dtConsulta = oconexion.Consulta(sentencia); Mensaje = oconexion.Mensaje; return dtConsulta;
        }

        public bool facConsST_CLASE_ELEMENTOSSERVICIO(ConexionBD oConexion, FACElementosReferencias entidadReferenciaFacOcasional, DbTransaction transaccion)
        {
            try
            {
                bool resultado;

                List<DbParameter> listaParametro = new List<DbParameter>();
                FACIMEElementosReferencias fACIMEElementosReferencias = new FACIMEElementosReferencias();

                listaParametro = fACIMEElementosReferencias.ProcedimientoST_CLASE_ELEMENTOSSERVICIO(entidadReferenciaFacOcasional);
                Console.WriteLine(listaParametro);
                resultado = oConexion.EjecutarProcedimietoTransaccion("ST_CLASE_ELEMENTOSSERVICIO", listaParametro, transaccion);

                if (oConexion.VariableSalida != null)
                {
                    oValor = oConexion.VariableSalida.Parameters;
                }

                //string Value = oValor[0].Value.ToString();
                //string obj = Value;

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                oValor = null;
                Mensaje = oConexion.Mensaje;
                return false;
            }
        }

        public bool facConsST_REFSERVICIO(ConexionBD oConexion, FACElementosReferencias entidadReferenciaFacOcasional, DbTransaction transaccion)
        {
            try
            {
                bool resultado;

                List<DbParameter> listaParametro = new List<DbParameter>();
                FACIMEElementosReferencias fACIMEElementosReferencias = new FACIMEElementosReferencias();

                listaParametro = fACIMEElementosReferencias.ProcedimientoST_REFSERVICIO(entidadReferenciaFacOcasional);
                Console.WriteLine(listaParametro);
                resultado = oConexion.EjecutarProcedimietoTransaccion("ST_REFSERVICIO", listaParametro, transaccion);

                if (oConexion.VariableSalida != null)
                {
                    oValor = oConexion.VariableSalida.Parameters;
                }

                //string Value = oValor[0].Value.ToString();
                //string obj = Value;

                return resultado;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                oValor = null;
                Mensaje = oConexion.Mensaje;
                return false;
            }
        }

        public DataTable ConsFACConsUnidades(ConexionBD oConexion, FACElementosReferencias fACentidadUnidades, string buscar)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = " SELECT COD_UNIDAD, NOM_UNIDAD FROM CLASE_UNIDADES ";

            if (buscar != null && buscar !="")
            {
                sentencia += " WHERE COD_UNIDAD LIKE '%" + fACentidadUnidades.COD_UNIDAD + "%' OR UPPER(NOM_UNIDAD) LIKE '%" + fACentidadUnidades.NOM_UNIDAD.ToUpper() + "%'" ;///" WHERE NOM_UNIDAD = " + fACentidadUnidades.NOM_UNIDAD;
            }
            //if (!string.IsNullOrEmpty(fACentidadUnidades.COD_UNIDAD))
            //{
            //    sentencia += " WHERE COD_UNIDAD = " + fACentidadUnidades.COD_UNIDAD;
            //}
            sentencia += " ORDER BY  COD_UNIDAD";
            dtConsulta = oConexion.Consulta(sentencia); Mensaje = oConexion.Mensaje; return dtConsulta;
        }

        private DbParameterCollection oValor;
        public DbParameterCollection Valores
        {
            get { return oValor; }
            set { oValor = value; }
        }
    }
}
