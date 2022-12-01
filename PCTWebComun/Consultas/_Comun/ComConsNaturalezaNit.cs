//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/07/2019 - Ticket Nº 35702 - Caso: Implementacion pagina Consulta NATURALEZA_NIT - Participantes: Oscar Ramos

using System;
using System.Data;
using PCTWebComun.Entidades._Comun;
using PCTWebComun._ConexionesBD;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsNaturalezaNit
    {
        public string Mensaje;

        //Función que Consultar los datos de la tabla NATURALEZA_NIT
        public DataTable ConsCargarNaturalezaNit(ConexionBD oConexion)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT * FROM NATURALEZA_NIT ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }
    }
}
