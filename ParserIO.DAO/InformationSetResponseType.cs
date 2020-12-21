using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.DAO
{
    public class InformationSetResponseType : BasicResponseType
    {
        private string _ParserIOVersion = string.Empty;
        //public string ParserIOVersion
        //{
        //    get { return _ParserIOVersion; }
        //    set { _ParserIOVersion = value; }
        //}

        public InformationSet InformationSet = new InformationSet();

        public InformationSetResponseType(InformationSetRequestType Request)
        {
            //ParserIOVersion = Assembly.Load("ParserIO.Core").GetName().Version.ToString();
        }

        public InformationSetResponseType()
        {
            
        }
    }
}