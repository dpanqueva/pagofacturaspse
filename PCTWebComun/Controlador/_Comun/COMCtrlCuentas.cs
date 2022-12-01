using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCuentas
    {
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public DataTable CtrlConsultarCuentas(ComCuentas entidadCuentas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCuentas comConsCuentas = new ComConsCuentas();

            if (oconexion.Conectar())
            {
                dtConsulta = comConsCuentas.ConsConsultarCuentas(oconexion, entidadCuentas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlConsultaPagCuentas(int pagina, int cantidad, ComCuentas entidadCuentas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCuentas consultaCuentas = new ComConsCuentas();

            if (oconexion.Conectar())
            {
                dtConsulta = consultaCuentas.ConsultaPaginadaCuentas(oconexion, pagina, cantidad, entidadCuentas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }
        //conteo de paginas
        public DataTable CtrlCountPagCuentas(ComCuentas entidadCuentas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCuentas consultaCuentas = new ComConsCuentas();

            if (oconexion.Conectar())
            {
                dtConsulta = consultaCuentas.ConsultaCountPagCuentas(oconexion, entidadCuentas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlContarRegCuentas()
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCuentas consultaCuentas = new ComConsCuentas();

            if (oconexion.Conectar())
            {
                dtConsulta = consultaCuentas.ContarRegCuentas(oconexion);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable CtrlConsultaValidarDatosCuenta(ComCuentas entidadCuentas)
        {
            ConexionBD oconexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCuentas consultaCuentas = new ComConsCuentas();

            if (oconexion.Conectar())
            {
                dtConsulta = consultaCuentas.ValidarDatosCuentas(oconexion, entidadCuentas);
                oconexion.Desconectar();
            }
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public Boolean CtrlEditarCuentas(ComCuentas entidadCuentas)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsCuentas comConsCuentas = new ComConsCuentas();

            if (oConexion.Conectar())
            {
                Consulta = comConsCuentas.ConsEditarCuentas(oConexion, entidadCuentas);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }

            return Consulta;
        }

        public Boolean CtrlEliminarCuentas(ComCuentas entidadCuentas)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsCuentas comConsCuentas = new ComConsCuentas();

            if (oConexion.Conectar())
            {
                Consulta = comConsCuentas.ConsEliminarCuentas(oConexion, entidadCuentas);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }

            return Consulta;
        }

        public bool CtrlGrabarCuentasReciprocas(ComCambiosEntidades<ComCuentas> Cambios)
        {

            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsCuentas comConsCuentas = new ComConsCuentas();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    //valido = comConsCuentas.InsertarVariosCuentasReciprocas(oconexion, Cambios.ItemsNuevos);
                    //if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsCuentas.ActualizarVariosCuentasReciprocas(oconexion, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsCuentas.EliminarVariosCuentasReciprocas(oconexion, Cambios.ItemsEliminados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

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
