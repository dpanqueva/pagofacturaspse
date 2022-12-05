﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneCeroOneConsume.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.IO;

namespace OneCeroOneConsume.Controllers
{
    public class OneCeroOneController 
    {

        private string BASE_URL = "https://www.1cero1pay.com/ApiPayment/api/";

        public async Task<RSPayOneCeroOne> TransactionAPIPayment() {

            using (var client = new System.Net.Http.HttpClient()) {
                RSPayOneCeroOne rs = new RSPayOneCeroOne();
                try {
                    var serializer = new JsonSerializer();
                    using (var request_ = new HttpRequestMessage()) {
                        HttpClient httpClient = new HttpClient();
                        /**create session with token*/

                    }
                }
                catch (Exception ex)
                { 
                
                }


                    return rs;
            }
        }

        private async Task<string> BuildTokenAsync()
        {
            var token = "";
            try
            {
                var serializer = new JsonSerializer();


                using (var request_ = new HttpRequestMessage())
                {
                    HttpClient httpClient = new HttpClient();
                    RQLoginModel rqSession = new RQLoginModel("HLF26+ab0xEMPbPlEBe1cl2dNkVtolspdhG+3K3t6e8=", "HLF26+ab0xEMPbPlEBe1ci4JWvvUJsZagnsjbRJZWPn14keMkZIoEyomwLIE/oo+");
                    var jsonString = new StringContent(JsonConvert.SerializeObject(rqSession), Encoding.UTF8, "application/json");
                    request_.Content = jsonString;
                    request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request_.Method = new HttpMethod("POST");
                    Uri myUriLog = new Uri(BASE_URL+ "Login/authenticate");
                    request_.RequestUri = myUriLog;
                    httpClient.Timeout = TimeSpan.FromMinutes(20);
                    var response_ = await httpClient.SendAsync(request_, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    if (response_.StatusCode == System.Net.HttpStatusCode.OK) // 200
                    {
                        if (response_.IsSuccessStatusCode)
                        {
                            var stream = await response_.Content.ReadAsStreamAsync();
                            serializer = new JsonSerializer();
                            using (var sr = new StreamReader(stream))
                            using (var jsonTextReader = new JsonTextReader(sr))
                            {
                                token = serializer.Deserialize<string>(jsonTextReader);

                            }

                        }
                    }
                    else
                    {
                       /** response definition when exist an error**/

                    }
                    httpClient.Dispose();
                }
            }
            catch (Exception e)
            {

            }

            return token;
        }
    }
}