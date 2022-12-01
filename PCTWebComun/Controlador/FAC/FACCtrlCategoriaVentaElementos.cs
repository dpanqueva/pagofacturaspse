//PCT.NET_NVO_0000_20200430 - Fecha Inicio 24 / 09 / 2021 - Ticket N° 00000 - Caso: Se agrega la pagina de FACCtrlCategoriaVentaElementos, Solicitud de Ingrid - Participantes: Maribel Pedrozausing System;
//PCT.NET_NVO_0000_20200430 - Fecha Inicio 04/10/2021 - Ticket N° 040676 - Caso: Se agrega Clase controlador CATEGORIAVENTA_ELEMENTOS - Participantes:Ingrid Gomez

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlCategoriaVentaElementos
    {
        public string Mensaje;
        public DataTable CtrlConsultarCategoriaelem(FACCategoriaVentaElementos EntidadCategoriaelementos)
        {

            ConexionBD oConexion = new ConexionBD();
            FACConsCategoriaVentaElementos fACConsCategoriaVentaElementos = new FACConsCategoriaVentaElementos();
            DataTable dtResultado = new DataTable();

            if (oConexion.Conectar())
            {
                dtResultado = fACConsCategoriaVentaElementos.ConsConsultarFACCategoriaelem(oConexion, EntidadCategoriaelementos);
                Mensaje = fACConsCategoriaVentaElementos.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = "Error Controlador Categoria: " + oConexion.Mensaje;
            }
            return dtResultado;

            //ConexionBD oConexion = new ConexionBD();
            //DataTable dtConsulta = new DataTable();
            //FACConsCategoriaVentaElementos fACConsCategoriaVentaElementos = new FACConsCategoriaVentaElementos();

            //if (oConexion.Conectar())
            //{
            //    dtConsulta = fACConsCategoriaVentaElementos.ConsConsultarFACCategoriaelem(oConexion, EntidadCategoriaelementos);
            //    Mensaje = oConexion.Mensaje;
            //    oConexion.Desconectar();
            //}
            //else
            //{
            //    Mensaje = oConexion.Mensaje;
            //}

            //return dtConsulta;
        }
    }
}
