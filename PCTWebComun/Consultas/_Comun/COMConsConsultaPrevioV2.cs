//PCT.NET_NVO_0000_20191031 - Fecha Inicio 07/03/2021 - Ticket N° 039764 - Caso: Se adiciona campos  consulta Planeacion precontractual - Participantes: Milena Leon
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;

namespace PCTWebComun.Consultas._Comun
{
    public class COMConsConsultaPrevioV2
    {

        private string Mensaje;

        public DataTable ConsConsultarConsultaPrevioV2(ConexionBD oconexion, COMConsultaPrevioV2 EntidadConsultaPrevioV2, string NumeroIniPre, string NumeroFinPre, string FechaInPag, string FechaFinPag, string[] NumPrevioCdp)
        {
            string sentencia = "SELECT DISTINCT * FROM  CONSULTA_PREVIO_V2 ";
            DataTable dtsConsulta;

            sentencia += " WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.VIGENCIA))
            {
                sentencia += " AND VIGENCIA=" + EntidadConsultaPrevioV2.VIGENCIA;
            }
            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.NUM_PREVIO))
            {
                sentencia += " AND NUM_PREVIO = " + EntidadConsultaPrevioV2.NUM_PREVIO;
            }

            //PCT.NET_NVO_0000_20191031 - Fecha Inicio 07/03/2021

            if (!string.IsNullOrEmpty(NumeroIniPre) && (!string.IsNullOrEmpty(NumeroFinPre)))
            {
                sentencia += " AND NUM_PREVIO  BETWEEN " + NumeroIniPre + " AND " + NumeroFinPre + " ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.NIT_DESIGNADO))
            {
                sentencia += " AND NIT_DESIGNADO = '" + EntidadConsultaPrevioV2.NIT_DESIGNADO +"' ";
            }
            if (!string.IsNullOrEmpty(FechaInPag) && (!string.IsNullOrEmpty(FechaFinPag)))
            {
                sentencia += " AND FECHA_ELABORACION BETWEEN '" + FechaInPag + "' AND '" + FechaFinPag + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.NIT_SUPERVISOR))
            {
                sentencia += " AND NIT_SUPERVISOR = '" + EntidadConsultaPrevioV2.NIT_SUPERVISOR +"' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.COD_CENTRO))
            {
                sentencia += " AND COD_CENTRO = '" + EntidadConsultaPrevioV2.COD_CENTRO + "' ";
            }
            if (!string.IsNullOrEmpty(EntidadConsultaPrevioV2.ESTADO))
            {
                sentencia += " AND ESTADO =" + EntidadConsultaPrevioV2.ESTADO;
            }
           if (string.IsNullOrEmpty(EntidadConsultaPrevioV2.ESTADO) && (string.IsNullOrEmpty(EntidadConsultaPrevioV2.VIGENCIA)) &&
              (string.IsNullOrEmpty(NumeroIniPre) && (string.IsNullOrEmpty(NumeroFinPre))) && (string.IsNullOrEmpty(EntidadConsultaPrevioV2.NUM_PREVIO)) &&
              (string.IsNullOrEmpty(EntidadConsultaPrevioV2.NIT_DESIGNADO)) && (string.IsNullOrEmpty(FechaInPag) && (string.IsNullOrEmpty(FechaFinPag))) &&
              (string.IsNullOrEmpty(EntidadConsultaPrevioV2.NIT_SUPERVISOR)) && (string.IsNullOrEmpty(EntidadConsultaPrevioV2.COD_CENTRO)) && (NumPrevioCdp == null))
            {
                sentencia += " AND ESTADO= 1";
            }
            if (NumPrevioCdp!= null)
            {
                string nuevaSentencia =  string.Join(", ", NumPrevioCdp);
                sentencia += " AND NUM_PREVIO IN (" + nuevaSentencia + ")";
            }
            sentencia += " ORDER BY VIGENCIA, NUM_PREVIO";

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
