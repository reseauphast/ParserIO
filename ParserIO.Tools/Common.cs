using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ParserIO.Tools
{
    public static class Common
    {
        public class Variance
        {
            public int analyseId { get; set; }
            public string propertyName { get; set; }
            public object masterValue { get; set; }
            public object checkedValue { get; set; }
        }

        public static List<Variance> DetailedCompare<T>(this T master, T toCheck, int analyseId)
        {
            List<Variance> variances = new List<Variance>();
            PropertyInfo[] pi = master.GetType().GetProperties();
            DAO.Analyse temp = new DAO.Analyse();

            foreach (PropertyInfo f in pi)
            {
                Variance v = new Variance();
                v.analyseId = analyseId;
                v.propertyName = f.Name;
                v.masterValue = f.GetValue(master);
                v.checkedValue = f.GetValue(toCheck);
                if (!v.masterValue.Equals(v.checkedValue))
                    variances.Add(v);

            }
            return variances;
        }
        static DAO.InformationSet result = new DAO.InformationSet();
        public static DAO.InformationSet Wrapper(string code)
        {
            DAO.InformationSet temp = new DAO.InformationSet();
            RunAsync(code).Wait();
            temp = result;
            return temp;
        }

        public static async Task RunAsync(string code)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/ParserIO.WebAPI/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                string responseResult = "";

                // GetVersion
                //response = await client.GetAsync("api/ParserIO/GetVersion");
                //if (response.IsSuccessStatusCode)
                //{
                //    responseResult = await response.Content.ReadAsStringAsync();
                //    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                //    string version = JSserializer.Deserialize<string>(responseResult);
                //}

                // GetFullInformationSet
                string urlEncode = WebUtility.UrlEncode(code);
                response = await client.GetAsync("api/ParserIO/GetFullInformationSet?code=" + urlEncode);
                if (response.IsSuccessStatusCode)
                {
                    responseResult = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    result = JSserializer.Deserialize<DAO.InformationSet>(responseResult);
                }
            }
        }
    }
}
