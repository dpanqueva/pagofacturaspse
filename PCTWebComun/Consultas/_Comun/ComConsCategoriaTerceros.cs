//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/07/2019 - Ticket Nº 35702 - Caso: Implementacion pagina Consulta NATURALEZA_NIT - Participantes: Oscar Ramos

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System.Data;
using System.Web;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsCategoriaTerceros
    {
        public string Mensaje;

        //Función que permite cargar datos de CATEGORIA_TERCEROS
        public DataTable ConsCargarCategoriaTerceros(ConexionBD oConexion)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT COD_CATEGORIA, NOM_CATEGORIA, COD_CGN, FUNCIONARIO " +
                " FROM CATEGORIA_TERCEROS ";

            sentencia = sentencia + " ORDER BY NOM_CATEGORIA ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }

        //Función que permite insertar datos de CATEGORIA_TERCEROS
        public bool InsertarVariosCategoriaTerceros(ConexionBD oconexion, List<ComCategoriaTerceros> ItemsNuevos)
    {

        bool valido;
        string sentencia = "INSERT INTO CATEGORIA_TERCEROS(COD_CATEGORIA,NOM_CATEGORIA,COD_CGN,FUNCIONARIO) VALUES ({values})";

        try
        {
            if (ItemsNuevos != null)
            {
                foreach (ComCategoriaTerceros itemNuevo in ItemsNuevos)
                {
                    string valores = (!string.IsNullOrEmpty(itemNuevo.COD_CATEGORIA) ? "'" + itemNuevo.COD_CATEGORIA + "'" : "null") + ",'"
                        + itemNuevo.NOM_CATEGORIA + "','"
                        + itemNuevo.COD_CGN + "','"
                        + itemNuevo.FUNCIONARIO + "'";

                    string nuevasentencia = sentencia.Replace("{values}", valores);
                    valido = oconexion.EjecutarSQL(nuevasentencia);
                    if (!valido) { throw new Exception(oconexion.Mensaje); }

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

    //Función que permite Actualizar datos de CATEGORIA_TERCEROS
    public bool ActualizarVariosCategoriaTerceros(ConexionBD oconexion, List<ComCategoriaTerceros> ItemsActualizados)
    {
        bool valido;
        string sentenciaBase = "UPDATE CATEGORIA_TERCEROS SET ";

        try
        {
            if (ItemsActualizados != null)
            {
                foreach (ComCategoriaTerceros itemNuevo in ItemsActualizados)
                {
                    List<string> actualizaciones = new List<string>();

                    if (!string.IsNullOrEmpty(itemNuevo.NOM_CATEGORIA))
                        actualizaciones.Add("NOM_CATEGORIA ='" + itemNuevo.NOM_CATEGORIA + "'");

                    if (!string.IsNullOrEmpty(itemNuevo.COD_CGN))
                        actualizaciones.Add("COD_CGN ='" + itemNuevo.COD_CGN + "'");

                    if (!string.IsNullOrEmpty(itemNuevo.FUNCIONARIO))
                        actualizaciones.Add("FUNCIONARIO ='" + itemNuevo.FUNCIONARIO + "'");       


                    if (actualizaciones.Count > 0)
                    {
                        string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                        nuevaSentencia += " WHERE COD_CATEGORIA = '" + itemNuevo.COD_CATEGORIA + "'";
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
        
    //Función que permite Eliminar datos de CATEGORIA_TERCEROS
     public bool EliminarVariosCategoriaTerceros(ConexionBD oconexion, List<ComCategoriaTerceros> ItemEliminados)
    {
        bool valido;
        string sentenciaBase = "delete from CATEGORIA_TERCEROS where COD_CATEGORIA= '{value}'";

        try
        {
            if (ItemEliminados != null)
            {
                foreach (ComCategoriaTerceros itemNuevo in ItemEliminados)
                {
                    if (!string.IsNullOrEmpty(itemNuevo.COD_CATEGORIA))
                    {
                        string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_CATEGORIA);
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
 }
}
