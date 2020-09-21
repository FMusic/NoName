using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManagementApp.Repo
{
    class RestCom<T, K>
    {
        public static T CommunicatePost(K obj, string url)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(obj);
            client.BaseAddress = new UriBuilder(ApiStrings.API_BASE).Uri;
            var resp = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var str = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(str);
            }
            else
            {
                throw new Exception("Status code:" + resp.StatusCode);
            }
        }
    }
    public class RestCom<T>
    {
        public static int CommunicatePost(T obj, string url)
        {
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(obj);
            client.BaseAddress = new UriBuilder(ApiStrings.API_BASE).Uri;
            var resp = client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var str = resp.Content.ReadAsStringAsync().Result;
                return int.Parse(str);
            }
            else
            {
                throw new Exception("Status code:" + resp.StatusCode);
            }
        }

        public static T CommunicateGet(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new UriBuilder(ApiStrings.API_BASE).Uri;
            var resp = client.GetAsync(url).Result;
            return JsonConvert.DeserializeObject<T>(resp.Content.ReadAsStringAsync().Result);
        }

        internal static int CommunicatePut(string url, T t)
        {
            var client = new HttpClient();
            client.BaseAddress = new UriBuilder(ApiStrings.API_BASE).Uri;
            var content = JsonConvert.SerializeObject(t);
            var resp = client.PutAsync(url, new StringContent(content, Encoding.UTF8, "application/json")).Result;
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var str = resp.Content.ReadAsStringAsync().Result;
                return int.Parse(str);
            }
            else
            {
                throw new Exception("Status code:" + resp.StatusCode);
            }
        }
    }
}
