using PlaceToPayConsume.Configuration;
using PlaceToPayConsume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PlaceToPayConsume.Controllers
{
    public class ConsumoPlaceToPayController
    {
        public AppConfiguration appSettings;

        public ConsumoPlaceToPayController()
        {
            // this.appSettings = new AppConfiguration();
        }
        public async Task<ResponseCheckStatus> ConsultarSesionPlaceToPay(string id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                ResponseCheckStatus res = new ResponseCheckStatus();
                ModelToSendCheckTransaction model = new ModelToSendCheckTransaction();
                try
                {

                    var serializer = new JsonSerializer();


                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                        model.auth = new auth();
                        var tempAuth = new auth();
                        tempAuth.login = "73452cf22735e245de93e1ad5ec3a496";
                        tempAuth.tranKey = "8Hh7c1vjWEcevlOf";
                        byte[] array = new byte[8];
                        Random random = new Random();
                        random.NextBytes(array);
                        tempAuth.nonce = System.Text.Encoding.ASCII.GetString(array);
                        tempAuth.seed = (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
                        model.auth = tempAuth;
                        model.auth.tranKey = Digest(tempAuth);
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(tempAuth.nonce);
                        model.auth.nonce = Convert.ToBase64String(plainTextBytes);
                        var test = JsonConvert.SerializeObject(model);

                        var jsonString = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        request_.Content = jsonString;
                        request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request_.Method = new HttpMethod("POST");
                        Uri myUriLog = new Uri("https://checkout-test.placetopay.com/api/session/" + id);
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
                                    res = serializer.Deserialize<ResponseCheckStatus>(jsonTextReader);

                                }

                            }
                        }
                        else
                        {
                            res.status = new Status();
                            res.status.status = "Error";
                            res.status.message = "Se ha producido un Error al crear la sesion Place To Pay";

                        }
                        httpClient.Dispose();


                    }
                    return res;
                }


                catch (Exception ex)
                {
                    res.status = new Status();
                    res.status.status = "Error";
                    res.status.message = "Se ha producido un Error al crear la sesion Place To Pay : " + ex.Message;
                    throw new Exception("ConsumoPlaceToPayController :: ConsultarSesionPlaceToPay", ex);
                }
            }
        }
        public async Task<Response> CrearSesionPlaceToPayAsync(ModelToSend model)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                Response res = new Response();

                try
                {

                    var serializer = new JsonSerializer();


                    using (var request_ = new HttpRequestMessage())
                    {
                        HttpClient httpClient = new HttpClient();
                        model.auth = new auth();
                        var tempAuth = new auth();
                        tempAuth.login = "73452cf22735e245de93e1ad5ec3a496";
                        tempAuth.tranKey = "8Hh7c1vjWEcevlOf";
                        byte[] array = new byte[8];
                        Random random = new Random();
                        random.NextBytes(array);
                        tempAuth.nonce = System.Text.Encoding.ASCII.GetString(array);
                        tempAuth.seed = (DateTime.Now).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
                        model.auth = tempAuth;
                        model.auth.tranKey = Digest(tempAuth);
                        model.expiration = (DateTime.Now.AddMinutes(20)).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(tempAuth.nonce);
                        model.auth.nonce = Convert.ToBase64String(plainTextBytes);
                        var test = JsonConvert.SerializeObject(model);

                        var jsonString = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        request_.Content = jsonString;
                        request_.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        request_.Method = new HttpMethod("POST");
                        Uri myUriLog = new Uri("https://checkout-test.placetopay.com/api/session");
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
                                    return serializer.Deserialize<Response>(jsonTextReader);

                                }

                            }
                        }
                        else
                        {
                            if (response_.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            {
                                var stream = await response_.Content.ReadAsStreamAsync();
                                serializer = new JsonSerializer();
                                using (var sr = new StreamReader(stream))
                                using (var jsonTextReader = new JsonTextReader(sr))
                                {
                                    res.status = new Status();
                                    res.status.status = "Error";
                                    var g = serializer.Deserialize<Response>(jsonTextReader);
                                    res.status.message = g.status.message;


                                }

                            }
                            else
                            {
                                res.status = new Status();
                                res.status.status = "Error";
                                res.status.message = "Se ha producido un Error al crear la sesion Place To Pay";
                            }
                        }
                        httpClient.Dispose();


                    }
                    return res;
                }


                catch (Exception ex)
                {
                    res.status = new Status();
                    res.status.status = "Error";
                    res.status.message = "Se ha producido un Error al crear la sesion Place To Pay : " + ex.Message;
                    throw new Exception("ConsumoPlaceToPayController :: CrearSesionPlaceToPayAsync", ex);
                }


            }
        }
        public string Digest(auth model)
        {
            string digest = "";
            digest = model.nonce + model.seed + model.tranKey;
            return Base64(Sha1(digest));
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
        public static byte[] Sha1(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(Encoding.ASCII.GetBytes(input));
            }
        }

        public static string Base64(byte[] input)
        {
            return Convert.ToBase64String(input);
        }
    }
}