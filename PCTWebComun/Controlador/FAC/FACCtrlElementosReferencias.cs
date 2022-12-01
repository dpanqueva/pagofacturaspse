//PCT.NET_NVO_0000_20190521 - Fecha Inicio 13/01/2021 - Ticket Nº 0000  - Caso: se agrega clase Controlador ElementosReferencias, Solicitud deJheisone Padilla- Participantes: Oscar Ramos

using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas.FAC;
using PCTWebComun.Entidades.FAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador.FAC
{
    public class FACCtrlElementosReferencias
    {
        public string Mensaje;
        public DataTable CtrlConsultarElementosReferencias(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarElementosReferencias(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQCategoria(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQCategoria(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQCategoriaS(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQCategoriaS(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQCategoriaventaelementos(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQCategoriaventaelementos(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQCentroUtilidad(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQCentroUtilidad(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQConsultaCategoriaSer(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQConsultaCategoriaSer(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQClaseGastos(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQClaseGastos(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQCategoriaElemento(FACElementosReferencias entidadVigenciaFacOcasional)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQCategoriaElemento(oConexion, entidadVigenciaFacOcasional);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQDistrib(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQDistrib(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQGauge(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQGauge(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQNivel(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQNivel(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQReferenciaServicio(FACElementosReferencias entidadVigenciaFacOcasional)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQReferenciaServicio(oConexion, entidadVigenciaFacOcasional);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQRegiones(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQRegiones(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQRCategoriaServicio(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQRCategoriaServicio(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQRegula(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQRegula(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQRPTElementos(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQRPTElementos(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQunidades(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQunidades(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarVigenciaActual(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarVigenciaActual(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQSession(FACElementosReferencias EntidadFACElementosReferencias, string opcion)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQSession(oConexion, EntidadFACElementosReferencias,opcion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlConsultarST_CLASE_ELEMENTOSSERVICIO(FACElementosReferencias entidadReferenciaFacOcasional, DbTransaction transaccion)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            FACConsElementosReferencias fACConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                Consulta = fACConsElementosReferencias.facConsST_CLASE_ELEMENTOSSERVICIO(oConexion, entidadReferenciaFacOcasional, transaccion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            if (fACConsElementosReferencias.Valores != null)
            {
                oValor = fACConsElementosReferencias.Valores;
            }

            return Consulta;
        }
        public DataTable CtrlConsultarQElementosServicio(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQElementosServicio(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public bool CtrlConsultarST_REFSERVICIO(FACElementosReferencias entidadReferenciaFacOcasional, DbTransaction transaccion)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            FACConsElementosReferencias fACConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                Consulta = fACConsElementosReferencias.facConsST_REFSERVICIO(oConexion, entidadReferenciaFacOcasional, transaccion);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            if (fACConsElementosReferencias.Valores != null)
            {
                oValor = fACConsElementosReferencias.Valores;
            }

            return Consulta;
        }

        public DataTable CtrlFACConsUnidades(FACElementosReferencias FACentidadUnidades, string buscar)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsUnidades = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsUnidades.ConsFACConsUnidades(oConexion, FACentidadUnidades, buscar);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }

        public DataTable CtrlConsultarQDistribBeforeDelete(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQDistribBeforeDelete(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQClaseGastosNewRecord(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQClaseGastosNewRecord(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        public DataTable CtrlConsultarQClaseGastosBeforeDelete(FACElementosReferencias EntidadFACElementosReferencias)
        {
            ConexionBD oConexion = new ConexionBD();
            DataTable dtConsulta = new DataTable();
            FACConsElementosReferencias facConsElementosReferencias = new FACConsElementosReferencias();

            if (oConexion.Conectar())
            {
                dtConsulta = facConsElementosReferencias.ConsConsultarQClaseGastosBeforeDelete(oConexion, EntidadFACElementosReferencias);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return dtConsulta;
        }
        private DbParameterCollection oValor;
        public DbParameterCollection Valores
        {
            get { return oValor; }
            set { oValor = value; }
        }
    }
}
