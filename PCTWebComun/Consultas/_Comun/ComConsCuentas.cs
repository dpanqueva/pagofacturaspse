using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsCuentas
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        //public DataTable ConsultaPaginadaCuentas(ConexionBD oconexion, int pagina, int cantidad, ComCuentas entidadCuentas)
        public DataTable ConsultaPaginadaCuentas(ConexionBD oconexion, int pagina, int cantidad, ComCuentas entidadCuentas)
        {
            DataTable dtsConsulta = new DataTable();
            try
            {
                List<string> condiciones = new List<string>();
                string Sentencia = "SELECT * FROM CUENTAS WHERE 1 = 1";
                if (!string.IsNullOrEmpty(entidadCuentas.COD_CTA) && (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA)))
                {
                    Sentencia = Sentencia + " AND UPPER(COD_CTA) LIKE UPPER('" + entidadCuentas.COD_CTA + "%') OR UPPER(NOM_CTA) LIKE UPPER('%" + entidadCuentas.NOM_CTA + "%')";
                }
                else
                {
                    if (!string.IsNullOrEmpty(entidadCuentas.COD_CTA))
                    {
                        Sentencia = Sentencia + " AND COD_CTA LIKE '" + entidadCuentas.COD_CTA + "%'";
                    }

                    if (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA))
                    {
                        Sentencia = Sentencia + " AND UPPER(NOM_CTA) LIKE UPPER('%" + entidadCuentas.NOM_CTA + "%')";
                    }

                }

                Sentencia += string.Join(" AND ", condiciones);
                Sentencia += " ORDER BY COD_CTA";
                dtsConsulta = oconexion.ConsultaPaginada(Sentencia, pagina, cantidad);
                Mensaje = oconexion.Mensaje;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtsConsulta;
        }
        public DataTable ConsultaCountPagCuentas(ConexionBD oconexion, ComCuentas entidadCuentas)
        {
            DataTable dtsConsulta = new DataTable();
            try
            {
                string Sentencia = "SELECT COUNT(*)CANTIDAD FROM CUENTAS WHERE 1 = 1 ";
                if (!string.IsNullOrEmpty(entidadCuentas.COD_CTA) && (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA)))
                {
                    Sentencia = Sentencia + " AND UPPER(COD_CTA) LIKE UPPER('" + entidadCuentas.COD_CTA + "%') OR UPPER(NOM_CTA) LIKE UPPER('%" + entidadCuentas.NOM_CTA + "%')";
                }
                else
                {
                    if (!string.IsNullOrEmpty(entidadCuentas.COD_CTA))
                    {
                        Sentencia = Sentencia + " AND COD_CTA LIKE '" + entidadCuentas.COD_CTA + "%'";
                    }

                    if (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA))
                    {
                        Sentencia = Sentencia + " AND UPPER(NOM_CTA) LIKE UPPER('%" + entidadCuentas.NOM_CTA + "%')";
                    }

                }

                dtsConsulta = oconexion.Consulta(Sentencia); 
                Mensaje = oconexion.Mensaje;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtsConsulta;
        }

        public DataTable ConsultaCuentas(ConexionBD oconexion)
        {
            DataTable dtsConsulta = new DataTable();
            try
            {
                string Sentencia = "SELECT COD_CTA, NRO_NIVEL, NOM_CTA, SAL00, SAL01, SAL02, SAL03, SAL04, SAL05,"
                                    + "SAL06, SAL07, SAL08, SAL09, SAL10, SAL11, SAL12, SAL13, IND_CUTIL, IND_BASES, IND_MONET,"
                                    + "IND_DCTO, IND_MONEXT, IND_FLUJO, IND_CTE, IND_NATURALEZA, IND_RENTA, IND_IVA,"
                                    + "IND_RTE_FUENTE, IND_RETENCION, CTA_INFLAC, CTA_CORREC, IND_BASE_RTE_FUENTE, TIPO_CTA, VER_CGN02"
                                    + " FROM CUENTAS ORDER BY COD_CTA";

                dtsConsulta = oconexion.Consulta(Sentencia);
                Mensaje = oconexion.Mensaje;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
            }

            return dtsConsulta;
        }

        public DataTable ContarRegCuentas(ConexionBD oconexion)
        {
            string Sentencia = "SELECT COUNT(COD_CTA) AS TOTAL FROM CUENTAS";

            DataTable dtsConsulta;

            //dtsConsulta = oconexion.Consulta(Sentencia);
            dtsConsulta = oconexion.Consulta(Sentencia);
            Mensaje = oconexion.Mensaje;

            return dtsConsulta;
        }

        public DataTable ConsConsultarCuentas(ConexionBD oconexion, ComCuentas entidadCuentas)
        {
            string sentencia="SELECT * FROM CUENTAS";

            sentencia += " WHERE 1 = 1";

            DataTable dtsConsulta;

            if(!string.IsNullOrEmpty(entidadCuentas.COD_CTA) && (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA)))
            {
                sentencia = sentencia + " AND UPPER(COD_CTA) LIKE UPPER('%"+ entidadCuentas.COD_CTA +"%') OR UPPER(NOM_CTA) LIKE UPPER('%" +entidadCuentas.NOM_CTA +"%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadCuentas.COD_CTA))
                {
                    sentencia = sentencia + " AND UPPER(COD_CTA) LIKE UPPER('" + entidadCuentas.COD_CTA + "%')";
                }

                if (!string.IsNullOrEmpty(entidadCuentas.NOM_CTA))
                {
                    sentencia = sentencia + " AND UPPER(NOM_CTA) LIKE UPPER('" + entidadCuentas.NOM_CTA + "%')";
                }

            }

            sentencia = sentencia + " ORDER BY COD_CTA ASC";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

        public DataTable ValidarDatosCuentas(ConexionBD oconexion, ComCuentas entidadCuentas)
        {
            string sentencia;
            DataTable dtsConsulta;

            if (string.IsNullOrEmpty(entidadCuentas.COD_CTA))
            {
                sentencia = "SELECT * FROM CUENTAS";
            }
            else
            {
                if (!string.IsNullOrEmpty(entidadCuentas.AUXILIARES))
                {
                    sentencia = "SELECT * FROM CUENTAS WHERE COD_CTA LIKE '"+ entidadCuentas.COD_CTA + "%' ";
                }
                else
                {
                    sentencia = "SELECT * FROM CUENTAS WHERE COD_CTA = '" + entidadCuentas.COD_CTA + "'";
                }
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
        public bool ConsEditarCuentas(ConexionBD oConexion, ComCuentas EntidadCuentas)
        {
            string consulta = "";
            bool resultado;

            consulta = "UPDATE CUENTAS SET NOM_CTA ='" + EntidadCuentas.NOM_CTA + "', COD_PADRE = '" + EntidadCuentas.COD_PADRE + "', NIVEL = '" + EntidadCuentas.NIVEL + "'," +
            " NRO_NIVEL = '" + EntidadCuentas.NRO_NIVEL + "', TIPO_CTA = '" + EntidadCuentas.TIPO_CTA + "', IND_CUTIL = '" + EntidadCuentas.IND_CUTIL + "', IND_BASES = '" + EntidadCuentas.IND_BASES + "'," +
            " IND_MONET = '" + EntidadCuentas.IND_MONET + "', IND_DCTO = '" + EntidadCuentas.IND_DCTO + "', IND_MONEXT = '" + EntidadCuentas.IND_MONEXT + "', IND_FLUJO = '" + EntidadCuentas.IND_FLUJO + "'," +
            " IND_CTE = '" + EntidadCuentas.IND_CTE + "', IND_NATURALEZA = '" + EntidadCuentas.IND_NATURALEZA + "', CTA_INFLAC = '" + EntidadCuentas.CTA_INFLAC + "'," +
            " CTA_CORREC = '" + EntidadCuentas.CTA_CORREC + "', SAL00 = '" + EntidadCuentas.SAL00 + "', SAL01 = '" + EntidadCuentas.SAL01 + "', SAL02 = '" + EntidadCuentas.SAL02 + "'," +
            " SAL03 = '" + EntidadCuentas.SAL03 + "', SAL04 = '" + EntidadCuentas.SAL04 + "', SAL05 = '" + EntidadCuentas.SAL05 + "', SAL06 = '" + EntidadCuentas.SAL06 + "', SAL07 = '" + EntidadCuentas.SAL07 + "'," +
            " SAL08 = '" + EntidadCuentas.SAL08 + "', SAL09 = '" + EntidadCuentas.SAL09 + "', SAL10 = " + EntidadCuentas.SAL10 + ", SAL11 = '" + EntidadCuentas.SAL11 + "'," +
            " SAL12 = '" + EntidadCuentas.SAL12 + "', SAL13 = '" + EntidadCuentas.SAL13 + "', IND_RENTA='" + EntidadCuentas.IND_RENTA + "'," +
            " IND_IVA = '" + EntidadCuentas.IND_IVA + "', IND_RTE_FUENTE = '" + EntidadCuentas.IND_RTE_FUENTE + "', IND_BASE_RTE_FUENTE = '" + EntidadCuentas.IND_BASE_RTE_FUENTE + "', CTA_CIERRE = '" + EntidadCuentas.CTA_CIERRE + "'," +
            " VER_CGN02 = '" + EntidadCuentas.VER_CGN02 + "', ELIMINATORIA_CG02 = '" + EntidadCuentas.ELIMINATORIA_CG02 + "', NOM_ELIMINATORIA_CG02 = '" + EntidadCuentas.NOM_ELIMINATORIA_CG02 + "', REPORTA_100POR = '" + EntidadCuentas.REPORTA_100POR + "' " +
            " WHERE COD_CTA = '" + EntidadCuentas.COD_CTA + "'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }

        public bool ConsEliminarCuentas(ConexionBD oConexion, ComCuentas EntidadCuentas)
        {
            bool resultado;
            string consulta;

            consulta = "DELETE FROM CUENTAS WHERE COD_CTA = '" + EntidadCuentas.COD_CTA + "'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }
        public bool ActualizarVariosCuentasReciprocas(ConexionBD oconexion, List<ComCuentas> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE CUENTAS SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComCuentas itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.VER_CGN02))
                            actualizaciones.Add("VER_CGN02 ='" + itemNuevo.VER_CGN02 + "'");


                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_CTA = '" + itemNuevo.COD_CTA + "'";
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

        //Función que permite Eliminar datos de CATEGORIA_TERCEROS
        public bool EliminarVariosCuentasReciprocas(ConexionBD oconexion, List<ComCuentas> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "delete from CUENTAS where COD_CTA = '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComCuentas itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_CTA))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_CTA);
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
