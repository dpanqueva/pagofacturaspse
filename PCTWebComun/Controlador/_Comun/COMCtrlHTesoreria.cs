//PCT.NET_NVO_0000_20200430 - Fecha Inicio 30/11/2020 - Ticket N° 0000 - Caso: Se agrega clase controlador de HTESORERIA a solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 07/12/2020 - Ticket N° 039019 - Caso: Se agrega controlador de HTESORERIA - Participantes: Milena Leon

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
    public class COMCtrlHTesoreria
    {
            public string Mensaje;
            public DataTable ctrlComHTesoreria(COMHTesoreria EntidadHTesoreria)
            {
                ConexionBD oConexion = new ConexionBD();
                DataTable dtsResultado = new DataTable();
                COMConsHTesoreria comConsHTesoreria = new COMConsHTesoreria();

                if (oConexion.Conectar())
                {
                    dtsResultado = comConsHTesoreria.ConsConsultaHTesoreria(oConexion, EntidadHTesoreria);
                    Mensaje = oConexion.Mensaje;
                    oConexion.Desconectar();
                }
                else
                {
                    Mensaje = oConexion.Mensaje;
                }
                return dtsResultado;
            }
    }
}
