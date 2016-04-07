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
using System.Xml;
using System.Xml.XPath;

namespace ParserIO_WSBenchmark
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
      string ACL = "";    //1
      string ADDITIONALID = "";   //2
      string BESTBEFORE = "";   //3
      string CIP = "";    //4
      string Company = "";  //5
      bool containsOrMayContainId = false;
      string CONTENT = "";  //6
      string COUNT = "";    //7
      string EAN = "";
      string Expiry = "";   //8
      string Family = "";   //9
      string GTIN = "";   //10
      string LIC = "";    //11
      string Lot = "";    //12
      string LPP = "";    //13
      string NaS7 = "";   //14
      string NormalizedBESTBEFORE = ""; //15
      string NormalizedExpiry = "";   //16
      string NormalizedPRODDATE = ""; //17
      string PCN = "";    //18
      string PRODDATE = ""; //19
      string Product = "";  //20
      string Quantity = ""; //21
      string Reference = "";  //22
      string NaSIdParamName = "";
      string Serial = "";   //23
      string SSCC = "";   //24
      string SymbologyID = "";
      string subType = "";  //25
      string type = "";   //26
      string UoM = "";    //28
      string UPN = "";
      string VARCOUNT = ""; //29
      string VARIANT = "";  //30
      string Errors = ""; 
      //ParserIO.ParserIO myRequest = new ParserIO.ParserIO();
      ParserIO_local.ParserIO_WS myRequest = new ParserIO_local.ParserIO_WS();
      string parseriowsoutput = myRequest.Parse_1(Barcode,
        out ACL,  //1
        out ADDITIONALID, //2
        out BESTBEFORE,   //3
        out CIP,    //4
        out Company,  //5
        out containsOrMayContainId,
        out CONTENT,    //6
        out COUNT,    //7
        out EAN,
        out Expiry,   //8
        out Family,   //9
        out GTIN,   //10
        out LIC,    //11
        out Lot,    //12
        out LPP,    //13
        out NaS7, //14
        out NormalizedBESTBEFORE, //15
        out NormalizedExpiry,   //16
        out NormalizedPRODDATE, //17
        out PCN,    //18
        out PRODDATE,   //19
        out Product,    //20
        out Quantity,   //21
        out Reference,  //22
        out NaSIdParamName,
        out Serial,   //23
        out SymbologyID,
        out SSCC,   //24
        out subType,  //25
        out type,   //26
        out UoM,    //28
        out UPN,
        out VARCOUNT, //29
        out VARIANT,   //30
        out Errors).ToString();
        result = "<Barcode>" + Barcode + "</Barcode>" +
               "<ACL>" + ACL + "</ACL>" +  //1
               "<ADDITIONALID>" + ADDITIONALID + "</ADDITIONALID>" +  //2
               "<BESTBEFORE>" + BESTBEFORE + "</BESTBEFORE>" +  //3
               "<CIP>" + CIP + "</CIP>" +  //4
               "<Company>" + Company + "</Company>" +  //5
               "<containsOrMayContainId>" + containsOrMayContainId + "</containsOrMayContainId>" +
               "<CONTENT>" + CONTENT + "</CONTENT>" +  //6
               "<COUNT>" + COUNT + "</COUNT>" +  //7
               "<EAN>" + EAN + "</EAN>" +
               "<Expiry>" + Expiry + "</Expiry>" +  //8
               "<Family>" + Family + "</Family>" +  //9
               "<GTIN>" + GTIN + "</GTIN>" +  //10
               "<LIC>" + LIC + "</LIC>" +  //11
               "<Lot>" + Lot + "</Lot>" +  //12
               "<LPP>" + LPP + "</LPP>" +  //13
               "<NaS7>" + NaS7 + "</NaS7>" +  //14
               "<NormalizedBESTBEFORE>" + NormalizedBESTBEFORE + "</NormalizedBESTBEFORE>" + //15
               "<NormalizedExpiry>" + NormalizedExpiry + "</NormalizedExpiry>" +  //16
               "<NormalizedPRODDATE>" + NormalizedPRODDATE + "</NormalizedPRODDATE>" +  //17
               "<PCN>" + PCN + "</PCN>" +  //18
               "<PRODDATE>" + PRODDATE + "</PRODDATE>" +  //19
               "<Product>" + Product + "</Product>" +  //20
               "<Quantity>" + Quantity + "</Quantity>" +  //21
               "<Reference>" + Reference + "</Reference>" +  //22
               "<NaSIdParamName>" + NaSIdParamName + "</NaSIdParamName>" +
               "<Serial>" + Serial + "</Serial>" +  //23
               "<SymbologyID>" + SymbologyID + "</SymbologyID>" +
               "<SSCC>" + SSCC + "</SSCC>" +  //24
               "<SubType>" + subType + "</SubType>" + //25
               "<Type>" + type + "</Type>" +  //26
               "<UoM>" + UoM + "</UoM>" +  //28
               "<UPN>" + UPN + "</UPN>" +
               "<VARCOUNT>" + VARCOUNT + "</VARCOUNT>" +  //29
               "<VARIANT>" + VARIANT + "</VARIANT>";  //30
      return result;
    }

    static void AppendBarcode(string Analyse, ref string BarcodeOut)
    {
      XmlDocument BarcodeOutXML = new XmlDocument();
      BarcodeOutXML.Load(BarcodeOut);
      XmlElement BarcodeXML = BarcodeOutXML.CreateElement("Barcode");
      BarcodeXML.InnerXml = Analyse;
      BarcodeOutXML.DocumentElement.AppendChild(BarcodeXML);
      BarcodeOutXML.Save(BarcodeOut);
    }

    static void Main(string[] args)
    {
      string Analyse;
      int count;
      string BarcodeOut = CreateFileOutput() + ".xml";
      XPathDocument BarcodestoreIn = new XPathDocument("Barcodestore.xml");
      XPathNavigator navigator = BarcodestoreIn.CreateNavigator();
      XPathNodeIterator iterator = navigator.Select(@"/Barcodestore/Barcode/Code_barres");
      count = iterator.Count;
      while (iterator.MoveNext())
      {
        Analyse = ParseBarcode(iterator.Current.Value);
        AppendBarcode(Analyse, ref BarcodeOut);
        Console.Out.WriteLine(iterator.Current.Value);
      }
      Console.WriteLine("Nombre de codes à barres analysés : " + count);
      Console.ReadLine();
    }
  }
}
