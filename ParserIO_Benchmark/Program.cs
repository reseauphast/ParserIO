// “Copyright (C) 2009-2011 Association Réseau Phast”
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
// 14/09/11 Version 0.1
// 14/09/11 DU [fr] Livraison de la première version qui utilise le ParserIO 0.28 et le schéma Barcodestore.0.0.1.xsd
//             [en] First release ParserIO 0.28 and Barcodestore.0.0.1.xsd compliant
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ParserIO_functions;
using System.Xml;
using System.Xml.XPath;

namespace ParserIO_Benchmark
{
  class Program
  {
    static string CreateFileOutput()
    {
      string result = DateTime.Now.ToString("yyyyMMddHHmmss");
      TextWriter fileoutput = new StreamWriter(result + ".xml");
      fileoutput.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");   
      fileoutput.WriteLine("<Barcodestore xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"Barcodestore.0.0.1.xsd\" Version=\"20110825170200\">");
      fileoutput.WriteLine("</Barcodestore>");
      fileoutput.Close();
      return result;
    }

    static string ParseBarcode(string Barcode)
    {
      string result = "";
      ParserIO_functions.ParserIO_func Parser = new ParserIO_functions.ParserIO_func();
      string type = Parser.Type(Barcode);
      string subType = Parser.SubType(Barcode);
      string ACL = Parser.ACL(Barcode, type, subType);
      string ADDITIONALID = Parser.ADDITIONALID(Barcode, type, subType);
      string BESTBEFORE = Parser.BESTBEFORE(Barcode, type, subType);
      string CIP = Parser.CIP(Barcode, type, subType);
      string Company = Parser.Company(Barcode, type, subType);
      bool containsOrMayContainId = Parser.containsOrMayContainId(Barcode, type, subType);
      string CONTENT = Parser.CONTENT(Barcode, type, subType);
      string COUNT = Parser.COUNT(Barcode, type, subType);
      string EAN = Parser.EAN(Barcode, type, subType);
      string Expiry = Parser.Expiry(Barcode, type, subType);
      string Family = Parser.Family(Barcode, type, subType);
      string GTIN = Parser.GTIN(Barcode, type, subType);
      string LIC = Parser.LIC(Barcode, type, subType);
      string Lot = Parser.Lot(Barcode, type, subType);
      string LPP = Parser.LPP(Barcode, type, subType);
      string NaS7 = Parser.NaS7(Barcode, type, subType);
      string NormalizedBESTBEFORE = Parser.NormalizedBESTBEFORE(Barcode, type, subType);
      string NormalizedExpiry = Parser.NormalizedExpiry(Barcode, type, subType);
      string NormalizedPRODDATE = Parser.NormalizedPRODDATE(Barcode, type, subType);
      string PCN = Parser.PCN(Barcode, type, subType);
      string PRODDATE = Parser.PRODDATE(Barcode, type, subType);
      string Product = Parser.Product(Barcode, type, subType);
      string Quantity = Parser.Quantity(Barcode, type, subType);
      string Reference = Parser.Reference(Barcode, type, subType);
      string NaSIdParamName = Parser.NaSIdParamName(type, subType);
      string Serial = Parser.Serial(Barcode, type, subType);
      string SymbologyID = Parser.SymbologyID(Barcode);
      string SSCC = Parser.SSCC(Barcode, type, subType);
      string UDI = Parser.UDI(Barcode, type, subType);
      string UoM = Parser.UoM(Barcode, type, subType);
      string UPN = Parser.UPN(Barcode, type, subType);
      string VARCOUNT = Parser.VARCOUNT(Barcode, type, subType);
      string VARIANT = Parser.VARIANT(Barcode, type, subType);
      result = //"<Barcode_withoutGS>" + Barcode + "</Barcode_withoutGS>" +
               "<Barcode_withGS>" + Barcode + "</Barcode_withGS>" +
               "<ACL>" + ACL + "</ACL>" +  //1
               "<ADDITIONALID>" + ADDITIONALID + "</ADDITIONALID>" +  //2
               "<BESTBEFORE>" + BESTBEFORE + "</BESTBEFORE>" +  //3
               "<CIP>" + CIP + "</CIP>" +  //3
               "<Company>" + Company + "</Company>" +  //4
               "<containsOrMayContainId>" + Convert.ToInt32(containsOrMayContainId) + "</containsOrMayContainId>" +
               "<CONTENT>" + CONTENT + "</CONTENT>" +  //5
               "<COUNT>" + COUNT + "</COUNT>" +  //6
               "<EAN>" + EAN + "</EAN>" +
               "<Expiry>" + Expiry + "</Expiry>" +  //7
               "<Family>" + Family + "</Family>" +  //8
               "<GTIN>" + GTIN + "</GTIN>" +  //9
               "<LIC>" + LIC + "</LIC>" +  //10
               "<Lot>" + Lot + "</Lot>" +  //11
               "<LPP>" + LPP + "</LPP>" +  //12
               "<NaS7>" + NaS7 + "</NaS7>" +  //13
               "<NaSIdParamName>" + NaSIdParamName + "</NaSIdParamName>" +
               "<NormalizedBESTBEFORE>" + NormalizedBESTBEFORE + "</NormalizedBESTBEFORE>" + //14
               "<NormalizedExpiry>" + NormalizedExpiry + "</NormalizedExpiry>" +  //15
               "<NormalizedPRODDATE>" + NormalizedPRODDATE + "</NormalizedPRODDATE>" +  //16
               "<PCN>" + PCN + "</PCN>" +  //17
               "<PRODDATE>" + PRODDATE + "</PRODDATE>" +  //18
               "<Product>" + Product + "</Product>" +  //19
               "<Quantity>" + Quantity + "</Quantity>" +  //20
               "<Reference>" + Reference + "</Reference>" +  //21
               "<Serial>" + Serial + "</Serial>" +  //22
               "<SSCC>" + SSCC + "</SSCC>" +  //23
               "<SymbologyID>" + SymbologyID + "</SymbologyID>" +  //23
               "<SubType>" + subType + "</SubType>" + //29
               "<Type>" + type + "</Type>" +  //24
               "<UDI>" + UDI + "</UDI>" +
               "<UoM>" + UoM + "</UoM>" +  //26
               "<UPN>" + UPN+ "</UPN>" +
               "<VARCOUNT>" + VARCOUNT + "</VARCOUNT>" +  //27
               "<VARIANT>" + VARIANT + "</VARIANT>" +  //28
               "<Commentary>" + "</Commentary>";
      return result;
    }

