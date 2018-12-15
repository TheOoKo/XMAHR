using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Extensions.Compression.Client;


using System.Net.Http.Extensions.Compression.Core.Compressors;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helper
{
    public class ApiRequest<T>
    {
        private static String API_URL = "http://localhost:54365/";
        //private static String API_URL = "http://ecomhostapi.azurewebsites.net/";
        //Cloud Token
        //private static string accessToken = "-T0LbJhi38sAV3Sr7D6MHPqcruhnqcVm-S6n_k1O_8UOEpgIc0OQtMNuKhJHagQQsE8c48228ukR7me4FLh9dQEat3wpcPc1TsG1cXzCRIjAXrWqJZfXa01f6NvU-h5KdafsGzqd45rq5PQ6zjULHpq4ugSkhvlJ6OHzWgIAnSxdUmmiHqbBDQXLbwls0JyPlq31KsUfybwx9D7jgptbF4vaWgdt4iwEeZioYO5VT4tZQXxVlXJbobXay5qt_fLiTmiIQ7-SqR6OTuCMeyVjaMf0pmRK1zzfcj8sHULovxKft2DMgO33Tzp4JnhGIJXddbOvETAgKl0EDFxS-znMAJJrPKWgBWa3rnaNq6FI9foFDTP2cts6SyvilVgks4qzYV934SAaWUPjHFgXiyjSwpspACyUsTUr_bfaARzpi0wFYPh3TubeGdfJ71_bXkU_uPwdtopl45k3gGIP76HpfkIBwKGtRyKK7qiET0redMcplKLvgyhzX2NGawKXkB9Y";
        //Local Token
        //private static string accessToken = "wJdsaMbfjk8hTFsuLs9ysRWX5nQpZQaj3DC12QD_oYQtUi1jd4L-fcVjd1KomkjsumPZ39IMXkqUahpYe1oNLcIupoBoGJ4mGKm8J1Ft_6JDUtKyefRBIwMS0n6WCjlUs8UgQYuQ-ecPemxqd-gHXGNwmv31n3GUNOB-0V00RJ5rFUYGYDutsGwsVFz4ndlVl8FoPmTPq7T7f9lkkKdyFsC2ky90Ss-BdvZKEJBEttzPdUw3vDW22-ovlrDGooX6z3-Y8VylF6RhJ5UxpJDu2ItzcHeMA-ISUSirgD17O9uvvzfpNhnzXn35WB9RuRPrbOOaaNGxg0ZeyMN9uitOOjUDnkpqRYlaokUz-pVrMxcQ4KvpoRU8mrTYAv8cfNjzWLNBxeC_De8aLQd4GObd39jhB6y12R8ZPqkkpIG7qekrUkDWZzYU7M0_vb1yy159RqZOdEqa0DDGYQjiD7QEmRAz2va26Gmb3QTYKloE0SfJ6xDNfLEDja4aIKTRqv0";

        public static string Get(string url, out T entity)
        {
            try
            {
                url = API_URL + url;
                entity = default(T);
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(url); //URI 
                    if (result != null)
                    {
                        entity = JsonConvert.DeserializeObject<T>(result);
                        return "SUCCESS";
                    }
                    else
                    {
                        return "FAIL";
                    }
                }
            }
            catch (WebException ex)
            {
                entity = default(T);
                return "E01";
            }
            catch (Exception ex)
            {
                entity = default(T);
                return "E02";
            }
        }

        public static async Task<T> GetRequest(string url, bool isCompressed = false, string rootUrl = null)
        {

            if (rootUrl != null)
            {
                API_URL = rootUrl;
            }
            url = API_URL + url;
            try
            {
                if (isCompressed)
                {
                    using (var client = new HttpClient(new ClientCompressionHandler(new GZipCompressor(), new DeflateCompressor())))
                    {
                        //client.DefaultRequestHeaders.Add("Authorization",string.Format("Bearer {0}",accessToken));
                        client.BaseAddress = new Uri(API_URL);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                        client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var objsJsonString = await response.Content.ReadAsStringAsync();
                                var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                                return jsonContent;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                        client.BaseAddress = new Uri(API_URL);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (var response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                var objsJsonString = await response.Content.ReadAsStringAsync();
                                var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                                return jsonContent;
                            }
                            else
                            {
                                return default(T);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var x = ex;
                return default(T);
            }
        }
        public static async Task<T> DeleteRequest(string url)
        {
            url = API_URL + url;
            try
            {

                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var response = await client.DeleteAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }

            }
            catch
            {
                return default(T);
            }
        }

        public static async Task<T> PostRequest(string url, T entity, string rootUrl = null)
        {

            if (rootUrl != null)
            {
                API_URL = rootUrl;
            }
            url = API_URL + url;

            using (var client = new HttpClient(new ClientCompressionHandler(new GZipCompressor(), new DeflateCompressor())))
            {
                //client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", accessToken));
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                //client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

                using (var content = new StringContent(JsonConvert.SerializeObject(entity), UTF8Encoding.UTF8, "application/json"))
                {
                    using (var response = await client.PostAsync(url, content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);
                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
        }

    }
}