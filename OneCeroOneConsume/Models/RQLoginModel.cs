using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCeroOneConsume.Models
{

    public class RQLoginModel
    {
        private string Username { get;  }
        private string Password { get; }

        public RQLoginModel(string Username, string Password) {
            this.Username = Username;
            this.Password = Password;
        }
    }
}