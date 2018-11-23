using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ParserIO.DAO;

namespace ParserIO.DAL
{
    public class Barcodestore
    {
        public static int P_Barcode_Upsert(int AnalyseId,
                                           DateTime TimeStamp,
                                           string ParserIOVersion,
                                           string Barcode,
                                           string SymbologyID,
                                           string Type,
                                           string SubType,
                                           string NaSIdParamName,
                                           bool ContainsOrMayContainId,
                                           List<Identifier> Identifiers,
                                           string ACL,
                                           string ADDITIONALID,
                                           string BESTBEFORE,
                                           string CIP,
                                           string CONTENT,
                                           string COUNT,
                                           string CUSTPARTNO,
                                           string EAN13,
                                           string Expiry,
                                           string Family,
                                           string GTIN,
                                           string INTERNAL_90,
                                           string INTERNAL_91,
                                           string INTERNAL_92,
                                           string INTERNAL_93,
                                           string INTERNAL_94,
                                           string INTERNAL_95,
                                           string INTERNAL_96,
                                           string INTERNAL_97,
                                           string INTERNAL_98,
                                           string INTERNAL_99,
                                           string LIC,
                                           string Lot,
                                           string LPP,
                                           string NaS7,
                                           string NormalizedBESTBEFORE,
                                           string NormalizedExpiry,
                                           string NormalizedPRODDATE,
                                           string PCN,
                                           string PRODDATE,
                                           string Quantity,
                                           string Reference,
                                           string Serial,
                                           string SSCC,
                                           string StorageLocation,
                                           string UDI,
                                           string UoM,
                                           string UPN,
                                           string VARCOUNT,
                                           string VARIANT,
                                           string AdditionalInformation,
                                           string Commentary)
        {
            int executeResult = 0;
            string sqlCmdName = "P_Barcode_Upsert";
            List<SqlParameter> inParam = new List<SqlParameter>();

            SqlParameter AnalyseIdParam = new SqlParameter();
            AnalyseIdParam.ParameterName = "AnalyseId";
            AnalyseIdParam.Value = AnalyseId;
            inParam.Add(AnalyseIdParam);

            SqlParameter TimeStampParam = new SqlParameter();
            TimeStampParam.ParameterName = "TimeStamp";
            TimeStampParam.Value = TimeStamp;
            inParam.Add(TimeStampParam);

            SqlParameter ParserIOVersionParam = new SqlParameter();
            ParserIOVersionParam.ParameterName = "ParserIOVersion";
            ParserIOVersionParam.Value = ParserIOVersion;
            inParam.Add(ParserIOVersionParam);

            SqlParameter BarcodeParam = new SqlParameter();
            BarcodeParam.ParameterName = "Barcode";
            BarcodeParam.Value = Barcode;
            inParam.Add(BarcodeParam);

            SqlParameter SymbologyIDParam = new SqlParameter();
            SymbologyIDParam.ParameterName = "SymbologyID";
            SymbologyIDParam.Value = SymbologyID;
            inParam.Add(SymbologyIDParam);

            SqlParameter TypeParam = new SqlParameter();
            TypeParam.ParameterName = "Type";
            TypeParam.Value = Type;
            inParam.Add(TypeParam);

            SqlParameter SubTypeParam = new SqlParameter();
            SubTypeParam.ParameterName = "SubType";
            SubTypeParam.Value = SubType;
            inParam.Add(SubTypeParam);

            SqlParameter containsOrMayContainIdParam = new SqlParameter();
            containsOrMayContainIdParam.ParameterName = "ContainsOrMayContainId";
            containsOrMayContainIdParam.Value = ContainsOrMayContainId;
            inParam.Add(containsOrMayContainIdParam);


            //Identifiers
            string IdentifiersRawList = string.Empty;
            bool isFirst = true;
            string separator = string.Empty;
            foreach(Identifier x in Identifiers)
            {
                IdentifiersRawList = IdentifiersRawList + "@" + x.Value;
            }
            if(IdentifiersRawList.StartsWith("@"))
            {
                IdentifiersRawList = IdentifiersRawList.TrimStart('@');
            }


            SqlParameter identifiersParam = new SqlParameter();
            identifiersParam.ParameterName = "Identifiers";
            identifiersParam.Value = IdentifiersRawList;
            inParam.Add(identifiersParam);



            SqlParameter ACLParam = new SqlParameter();
            ACLParam.ParameterName = "ACL";
            ACLParam.Value = ACL;
            inParam.Add(ACLParam);

            SqlParameter NaSIdParamNameParam = new SqlParameter();
            NaSIdParamNameParam.ParameterName = "NaSIdParamName";
            NaSIdParamNameParam.Value = NaSIdParamName;
            inParam.Add(NaSIdParamNameParam);

            SqlParameter ADDITIONALIDParam = new SqlParameter();
            ADDITIONALIDParam.ParameterName = "ADDITIONALID";
            ADDITIONALIDParam.Value = ADDITIONALID;
            inParam.Add(ADDITIONALIDParam);

            SqlParameter BESTBEFOREParam = new SqlParameter();
            BESTBEFOREParam.ParameterName = "BESTBEFORE";
            BESTBEFOREParam.Value = BESTBEFORE;
            inParam.Add(BESTBEFOREParam);

            SqlParameter CIPParam = new SqlParameter();
            CIPParam.ParameterName = "CIP";
            CIPParam.Value = CIP;
            inParam.Add(CIPParam);

            SqlParameter CONTENTParam = new SqlParameter();
            CONTENTParam.ParameterName = "CONTENT";
            CONTENTParam.Value = CONTENT;
            inParam.Add(CONTENTParam);

            SqlParameter COUNTParam = new SqlParameter();
            COUNTParam.ParameterName = "COUNT";
            COUNTParam.Value = COUNT;
            inParam.Add(COUNTParam);

            SqlParameter CUSTPARTNOParam = new SqlParameter();
            CUSTPARTNOParam.ParameterName = "CUSTPARTNO";
            CUSTPARTNOParam.Value = CUSTPARTNO;
            inParam.Add(CUSTPARTNOParam);

            SqlParameter EANParam = new SqlParameter();
            EANParam.ParameterName = "EAN";
            EANParam.Value = EAN13;
            inParam.Add(EANParam);

            SqlParameter ExpiryParam = new SqlParameter();
            ExpiryParam.ParameterName = "Expiry";
            ExpiryParam.Value = Expiry;
            inParam.Add(ExpiryParam);

            SqlParameter FamilyParam = new SqlParameter();
            FamilyParam.ParameterName = "Family";
            FamilyParam.Value = Family;
            inParam.Add(FamilyParam);

            SqlParameter GTINParam = new SqlParameter();
            GTINParam.ParameterName = "GTIN";
            GTINParam.Value = GTIN;
            inParam.Add(GTINParam);

            SqlParameter INTERNAL_90Param = new SqlParameter();
            INTERNAL_90Param.ParameterName = "INTERNAL_90";
            INTERNAL_90Param.Value = INTERNAL_90;
            inParam.Add(INTERNAL_90Param);

            SqlParameter INTERNAL_91Param = new SqlParameter();
            INTERNAL_91Param.ParameterName = "INTERNAL_91";
            INTERNAL_91Param.Value = INTERNAL_91;
            inParam.Add(INTERNAL_91Param);

            SqlParameter INTERNAL_92Param = new SqlParameter();
            INTERNAL_92Param.ParameterName = "INTERNAL_92";
            INTERNAL_92Param.Value = INTERNAL_92;
            inParam.Add(INTERNAL_92Param);

            SqlParameter INTERNAL_93Param = new SqlParameter();
            INTERNAL_93Param.ParameterName = "INTERNAL_93";
            INTERNAL_93Param.Value = INTERNAL_93;
            inParam.Add(INTERNAL_93Param);

            SqlParameter INTERNAL_94Param = new SqlParameter();
            INTERNAL_94Param.ParameterName = "INTERNAL_94";
            INTERNAL_94Param.Value = INTERNAL_94;
            inParam.Add(INTERNAL_94Param);

            SqlParameter INTERNAL_95Param = new SqlParameter();
            INTERNAL_95Param.ParameterName = "INTERNAL_95";
            INTERNAL_95Param.Value = INTERNAL_95;
            inParam.Add(INTERNAL_95Param);

            SqlParameter INTERNAL_96Param = new SqlParameter();
            INTERNAL_96Param.ParameterName = "INTERNAL_96";
            INTERNAL_96Param.Value = INTERNAL_96;
            inParam.Add(INTERNAL_96Param);

            SqlParameter INTERNAL_97Param = new SqlParameter();
            INTERNAL_97Param.ParameterName = "INTERNAL_97";
            INTERNAL_97Param.Value = INTERNAL_97;
            inParam.Add(INTERNAL_97Param);

            SqlParameter INTERNAL_98Param = new SqlParameter();
            INTERNAL_98Param.ParameterName = "INTERNAL_98";
            INTERNAL_98Param.Value = INTERNAL_98;
            inParam.Add(INTERNAL_98Param);

            SqlParameter INTERNAL_99Param = new SqlParameter();
            INTERNAL_99Param.ParameterName = "INTERNAL_99";
            INTERNAL_99Param.Value = INTERNAL_99;
            inParam.Add(INTERNAL_99Param);

            SqlParameter LICParam = new SqlParameter();
            LICParam.ParameterName = "LIC";
            LICParam.Value = LIC;
            inParam.Add(LICParam);

            SqlParameter LotParam = new SqlParameter();
            LotParam.ParameterName = "Lot";
            LotParam.Value = Lot;
            inParam.Add(LotParam);

            SqlParameter LPPParam = new SqlParameter();
            LPPParam.ParameterName = "LPP";
            LPPParam.Value = LPP;
            inParam.Add(LPPParam);

            SqlParameter NaS7Param = new SqlParameter();
            NaS7Param.ParameterName = "NaS7";
            NaS7Param.Value = NaS7;
            inParam.Add(NaS7Param);

            SqlParameter NormalizedBESTBEFOREParam = new SqlParameter();
            NormalizedBESTBEFOREParam.ParameterName = "NormalizedBESTBEFORE";
            NormalizedBESTBEFOREParam.Value = NormalizedBESTBEFORE;
            inParam.Add(NormalizedBESTBEFOREParam);

            SqlParameter NormalizedExpiryParam = new SqlParameter();
            NormalizedExpiryParam.ParameterName = "NormalizedExpiry";
            NormalizedExpiryParam.Value = NormalizedExpiry;
            inParam.Add(NormalizedExpiryParam);

            SqlParameter NormalizedPRODDATEParam = new SqlParameter();
            NormalizedPRODDATEParam.ParameterName = "NormalizedPRODDATE";
            NormalizedPRODDATEParam.Value = NormalizedPRODDATE;
            inParam.Add(NormalizedPRODDATEParam);

            SqlParameter PCNParam = new SqlParameter();
            PCNParam.ParameterName = "PCN";
            PCNParam.Value = PCN;
            inParam.Add(PCNParam);

            SqlParameter PRODDATEParam = new SqlParameter();
            PRODDATEParam.ParameterName = "PRODDATE";
            PRODDATEParam.Value = PRODDATE;
            inParam.Add(PRODDATEParam);

            SqlParameter QuantityParam = new SqlParameter();
            QuantityParam.ParameterName = "Quantity";
            QuantityParam.Value = Quantity;
            inParam.Add(QuantityParam);

            SqlParameter ReferenceParam = new SqlParameter();
            ReferenceParam.ParameterName = "Reference";
            ReferenceParam.Value = Reference;
            inParam.Add(ReferenceParam);

            SqlParameter SerialParam = new SqlParameter();
            SerialParam.ParameterName = "Serial";
            SerialParam.Value = Serial;
            inParam.Add(SerialParam);

            SqlParameter SSCCParam = new SqlParameter();
            SSCCParam.ParameterName = "SSCC";
            SSCCParam.Value = SSCC;
            inParam.Add(SSCCParam);

            SqlParameter StorageLocationParam = new SqlParameter();
            StorageLocationParam.ParameterName = "StorageLocation";
            StorageLocationParam.Value = StorageLocation;
            inParam.Add(StorageLocationParam);

            SqlParameter UDIParam = new SqlParameter();
            UDIParam.ParameterName = "UDI";
            UDIParam.Value = UDI;
            inParam.Add(UDIParam);

            SqlParameter UoMParam = new SqlParameter();
            UoMParam.ParameterName = "UoM";
            UoMParam.Value = UoM;
            inParam.Add(UoMParam);

            SqlParameter UPNParam = new SqlParameter();
            UPNParam.ParameterName = "UPN";
            UPNParam.Value = UPN;
            inParam.Add(UPNParam);

            SqlParameter VARCOUNTParam = new SqlParameter();
            VARCOUNTParam.ParameterName = "VARCOUNT";
            VARCOUNTParam.Value = VARCOUNT;
            inParam.Add(VARCOUNTParam);

            SqlParameter VARIANTParam = new SqlParameter();
            VARIANTParam.ParameterName = "VARIANT";
            VARIANTParam.Value = VARIANT;
            inParam.Add(VARIANTParam);

            SqlParameter AdditionalInformationParam = new SqlParameter();
            AdditionalInformationParam.ParameterName = "AdditionalInformation";
            AdditionalInformationParam.Value = AdditionalInformation;
            inParam.Add(AdditionalInformationParam);

            SqlParameter CommentaryParam = new SqlParameter();
            CommentaryParam.ParameterName = "Commentary";
            CommentaryParam.Value = Commentary;
            inParam.Add(CommentaryParam);

            DataBaseHelper dbHelper = new DataBaseHelper();
            dbHelper.ExecuteScalarStoredProcedure(sqlCmdName, inParam);
            return executeResult;
        }

        public static DataSet P_Barcode_List()
        {
            string spName = "P_Barcode_List";
            DataBaseHelper dbHelper = new DataBaseHelper();
            DataSet result = new DataSet();
            result = dbHelper.ExecuteStoredProcedure(spName);
            return result;
        }
    }
}
