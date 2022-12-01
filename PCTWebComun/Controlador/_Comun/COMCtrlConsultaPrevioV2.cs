//PCT.NET_NVO_0000_20191031 - Fecha Inicio 07/03/2021 - Ticket N° 039764 - Caso: Se adiciona campos  consulta Planeacion precontractual - Participantes: Milena Leon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System.Data;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlConsultaPrevioV2
    {
        public string Mensaje;

        public DataTable CtrlConsultarConsultaPrevioV2(COMConsultaPrevioV2 EntidadConsultaPrevioV2,  string NumeroIniPre, string NumeroFinPre, string FechaInPag, string fechaFinPag, string[] NumPrevioCdp)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            COMConsConsultaPrevioV2 comConsConsultaPrevioV2 = new COMConsConsultaPrevioV2();

            if (oConexion.Conectar())
            {
                dtConsulta = comConsConsultaPrevioV2.ConsConsultarConsultaPrevioV2(oConexion, EntidadConsultaPrevioV2, NumeroIniPre,  NumeroFinPre, FechaInPag, fechaFinPag, NumPrevioCdp);
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
