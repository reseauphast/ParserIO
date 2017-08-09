using System.Reflection;
using System.Web.Http;
using ParserIO.DAO;

namespace ParserIO.WebAPI.Controllers
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
