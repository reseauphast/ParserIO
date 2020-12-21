using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.Tools.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingFolder = ConfigurationManager.AppSettings["workingFolder"];
            string fileName = workingFolder + "Barcodestore_master_20201120132923.xml";
            //FileProcess.BarcodestoreImport(fileName);
            FileProcess.BarcodestoreExport(workingFolder);
        }
    }
}
