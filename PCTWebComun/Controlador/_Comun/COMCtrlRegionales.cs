//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35357 - Caso: se añade el controlador- Participantes: Maribel Pedroza

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComunNet.Entidades._Comun;
using System;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlRegionales
    {
        public string Mensaje;
        public DataTable CtrlConsultarRegionales(ComRegionales EntidadRegionales)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsRegionales comConsRegionales = new ComConsRegionales();

            if (oConexion.Conectar())
            {
            	                //dtConsulta = oConsRegionales.ConsultarRegionales(oConexion);
                Mensaje = oConexion.Mensaje;

                
                dtConsulta = comConsRegionales.ConsConsultarRegionales(EntidadRegionales, oConexion);
                Mensaje = oConexion.Mensaje;

                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        public bool CtrlGrabarArbolRegionales(ComCambiosArbol<ComRegionales> Cambios, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsRegionales consulta = new ComConsRegionales();

            try
            {
                if (oconexion.IniciarTransaccion())
                {

                    valido = consulta.InertarVariosRegionales(oconexion, Cambios.ItemsNuevos, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.ActualizarVariosRegionales(oconexion, Cambios.ItemsActualizados, EntidadCtrlEntidad);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }
                    valido = consulta.EliminarVariosRegionales(oconexion, Cambios.ItemsEliminados);
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
