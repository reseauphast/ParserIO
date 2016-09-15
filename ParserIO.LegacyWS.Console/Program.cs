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
// 22/09/11 Version 0.2
// 22/09/11 DU [fr] ParserIO_functions 0.28 compliant
//             [en] ParserIO_functions 0.28 compliant
using ParserIO.DAO;

namespace ParserIO.LegacyWS.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "";
            string ACL = "";
            string ADDITIONALID = "";
            string BESTBEFORE = "";
            string CIP = "";
            string Company = "";
            bool containsOrMayContainId = false;
            string CONTENT = "";
            string COUNT = "";
            string EAN = "";
            string Expiry = "";
            string Family = "";
            string GTIN = "";
            string LIC = "";
            string Lot = "";
            string LPP = "";
            string NaS7 = "";
            string NormalizedBESTBEFORE = "";
            string NormalizedExpiry = "";
            string NormalizedPRODDATE = "";
            string PCN = "";
            string PRODDATE = "";
            string Product = "";
            string Quantity = "";
            string Reference = "";
            string NaSIdParamName = "";
            string Serial = "";
            string SSCC = "";
            string subType = "";
            string SymbologyID = "";
            string type = "";
            string UDI = "";
            string UoM = "";
            string UPN = "";
            string VARCOUNT = "";
            string VARIANT = "";
            string Errors = "";
            System.Console.WriteLine("ParserIO - Client d'exemple \n");
            System.Console.WriteLine("Fournir un code à barres");
            code = "1234"; // System.Console.ReadLine();

            parserioWS.ParserIO_WS client = new parserioWS.ParserIO_WS();

            
            

            var result =  client.GetFullInformationSet(code);
           

            //int parseriowsoutput = myRequest.Parse_1(code,
            //        out ACL,    //1
            //        out ADDITIONALID, //2
            //        out BESTBEFORE,   //3
            //        out CIP,    //4
            //        out Company,  //5
            //        out containsOrMayContainId,
            //        out CONTENT,  //6
            //        out COUNT,    //7
            //        out EAN,
            //        out Expiry,   //8
            //        out Family,   //9
            //        out GTIN,   //10
            //        out LIC,    //11
            //        out Lot,   //12
            //        out LPP,    //13
            //        out NaS7,   //14
            //        out NormalizedBESTBEFORE, //15
            //        out NormalizedExpiry, //16
            //        out NormalizedPRODDATE, //17
            //        out PCN,  //18
            //        out PRODDATE, //19
            //        out Product,  //20
            //        out Quantity, //21
            //        out Reference,  //22
            //        out NaSIdParamName,
            //        out Serial, //23
            //        out SSCC, //24
            //        out subType,  //25
            //        out SymbologyID,
            //        out type,   //26
            //        out UDI,
            //        out UoM,   //28
            //        out UPN,
            //        out VARCOUNT,   //29
            //        out VARIANT,    //30
            //        out Errors);

            //System.Console.WriteLine("ACL : {0}", ACL);
            //System.Console.WriteLine("ADDITIONALID : {0}", ADDITIONALID);
            //System.Console.WriteLine("BESTBEFORE : {0}", BESTBEFORE);
            //System.Console.WriteLine("CIP : {0}", CIP);
            //System.Console.WriteLine("containsOrMayContainId : {0}", containsOrMayContainId);
            //System.Console.WriteLine("CONTENT : {0}", CONTENT);
            //System.Console.WriteLine("COUNT : {0}", COUNT);
            //System.Console.WriteLine("EAN : {0}", EAN);
            //System.Console.WriteLine("Entreprise : {0}", Company);
            //System.Console.WriteLine("Expiry : {0}", Expiry);
            //System.Console.WriteLine("Family : {0}", Family);
            //System.Console.WriteLine("GTIN : {0}", GTIN);
            //System.Console.WriteLine("LIC : {0}", LIC);
            //System.Console.WriteLine("Lot : {0}", Lot);
            //System.Console.WriteLine("LPP : {0}", LPP);
            //System.Console.WriteLine("NaS7 : {0}", NaS7);
            //System.Console.WriteLine("NormalizedBESTBEFORE : {0}", NormalizedBESTBEFORE);
            //System.Console.WriteLine("NormalizedExpiry : {0}", NormalizedExpiry);
            //System.Console.WriteLine("NormalizedPRODDATE : {0}", NormalizedPRODDATE);
            //System.Console.WriteLine("PCN : {0}", PCN);
            //System.Console.WriteLine("PRODDATE : {0}", PRODDATE);
            //System.Console.WriteLine("Produit : {0}", Product);
            //System.Console.WriteLine("Quantite : {0}", Quantity);
            //System.Console.WriteLine("Reference : {0}", Reference);
            //System.Console.WriteLine("NaSIdParamName : {0}", NaSIdParamName);
            //System.Console.WriteLine("Serial : {0}", Serial);
            //System.Console.WriteLine("SSCC : {0}", SSCC);
            //System.Console.WriteLine("SymbologyID : {0}", SymbologyID);
            //System.Console.WriteLine("SubType : {0}", subType);
            //System.Console.WriteLine("Type : {0}", type);
            //System.Console.WriteLine("UoM : {0}", UoM);
            //System.Console.WriteLine("UPN : {0}", UPN);
            //System.Console.WriteLine("VARCOUNT : {0}", VARCOUNT);
            //System.Console.WriteLine("VARIANT : {0}", VARIANT);
            //System.Console.WriteLine("Errors : {0}", Errors);
            //System.Console.ReadLine();
        }
    }
}