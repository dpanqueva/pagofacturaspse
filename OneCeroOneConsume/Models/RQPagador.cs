using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class RQPagador
    {
        private int TipoDocumento { get; }
        private string Identificacion { get; }
        private string Nombre { get; }
        private string Email { get; }
        private string Telefono { get; } 

        public RQPagador() { }
        public RQPagador(int TipoDocumento, string Identificacion, string Nombre, string Email, string Telefono) {
            this.TipoDocumento = TipoDocumento;
            this.Identificacion = Identificacion;
            this.Nombre = Nombre;
            this.Email = Email;
            this.Telefono = Telefono;
        }
    }
}