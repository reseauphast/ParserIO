using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ParserIO.Tools
{
    public class FileProcess
    {
        public static void BarcodestoreImport(string fileName)
        {
            StreamReader source;
            XmlDocument document;
            XmlNodeList analyses;
            source = new StreamReader(fileName, Encoding.UTF8);
            document = new XmlDocument();
            document.Load(source);

            analyses = document.GetElementsByTagName("Analyse");

            XmlSerializer deserializer = new XmlSerializer(typeof(DAO.Barcodestore));
            TextReader reader = new StreamReader(fileName);
            object obj = deserializer.Deserialize(reader);
            DAO.Barcodestore bcs = (DAO.Barcodestore)obj;
            reader.Close();

            foreach(DAO.Analyse analyse in bcs.Analyses)
            {
                ORM.Barcodestore.Save(analyse);
            }
        }

        public static void BarcodestoreExport(string workingFolder)
        {
            string StandardDateFormat14 = "yyyyMMddHHmmss";
            string outputFileName = workingFolder + "Barcodestore_master_" + DateTime.Now.ToString(StandardDateFormat14) + ".xml";

            DAO.Barcodestore result = new DAO.Barcodestore();
            
            List<DAO.Analyse> barcodeList = ORM.Barcodestore.List();

            result.ProviderName = "master";
            result.Version = DateTime.UtcNow.ToUniversalTime().ToString(StandardDateFormat14);
            result.Analyses = barcodeList;
            
            using (StreamWriter myWriter = new StreamWriter(outputFileName, false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(DAO.Barcodestore));
                
                mySerializer.Serialize(myWriter, result);
            }
        }
    }
}