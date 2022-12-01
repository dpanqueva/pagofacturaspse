//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade el controlador- Participantes: Maribel Pedroza

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComunNet.Entidades._Comun;
using System;
using System.Data;


namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseGastos
    {
        public string Mensaje;

        public DataTable CtrlConsultarClasegastos(ComClaseGastos EntidadClaseGastos)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsClaseGastos comConsClaseGastos = new ComConsClaseGastos();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsClaseGastos.ConsConsultarClaseGastos(oconexion, EntidadClaseGastos);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlConsClasegastos(ComClaseGastos EntidadClaseGastos, string Vigencia)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsClaseGastos comConsClaseGastos = new ComConsClaseGastos();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsClaseGastos.ConsConsClaseGastos(oconexion, EntidadClaseGastos, Vigencia);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public bool CtrGrabarCambiosArbolClaseGastos(ComCambiosArbol<ComClaseGastos> Cambios, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido = false;
       

            ConexionBD oconexion = new ConexionBD();
            ComConsClaseGastos consulta = new ComConsClaseGastos();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    if(Cambios.ItemsNuevos != null)
                    {
                        valido = consulta.InsertarVariosClaseGastos(oconexion, Cambios.ItemsNuevos, EntidadCtrlEntidad);                        
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }

                    if (Cambios.ItemsActualizados != null)
                    {
                        valido = consulta.ActualizarVariosClaseGastos(oconexion, Cambios.ItemsActualizados, EntidadCtrlEntidad);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }

                    if (Cambios.ItemsEliminados != null)
                    {
                        valido = consulta.EliminarVariosClaseGastos(oconexion, Cambios.ItemsEliminados, EntidadCtrlEntidad);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }                     

                    oconexion.CommitTransaccion();              
                    Mensaje = "Cambios realizados correctamente";               
                }
            }
            catch (Exception ex)
            {
                oconexion.RollbackTransaccion();
                Mensaje = ex.Message;
            }

            oconexion.Desconectar();
            return valido;
        }

    }
}
