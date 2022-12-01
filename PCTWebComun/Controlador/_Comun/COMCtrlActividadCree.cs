using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComun._ConexionesBD;
using System.Collections.Generic;
using System.Data;
using System;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlActividadCree
    {
        public string Mensaje;

        public DataTable CtrlConsultarActividadesCree(ComActividadesCree entidadActividadesCree)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsComActividadesCree comConsComActividadesCree = new ComConsComActividadesCree();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsComActividadesCree.ConsConsultarActividadesCree(oConexion ,entidadActividadesCree);
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlGrabarActividadCree(ComCambiosEntidades<ComActividadesCree> Cambios)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsComActividadesCree ComConsComActividadesCree = new ComConsComActividadesCree();

            try
            {
                if (oconexion.IniciarTransaccion())
                {

                    valido = ComConsComActividadesCree.InsertarVariosActividadesCree(oconexion, Cambios.ItemsNuevos); 
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = ComConsComActividadesCree.ActualizarVariosActividadesCree(oconexion, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = ComConsComActividadesCree.EliminarVariosActividadesCree(oconexion, Cambios.ItemsEliminados);
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
