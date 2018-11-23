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
            string fileName = workingFolder + "Barcodestore_dll_20185323035342.xml";
            //FileProcess.BarcodestoreImport(fileName);
            FileProcess.BarcodestoreExport(workingFolder);
        }
    }
}
