using PCTWebComun._ConexionesBD;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Consultas._Comun
{
    public class ComConsHAuditoria
    {
        public string Mensaje;
        public bool ConsInsertarHAuditoria(ConexionBD oConexion, ComHAuditoria EntidadHAuditoria1, ComHAuditoria EntidadHAuditoria2)
        {
            string consulta = "";
            bool resultado;

            consulta = "INSERT INTO HAUDITORIA (COD_AUDITORIA,DESCRIPCION,USUARIO) VALUES (193,'(AP)CAMBIAR NIT: " + EntidadHAuditoria1.NIT + " POR: " + EntidadHAuditoria2.NIT + "','" + EntidadHAuditoria1.USUARIO + "')";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }    
        
        public bool ConsInsertHAuditoria(ConexionBD oConexion, ComHAuditoria EntidadHAuditoria)
        {
            string consulta = "";
            bool resultado;

            consulta = "INSERT INTO HAUDITORIA (COD_AUDITORIA,DESCRIPCION,USUARIO,FEC_OPERACION) VALUES (80,"+ EntidadHAuditoria.DESCRIPCION+ " , USER, SYSDATE)";

            resultado = oConexion.EjecutarSQL(consulta);
            Mensaje = oConexion.Mensaje;

            return resultado;
        }
    }
}
