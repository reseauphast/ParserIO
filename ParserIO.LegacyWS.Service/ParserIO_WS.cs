// “Copyright (C) 2009-2016 Association Réseau Phast”
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
// ParserIO_WS.cs (ParserIO_WS.ParserIO_WS)

// 18/10/10 NC First draft
// 01/04/11 DU Rename description from Parser to ParserIO
//
// 13/04/11 Version 0.25
//             [fr] Ajouté la WebMethod Parse_22
//             [en] Added the WebMethod Parse_22
// 22/09/11 Version 0.28
//             [fr] Ajouté la WebMethod Parse_30
//             [en] Added the WebMethod Parse_30
//
// 26-08-2013 Version 1.0.0.0
//               [fr] Ajouté la WebMethod Parse_32
//               [en] Added the WebMethod Parse_32
// 26-02-2014 Version 1.0.0.1
//               [fr] Voir librarie fonctions
//               [en] Loot at functions library
// 12-11-2014 Version 1.0.0.4
// 12-11-2014    [fr] Ajouté UPN
//               [en] Added UPN
// 12-11-2014    [fr] Ajouté EAN
//               [en] Added EAN
// 12-11-2014    [fr] Ajouté SymbologyID
//               [en] Added SymbologyID
// 12-15-2014    [fr] Ajouté returnNaSIdParamName
//               [en] Added returnNaSIdParamName
// 11-16-2015    [fr] Ajouté UDI
//               [en] Added UDI method


using System;
using System.Web.Services;
using System.Reflection;
using ParserIO.DAO;

namespace ParserIO.LegacyWS.Service
{


    [WebService(Namespace = "urn:Phast/ParserIO", Description = "ParserIO")]
    public class ParserIO_WS : WebService
    {
        public ParserIO_WS()
        {
            //CODEGEN: This call is required by the ASP.NET Web Services Designer
            InitializeComponent();
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>

        protected override void Dispose(bool disposing)
        {
        }

        [WebMethod(Description = "Returns ParserIO Core Version")]
        public string GetVersion()
        {
            string result="";
            if (false) //WebAPI
            {
                // To do : problème
            }
            else //DLL
            {
                result = Assembly.Load("ParserIO.Core").GetName().Version.ToString();
            }
            return result;
        }

        [WebMethod(Description = "Takes a barcode value as input and returns a full set of information as object")]
        public InformationSet GetFullInformationSet(string code)
        {
            InformationSet result = new InformationSet();
            if (false) //WebAPI
            {
                // To do : problème
            }
            else //DLL
            {
                Core.Functions client = new Core.Functions();
                result = client.GetFullInformationSet(code);
            }
            return result;
        }

        [WebMethod(Description = "Takes a barcode value as input and returns a full set of information")]
        public int Parse_1(string Barcode,
          out string ACL,   //1
          out string ADDITIONALID,  //2
          out string BESTBEFORE,    //3
          out string CIP,   //4
          out string Company,   //5
          out bool containsOrMayContainId,
          out string CONTENT,   //6
          out string COUNT,   //7
          out string EAN,
          out string Expiry,    //8
          out string Family,    //9
          out string GTIN,    //10
          out string LIC,   //11
          out string Lot,   //12
          out string LPP,   //13
          out string NaS7,  //14
          out string NormalizedBESTBEFORE,    //15
          out string NormalizedExpiry,    //16
          out string NormalizedPRODDATE,   //17
          out string PCN,       //18
          out string PRODDATE,  //19
          out string Product,   //20
          out string Quantity,  //21
          out string Reference, //22
          out string NaSIdParamName,
          out string Serial,    //23
          out string SSCC,      //24
          out string SubType,   //25
          out string SymbologyID,
          out string Type,      //26
          out string UDI,
          out string UoM,       //28
          out string UPN,
          out string VARCOUNT,  //29
          out string VARIANT,   //30
          out string Errors)
        {
            int executeResult = 0;
            ACL = "";   //1
            ADDITIONALID = "";    //2
            BESTBEFORE = "";    //3
            CIP = "";   //4
            Company = "";   //5
            containsOrMayContainId = false; //31
            CONTENT = "";   //6
            COUNT = "";   //7
            EAN = "";
            Expiry = "";    //8
            Family = "";    //9
            GTIN = "";    //10
            LIC = "";   //11
            Lot = "";   //12
            LPP = "";   //13
            NaS7 = "";    //14
            NormalizedBESTBEFORE = "";  //15
            NormalizedExpiry = "";    //16
            NormalizedPRODDATE = "";  //17
            PCN = "";   //18
            PRODDATE = "";  //19
            Product = "";   //20
            Quantity = "";   //21
            Reference = "";   //22
            NaSIdParamName = "";
            Serial = "";    //23
            SSCC = "";    //24
            SubType = ""; //25
            SymbologyID = "";
            Type = "";    //26
            UDI = "";
            UoM = "";   //28
            UPN = "";
            VARCOUNT = "";  //29
            VARIANT = ""; //30
            Errors = "";
            try
            {
                InformationSet result = new InformationSet();
                Core.Functions client = new Core.Functions();
                result = client.GetFullInformationSet(Barcode);
                executeResult = result.executeResult;
                Type = result.Type;
                SubType = result.SubType;
                ACL = result.ACL;
                ADDITIONALID = result.ADDITIONALID;
                BESTBEFORE = result.BESTBEFORE;
                CIP = result.CIP;    //4
                Company = ""; // result.Company;  //5 Obsolete
                containsOrMayContainId = result.ContainsOrMayContainId;
                CONTENT = result.CONTENT;   //6
                COUNT = result.COUNT;    //7
                EAN = result.EAN;
                Expiry = result.Expiry;  //8
                Family = result.Family;   //9
                GTIN = result.GTIN;    //10
                LIC = result.LIC;    //11
                Lot = result.Lot;    //12
                LPP = result.LPP;    //13
                NaS7 = result.NaS7;  //14
                NormalizedBESTBEFORE = result.NormalizedBESTBEFORE;  //15
                NormalizedExpiry = result.NormalizedExpiry;  //16
                NormalizedPRODDATE = result.NormalizedPRODDATE;  //17
                PCN = result.PCN;    //18
                PRODDATE = result.PRODDATE;    //19
                Product = ""; // result.Product;  //20 //Obsolete
                Quantity = result.Quantity;  //21
                Reference = result.Reference;  //22
                NaSIdParamName = result.NaSIdParamName;
                Serial = result.Serial;  //23
                SSCC = result.SSCC;    //24
                SymbologyID = result.SymbologyID;
                UDI = result.UDI;
                UoM = result.UoM;    //28
                UPN = result.UPN;
                VARCOUNT = result.VARCOUNT;  //29
                VARIANT = result.VARIANT;    //30
                Errors = result.AdditionalInformation;
            }
            catch (Exception e)
            {
                Errors = Errors + e.Message;
            }
            return executeResult;
        }
    }
}
