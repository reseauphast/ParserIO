using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.Tools.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "D:\\ParserIO\\Barcodestore_dll_20170102050118.xml";
            //FileProcess.BarcodestoreImport(fileName);
            FileProcess.BarcodestoreExport();
        }
    }
}
