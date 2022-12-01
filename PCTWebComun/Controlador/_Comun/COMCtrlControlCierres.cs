using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComun._ConexionesBD;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlControlCierres
    {
        public string Mensaje;

        public DataTable CtrlConsultarControlCierres(ComControlCierres EntidadControlCierres)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsControlCierres comConsControlCierres = new ComConsControlCierres();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsControlCierres.ConsConsultarControlCierres(oConexion, EntidadControlCierres);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlGrabarControlCierres(ComCambiosEntidades<ComControlCierres> CambiosControlCierres)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsControlCierres consulta = new ComConsControlCierres();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = consulta.InsertarVariosControlCierres(oconexion, CambiosControlCierres.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consulta.ActualizarVariosControlCierres(oconexion, CambiosControlCierres.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consulta.EliminarVariosControlCierres(oconexion, CambiosControlCierres.ItemsEliminados);
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
