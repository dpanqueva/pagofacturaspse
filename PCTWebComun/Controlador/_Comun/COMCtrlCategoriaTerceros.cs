using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Collections.Generic;
using System;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCategoriaTerceros
    {
        public string Mensaje;
        public DataTable CtrlCargarCategoriaTerceros()
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCategoriaTerceros comConsCategoriaTerceros = new ComConsCategoriaTerceros();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsCategoriaTerceros.ConsCargarCategoriaTerceros(oConexion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

public bool CtrlGrabarCategoriaTerceros(ComCambiosEntidades<ComCategoriaTerceros> Cambios)
{
       
        bool valido = false;

    ConexionBD oconexion = new ConexionBD();
    ComConsCategoriaTerceros consComConsCategoriaTerceros = new ComConsCategoriaTerceros();

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    valido = consComConsCategoriaTerceros.InsertarVariosCategoriaTerceros(oconexion, Cambios.ItemsNuevos);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consComConsCategoriaTerceros.ActualizarVariosCategoriaTerceros(oconexion, Cambios.ItemsActualizados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    valido = consComConsCategoriaTerceros.EliminarVariosCategoriaTerceros(oconexion, Cambios.ItemsEliminados);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

                    oconexion.CommitTransaccion();
                    Mensaje = "Cambios realizados correctamente";    
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
    }
}
