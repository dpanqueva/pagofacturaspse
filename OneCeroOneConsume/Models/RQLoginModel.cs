using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{

    public class RQLoginModel
    {
        private string username { get;  }
        private string password { get; }

        public RQLoginModel(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
}