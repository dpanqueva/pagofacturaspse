//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade el controlador- Participantes: Maribel Pedroza
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
    public class COMCtrlComActividadesCreeNit
    {
        public string Mensaje;
        public DataTable CtrlConsultarActividadesCreeNit(ComComActividadesCreeNit EntidadComActividadesCreeNit)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsComActividadesCreeNit comConsComActividadesCreeNit = new ComConsComActividadesCreeNit();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsComActividadesCreeNit.ConsConsultarActividadesCreeNit(oConexion, EntidadComActividadesCreeNit);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlGrabarActividadesCreeNit(ComComActividadesCreeNit EntidadComActividadesCreeNit, ComCambiosEntidades<ComComActividadesCreeNit> Cambios)
        {

            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsComActividadesCreeNit comConsComActividadesCreeNit = new ComConsComActividadesCreeNit();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = comConsComActividadesCreeNit.ConsInsertarVariosActividadesCreeNit(oconexion, EntidadComActividadesCreeNit, Cambios.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsComActividadesCreeNit.ConsActualizarVariosActividadesCreeNit(oconexion, EntidadComActividadesCreeNit, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsComActividadesCreeNit.ConsEliminarVariosActividadesCreeNit(oconexion, EntidadComActividadesCreeNit, Cambios.ItemsEliminados);
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
