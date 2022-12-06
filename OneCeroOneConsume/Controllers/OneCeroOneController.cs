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

        /*
         * Method for send the request pay to api 1cero1
         * @return new instance with response from api 1cero1
         */
        public async Task<object> TransactionAPIPayment(RQPayLoadPay rqPayLoadPay)
        {
            /**create session with token*/
            var token = Task.Run(async () => await BuildTokenAsync()).GetAwaiter().GetResult();

            using (var client = new System.Net.Http.HttpClient())
            {
                RSPayOneCeroOne rs = new RSPayOneCeroOne();
                try
                {
                    
                    var serializer = new JsonSerializer();
                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                        
                        if (!token.Equals(""))
                        {
                            var jsonString = new StringContent(JsonConvert.SerializeObject(rqPayLoadPay), Encoding.UTF8, "application/json");
                            request_.Content = jsonString;
                            var test = JsonConvert.SerializeObject(rqPayLoadPay);
                            request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            //request_.Content.Headers.Add("Authorization", "Bearer " + token);
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                            request_.Method = new HttpMethod("POST");
                            Uri myUriLog = new Uri(BASE_URL + "transaction/InsertTransaction");
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
                                        rs = serializer.Deserialize<RSPayOneCeroOne>(jsonTextReader);
                                    }
                                }
                            }
                            else
                            {

                            }
                            httpClient.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    /** response definition when exist an error**/
                    // se debe definir una respuesta general o propia
                    throw new Exception("OneCeroOneController :: TransactionAPIPayment", ex);
                }


                return rs;
            }
        }

        /*
         * Method for consume and get token 
         * @return new instance token
         */
        public async Task<string> BuildTokenAsync()
        {
            var token = "";
            try
            {
                var serializer = new JsonSerializer();
                using (var request_ = new HttpRequestMessage())
                {
                    HttpClient httpClient = new HttpClient();
                    RQLoginModel rqSession = new RQLoginModel();
                    rqSession.Username = "HLF26+ab0xEMPbPlEBe1cl2dNkVtolspdhG+3K3t6e8=";
                    rqSession.Password = "HLF26+ab0xEMPbPlEBe1ci4JWvvUJsZagnsjbRJZWPn14keMkZIoEyomwLIE/oo+";
                    var jsonString = new StringContent(JsonConvert.SerializeObject(rqSession), Encoding.UTF8, "application/json");
                    request_.Content = jsonString;
                    var test = JsonConvert.SerializeObject(rqSession);
                    //request_.Content = new StringContent("{\"name\":\"John Doe\",\"age\":33}", Encoding.UTF8, "application/json");
                    request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request_.Method = new HttpMethod("POST");
                    Uri myUriLog = new Uri(BASE_URL + "Login/authenticate");
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
                                return token;
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
            catch (Exception ex)
            {
                // se debe definir una respuesta general o propia
                throw new Exception("OneCeroOneController :: BuildTokenAsync", ex);
            }

            return token;
        }

        public async Task<object> TransactionQueryPayment()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                RSQueryTransaction rs = new RSQueryTransaction();
                try
                {
                    /**create session with token*/
                    var token = await BuildTokenAsync();
                    var serializer = new JsonSerializer();
                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                       
                        if (!token.Equals(""))
                        {
                            RQQueryTransaction rqPayLoadQuery = new RQQueryTransaction();
                            request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            request_.Content.Headers.Add("Authorization", "Bearer " + token);
                            request_.Method = new HttpMethod("GET");
                            Uri myUriLog = new Uri(BASE_URL + "transaction" + "");
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
                                        rs = serializer.Deserialize<RSQueryTransaction>(jsonTextReader);
                                    }
                                }
                            }
                            else
                            {

                            }
                            httpClient.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    /** response definition when exist an error**/
                    // se debe definir una respuesta general o propia
                    throw new Exception("OneCeroOneController :: TransactionQueryPayment", ex);
                }


                return rs;
            }

        }
    }

}