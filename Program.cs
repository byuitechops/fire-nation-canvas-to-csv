using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace learn
{
    class Program
    {
        public static async Task<string> makeHttpRequest()
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", /* API KEY */);
                    string response = await client.GetStringAsync("https://byui.instructure.com/api/v1/accounts/1/courses?by_subaccounts=25");
                    return response;
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return e.ToString();
                }
            }
        }

        static void Main(string[] args)
        {
            bool flag = true;//smelly
            string json = makeHttpRequest().Result;
            if(json[0] == '{')
                json = '[' + json + ']';//smelly

            JArray arr = JArray.Parse(json);
            //var objs = new List<JObject>{};
            //var arr2 = JObject.Parse(json);
            //JObject o = JObject.Parse(json);
            //objs.Add(o);
            using(var writer = new StreamWriter("csv.csv"))
            using(var csv = new CsvWriter(writer))
            {
            foreach(var obj in arr.Children<JObject>()) {
                var vals = obj.PropertyValues(); //smelly
                var props = obj.Properties();
                
                if(flag == true) //smelly
                {
                    foreach(var prop in props)
                    {
                        csv.WriteField(prop.Name);
                    }
                    csv.NextRecord();
                }
                foreach(var val in vals)
                {     
                    if(val.ToString() == "") csv.WriteField("null"); 
                    else if(val.GetType() == obj.GetType()) csv.WriteField("[Object]");            
                    else csv.WriteField(val.ToString());
                }
                csv.NextRecord();
                flag = false;//smelly
            }
            }

        }
    }
}
