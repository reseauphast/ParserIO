// “Copyright (C) 2009-2016 Association Réseau Phast”
// This file is part of ParserIO.
// ParserIO is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// ParserIO is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with ParserIO.  If not, see <http://www.gnu.org/licenses/>.
//
//For more information, please consult the ParserIO web site at
//<http://parserio.codeplex.com>
//
// parserio.svc.cs

// 12/18/2014 DU v 1.0.0.0
using System;
using ParserIO.Core;
using ParserIO.DAO;
using System.Net;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Configuration;

namespace ParserIO.WCF.Service
{
    public class ParserIO : IParserIO
    {
        static InformationSet result = new InformationSet();
        public InformationSet GetFullInformationSet(string code)
        {
            if (true) //WebAPI
            {
                RunAsync(code).Wait();
                
            }
            else //DLL
            {
                Functions client = new Functions();
                try
                {
                    result = client.GetFullInformationSet(code);
                }
                catch (Exception e)
                {
                    result.executeResult = -1;
                    result.AdditionalInformation = e.Message;
                }

            }
            return result;
        }

        static async Task RunAsync(string code)
        {
            using (var client = new HttpClient())
            {
                string baseAddress = ConfigurationManager.AppSettings["baseAddress"];
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                string responseResult = "";

                // GetFullInformationSet
                string urlEncode = WebUtility.UrlEncode(code);
                response = await client.GetAsync("api/ParserIO/GetFullInformationSet?code=" + urlEncode);
                if (response.IsSuccessStatusCode)
                {
                    responseResult = await response.Content.ReadAsStringAsync();
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    result = JSserializer.Deserialize<InformationSet>(responseResult);
                }
            }
        }
    }
}
