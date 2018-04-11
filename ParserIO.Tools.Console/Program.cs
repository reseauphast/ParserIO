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
            string fileName = "D:\\ParserIO\\Barcodestore_master_20180410170614.xml";
            //FileProcess.BarcodestoreImport(fileName);
            FileProcess.BarcodestoreExport();
        }
    }
}
