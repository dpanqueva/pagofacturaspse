using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComunNet.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsClaseIngresos
    {
        private readonly string Vigencia = HttpContext.Current.Session["Vigencia"].ToString();
        public string Mensaje;
        public DataTable ConsConsultarClaseIngresos(ConexionBD oconexion, ComClaseIngreso entidadClaseIngresos, string Vigencia)
        {
            DataTable dtsConsulta = new DataTable();
            string sentencia = "SELECT * FROM CLASE_INGRESO";      

            sentencia += " WHERE 1 = 1";

            if ((!string.IsNullOrEmpty(entidadClaseIngresos.COD_INGRESO))&&(!string.IsNullOrEmpty(entidadClaseIngresos.NOM_INGRESO)))
            {
                sentencia = sentencia + " AND UPPER(COD_INGRESO) LIKE UPPER('%" + entidadClaseIngresos.COD_INGRESO + "%') OR UPPER(NOM_INGRESO) LIKE UPPER('%" + entidadClaseIngresos.NOM_INGRESO + "%')";
            }
            else
            {

                if (!string.IsNullOrEmpty(entidadClaseIngresos.COD_INGRESO))
                {
                    sentencia = sentencia + " AND UPPER(COD_INGRESO) LIKE UPPER('%" + entidadClaseIngresos.COD_INGRESO + "%')";
                }

                if (!string.IsNullOrEmpty(entidadClaseIngresos.NOM_INGRESO))
                {
                   sentencia = sentencia + " AND UPPER(NOM_INGRESO) LIKE UPPER('%" + entidadClaseIngresos.NOM_INGRESO + "%')";

                }
            }

            if (!string.IsNullOrEmpty(entidadClaseIngresos.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + entidadClaseIngresos.VIGENCIA;
            }


            if (!string.IsNullOrEmpty(Vigencia))
            {
                sentencia += " AND VIGENCIA="+Vigencia;
            }

            sentencia = sentencia + " ORDER BY COD_INGRESO ";    

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable CargarClaseIngreso(ConexionBD oconexion, ComClaseIngreso entidadCIngresos)
        {
            string sentencia;
            DataTable dtsConsulta;

            sentencia = "select * from CLASE_INGRESO where upper(COD_INGRESO) like upper('" + entidadCIngresos.COD_INGRESO + "') order by COD_INGRESO";
           
            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable ConsultarCIngresosPag(ComClaseIngreso entidadCIngresos, int numPagActual, ConexionBD oconexion)
        {
            DataTable dtConsulta;
            string sentencia;

            sentencia = "SELECT A.COD_INGRESO, A.NOM_INGRESO, A.NIVEL, a.NRO_NIVEL, A.COD_PADRE, SUBSTR(LPAD(' ', (A.NRO_NIVEL-1)*2,'  ')||A.NOM_INGRESO,1,100) NOMBRE FROM CLASE_INGRESO A";

            if (!string.IsNullOrEmpty(entidadCIngresos.NOM_INGRESO))
            {
                sentencia = sentencia + " WHERE trim(upper(SUBSTR(LPAD(' ',(A.NRO_NIVEL-1)*2,'  ')||A.NOM_INGRESO,1,100))) like upper('%" + entidadCIngresos.NOM_INGRESO + "%') ";
            }

            sentencia += " ORDER BY A.COD_INGRESO";

            dtConsulta = oconexion.ConsultaPaginada(sentencia, numPagActual, 15);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable ContarRegCIngresos(ComClaseIngreso entidadCIngresos, ConexionBD oconexion)
        {
            DataTable dtConsulta;
            string sentencia;

            sentencia = "SELECT count(A.COD_INGRESO) FROM CLASE_INGRESO A";

            if (!string.IsNullOrEmpty(entidadCIngresos.NOM_INGRESO))
            {
                sentencia = sentencia + " WHERE trim(upper(SUBSTR(LPAD(' ',(A.NRO_NIVEL-1)*2,'  ')||A.NOM_INGRESO,1,100))) like upper('%" + entidadCIngresos.NOM_INGRESO + "%') ";
            }

            sentencia += " ORDER BY A.COD_INGRESO";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;

        }

        public bool InertarVariosCIngresos(ConexionBD oconexion, List<ComClaseIngreso> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentencia = "INSERT INTO CLASE_INGRESO (COD_PADRE,COD_INGRESO,NOM_INGRESO,NIVEL,NRO_NIVEL,INGRESO,VIGENCIA) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComClaseIngreso itemNuevo in ItemsNuevos)
                    {
                        string valores = (!string.IsNullOrEmpty(itemNuevo.COD_PADRE) ? "'" + itemNuevo.COD_PADRE + "'" : "null") + ",'"
                                        + itemNuevo.COD_INGRESO + "','"
                                        + itemNuevo.NOM_INGRESO + "','"
                                        + itemNuevo.NIVEL + "',"
                                        + itemNuevo.NRO_NIVEL + ",'"
                                        + itemNuevo.INGRESO + "','"
                                        + (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? itemNuevo.VIGENCIA : EntidadCtrlEntidad.VIGENCIA_ACTUAL) + "'";

                        string nuevaSentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevaSentencia);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        public bool ActualizarVariosCIngresos(ConexionBD oconexion, List<ComClaseIngreso> ItemsActualizados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE CLASE_INGRESO SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComClaseIngreso itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_INGRESO))
                        {
                            actualizaciones.Add("NOM_INGRESO = '" + itemNuevo.NOM_INGRESO + "'");
                        }

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                        {
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");
                        }

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_INGRESO = '" + itemNuevo.COD_INGRESO + "'";
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        public bool EliminarVariosCIngresos(ConexionBD oconexion, List<ComClaseIngreso> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM CLASE_INGRESO WHERE COD_INGRESO = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComClaseIngreso itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_INGRESO))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_INGRESO);
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }


        public DataTable MovimientosCIngresos(ConexionBD oconexion, ComClaseIngreso entidad)
        {
            DataTable dtConsulta;
            string sentencia;

            sentencia = "SELECT COUNT(*) AS MOVIMIENTOS FROM PPTO_INGRESOS WHERE VIGENCIA=" + Vigencia + " AND COD_INGRESO = '" + entidad.COD_INGRESO + "'";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

    }
}
