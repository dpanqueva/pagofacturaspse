//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/12/2020 - Ticket Nº 0000  - Caso: Se agrega pagina Clase Controlador de la entidad NOTAS_TRASLADOS, solicitud de Milena Leon - Participantes: Oscar Ramos
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 07/12/2020 - Ticket Nº 039019  - Caso: Se agrega Controlador de NOTAS_TRASLADOS - Participantes: Milena Leon

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
    public class COMCtrlNotasTraslados
    {
            public string Mensaje;
            public DataTable ctrlComNotasTraslados(COMNotasTraslados EntidadComNotasTraslados)
            {
                ConexionBD oConexion = new ConexionBD();
                DataTable dtsResultado = new DataTable();
                COMConsNotasTraslados ComConsComNotasTraslados = new COMConsNotasTraslados();

                if (oConexion.Conectar())
                {
                    dtsResultado = ComConsComNotasTraslados.ConsConsultaComNotasTraslados(oConexion, EntidadComNotasTraslados);
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
