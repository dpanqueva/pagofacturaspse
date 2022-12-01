//PCT.NET_NVO_0000_20190521 - Fecha Inicio 14/10/2020 - Ticket Nº 038738- Caso: se crea Controlador para la función de compara ppto se llama desde Modificaciones de Apropiacion - Participantes: Wendy Simbaqueba
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
    public class COMCtrlPptoGastos
    {
        
            public string Mensaje;
            public DataTable CtrlConsultarPptoGastos(COMPptoGastos EntidadPptoGastos)
            {

                ConexionBD oConexion = new ConexionBD();
                DataTable dtConsulta = new DataTable();
                COMConsPptoGastos comConsPptoGastos = new COMConsPptoGastos();

                if (oConexion.Conectar())
                {
                    dtConsulta = comConsPptoGastos.ConsConsultarPptoGastos(oConexion, EntidadPptoGastos);
                    Mensaje = oConexion.Mensaje;
                    oConexion.Desconectar();
                }
                else
                {
                    Mensaje = oConexion.Mensaje;
                }

                return dtConsulta;
            }


        public DataTable CtrlConsPptoGastosTipPac(COMPptoGastos EntidadPptoGastos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsPptoGastos comConsPptoGastos = new COMConsPptoGastos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsPptoGastos.ConsConsPptoGastosTipPac(oConexion, EntidadPptoGastos);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }


        public DataTable CtrlComparaPptos()
            {

                ConexionBD oConexion = new ConexionBD();
                DataTable dtConsulta = new DataTable();
                COMConsPptoGastos comConsPptoGastos = new COMConsPptoGastos();

                if (oConexion.Conectar())
                {
                    dtConsulta = comConsPptoGastos.ConsComparaPptos(oConexion);
                    Mensaje = oConexion.Mensaje;
                    oConexion.Desconectar();
                }
                else
                {
                    Mensaje = oConexion.Mensaje;
                }

                return dtConsulta;
            }


        public DataTable CtrlComparaPptosPacInicial(COMPptoGastos EntidadPptoGastos)
        {

            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsPptoGastos comConsPptoGastos = new COMConsPptoGastos();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsPptoGastos.ConsComparaPptosPacInicial(oConexion, EntidadPptoGastos);
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

