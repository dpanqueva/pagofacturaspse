//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/07/2019 - Ticket Nº 35554 - Caso: Implementacion pagina Consulta Apr Clase Recursos - Participantes: Oscar Ramos

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
    public class AprConsClaseRecursos
    {
        private string Mensaje;

        //Función que permite consultar Apr Clase Recursos
        public DataTable ConsConsultarAprClaseRecursos(ConexionBD oconexion, ComAprClaseRecursos entidadAprClaseRecursos)
        {
            string sentencia;

            DataTable dtsConsulta = new DataTable();

            if (string.IsNullOrEmpty(entidadAprClaseRecursos.ID_CLS_RECURSO))
            {
                sentencia = "SELECT * FROM APR_CLASE_RECURSOS ORDER BY ID_CLS_RECURSO";
            }
            else
            {
                sentencia = "SELECT NOM_CLS_RECURSO FROM APR_CLASE_RECURSOS WHERE UPPER(NOM_CLS_RECURSO) LIKE UPPER('%"+entidadAprClaseRecursos.ID_CLS_RECURSO+"%');";
            }
                                   
                 
            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }
    }
}
