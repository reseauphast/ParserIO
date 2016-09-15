using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string barcode = "+M150AR1588RT2E";
            Core.Functions client = new Core.Functions();
            DAO.InformationSet result = new DAO.InformationSet();
            result = client.GetFullInformationSet(barcode);
        }
    }
}
