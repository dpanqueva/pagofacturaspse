using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComunNet.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseIngreso
    {
        public string Mensaje;

        public DataTable CtrContarRegcIngresos(ComClaseIngreso entidadCIngresos)
        {
            ConexionBD oconexion = new ConexionBD();
            ComConsClaseIngresos consulta = new ComConsClaseIngresos();
            DataTable dtConsulta = new DataTable();

            if (oconexion.Conectar())
            {
                // Esta consulta se debe cambiar
                dtConsulta = consulta.ContarRegCIngresos(entidadCIngresos, oconexion);
                oconexion.Desconectar();
            } else
            {
                oconexion.Desconectar();
            }

            Mensaje = consulta.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrConsultaPagCIngresos(ComClaseIngreso entidadcIngresos, int pagActual)
        {
            ConexionBD oconexion = new ConexionBD();
            ComConsClaseIngresos consulta = new ComConsClaseIngresos();
            DataTable dtConsulta = new DataTable();

            if (oconexion.Conectar())
            {
                // Esta consulta se debe cambiar
                dtConsulta = consulta.ConsultarCIngresosPag(entidadcIngresos, pagActual, oconexion);
                oconexion.Desconectar();
            }
            else
            {
                oconexion.Desconectar();
            }

            Mensaje = consulta.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlConsultarClaseIngresos(ComClaseIngreso entidadClaseIngresos, string Vigencia)
        {
            ConexionBD oconexion = new ConexionBD();            
            DataTable dtConsulta = new DataTable();
            ComConsClaseIngresos comConsClaseIngresos = new ComConsClaseIngresos();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsClaseIngresos.ConsConsultarClaseIngresos(oconexion, entidadClaseIngresos, Vigencia);
                Mensaje = oconexion.Mensaje;
             }
            else
            {
                Mensaje = oconexion.Mensaje;
            }
    
            return dtConsulta;
        }

        public bool CtrGrabarCambiosArbol(ComCambiosArbol<ComClaseIngreso> Cambios, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsClaseIngresos consulta = new ComConsClaseIngresos();
            
            try
            {
                if (oconexion.IniciarTransaccion())
                {
                	
                    valido = consulta.InertarVariosCIngresos(oconexion, Cambios.ItemsNuevos, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.ActualizarVariosCIngresos(oconexion, Cambios.ItemsActualizados, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.EliminarVariosCIngresos(oconexion, Cambios.ItemsEliminados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    oconexion.CommitTransaccion();
                    Mensaje = "Cambios realizados correctamente";

                }
            } catch(Exception ex)
            {
                oconexion.RollbackTransaccion();
                Mensaje = ex.Message;
            }

            oconexion.Desconectar();
            return valido;
        }

        public DataTable CtrlMovimientosCIgreso(ComClaseIngreso entidadcIngresos)
        {
            ConexionBD oconexion = new ConexionBD();
            ComConsClaseIngresos consulta = new ComConsClaseIngresos();
            DataTable dtConsulta = new DataTable();

            if (oconexion.Conectar())
            {
                // Esta consulta se debe cambiar
                dtConsulta = consulta.MovimientosCIngresos(oconexion, entidadcIngresos);
                oconexion.Desconectar();
            }
            else
            {
                oconexion.Desconectar();
            }

            Mensaje = consulta.Mensaje;
            return dtConsulta;
        }

    }
}
