using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{
    public class ResponseError
    {
        public string CodigoError { set; get; }
        public string Mensaje { set; get; }

        public ResponseError() { 
        }
    }
}