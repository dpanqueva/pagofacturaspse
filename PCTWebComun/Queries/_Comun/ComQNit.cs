//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se añade el Query - Participantes: Maribel Pedroza
//PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021 - Ticket Nº 39019 - Caso: se añade el Query QNitsEgresoMB - Participantes: Milena Leon 

using PCTWebComun._ConexionesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCTWebComun.CamposQueries._Comun;

namespace PCTWebComun.Queries._Comun
{
    public class ComQNit
    {
        public string Mensaje;

        public DataTable ConsConsultarNit(ConexionBD oConexcion, ComCQNit CamposQueryNit)
        {
            DataTable dtResultado = new DataTable();
            string consulta = "";

            consulta = "SELECT A.NIT, A.CHEQUEO, A.TIPO_DOCUMENTO, A.NOMBRE, A.REP_LEGAL, A.CONTACTO, A.CODIGO_POSTAL, " +
                    " A.TELEFONO, A.FAX, A.EMAIL, A.DIRECCION, A.COD_MUNIC, A.CIUDAD, A.TIPO_NIT," +
                    " A.CLASE_NIT, COD_CONTABLE, SANCIONADO, OBSERVACIONES, CTA_BANCO," +
                    " A.COD_BANCO, A.SUCURSAL, A.COD_DEPTO, A.COD_USUARIO, A.COD_DEPTOCTA, F.COD_CATEGORIA, E.COD_REGIMEN, A.COD_NATURALEZA," +
                    " A.COD_MUNICCTA, A.TIPO_CTABANCARIA, A.PRIMER_NOMBRE, A.OTROS_NOMBRES," +
                    " A.PRIMER_APELLIDO, A.OTROS_APELLIDOS, A.COD_CONTRALORIA,A.COD_NATURALEZA,A.ENT_OFICIAL," +
                    " D.NOM_TIPO, G.NATURALEZA, C.NOM_DEPTO, B.NOM_MUNICIPIO, F.NOM_CATEGORIA, F.COD_CGN, E.NOM_REGIMEN, A.ACTIVO, A.CUIN, A.FUNCIONARIO, A.TELEFONO_CELULAR " +
                    " FROM NIT A, MUNICIPIOS B, DEPARTAMENTOS C, TIPO_NIT D," +
                    " REGIMEN_TERCEROS E, CATEGORIA_TERCEROS F, NATURALEZA_NIT G " +
                    " WHERE 1=1 AND ROWNUM <= 500 " +
                    " AND (A.COD_MUNIC = B.COD_MUNICIPIO AND A.COD_DEPTO = B.COD_DEPTO)" +
                    " AND A.COD_DEPTO = C.COD_DEPTO AND A.TIPO_DOCUMENTO = D.TIPO_DOCUMENTO" +
                    " AND A.CLASE_NIT = E.COD_REGIMEN AND A.TIPO_NIT = F.COD_CATEGORIA" +
                    " AND A.COD_NATURALEZA = G.COD_NATURALEZA";

            if (!string.IsNullOrEmpty(CamposQueryNit.COLUMNAR)) { 
                if (!string.IsNullOrEmpty(CamposQueryNit.NIT))
                {
                    consulta += " AND A.NIT = '" + CamposQueryNit.NIT + "'";
                }
            }else {
                if (!string.IsNullOrEmpty(CamposQueryNit.NIT) && !string.IsNullOrEmpty(CamposQueryNit.NOMBRE))
                {
                    consulta += " AND A.NIT LIKE '%" + CamposQueryNit.NIT + "%' OR UPPER(A.NOMBRE) LIKE '%" + CamposQueryNit.NOMBRE.ToUpper() + "%'";
                }
                else {
                    if (!string.IsNullOrEmpty(CamposQueryNit.NIT))
                    {
                        consulta += " AND A.NIT LIKE '" + CamposQueryNit.NIT + "' ";
                    }
                    if (!string.IsNullOrEmpty(CamposQueryNit.NOMBRE))
                    {
                        consulta += " AND UPPER(A.NOMBRE) LIKE '%" + CamposQueryNit.NOMBRE.ToUpper() + "%' ";
                    }
                }
            }
            
            if (!string.IsNullOrEmpty(CamposQueryNit.TIPO_DOCUMENTO))
            {
                consulta += " AND A.TIPO_DOCUMENTO = '" + CamposQueryNit.TIPO_DOCUMENTO + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.CLASE_NIT))
            {
                consulta += " AND A.CLASE_NIT = '" + CamposQueryNit.CLASE_NIT + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.TIPO_NIT))
            {
                consulta += " AND A.TIPO_NIT = '" + CamposQueryNit.TIPO_NIT + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_NATURALEZA))
            {
                consulta += " AND A.COD_NATURALEZA = '" + CamposQueryNit.COD_NATURALEZA + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_DEPTO))
            {
                consulta += " AND A.COD_DEPTO = '" + CamposQueryNit.COD_DEPTO + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_MUNIC))
            {
                consulta += " AND A.COD_MUNIC = '" + CamposQueryNit.COD_MUNIC + "'";
            }

            consulta += " ORDER BY A.NOMBRE ASC";
            dtResultado = oConexcion.Consulta(consulta);
            Mensaje = oConexcion.Mensaje;

            return dtResultado;
        }
        public DataTable QConsultarDeptoMunicipiosNit(ConexionBD oConexion, ComCQNit CamposQueryNit)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT A.COD_DEPTO, A.NOM_DEPTO, B.COD_MUNICIPIO, B.NOM_MUNICIPIO ";
            sentencia = sentencia + " FROM DEPARTAMENTOS A , MUNICIPIOS B ";
            sentencia = sentencia + " WHERE A.COD_DEPTO = B.COD_DEPTO ";

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_MUNICIPIO) && !string.IsNullOrEmpty(CamposQueryNit.NOM_MUNICIPIO))
            {
                sentencia = sentencia + " AND COD_MUNICIPIO LIKE '%" + CamposQueryNit.COD_MUNICIPIO + "%' OR UPPER(NOM_MUNICIPIO) LIKE '%" + CamposQueryNit.NOM_MUNICIPIO.ToUpper() + "%'";

            }
            else
            {
                if (!string.IsNullOrEmpty(CamposQueryNit.COD_MUNICIPIO))
                {
                    sentencia = sentencia + "  AND UPPER(COD_MUNICIPIO) LIKE UPPER('" + CamposQueryNit.COD_MUNICIPIO + "')";
                }

                if (!string.IsNullOrEmpty(CamposQueryNit.NOM_MUNICIPIO))
                {
                    sentencia = sentencia + " AND UPPER(NOM_MUNICIPIO) LIKE UPPER('%" + CamposQueryNit.NOM_MUNICIPIO + "%')";
                }
            }

            sentencia += " ORDER BY B.NOM_MUNICIPIO ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }

        public DataTable ConsConsultarTipoNit(ConexionBD oconexion, ComCQNit CamposQueryNit)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT B.TIPO_DOCUMENTO, B.NOM_TIPO, B.ID_COM_ENTIDAD, B.USUARIO, B.CTRL_ALFA, B.CALCULAR_DV , A.TIPO_DOCUMENTO TIPO_DOCUMENTONIT, A.NIT, A.CHEQUEO FROM NIT A,TIPO_NIT B ";

            sentencia += " WHERE A.TIPO_DOCUMENTO = B.TIPO_DOCUMENTO AND NIT ='" + CamposQueryNit.NIT + "'";

            dtConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;

            return dtConsulta;
        }

        public DataTable ConsExcelConsNitColumnar(ConexionBD oconexion, ComCQNit CamposQueryNit)
        {
            DataTable dtConsulta = new DataTable();
            string consulta = " SELECT NIT, CHEQUEO, TIPO_DOCUMENTO, NOMBRE, REP_LEGAL, "+
                    "CONTACTO, TELEFONO, FAX, EMAIL, DIRECCION,COD_MUNIC, CIUDAD,"+
                    "TIPO_NIT, CLASE_NIT, COD_CONTABLE, SANCIONADO, OBSERVACIONES,"+
                    "CTA_BANCO, COD_BANCO, SUCURSAL, A.COD_DEPTO, COD_USUARIO, "+
                    "COD_DEPTOCTA, COD_MUNICCTA, TIPO_CTABANCARIA, PRIMER_NOMBRE, "+
                    "OTROS_NOMBRES, PRIMER_APELLIDO, OTROS_APELLIDOS, COD_CONTRALORIA, "+
                    "COD_NATURALEZA, ENT_OFICIAL, B.NOM_DEPTO, C.NOM_MUNICIPIO ";

            consulta += " FROM NIT A, DEPARTAMENTOS B, MUNICIPIOS C";
            consulta += " WHERE A.COD_DEPTO = B.COD_DEPTO";
            consulta += " AND A.COD_MUNIC = C.COD_MUNICIPIO";
            consulta += " AND B.COD_DEPTO = C.COD_DEPTO";
                       
            if (!string.IsNullOrEmpty(CamposQueryNit.NIT))
            {
                consulta += " AND A.NIT = '" + CamposQueryNit.NIT + "'";
            }
            
            if (!string.IsNullOrEmpty(CamposQueryNit.TIPO_DOCUMENTO))
            {
                consulta += " AND A.TIPO_DOCUMENTO = '" + CamposQueryNit.TIPO_DOCUMENTO + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.CLASE_NIT))
            {
                consulta += " AND A.CLASE_NIT = '" + CamposQueryNit.CLASE_NIT + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.TIPO_NIT))
            {
                consulta += " AND A.TIPO_NIT = '" + CamposQueryNit.TIPO_NIT + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_NATURALEZA))
            {
                consulta += " AND A.COD_NATURALEZA = '" + CamposQueryNit.COD_NATURALEZA + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_DEPTO))
            {
                consulta += " AND A.COD_DEPTO = '" + CamposQueryNit.COD_DEPTO + "'";
            }

            if (!string.IsNullOrEmpty(CamposQueryNit.COD_MUNIC))
            {
                consulta += " AND A.COD_MUNIC = '" + CamposQueryNit.COD_MUNIC + "'";
            }

            consulta += " ORDER BY A.NOMBRE ASC";
            dtConsulta = oconexion.Consulta(consulta);
            Mensaje = oconexion.Mensaje;
            dtConsulta.TableName = "Xls Nit Columnar";
            return dtConsulta;
        }

        //PCT.NET_NVO_0000_20190521 - Fecha Inicio 06/01/2021
        public DataTable QConsultarNitsEgresoMB(ConexionBD oConexion, ComCQNit CamposQueryNit)
        {
            DataTable dtConsulta = new DataTable();
            string sentencia = "SELECT DISTINCT A.NIT,B.NOMBRE,C.NUM_ORDEN FROM DEGRESO A, NIT B, MORDEN C WHERE A.NIT=B.NIT AND A.NUM_EGRESO=C.NUM_EGRESO AND A.CLS_EGRESO=C.CLS_EGRESO ";

            if ((!string.IsNullOrEmpty(CamposQueryNit.NIT)) && (!string.IsNullOrEmpty(CamposQueryNit.NOMBRE)))
            {
                sentencia = sentencia + " AND UPPER(A.NIT) LIKE '%" + CamposQueryNit.NIT + "%' OR UPPER(B.NOMBRE) LIKE UPPER('%" + CamposQueryNit.NOMBRE + "%')";
            }
            else
            {
                if (!string.IsNullOrEmpty(CamposQueryNit.NIT))
                {
                    sentencia = sentencia + "  AND UPPER(A.NIT) LIKE UPPER('" + CamposQueryNit.NIT + "')";
                }

                if (!string.IsNullOrEmpty(CamposQueryNit.NOMBRE))
                {
                    sentencia = sentencia + " AND UPPER(B.NOMBRE) LIKE UPPER('%" + CamposQueryNit.NOMBRE + "%')";
                }
            }
                if (!string.IsNullOrEmpty(CamposQueryNit.NUM_ORDEN))
                {
                   sentencia = sentencia + " AND C.NUM_ORDEN = " + CamposQueryNit.NUM_ORDEN + "";
                }

            sentencia += " ORDER BY A.NIT";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }
    }
}
