using System;
using System.Collections.Generic;
using System.Web.SessionState;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace PlaceToPayConsume.Configuration
{
    public class AppConfiguration
    {
        public string login;
        public string secretKey;

        public AppConfiguration()
        {

            this.login = ConfigurationManager.AppSettings["loginPlaceToPay"];

            this.secretKey = ConfigurationManager.AppSettings["secretKey"];


        }
    }
}