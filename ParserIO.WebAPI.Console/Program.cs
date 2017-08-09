using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ParserIO.WebAPI.Console
{
    class Program
    {
        static DAO.InformationSet result = new DAO.InformationSet();
        static void Main(string[] args)
        {
            string code = "+M150AR1588RT2E";
            DAO.InformationSet temp = new DAO.InformationSet();
            temp = Tools.Common.Wrapper(code);
        }

        
    }
}
