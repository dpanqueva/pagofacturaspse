//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se añade el controlador- Participantes: Maribel Pedroza
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
    public class COMCtrlComNitIngresos
    {
        public string Mensaje;

        public DataTable CtrlConsultarNitIngresos(ComComNitIngresos EntidadComNitIngresos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsComNitIngresos comConsComNitIngresos = new ComConsComNitIngresos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsComNitIngresos.ConsConsultarNitIngresos(oConexion, EntidadComNitIngresos);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlGrabarNitIngresos(ComComNitIngresos EntidadComNitIngresos, ComCambiosEntidades<ComComNitIngresos> Cambios)
        {

            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsComNitIngresos comConsComNitIngresos = new ComConsComNitIngresos();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = comConsComNitIngresos.ConsInsertarVariosNitIngresos(oconexion, EntidadComNitIngresos, Cambios.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsComNitIngresos.ConsActualizarVariosNitIngresos(oconexion, EntidadComNitIngresos, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = comConsComNitIngresos.ConsEliminarVariosNitIngresos(oconexion, EntidadComNitIngresos, Cambios.ItemsEliminados);
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
