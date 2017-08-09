using ParserIO.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace ParserIO.WebAPI.Service.Controllers
{
    public class ParserIOController : ApiController
    {
        public string GetVersion()
        {
            string result = "";
            result = Assembly.Load("ParserIO.Core").GetName().Version.ToString();
            return result;
        }
        public InformationSet GetFullInformationSet(string code)
        {
            InformationSet result = new InformationSet();
            Core.Functions client = new Core.Functions();
            result = client.GetFullInformationSet(code);
            return result;
        }
    }
}
