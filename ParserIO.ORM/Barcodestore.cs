using ParserIO.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.ORM
{
    public class Barcodestore
    {
        public static int Save(DAO.Analyse analyse)
        {
            int executeResult = 0;
            executeResult = DAL.Barcodestore.P_Barcode_Upsert(analyse.AnalyseId,
                                                              analyse.TimeStamp,
                                                              analyse.Barcode,
                                                              analyse.InformationSet.ParserIOVersion,
                                                              analyse.InformationSet.InputCode,
                                                              analyse.InformationSet.SymbologyID,
                                                              analyse.InformationSet.SymbologyIDDesignation,
                                                              analyse.InformationSet.Type,
                                                              analyse.InformationSet.SubType,
                                                              analyse.InformationSet.NaSIdParamName,
                                                              analyse.InformationSet.ContainsOrMayContainId,
                                                              analyse.InformationSet.Identifiers,
                                                              analyse.InformationSet.ACL,
                                                              analyse.InformationSet.ADDITIONALID,
                                                              analyse.InformationSet.BESTBEFORE,
                                                              analyse.InformationSet.CIP,
                                                              analyse.InformationSet.CONTENT,
                                                              analyse.InformationSet.COUNT,
                                                              analyse.InformationSet.CUSTPARTNO,
                                                              analyse.InformationSet.EAN,
                                                              analyse.InformationSet.Expiry,
                                                              analyse.InformationSet.Family,
                                                              analyse.InformationSet.GTIN,
                                                              analyse.InformationSet.INTERNAL_90,
                                                              analyse.InformationSet.INTERNAL_91,
                                                              analyse.InformationSet.INTERNAL_92,
                                                              analyse.InformationSet.INTERNAL_93,
                                                              analyse.InformationSet.INTERNAL_94,
                                                              analyse.InformationSet.INTERNAL_95,
                                                              analyse.InformationSet.INTERNAL_96,
                                                              analyse.InformationSet.INTERNAL_97,
                                                              analyse.InformationSet.INTERNAL_98,
                                                              analyse.InformationSet.INTERNAL_99,
                                                              analyse.InformationSet.LIC,
                                                              analyse.InformationSet.Lot,
                                                              analyse.InformationSet.LPP,
                                                              analyse.InformationSet.NaS7,
                                                              analyse.InformationSet.NormalizedBESTBEFORE,
                                                              analyse.InformationSet.NormalizedExpiry,
                                                              analyse.InformationSet.NormalizedPRODDATE,
                                                              analyse.InformationSet.PCN,
                                                              analyse.InformationSet.PRODDATE,
                                                              analyse.InformationSet.Quantity,
                                                              analyse.InformationSet.Reference,
                                                              analyse.InformationSet.Serial,
                                                              analyse.InformationSet.SSCC,
                                                              analyse.InformationSet.StorageLocation,
                                                              analyse.InformationSet.UDI,
                                                              analyse.InformationSet.UDI_DI,
                                                              analyse.InformationSet.Issuer,
                                                              analyse.InformationSet.UoM,
                                                              analyse.InformationSet.UPN,
                                                              analyse.InformationSet.VARCOUNT,
                                                              analyse.InformationSet.VARIANT,
                                                              analyse.InformationSet.AdditionalInformation,
                                                              analyse.Commentary);
            return executeResult;
        }


        public static List<DAO.Analyse> List()
        {
            List<DAO.Analyse> result = new List<DAO.Analyse>();

            DataSet dsResult = new DataSet();
            dsResult = DAL.Barcodestore.P_Barcode_List();
            DataTable dtResult = new DataTable();
            dtResult = dsResult.Tables[0];

            foreach (DataRow dr in dtResult.Rows)
            {
                DAO.Analyse item = new DAO.Analyse();
                item.AnalyseId = Convert.ToInt32(dr["AnalyseId"]);
                item.TimeStamp = Convert.ToDateTime(dr["TimeStamp"]);
                item.InformationSet.ParserIOVersion = dr["ParserIOVersion"].ToString();
                item.Barcode = dr["Barcode"].ToString();
                item.Commentary = dr["Commentary"].ToString();
                item.InformationSet.InputCode = dr["InputCode"].ToString();
                item.InformationSet.SymbologyID = dr["SymbologyID"].ToString();
                item.InformationSet.SymbologyIDDesignation = dr["SymbologyIDDesignation"].ToString();
                item.InformationSet.Type = dr["Type"].ToString();
                item.InformationSet.SubType = dr["SubType"].ToString();
                item.InformationSet.ContainsOrMayContainId = Convert.ToBoolean(Convert.ToInt32(dr["containsOrMayContainId"])); // Convert.ToBoolean(Convert.ToInt32("1")); //
                item.InformationSet.ACL = dr["ACL"].ToString();
                item.InformationSet.ADDITIONALID = dr["ADDITIONALID"].ToString();
                item.InformationSet.BESTBEFORE = dr["BESTBEFORE"].ToString();
                item.InformationSet.CIP = dr["CIP"].ToString();
                item.InformationSet.Company = ""; // dr["Company"].ToString(); //Obsolete
                item.InformationSet.CONTENT = dr["CONTENT"].ToString();
                item.InformationSet.COUNT = dr["COUNT"].ToString();
                item.InformationSet.CUSTPARTNO = dr["CUSTPARTNO"].ToString();
                item.InformationSet.EAN = dr["EAN"].ToString();
                item.InformationSet.Expiry = dr["Expiry"].ToString();
                item.InformationSet.Family = dr["Family"].ToString();
                item.InformationSet.GTIN = dr["GTIN"].ToString();
                item.InformationSet.INTERNAL_90 = dr["INTERNAL_90"].ToString();
                item.InformationSet.INTERNAL_91 = dr["INTERNAL_91"].ToString();
                item.InformationSet.INTERNAL_92 = dr["INTERNAL_92"].ToString();
                item.InformationSet.INTERNAL_93 = dr["INTERNAL_93"].ToString();
                item.InformationSet.INTERNAL_94 = dr["INTERNAL_94"].ToString();
                item.InformationSet.INTERNAL_95 = dr["INTERNAL_95"].ToString();
                item.InformationSet.INTERNAL_96 = dr["INTERNAL_96"].ToString();
                item.InformationSet.INTERNAL_97 = dr["INTERNAL_97"].ToString();
                item.InformationSet.INTERNAL_98 = dr["INTERNAL_98"].ToString();
                item.InformationSet.INTERNAL_99 = dr["INTERNAL_99"].ToString();
                item.InformationSet.LIC = dr["LIC"].ToString();
                item.InformationSet.Lot = dr["Lot"].ToString();
                item.InformationSet.LPP = dr["LPP"].ToString();
                item.InformationSet.NaS7 = dr["NaS7"].ToString();
                item.InformationSet.NaSIdParamName = dr["NaSIdParamName"].ToString();
                item.InformationSet.NormalizedBESTBEFORE = dr["NormalizedBESTBEFORE"].ToString();
                item.InformationSet.NormalizedExpiry = dr["NormalizedExpiry"].ToString();
                item.InformationSet.NormalizedPRODDATE = dr["NormalizedPRODDATE"].ToString();
                item.InformationSet.PCN = dr["PCN"].ToString();
                item.InformationSet.PRODDATE = dr["PRODDATE"].ToString();
                item.InformationSet.Product = ""; // dr["Product"].ToString(); //Obsolete
                item.InformationSet.Quantity = dr["Quantity"].ToString();
                item.InformationSet.Reference = dr["Reference"].ToString();
                item.InformationSet.Serial = dr["Serial"].ToString();
                item.InformationSet.SSCC = dr["SSCC"].ToString();
                item.InformationSet.StorageLocation = dr["StorageLocation"].ToString();
                item.InformationSet.UDI = dr["UDI"].ToString();
                item.InformationSet.UDI_DI = dr["UDI_DI"].ToString();
                item.InformationSet.Issuer = dr["Issuer"].ToString();
                item.InformationSet.UoM = dr["UoM"].ToString();
                item.InformationSet.UPN = dr["UPN"].ToString();
                item.InformationSet.VARCOUNT = dr["VARCOUNT"].ToString();
                item.InformationSet.VARIANT = dr["VARIANT"].ToString();
                item.InformationSet.AdditionalInformation = dr["AdditionalInformation"].ToString();

                //Identifiers
                string IdentifiersRawList = dr["Identifiers"].ToString();
                
                if (IdentifiersRawList.Length > 0)
                {
                    int count = IdentifiersRawList.Split('@').Length;
                    string[] IdentifiersSplitList = new string[count];
                    IdentifiersSplitList = IdentifiersRawList.Split('@');

                    foreach(string x in IdentifiersSplitList)
                    {
                        item.InformationSet.Identifiers.Add(new Identifier { Value = x });
                    }
                }

                result.Add(item);
            }
            return result;
        }

    }
}
