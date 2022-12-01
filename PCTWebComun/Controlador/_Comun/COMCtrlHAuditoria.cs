using PCTWebComun._ConexionesBD;
using PCTWebComun.Consultas._Comun;
using PCTWebComun.Entidades._Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCTWebComun.Controlador._Comun
{
    public class COMCtrlHAuditoria
    {
        public string Mensaje;
        public Boolean CtrlInsertarHAuditoria(ComHAuditoria EntidadHAuditoria1, ComHAuditoria EntidadHAuditoria2)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsHAuditoria comConsHAuditoria = new ComConsHAuditoria();

            if (oConexion.Conectar())
            {
                Consulta = comConsHAuditoria.ConsInsertarHAuditoria(oConexion, EntidadHAuditoria1, EntidadHAuditoria2);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        } 
        
        public Boolean CtrlInsertHAuditoria(ComHAuditoria EntidadHAuditoria)
        {
            ConexionBD oConexion = new ConexionBD();
            Boolean Consulta = new Boolean();
            ComConsHAuditoria comConsHAuditoria = new ComConsHAuditoria();

            if (oConexion.Conectar())
            {
                Consulta = comConsHAuditoria.ConsInsertHAuditoria(oConexion, EntidadHAuditoria);
                Mensaje = oConexion.Mensaje;
                oConexion.Desconectar();
            }
            else
            {
                Mensaje = oConexion.Mensaje;
            }

            return Consulta;
        }

    }
}
