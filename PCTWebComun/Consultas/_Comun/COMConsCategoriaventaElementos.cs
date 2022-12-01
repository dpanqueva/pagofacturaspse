//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se clase consulta de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsCategoriaventaElementos
    {

        public string Mensaje;

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 08/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la consulta de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public DataTable ConsConsultarCategoriaventaElementos(ConexionBD oConexion, COMCategoriaventaElementos EntidadCategoriaventaElementos,string Vigencia, string Tipo)
        {
            DataTable dtsResultado = new DataTable();
            string sentencia = " SELECT * FROM CATEGORIAVENTA_ELEMENTOS WHERE 1=1";

            if (!string.IsNullOrEmpty(EntidadCategoriaventaElementos.TIPO))
            {
                sentencia += " AND TIPO='" + EntidadCategoriaventaElementos.TIPO + "'";
            }

            if (!string.IsNullOrEmpty(Tipo))
            {
                sentencia += " AND TIPO='" + Tipo+ "'";
            }

            if (!string.IsNullOrEmpty(EntidadCategoriaventaElementos.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + EntidadCategoriaventaElementos.VIGENCIA;
            }
            if (!string.IsNullOrEmpty(Vigencia))
            {
                sentencia += " AND VIGENCIA=" + Vigencia;
            }

            dtsResultado = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;
            return dtsResultado;
        }

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 09/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la INSERTAR de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public bool InsertarVariosCategoriaventaElementos(ConexionBD oconexion, List<COMCategoriaventaElementos> ItemsNuevos, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentencia = "INSERT INTO CATEGORIAVENTA_ELEMENTOS(VIGENCIA, COD_CATEGORIA, COD_PADRE, NOM_CATEGORIA, NRO_NIVEL, NIVEL, TIPO, ACTIVO) VALUES ({values})";

            try
            {
                if (ItemsNuevos != null)
                {
                    foreach (COMCategoriaventaElementos itemNuevo in ItemsNuevos)
                    {
                        string valores = "'" + (!string.IsNullOrEmpty(itemNuevo.VIGENCIA) ? itemNuevo.VIGENCIA : EntidadCtrlEntidad.VIGENCIA_ACTUAL) + "','"
                                        + itemNuevo.COD_CATEGORIA + "','"
                                        + itemNuevo.COD_PADRE + "','"
                                        + itemNuevo.NOM_CATEGORIA + "',"
                                        + itemNuevo.NRO_NIVEL + ",'"
                                        + itemNuevo.NIVEL + "','"
                                        + itemNuevo.TIPO + "','"
                                        + itemNuevo.ACTIVO + "'";

                        string nuevaSentencia = sentencia.Replace("{values}", valores);
                        valido = oconexion.EjecutarSQL(nuevaSentencia);
                        if (!valido)
                        {
                            throw new Exception(oconexion.Mensaje);
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

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 09/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la ACTUALIZAR de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public bool ActualizarVariosCategoriaventaElementos(ConexionBD oconexion, List<COMCategoriaventaElementos> ItemsActualizados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "UPDATE CATEGORIAVENTA_ELEMENTOS SET ";
            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (COMCategoriaventaElementos itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOM_CATEGORIA))
                        {
                            actualizaciones.Add("NOM_CATEGORIA = '" + itemNuevo.NOM_CATEGORIA + "'");
                        }

                        if (!string.IsNullOrEmpty(itemNuevo.NIVEL))
                        {
                            actualizaciones.Add("NIVEL = '" + itemNuevo.NIVEL + "'");
                        }

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE COD_CATEGORIA = '" + itemNuevo.COD_CATEGORIA + "' AND VIGENCIA=" + EntidadCtrlEntidad.VIGENCIA_ACTUAL;
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

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 09/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la ELIMINAR de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public bool EliminarVariosCategoriaventaElementos(ConexionBD oconexion, List<COMCategoriaventaElementos> ItemEliminados, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido;
            string sentenciaBase = "DELETE FROM CATEGORIAVENTA_ELEMENTOS WHERE COD_CATEGORIA = '{value}' AND VIGENCIA=" + EntidadCtrlEntidad.VIGENCIA_ACTUAL;

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (COMCategoriaventaElementos itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.COD_CATEGORIA))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_CATEGORIA);
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
