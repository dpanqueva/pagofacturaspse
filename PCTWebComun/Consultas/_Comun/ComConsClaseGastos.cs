//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade la consulta- Participantes: Maribel Pedroza

using System;
using System.Collections.Generic;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Web;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsClaseGastos
    {
        //private readonly string Vigencia = HttpContext.Current.Session["Vigencia"].ToString();
        public string Mensaje;
        public DataTable ConsConsultarClaseGastos(ConexionBD oConexion, ComClaseGastos EntidadClaseGastos)
        {
            string sentencia = "";
            DataTable dtConsulta = new DataTable();

            sentencia = " SELECT * FROM CLASE_GASTOS_V1 WHERE VIGENCIA <> 0 ";

            if (!string.IsNullOrEmpty(EntidadClaseGastos.VIGENCIA))
            {
                sentencia = sentencia + " AND VIGENCIA=" + EntidadClaseGastos.VIGENCIA;
            }
            else
            {
                sentencia = sentencia + " AND VIGENCIA=(SELECT VIGENCIA_ACTUAL FROM CTRL_ENTIDAD)";
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.RUBRO) && !string.IsNullOrEmpty(EntidadClaseGastos.NOM_GASTO))
            {
                sentencia = sentencia + "  AND UPPER(RUBRO) LIKE UPPER('%" + EntidadClaseGastos.RUBRO.ToUpper() + "%') OR UPPER(NOM_GASTO) LIKE UPPER('%" + EntidadClaseGastos.NOM_GASTO.ToUpper() + "%') ";
            }
            else {
                if (!string.IsNullOrEmpty(EntidadClaseGastos.NOM_GASTO))
                {
                    sentencia = sentencia + " AND UPPER(NOM_GASTO) LIKE UPPER('%" + EntidadClaseGastos.NOM_GASTO + "%')";
                }
                if (!string.IsNullOrEmpty(EntidadClaseGastos.RUBRO))
                {
                    sentencia = sentencia + " AND RUBRO = '" + EntidadClaseGastos.RUBRO + "'";
                }
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.NRO_NIVEL))
            {
                sentencia = sentencia + " AND NRO_NIVEL ="+ EntidadClaseGastos.NRO_NIVEL;
            }
            if (!string.IsNullOrEmpty(EntidadClaseGastos.COD_GASTO))
            {
                sentencia = sentencia + "  AND UPPER(COD_GASTO) LIKE UPPER('" + EntidadClaseGastos.COD_GASTO + "')";
            }

            sentencia = sentencia + " ORDER BY COD_GASTO ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }


        public DataTable ConsConsClaseGastos(ConexionBD oConexion, ComClaseGastos EntidadClaseGastos, string Vigencia)
        {
            string sentencia = "";
            DataTable dtConsulta = new DataTable();

            sentencia = " SELECT * FROM CLASE_GASTOS WHERE 1=1 ";

            if (!string.IsNullOrEmpty(Vigencia))
            {
                sentencia = sentencia + " AND VIGENCIA=" + Vigencia;
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.VIGENCIA))
            {
                sentencia = sentencia + " AND VIGENCIA=" + EntidadClaseGastos.VIGENCIA;
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.COD_GASTO))
            {
                sentencia = sentencia + "  AND UPPER(COD_GASTO) LIKE UPPER('" + EntidadClaseGastos.COD_GASTO + "')";
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.NOM_GASTO))
            {
                sentencia = sentencia + " AND UPPER(NOM_GASTO) LIKE UPPER('%" + EntidadClaseGastos.NOM_GASTO + "%')";
            }

            if (!string.IsNullOrEmpty(EntidadClaseGastos.NRO_NIVEL))
            {
                sentencia = sentencia + " AND NRO_NIVEL =" + EntidadClaseGastos.NRO_NIVEL;
            }
            if (!string.IsNullOrEmpty(EntidadClaseGastos.RUBRO))
            {
                sentencia = sentencia + " AND RUBRO = '" + EntidadClaseGastos.RUBRO + "'";
            }

            sentencia = sentencia + " ORDER BY COD_GASTO ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtConsulta;
        }


        public bool InsertarVariosClaseGastos(ConexionBD oconexion, List<ComClaseGastos> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentencia = "INSERT INTO CLASE_GASTOS (VIGENCIA, COD_GASTO, COD_PADRE, NOM_GASTO, NRO_NIVEL, NIVEL, GASTO, GASTO_AUX) VALUES ({values})";    

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComClaseGastos itemNuevo in ItemsNuevos)
                    {
                        string valores = "'"+(!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? itemNuevo.VIGENCIA : EntidadCtrlEntidad.VIGENCIA_ACTUAL) + "','"                                   
                                        + itemNuevo.COD_GASTO + "','"
                                        + itemNuevo.COD_PADRE + "','"
                                        + itemNuevo.NOM_GASTO + "',"
                                        + itemNuevo.NRO_NIVEL + ",'"
                                        + itemNuevo.NIVEL +"','"
                                        + itemNuevo.GASTO +"','"
                                        + itemNuevo.GASTO_AUX +"'";                                        

                        string nuevaSentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevaSentencia);
                        if (!valido) 
                        { 
                            throw new Exception(oconexion.Mensaje);
                        }
                        else
                        {
                            string valores2 = "UPDATE CLASE_GASTOS SET GASTO = RTRIM(SUBSTR(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 1, 4)), NULL) || ' - ' || RTRIM(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 5, 4)), NULL) || ' ' || NVL(TO_NUMBER(SUBSTR(COD_GASTO, 9, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 13, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 17, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 21, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 25, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 29, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 33, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 37, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 41, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 45, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 48, 4)), NULL)), 1, 100))," +
                          "GASTO_AUX = RTRIM(SUBSTR(RTRIM(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 5, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 9, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 13, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 17, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 21, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 25, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 29, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 33, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 37, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 41, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 45, 4)), NULL) || ' ' ||" +
                          "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 49, 4)), NULL)), 1, 100))" +
                          "WHERE GASTO IS NULL OR RTRIM(GASTO)='" + itemNuevo.COD_GASTO + "'";
                            valido = oconexion.EjecutarSQL(valores2);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                                 
                    }
                }
                valido = true;
                //oconexion.CommitTransaccion();
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }


        public bool pruebaclasegasto(ConexionBD oconexion, List<ComClaseGastos> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            //string sentencia = "INSERT INTO CLASE_GASTOS (VIGENCIA, COD_GASTO, COD_PADRE, NOM_GASTO, NRO_NIVEL, NIVEL, GASTO, GASTO_AUX) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (ComClaseGastos itemNuevo in ItemsNuevos)
                    {
                        string valores = "UPDATE CLASE_GASTOS SET GASTO = RTRIM(SUBSTR(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 1, 4)), NULL) || ' - ' || RTRIM(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 5, 4)), NULL) || ' ' || NVL(TO_NUMBER(SUBSTR(COD_GASTO, 9, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 13, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 17, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 21, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 25, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 29, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 33, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 37, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 41, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 45, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 48, 4)), NULL)), 1, 100))," +
                            "GASTO_AUX = RTRIM(SUBSTR(RTRIM(NVL(TO_NUMBER(SUBSTR(COD_GASTO, 5, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 9, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 13, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 17, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 21, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 25, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 29, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 33, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 37, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 41, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 45, 4)), NULL) || ' ' ||" +
                            "NVL(TO_NUMBER(SUBSTR(COD_GASTO, 49, 4)), NULL)), 1, 100))" +
                            "WHERE GASTO IS NULL OR RTRIM(GASTO)='"+ itemNuevo.COD_GASTO + "'";
                        valido = oconexion.EjecutarSQL(valores);
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

        public bool ActualizarVariosClaseGastos(ConexionBD oconexion, List<ComClaseGastos> ItemsActualizados,ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE CLASE_GASTOS SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComClaseGastos itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_GASTO))
                        {
                            actualizaciones.Add("NOM_GASTO = '" + itemNuevo.NOM_GASTO + "'");
                        }

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                        {
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");
                        }

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_GASTO = '" + itemNuevo.COD_GASTO + "' AND VIGENCIA="+EntidadCtrlEntidad.VIGENCIA_ACTUAL;
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

        public bool EliminarVariosClaseGastos(ConexionBD oconexion, List<ComClaseGastos> ItemEliminados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM CLASE_GASTOS WHERE COD_GASTO = '{value}' AND VIGENCIA="+ EntidadCtrlEntidad.VIGENCIA_ACTUAL;

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComClaseGastos itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_GASTO))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_GASTO);
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
    }   
}
