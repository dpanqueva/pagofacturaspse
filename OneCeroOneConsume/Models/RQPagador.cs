using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RQPagador
    {
        public int TipoDocumento { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; } 

        /*public RQPagador() { }
        public RQPagador(int TipoDocumento, string Identificacion, string Nombre, string Email, string Telefono) {
            this.TipoDocumento = TipoDocumento;
            this.Identificacion = Identificacion;
            this.Nombre = Nombre;
            this.Email = Email;
            this.Telefono = Telefono;
        }*/
    }
}