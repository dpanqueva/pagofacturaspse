using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Collections.Generic;
using System;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlRegimenTerceros
    {
        public string Mensaje;
        public DataTable CtrlCargarRegimenTerceros(ComRegimenTerceros EntidadRegimenTerceros)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsRegimenTerceros comConsRegimenTerceros = new ComConsRegimenTerceros();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsRegimenTerceros.ConsCargarRegimenTerceros(oConexion, EntidadRegimenTerceros);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlGrabarRegimenTerceros(ComCambiosEntidades<ComRegimenTerceros> Cambios)
        {

            bool valido = false;

            ConexionBD oconexion = new ConexionBD();
            ComConsRegimenTerceros consulta = new ComConsRegimenTerceros();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = consulta.InsertarVariosRegimenTerceros(oconexion, Cambios.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consulta.ActualizarVariosRegimenTerceros(oconexion, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consulta.EliminarVariosRegimenTerceros(oconexion, Cambios.ItemsEliminados);
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