    static void AppendBarcode(string Analyse, ref string BarcodeOut)
    {
      XmlDocument BarcodeOutXML = new XmlDocument();
      BarcodeOutXML.Load(BarcodeOut);
      XmlElement BarcodeXML = BarcodeOutXML.CreateElement("Analyse");
      BarcodeXML.InnerXml = Analyse;
      BarcodeOutXML.DocumentElement.AppendChild(BarcodeXML);
      BarcodeOutXML.Save(BarcodeOut);
    }

    static void Main(string[] args)
    {
      string Analyse;
      int count;
      string BarcodeOut = CreateFileOutput() + ".xml";
      //XmlReader reader = XmlReader.Create("Barcodestore.xml");
      //XPathDocument BarcodestoreIn = new XPathDocument(reader);
      //XmlTextReader reader = new XmlTextReader("Barcodestore.xml");

      XPathDocument BarcodestoreIn = new XPathDocument(@"C:\\vso\\ParserIO\\ParserIO_Benchmark\\Barcodestore.xml");
      XPathNavigator navigator = BarcodestoreIn.CreateNavigator();
      XPathNodeIterator iterator = navigator.Select(@"/Barcodestore/Analyse/Barcode_withGS");
      count = iterator.Count;
      while (iterator.MoveNext())
      {
                try
                {
                    Analyse = ParseBarcode(iterator.Current.Value);
                    AppendBarcode(Analyse, ref BarcodeOut);
                    Console.Out.WriteLine(iterator.Current.Value);
                }
                catch (Exception e)
                {

                }
        
      }
      Console.WriteLine("Nombre de codes à barres analysés : " + count);
      Console.ReadLine();
    }
  }
}
