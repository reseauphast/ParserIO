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
            string barcode = "";

            barcode = "]C0+ENOU60229/$$900001250128G004114M";

            Core.Functions client = new Core.Functions();
            DAO.InformationSet result;
            result = client.GetFullInformationSet(barcode);
        }
    }
}
