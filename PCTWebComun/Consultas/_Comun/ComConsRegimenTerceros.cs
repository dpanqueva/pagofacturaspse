//PCT.NET_NVO_0000_20190521 - Fecha Inicio 03/07/2019 - Ticket Nº 35702 - Caso: Implementacion pagina Consulta Regimen Terceros - Participantes: Oscar Ramos

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
    public class ComConsRegimenTerceros
    {
        public string Mensaje;

        //Función que permite Cargar Nombre y Codigo de la tabla REGIMEN_TERCEROS
        public DataTable ConsCargarRegimenTerceros(ConexionBD oConexion, ComRegimenTerceros EntidadRegimenTerceros)
        {
            string sentencia;
            DataTable dtConsulta = new DataTable();
            sentencia = "SELECT COD_REGIMEN, NOM_REGIMEN " +
                " FROM REGIMEN_TERCEROS WHERE 1 = 1";

            if (!string.IsNullOrEmpty(EntidadRegimenTerceros.COD_REGIMEN))
            {
                sentencia = sentencia + " AND COD_REGIMEN = '" + EntidadRegimenTerceros.COD_REGIMEN  + "' ";
            }
           
            sentencia = sentencia + " ORDER BY NOM_REGIMEN ";

            dtConsulta = oConexion.Consulta(sentencia);
            Mensaje = oConexion.Mensaje;

            return dtConsulta;
        }
    

        //Función que permite Insertar Varios datos a la tabla REGIMEN_TERCEROS
    public bool InsertarVariosRegimenTerceros(ConexionBD oconexion, List<ComRegimenTerceros> ItemsNuevos)
    {
        bool valido;
        string sentencia = "INSERT INTO REGIMEN_TERCEROS(COD_REGIMEN, NOM_REGIMEN) VALUES ({values})";

        try
        {
            if(ItemsNuevos != null)
            {
                foreach (ComRegimenTerceros itemNuevo in ItemsNuevos)
                {
                    string valores = (!string.IsNullOrEmpty(itemNuevo.COD_REGIMEN) ? "'" + itemNuevo.COD_REGIMEN + "'" : "null") + ",'"
                    + itemNuevo.NOM_REGIMEN + "'";

                    string nuevosentencia = sentencia.Replace("{values}", valores);
                    valido = oconexion.EjecutarSQL(nuevosentencia);
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

    //Función que permite actualizar Varios datos a la tabla REGIMEN_TERCEROS
    public bool ActualizarVariosRegimenTerceros(ConexionBD oconexion, List<ComRegimenTerceros> ItemsActualizados)
       {
        bool valido;
        string sentenciaBase = "UPDATE REGIMEN_TERCEROS SET ";

        try
        {
            if (ItemsActualizados != null)
            {
                foreach (ComRegimenTerceros itemNuevo in ItemsActualizados)
                {
                    List<string> actualizaciones = new List<string>();

                    if (!string.IsNullOrEmpty(itemNuevo.NOM_REGIMEN))
                        actualizaciones.Add("NOM_REGIMEN ='" + itemNuevo.NOM_REGIMEN + "'");          


                    if (actualizaciones.Count > 0)
                    {
                        string nuevaSentencia = sentenciaBase + string.Join(", ", actualizaciones);
                        nuevaSentencia += " WHERE COD_REGIMEN = '" + itemNuevo.COD_REGIMEN + "'";
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

        //Función que permite Eliminar Varios datos a la tabla REGIMEN_TERCEROS
        public bool EliminarVariosRegimenTerceros(ConexionBD oconexion, List<ComRegimenTerceros> ItemEliminados)
    {
        bool valido;
        string sentenciaBase = "DELETE FROM REGIMEN_TERCEROS WHERE COD_REGIMEN= '{value}'";

        try
        {
            if (ItemEliminados != null)
            {
                foreach (ComRegimenTerceros itemNuevo in ItemEliminados)
                {
                    if (!string.IsNullOrEmpty(itemNuevo.COD_REGIMEN))
                    {
                        string nuevaSentencia = sentenciaBase.Replace("{value}", itemNuevo.COD_REGIMEN);
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
