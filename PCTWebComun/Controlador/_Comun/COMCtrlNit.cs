//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se añade el controlador- Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021 - Ticket Nº 39019 - Caso: se añade el controlador Query QNitsEgresoMB - Participantes: Milena Leon 

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.CamposQueries._Comun;
using PCTWebComun.Queries._Comun;
using System;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlNit
    {
        private string lmensaje;

        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }

        public DataTable CtrlConsultarNit(ComCQNit CamposQueryNit)
        {
            ConexionBD oConexion = new ConexionBD();
            ComQNit comConsNit = new ComQNit();
            DataTable dtResultado = new DataTable();

            if (oConexion.Conectar())
            {
                dtResultado = comConsNit.ConsConsultarNit(oConexion, CamposQueryNit);
                Mensaje = comConsNit.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = "Error Controlador Nit: " + oConexion.Mensaje;
            }
            return dtResultado;
        }       

        public Boolean CtrlInsertarNit(ComNit EntidadNit)
        {

            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsInsertarNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public Boolean CtrlActualizarNit(ComNit EntidadNit)
        {

            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsActualizarNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public Boolean CtrlEliminarNit(ComNit EntidadNit)
        {

            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsEliminarNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public bool CtrlGrabarNitColumnar(ComCambiosEntidades<ComNit> Cambios)
        {
       
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsNit comConsNit = new ComConsNit();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    //valido = comConsNit.InsertarVariosCategoriaTerceros(oconexion, Cambios.ItemsNuevos);
                    //if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsNit.ConsActualizarVariosNit(oconexion, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsNit.ConsEliminarVariosNit(oconexion, Cambios.ItemsEliminados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    oconexion.CommitTransaccion();
                    //Mensaje = "Cambios realizados correctamente";    
                }
            }
            catch (Exception ex)
            {
                oconexion.RollbackTransaccion();
                Mensaje=ex.Message;
            }

            oconexion.Desconectar();
            return valido;
        }
        
        public Boolean CtrlStCambiarNit(ComNit EntidadNit1, ComNit EntidadNit2)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsStCambiarNit(oConexion, EntidadNit1, EntidadNit2);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }
            lmensaje = comConsNit.Mensaje;
            return Consulta;
        }
        
        public Boolean CtrlInsertarClaveTranspNit(ComNit EntidadNit)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsInsertarClaveTranspNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        public DataTable CtrlConsultarTipoNit(ComCQNit CamposQueryNit)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComQNit comConsTipoNit = new ComQNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsTipoNit.ConsConsultarTipoNit(oConexion, CamposQueryNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public Boolean CtrlActualizarFuncionarioNit(ComNit EntidadNit)
        {

            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsNit comConsNit = new ComConsNit();

            if (oConexion.Conectar())
            {
                Consulta = comConsNit.ConsActualizarFuncionarioNit(oConexion, EntidadNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

        //CONTROLADOR QUERY NIT COLUMNAR

        public DataTable CtrlConsultarDeptoMunicipiosNit(ComCQNit CamposQueryNit)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComQNit comQNit = new ComQNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comQNit.QConsultarDeptoMunicipiosNit(oConexion, CamposQueryNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlExcelConsNitColumnar(ComCQNit CamposQueryNit)
        {
            ConexionBD oConexion = new ConexionBD();
            ComQNit comConsNit = new ComQNit();
            DataTable dtResultado = new DataTable();

            if (oConexion.Conectar())
            {
                dtResultado = comConsNit.ConsExcelConsNitColumnar(oConexion, CamposQueryNit);
                Mensaje = comConsNit.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = "Error Controlador Nit: " + oConexion.Mensaje;
            }
            return dtResultado;
        }

        //PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021

        public DataTable CtrlConsultarNitsEgresoMB(ComCQNit CamposQueryNit)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComQNit comQNitMB = new ComQNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comQNitMB.QConsultarNitsEgresoMB(oConexion, CamposQueryNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
