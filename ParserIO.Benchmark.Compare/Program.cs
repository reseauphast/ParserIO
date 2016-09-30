using ParserIO.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using static ParserIO.Tools.Common;

namespace ParserIO.Benchmark.Compare
{
   
    class Program
    {
        static void Main(string[] args)
        {
            string workingFolder = "C:\\ParserIO\\";
            string dateTime = DateTime.Now.ToString("yyyymmddhhmmss");

            string masterFileName = workingFolder + "Barcodestore_master_20160926155425.xml";
            string sourceFileName = workingFolder + "Barcodestore_dll_20165426035448.xml";

            string outputFileName = workingFolder + "BenchmarkCompare_" + dateTime +".txt";

            DAO.Barcodestore result = new DAO.Barcodestore();

            XmlSerializer deserializer = new XmlSerializer(typeof(DAO.Barcodestore));
            TextReader reader = new StreamReader(masterFileName);
            object obj = deserializer.Deserialize(reader);
            DAO.Barcodestore bcs = (DAO.Barcodestore)obj;
            reader.Close();

            reader = new StreamReader(sourceFileName);
            obj = deserializer.Deserialize(reader);
            DAO.Barcodestore toCompare = (DAO.Barcodestore)obj;
            reader.Close();

            StreamWriter writetext = new StreamWriter(outputFileName);
            writetext.WriteLine("ParserIO.Benchmark.Compare");
            writetext.WriteLine(DateTime.Now.ToString());
            writetext.WriteLine(masterFileName);
            writetext.WriteLine(sourceFileName);
            writetext.WriteLine("Id" + "\t" + "Property" + "\t" + "MasterValue" + "\t" + "CheckedValue");

            int analysesVarianceCount = 0;
            foreach (DAO.Analyse masterItem in bcs.Analyses)
            {
                int analyseIdMaster = masterItem.AnalyseId;

                DAO.Analyse toCompareAnalyse = (from x in toCompare.Analyses
                                                where x.AnalyseId == analyseIdMaster
                                                select x).FirstOrDefault();

                List<Variance> varianceList = new List<Variance>();

                varianceList = Common.DetailedCompare(masterItem.InformationSet, toCompareAnalyse.InformationSet, analyseIdMaster);


                if (varianceList.Count != 0)
                {
                  analysesVarianceCount++;
                  foreach(Variance var in varianceList)
                    {
                        writetext.WriteLine(var.analyseId.ToString() + "\t" + analyseIdMaster.ToString() + "\t" + var.propertyName + "\t" + var.masterValue + "\t" + var.checkedValue);
                    }
                    writetext.WriteLine("");
                }

            }

            writetext.WriteLine("MasterFile Quantity Analyses : " + bcs.Analyses.Count.ToString());
            writetext.WriteLine("Variance Quantity Analyses : " + analysesVarianceCount.ToString());
            writetext.WriteLine("End");
            writetext.Flush();
        }
    }
}