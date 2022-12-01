using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Collections.Generic;
using System;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlClaseDesRecV1
    {
        public string Mensaje;
        public DataTable CtrlConsultarClaseDesResRecV1(ComClaseDesRecV1 EntidadCLaseDesResRecV1)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsClaseDesRecV1 comConsClaseDesRecV1 = new ComConsClaseDesRecV1();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsClaseDesRecV1.ConsConsultarClaseDesResRecV1(oConexion, EntidadCLaseDesResRecV1);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
    }
}
