//PCT.NET_NVO_0000_20190521 - Fecha Inicio 08/09/2021 - Ticket Nº 0000  - Caso: Se clase controlador de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Consultas._Comun;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCategoriaventaElementos
    {
        public string Mensaje;

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 08/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la consulta de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public DataTable CtrlConsultarCategoriaventaElementos(COMCategoriaventaElementos EntidadCategoriaventaElementos, string Vigencia, string Tipo)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtsResultado = new DataTable();
            COMConsCategoriaventaElementos comConsCategoriaventaElementos = new COMConsCategoriaventaElementos();

            if (oConexion.Conectar())
            {
                dtsResultado = comConsCategoriaventaElementos.ConsConsultarCategoriaventaElementos(oConexion, EntidadCategoriaventaElementos, Vigencia, Tipo);
                Mensaje = oConexion.Mensaje;
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }
            return dtsResultado;
        }

        //PCT.NET_NVO_0000_20200430 - Fecha de Inicio 09/09/2021 - Ticket N° 00000 - Caso: se crea metodo para la Grabar cambios de CATEGORIAVENTA_ELEMENTOS - Participantes: Oscar Ramos.
        public bool CtrlGrabarArbolCategoriaventaElementos(ComCambiosArbol<COMCategoriaventaElementos> Cambios, ComCtrlEntidad EntidadCtrlEntidad)
        {
            bool valido = false;
            ConexionBD oconexion = new ConexionBD();
            COMConsCategoriaventaElementos comConsCategoriaventaElementos = new COMConsCategoriaventaElementos();      

            try
            {
                if (oconexion.IniciarTransaccion())
                {
                    if (Cambios.ItemsNuevos != null)
                    {
                        valido = comConsCategoriaventaElementos.InsertarVariosCategoriaventaElementos(oconexion, Cambios.ItemsNuevos, EntidadCtrlEntidad);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }

                    if (Cambios.ItemsActualizados != null)
                    {
                        valido = comConsCategoriaventaElementos.ActualizarVariosCategoriaventaElementos(oconexion, Cambios.ItemsActualizados, EntidadCtrlEntidad);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }

                    if (Cambios.ItemsEliminados != null)
                    {
                        valido = comConsCategoriaventaElementos.EliminarVariosCategoriaventaElementos(oconexion, Cambios.ItemsEliminados, EntidadCtrlEntidad);
                        if (!valido) { throw new Exception(oconexion.Mensaje); }
                    }

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
