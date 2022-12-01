//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade el controlador- Participantes: Maribel Pedroza

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;
using System;
using System.Collections.Generic;
using System.Web;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlUnidades
    {
        public string Mensaje;
        public DataTable CtrlConsultarUnidades(ComUnidades entidadUnidades, string Vigencia) {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsUnidades comConsUnidades = new ComConsUnidades();

            if (oConexion.Conectar()) {
                dtConsulta = comConsUnidades.ConsConsultarUnidades(oConexion, entidadUnidades, Vigencia);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrGrabarCambiosArbolUnidades(ComCambiosArbol<ComUnidades> Cambios, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsUnidades consulta = new ComConsUnidades();

            try
            {
                if (oconexion.IniciarTransaccion())
                {

                    valido = consulta.InsertarVariosUnidades(oconexion, Cambios.ItemsNuevos, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.ActualizarVariosUnidades(oconexion, Cambios.ItemsActualizados, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.EliminarVariosUnidades(oconexion, Cambios.ItemsEliminados);
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
