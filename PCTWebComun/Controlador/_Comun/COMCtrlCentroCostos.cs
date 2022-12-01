//PCT.NET_NVO_0000_20190531 - Fecha Inicio 21/05 / 2019 - Ticket Nº 35358 - Caso: Se Crea Controlador Comun CtrlConsultarCentroCostos - Participantes: Oscar Ramos 

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.Controlador._Comun;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComunNet.Entidades._Comun;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlCentroCostos
    {
        public string Mensaje;

        //Método Controlador que recibe los datos de la Clase y hace los transfiere a la Consulta.  
        public DataTable CtrlConsultarCentroCostos(ComCentroCostos entidadCentroCostos)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            ComConsCentroCostos comConsCentroCostos = new ComConsCentroCostos();
            
            if (oConexion.Conectar())
            {
                dtConsulta = comConsCentroCostos.ConsConsultarCentroCostos(oConexion, entidadCentroCostos);
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
