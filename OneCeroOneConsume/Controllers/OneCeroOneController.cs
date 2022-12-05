using System;
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
        public async Task<RSPayOneCeroOne> TransactionAPIPayment()
        {

            using (var client = new System.Net.Http.HttpClient())
            {
                RSPayOneCeroOne rs = new RSPayOneCeroOne();
                try
                {
                    var serializer = new JsonSerializer();
                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                        /**create session with token*/
                        var token = BuildTokenAsync();
                        if (!token.Equals(""))
                        {
                            RQPayLoadPay rqPayLoadPay = new RQPayLoadPay();
                            // ¿Cómo se recibe este objeto desde el front?
                            var jsonString = new StringContent(JsonConvert.SerializeObject(rqPayLoadPay), Encoding.UTF8, "application/json");
                            request_.Content = jsonString;
                            request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                            request_.Content.Headers.Add("Authorization", "Bearer " + token);
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
                    throw new Exception("ConsumoPlaceToPayController :: ConsultarSesionPlaceToPay", ex);
                }


                return rs;
            }
        }

        /*
         * Method for consume and get token 
         * @return new instance token
         */
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
                throw new Exception("ConsumoPlaceToPayController :: ConsultarSesionPlaceToPay", ex);
            }

            return token;
        }

        public async Task<RSQueryTransaction> TransactionQueryPayment()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                RSQueryTransaction rs = new RSQueryTransaction();
                try
                {
                    var serializer = new JsonSerializer();
                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                        /**create session with token*/
                        var token = BuildTokenAsync();
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
                    throw new Exception("ConsumoPlaceToPayController :: ConsultarSesionPlaceToPay", ex);
                }


                return rs;
            }

        }
    }

}