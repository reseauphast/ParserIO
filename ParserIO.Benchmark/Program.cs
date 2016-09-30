using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ParserIO.Benchmark
{
    class Program
    {
        enum Provider
        {
            dll,   //ParserIO.Core
            ws,    //ParserIO.WS
            wcf,   //ParserIO.WCF
            webapi, //ParserIO.WebAPI
            fdagudid // FDA GUDID Parser
        }


        static void Main(string[] args)
        {

            Provider value = Provider.dll;
            string workingFolder = "C:\\ParserIO\\";
            string sourceFileName = workingFolder + "Barcodestore_master_20160926155425.xml";

            string outputFileName = workingFolder + "Barcodestore_" + value + "_"+ DateTime.Now.ToString("yyyymmddhhmmss") + ".xml";

            StreamReader source;
            XmlDocument document;
            XmlNodeList analyses;
            source = new StreamReader(sourceFileName, Encoding.UTF8);
            document = new XmlDocument();
            document.Load(source);

            DAO.Barcodestore bcs = new DAO.Barcodestore();
            bcs.Version = DateTime.Now.ToString("yyyymmddhhmm");
            bcs.ProviderName = value.ToString();
            bcs.Analyses = new List<DAO.Analyse>();
            
            analyses = document.GetElementsByTagName("Analyse");

            foreach (XmlElement sourceAnalyse in analyses)
            {
                DAO.Analyse x = new DAO.Analyse();
                DAO.InformationSet targetAnalyse = new DAO.InformationSet();
                x.AnalyseId = Convert.ToInt32(sourceAnalyse.GetElementsByTagName("AnalyseId")[0].InnerText);
                x.TimeStamp = Convert.ToDateTime(sourceAnalyse.GetElementsByTagName("TimeStamp")[0].InnerText);
                x.Barcode = sourceAnalyse.GetElementsByTagName("Barcode")[0].InnerText;
                x.Commentary = sourceAnalyse.GetElementsByTagName("Commentary")[0].InnerText;
                
                if (value == Provider.dll)
                {
                    Core.Functions client = new Core.Functions();
                    targetAnalyse = client.GetFullInformationSet(x.Barcode);
                }
                else if (value==Provider.ws)
                {
                    //todo
                }
                else if (value == Provider.wcf)
                {
                    //todo
                }
                else if (value == Provider.webapi)
                {
                    targetAnalyse = Tools.Common.Wrapper(x.Barcode);
                }
                else if (value == Provider.fdagudid)
                {
                    //todo
                }

                x.InformationSet.Type = targetAnalyse.Type;
                x.InformationSet.SubType = targetAnalyse.SubType;
                x.InformationSet.executeResult = targetAnalyse.executeResult;
                x.InformationSet.ACL = targetAnalyse.ACL;
                x.InformationSet.ADDITIONALID = targetAnalyse.ADDITIONALID;
                x.InformationSet.BESTBEFORE = targetAnalyse.BESTBEFORE;
                x.InformationSet.CIP = targetAnalyse.CIP;
                x.InformationSet.Company = targetAnalyse.Company;
                x.InformationSet.ContainsOrMayContainId = targetAnalyse.ContainsOrMayContainId;
                x.InformationSet.CONTENT = targetAnalyse.CONTENT;
                x.InformationSet.COUNT = targetAnalyse.COUNT;
                x.InformationSet.EAN = targetAnalyse.EAN;
                x.InformationSet.Expiry = targetAnalyse.Expiry;
                x.InformationSet.Family = targetAnalyse.Family;
                x.InformationSet.GTIN = targetAnalyse.GTIN;
                x.InformationSet.INTERNAL_91 = targetAnalyse.INTERNAL_91;
                x.InformationSet.INTERNAL_92 = targetAnalyse.INTERNAL_92;
                x.InformationSet.INTERNAL_93 = targetAnalyse.INTERNAL_93;
                x.InformationSet.INTERNAL_94 = targetAnalyse.INTERNAL_94;
                x.InformationSet.INTERNAL_95 = targetAnalyse.INTERNAL_95;
                x.InformationSet.INTERNAL_96 = targetAnalyse.INTERNAL_96;
                x.InformationSet.INTERNAL_97 = targetAnalyse.INTERNAL_97;
                x.InformationSet.INTERNAL_98 = targetAnalyse.INTERNAL_98;
                x.InformationSet.INTERNAL_99 = targetAnalyse.INTERNAL_99;
                x.InformationSet.LIC = targetAnalyse.LIC;
                x.InformationSet.Lot = targetAnalyse.Lot;
                x.InformationSet.LPP = targetAnalyse.LPP;
                x.InformationSet.NaS7 = targetAnalyse.NaS7;
                x.InformationSet.NaSIdParamName = targetAnalyse.NaSIdParamName;
                x.InformationSet.NormalizedBESTBEFORE = targetAnalyse.NormalizedBESTBEFORE;
                x.InformationSet.NormalizedExpiry = targetAnalyse.NormalizedExpiry;
                x.InformationSet.NormalizedPRODDATE = targetAnalyse.NormalizedPRODDATE;
                x.InformationSet.PCN = targetAnalyse.PCN;
                x.InformationSet.PRODDATE = targetAnalyse.PRODDATE;
                x.InformationSet.Product = targetAnalyse.Product;
                x.InformationSet.Quantity = targetAnalyse.Quantity;
                x.InformationSet.Reference = targetAnalyse.Reference;
                x.InformationSet.Serial = targetAnalyse.Serial;
                x.InformationSet.SSCC = targetAnalyse.SSCC;
                x.InformationSet.SymbologyID = targetAnalyse.SymbologyID;
                x.InformationSet.UDI = targetAnalyse.UDI;
                x.InformationSet.UoM = targetAnalyse.UoM;
                x.InformationSet.UPN = targetAnalyse.UPN;
                x.InformationSet.VARCOUNT = targetAnalyse.VARCOUNT;
                x.InformationSet.VARIANT = targetAnalyse.VARIANT;
                x.InformationSet.AdditionalInformation = targetAnalyse.AdditionalInformation;

                bcs.Analyses.Add(x);
                Console.WriteLine(x.AnalyseId);
            }

            
            using (StreamWriter myWriter = new StreamWriter(outputFileName, false))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(DAO.Barcodestore), new XmlRootAttribute("Barcodestore"));
                mySerializer.Serialize(myWriter, bcs);
            }

        }
    }
}
