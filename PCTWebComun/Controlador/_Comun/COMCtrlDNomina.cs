using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlDNomina
    {
        public string Mensaje;

        public DataTable CtrlConsultarDNomina(ComDNomina entidadDNomina)
        {
            ConexionBD oconexion = new ConexionBD();
            ComConsDNomina comConsDNomina = new ComConsDNomina();
            DataTable dtConsulta = new DataTable();

            if (oconexion.Conectar())
            {               
                dtConsulta = comConsDNomina.ConsCountDNomina(oconexion,entidadDNomina);
                oconexion.Desconectar();
            }
            else
            {
                oconexion.Desconectar();
            }

            Mensaje = comConsDNomina.Mensaje;

            return dtConsulta;
        }
    }
}
