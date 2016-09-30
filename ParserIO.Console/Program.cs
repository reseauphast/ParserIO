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

            barcode = "+J123AQ3451/$$3231231BC34567/S4012R";

            Core.Functions client = new Core.Functions();
            DAO.InformationSet result;
            result = client.GetFullInformationSet(barcode);
        }
    }
}
