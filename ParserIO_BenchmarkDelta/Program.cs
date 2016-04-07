// “Copyright (C) 2009-2014 Association Réseau Phast”
// This file is part of ParserIO.
// ParserIO is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// ParserIO is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with ParserIO.  If not, see <http://www.gnu.org/licenses/>.
//
//For more information, please consult the ParserIO web site at
//<http://parserio.codeplex.com>
//
// 14/09/11 Version 1.0.0.0
// 14/09/11 DU [fr] Livraison de la première version qui utilise le schéma Barcodestore.0.0.1.xsd
//             [en] First release Barcodestore.0.0.1.xsd compliant
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Microsoft.XmlDiffPatch;

namespace DeltaXML
{
    class Program
    {
        static string CreateFileOutput()
        {
            string result = "DeltaXML" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            TextWriter fileoutput = new StreamWriter(result);
            fileoutput.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            fileoutput.WriteLine("<Barcodestore xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"Barcodestore.0.0.1.xsd\" Version=\"20110825170200\">");
            fileoutput.WriteLine("</Barcodestore>");
            fileoutput.Close();
            return result;
        }

        static void AppendBarcode(string element, ref string BarcodeOut)
        {
            XmlDocument BarcodeOutXML = new XmlDocument();
            BarcodeOutXML.Load(BarcodeOut);
            XmlElement BarcodeXML = BarcodeOutXML.CreateElement("Analyse");
            BarcodeXML.InnerXml = element;
            BarcodeOutXML.DocumentElement.AppendChild(BarcodeXML);
            BarcodeOutXML.Save(BarcodeOut);
        }

        static void Main(string[] args)
        {
            //XPathDocument Barcodestore = new XPathDocument("Barcodestore.xml");
            //XPathNavigator BarcodetoreNavigator = Barcodestore.CreateNavigator();
            //XPathNodeIterator BarcodetoreIterator = BarcodetoreNavigator.Select(@"/Barcodestore/Analyse");
            //int count1 = BarcodetoreIterator.Count;

            //XPathDocument ParserIO_functions_Out = new XPathDocument("20160401161134.xml");
            //XPathNavigator ParserIO_functions_OutNavigator = ParserIO_functions_Out.CreateNavigator();
            //XPathNodeIterator ParserIO_functions_OutIterator = ParserIO_functions_OutNavigator.Select(@"/Barcodestore/Analyse");
            //float count2 = ParserIO_functions_OutIterator.Count;

            //string BarcodeOut = CreateFileOutput();

            //XPathDocument BarcodestoreDelta = new XPathDocument(BarcodeOut);
            //XPathNavigator BarcodestoreDeltaNavigator = BarcodestoreDelta.CreateNavigator();

            //string elem1;
            //string elem2;
            //float countDelta = 0;
            //while (BarcodetoreIterator.MoveNext())
            //{
            //    ParserIO_functions_OutIterator.MoveNext();
            //    elem1 = BarcodetoreIterator.Current.InnerXml;
            //    elem2 = ParserIO_functions_OutIterator.Current.InnerXml;


            //    if (elem1 != elem2)
            //    {
            //        Console.WriteLine(elem1, elem2);
            //        AppendBarcode(elem2, ref BarcodeOut);
            //        // Console.ReadLine();
            //        countDelta++;
            //    }
            //}

            XmlDocument doc = new XmlDocument();
            doc.Load("Barcodestore.xml");
            XmlNodeList nodes = doc.SelectNodes("//Barcode_withoutGS");
            for (int i = nodes.Count - 1; i >= 0; i--)
            {
                nodes[i].ParentNode.RemoveChild(nodes[i]);
            }
            doc.Save("Barcodestore.xml");

            //float taux = (countDelta / count2) * 100;
            //Console.WriteLine();
            //Console.WriteLine("count1: " + count1);
            //Console.WriteLine("count2: " + count2);
            //Console.WriteLine("countDelta: " + countDelta);
            //Console.WriteLine("taux: " + taux);
            Console.ReadLine();
        }
    }
}
