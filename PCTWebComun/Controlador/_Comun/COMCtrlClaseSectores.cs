using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun.Utilidades;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseSectores
    {
        public string Mensaje;
        public DataTable CtrlConsultarClaseSectores(ComClaseSectores EntidadClaseSectores)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsClaseSectores comConsClaseSectores = new ComConsClaseSectores();
            
            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseSectores.ConsConsultarClaseSectores(oConexion, EntidadClaseSectores);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        //Controlador para Insertar, Modificar, Eliminar COM_CLASE_SECTORES Creado por: Maribel Pedroza
        public bool CtrlGrabarComClaseSectores(ComClaseSectores EntidadComClaseSectores, ComCambiosEntidades<ComClaseSectores> Cambios)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsClaseSectores comConsClaseSectores = new ComConsClaseSectores();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = comConsClaseSectores.ConsInsertarVariosComClaseSectores(oconexion, EntidadComClaseSectores, Cambios.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsClaseSectores.ConsActualizarVariosComClaseSectores(oconexion, EntidadComClaseSectores, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsClaseSectores.ConsEliminarVariosComClaseSectores(oconexion, EntidadComClaseSectores, Cambios.ItemsEliminados);
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
