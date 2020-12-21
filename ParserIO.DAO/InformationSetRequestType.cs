using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.DAO
{
    public class InformationSetRequestType : BasicRequestType
    {
        private string _Code = string.Empty;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }
    }
}