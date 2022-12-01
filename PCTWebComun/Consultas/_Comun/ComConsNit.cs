//PCT.NET_NVO_0000_20190521 - Fecha Inicio 21/05/2019 - Ticket Nº 35551 - Caso: se añade la consulta- Participantes: Maribel Pedroza

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using PCTWebComun.IME.COM;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsNit
    {
        
        private string lmensaje;
        public string Mensaje
        {
            get { return lmensaje; }
            private set { }
        }
        public bool ConsInsertarNit(ConexionBD oConexion, ComNit oNit)
        {
            string consulta = "";
            bool resultado;

            consulta = "INSERT INTO NIT (NIT, CHEQUEO, COD_CONTABLE, CUIN, COD_CONTRALORIA, PRIMER_NOMBRE, OTROS_NOMBRES, PRIMER_APELLIDO, OTROS_APELLIDOS," +
            " NOMBRE, DIRECCION, TELEFONO, TELEFONO_CELULAR, FAX, EMAIL, REP_LEGAL, NIT_REP_LEGAL, CODIGO_POSTAL, CONTACTO, CTA_BANCO, SUCURSAL," +
            " OBSERVACIONES, TIPO_DOCUMENTO, CLASE_NIT, TIPO_NIT, COD_NATURALEZA, COD_DEPTO, COD_MUNIC, COD_BANCO, COD_DEPTOCTA, COD_MUNICCTA," +
            " TIPO_CTABANCARIA, SANCIONADO, ENT_OFICIAL, FUNCIONARIO, ACTIVO, USUARIO, ID_COM_NIT, CIUDAD, COD_USUARIO, FAC_AUTOMATICA, COD_PAIS, ID_COM_ENTIDAD )" +
            " VALUES ('" + oNit.NIT + "','" + oNit.CHEQUEO + "','" + oNit.COD_CONTABLE + "','" + oNit.CUIN + "','" + oNit.COD_CONTRALORIA + "','" + oNit.PRIMER_NOMBRE + "'," +
            "'" + oNit.OTROS_NOMBRES + "','" + oNit.PRIMER_APELLIDO + "','" + oNit.OTROS_APELLIDOS + "','" + oNit.NOMBRE + "','" + oNit.DIRECCION + "','" + oNit.TELEFONO + "'," +
            "'" + oNit.TELEFONO_CELULAR + "','" + oNit.FAX + "','" + oNit.EMAIL + "','" + oNit.REP_LEGAL + "','" + oNit.NIT_REP_LEGAL + "','" + oNit.CODIGO_POSTAL + "','" + oNit.CONTACTO + "','" + oNit.CTA_BANCO + "'," +
            "'" + oNit.SUCURSAL + "','" + oNit.OBSERVACIONES + "','" + oNit.TIPO_DOCUMENTO + "','" + oNit.CLASE_NIT + "','" + oNit.TIPO_NIT+ "','" + oNit.COD_NATURALEZA + "','" + oNit.COD_DEPTO + "'," +
            "'" + oNit.COD_MUNIC + "','" + oNit.COD_BANCO + "','" + oNit.COD_DEPTOCTA + "','" + oNit.COD_MUNICCTA + "','" + oNit.TIPO_CTABANCARIA + "','" + oNit.SANCIONADO + "'," +
            "'" + oNit.ENT_OFICIAL + "','" + oNit.FUNCIONARIO + "','" + oNit.ACTIVO+ "','" + oNit.USUARIO + "','" + oNit.ID_COM_NIT + "'," +
            "'" + oNit.CIUDAD + "','" + oNit.COD_USUARIO + "','" + oNit.FAC_AUTOMATICA + "','" + oNit.COD_PAIS + "','" + oNit.ID_COM_ENTIDAD + "')";
            
            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }

        public bool ConsActualizarNit(ConexionBD oConexion, ComNit oNit)
        {
            string consulta = "";
            bool resultado;

            consulta = "UPDATE NIT SET TIPO_DOCUMENTO ='" + oNit.TIPO_DOCUMENTO + "', NOMBRE='" + oNit.NOMBRE + "', TIPO_NIT='" + oNit.TIPO_NIT + "'," +
            " CLASE_NIT='" + oNit.CLASE_NIT + "', TIPO_CTABANCARIA='" + oNit.TIPO_CTABANCARIA + "', ID_COM_ENTIDAD='" + oNit.ID_COM_ENTIDAD + "', ENT_OFICIAL='" + oNit.ENT_OFICIAL + "'," +
            " USUARIO='" + oNit.USUARIO + "', CHEQUEO='" + oNit.CHEQUEO + "', CUIN='" + oNit.CUIN + "'," +
            " PRIMER_NOMBRE='" + oNit.PRIMER_NOMBRE + "', OTROS_NOMBRES='" + oNit.OTROS_NOMBRES + "', PRIMER_APELLIDO= '" + oNit.PRIMER_APELLIDO + "'," +
            " REP_LEGAL='" + oNit.REP_LEGAL + "',OTROS_APELLIDOS='" + oNit.OTROS_APELLIDOS + "', CONTACTO='" + oNit.CONTACTO + "', TELEFONO_CELULAR='" + oNit.TELEFONO_CELULAR + "'," +
            " TELEFONO='" + oNit.TELEFONO + "', FAX='" + oNit.FAX + "', EMAIL='" + oNit.EMAIL + "',DIRECCION= '" + oNit.DIRECCION + "', NIT_REP_LEGAL='" + oNit.NIT_REP_LEGAL + "'," +
            " COD_MUNIC='" + oNit.COD_MUNIC + "', CIUDAD='" + oNit.CIUDAD + "', COD_NATURALEZA=" + oNit.COD_NATURALEZA + ", COD_CONTABLE='" + oNit.COD_CONTABLE + "'," +
            " COD_CONTRALORIA='" + oNit.COD_CONTRALORIA + "', SANCIONADO='" + oNit.SANCIONADO + "', OBSERVACIONES='" + oNit.OBSERVACIONES + "'," +
            " CTA_BANCO='" + oNit.CTA_BANCO + "', COD_BANCO='" + oNit.COD_BANCO + "', SUCURSAL='" + oNit.SUCURSAL + "', COD_DEPTO='" + oNit.COD_DEPTO + "'," +
            " COD_USUARIO='" + oNit.COD_USUARIO + "', COD_DEPTOCTA='" + oNit.COD_DEPTOCTA + "',COD_MUNICCTA='" + oNit.COD_MUNICCTA + "', COD_PAIS='" + oNit.COD_PAIS + "'," +
            " FAC_AUTOMATICA='" + oNit.FAC_AUTOMATICA + "',  CODIGO_POSTAL= '" + oNit.CODIGO_POSTAL + "', FUNCIONARIO='" + oNit.FUNCIONARIO + "', ACTIVO='" + oNit.ACTIVO + "'" +
            " WHERE NIT = '" + oNit.NIT + "'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }

        public bool ConsEliminarNit(ConexionBD oConexion, ComNit oNit)
        {
            bool resultado;
            string consulta;

            consulta = "DELETE FROM NIT WHERE NIT = '" + oNit.NIT + "'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }

        public bool ConsStCambiarNit(ConexionBD oConexion, ComNit oNit1, ComNit oNit2)
        {
            bool resultado;     

            List<DbParameter> listaParametro = new List<DbParameter>();
            ComIMENit ImeNit = new ComIMENit();

            listaParametro = ImeNit.ProcedimientoComCambioNit(oNit1, oNit2);

            resultado = oConexion.EjecutarProcedimieto("ST_CAMBIAR_NIT", listaParametro);
            lmensaje = oConexion.Mensaje;
            return resultado;

        }

        public bool ConsActualizarVariosNit(ConexionBD oconexion, List<ComNit> ItemsActualizados)
        {
            bool valido;
            string sentenciaBase = "UPDATE NIT SET ";

            try
            {
                if (ItemsActualizados != null)
                {
                    foreach (ComNit itemNuevo in ItemsActualizados)
                    {
                        List<string> actualizaciones = new List<string>();

                        if (!string.IsNullOrEmpty(itemNuevo.NOMBRE))
                            actualizaciones.Add(" NOMBRE ='" + itemNuevo.NOMBRE + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.PRIMER_NOMBRE))
                            actualizaciones.Add(" PRIMER_NOMBRE ='" + itemNuevo.PRIMER_NOMBRE + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.OTROS_NOMBRES))
                            actualizaciones.Add(" OTROS_NOMBRES ='" + itemNuevo.OTROS_NOMBRES + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.PRIMER_APELLIDO))
                            actualizaciones.Add(" PRIMER_APELLIDO ='" + itemNuevo.PRIMER_APELLIDO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.OTROS_APELLIDOS))
                            actualizaciones.Add(" OTROS_APELLIDOS ='" + itemNuevo.OTROS_APELLIDOS + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.TIPO_DOCUMENTO))
                            actualizaciones.Add(" TIPO_DOCUMENTO ='" + itemNuevo.TIPO_DOCUMENTO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.CLASE_NIT))
                            actualizaciones.Add(" CLASE_NIT ='" + itemNuevo.CLASE_NIT + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.TIPO_NIT))
                            actualizaciones.Add(" TIPO_NIT ='" + itemNuevo.TIPO_NIT + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_NATURALEZA))
                            actualizaciones.Add(" COD_NATURALEZA ='" + itemNuevo.COD_NATURALEZA + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.TELEFONO))
                            actualizaciones.Add(" TELEFONO ='" + itemNuevo.TELEFONO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_DEPTO))
                            actualizaciones.Add(" COD_DEPTO ='" + itemNuevo.COD_DEPTO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_MUNIC))
                            actualizaciones.Add(" COD_MUNIC ='" + itemNuevo.COD_MUNIC + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.SANCIONADO))
                            actualizaciones.Add(" SANCIONADO ='" + itemNuevo.SANCIONADO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.CTA_BANCO))
                            actualizaciones.Add(" CTA_BANCO ='" + itemNuevo.CTA_BANCO + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_CONTRALORIA))
                            actualizaciones.Add(" COD_CONTRALORIA ='" + itemNuevo.COD_CONTRALORIA + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.ENT_OFICIAL))
                            actualizaciones.Add(" ENT_OFICIAL ='" + itemNuevo.ENT_OFICIAL + "'");

                        if (!string.IsNullOrEmpty(itemNuevo.COD_CONTABLE))
                            actualizaciones.Add(" COD_CONTABLE ='" + itemNuevo.COD_CONTABLE + "'");

                        if (actualizaciones.Count > 0)
                        {
                            string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                            nuevaSentencia += " WHERE NIT = '" + itemNuevo.NIT + "'";
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;

            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }

        public bool ConsEliminarVariosNit(ConexionBD oconexion, List<ComNit> ItemEliminados)
        {
            bool valido;
            string sentenciaBase = "delete from NIT where NIT= '{value}'";

            try
            {
                if (ItemEliminados != null)
                {
                    foreach (ComNit itemNuevo in ItemEliminados)
                    {
                        if (!string.IsNullOrEmpty(itemNuevo.NIT))
                        {
                            string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.NIT);
                            valido = oconexion.EjecutarSQL(nuevaSentencia);
                            if (!valido) { throw new Exception(oconexion.Mensaje); }
                        }
                    }
                }
                valido = true;
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                valido = false;
                oconexion.RollbackTransaccion();
            }

            return valido;
        }      

        public bool ConsInsertarClaveTranspNit(ConexionBD oConexion, ComNit oNit)
        {
            string consulta = "";
            bool resultado;

            consulta = "UPDATE NIT SET COD_USUARIO='"+ oNit.COD_USUARIO +"' WHERE NIT='"+ oNit.NIT +"'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }     

        public bool ConsActualizarFuncionarioNit(ConexionBD oConexion, ComNit oNit)
        {
            string consulta = "";
            bool resultado;

            consulta = "UPDATE NIT SET FUNCIONARIO ='" + oNit.FUNCIONARIO + "' WHERE TIPO_NIT='" + oNit.TIPO_NIT + "'";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }


        //Consulta nit - Oscar 10/11/2020
        public DataTable ConsConsultarNit(ConexionBD oconexion, ComNit EntidadNit)
        {
            DataTable dtsConsulta = new DataTable();
            string sentencia = "SELECT  * FROM  NIT  WHERE 1 = 1 AND ROWNUM <= 500 ";           
            //filtro para conulta de terceros - Maribel Pedroza
            if (!string.IsNullOrEmpty(EntidadNit.NIT) && !string.IsNullOrEmpty(EntidadNit.NOMBRE))
            {
                sentencia += " AND NIT LIKE '%" + EntidadNit.NIT + "%' OR UPPER(NOMBRE) LIKE '%" + EntidadNit.NOMBRE.ToUpper() + "%'";
            }
            else {
                if (!string.IsNullOrEmpty(EntidadNit.NIT))
                {
                    sentencia += "  AND NIT='" + EntidadNit.NIT + "'";
                }
            }

            dtsConsulta = oconexion.Consulta(sentencia);
            Mensaje = oconexion.Mensaje;
            return dtsConsulta;
        }

    }
}
