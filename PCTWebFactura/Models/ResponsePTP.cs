using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCTWebFactura.Models
{
    public class ResponsePTP
    {

        private bool isException;
        private string exception;
        private string message;
        private object obj;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public string Exception
        {
            get { return exception; }
            set { exception = value; }
        }
        public bool IsException
        {
            get { return isException; }
            set { isException = value; }
        }
        public object Obj
        {
            get { return obj; }
            set { obj = value; }
        }

        public string GetResponse()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}