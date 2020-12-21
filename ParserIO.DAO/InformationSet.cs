using System.Collections.Generic;

namespace ParserIO.DAO
{
    public class Identifier
    {
        private string _Value = string.Empty;

        public string Value
        {
            get
            {
                return _Value;
            }

            set
            {
                _Value = value;
            }
        }
    }

    public class InformationSet
    {
        private string _InputCode = string.Empty;
        private string _ACL = string.Empty;
        private string _ADDITIONALID = string.Empty;
        private string _BESTBEFORE = string.Empty;
        private string _CIP = string.Empty;
        private string _Company = string.Empty; //Obsolete
        private bool _ContainsOrMayContainId = false;
        private string _CONTENT = string.Empty;
        private string _COUNT = string.Empty;
        private string _CUSTPARTNO = string.Empty;
        private string _EAN = string.Empty;
        private string _Expiry = string.Empty;
        private string _Family = string.Empty;
        private string _GTIN = string.Empty;
        private string _Issuer = string.Empty;
        private string _LIC = string.Empty;
        private string _Lot = string.Empty;
        private string _LPP = string.Empty;
        private string _NaS7 = string.Empty;
        private string _NaSIdParamName = string.Empty;
        private string _NormalizedBESTBEFORE = string.Empty;
        private string _NormalizedExpiry = string.Empty;
        private string _NormalizedPRODDATE = string.Empty;
        private string _PCN = string.Empty;
        private string _PRODDATE = string.Empty;
        private string _Product = string.Empty; //Obsolete
        private string _Quantity = string.Empty;
        private string _Reference = string.Empty;
        private string _Serial = string.Empty;
        private string _SSCC = string.Empty;
        private string _subType=string.Empty;
        private string _SymbologyID = string.Empty;
        private string _SymbologyIDDesignation = string.Empty;
        private string _Type = string.Empty;
        private string _UDI = string.Empty;
        private string _UDI_DI = string.Empty;
        private string _UoM = string.Empty;
        private string _UPN = string.Empty;
        private string _VARCOUNT = string.Empty;
        private string _VARIANT = string.Empty;
        private string _AdditionalInformation=string.Empty;
        private string _INTERNAL_90 = string.Empty;
        private string _INTERNAL_91 = string.Empty;
        private string _INTERNAL_92 = string.Empty;
        private string _INTERNAL_93 = string.Empty;
        private string _INTERNAL_94 = string.Empty;
        private string _INTERNAL_95 = string.Empty;
        private string _INTERNAL_96 = string.Empty;
        private string _INTERNAL_97 = string.Empty;
        private string _INTERNAL_98 = string.Empty;
        private string _INTERNAL_99 = string.Empty;
        private string _StorageLocation = string.Empty;
        private List<Identifier> _Identifiers = new List<Identifier>();
        private string _ParserIOVersion = string.Empty;

        public string InputCode
        {
            get { return _InputCode; }
            set { _InputCode = value; }
        }
        public string ACL
        {
            get { return _ACL; }
            set { _ACL = value; }
        }
        public string ADDITIONALID
        {
            get { return _ADDITIONALID; }
            set { _ADDITIONALID = value; }
        }
        public string BESTBEFORE
        {
            get { return _BESTBEFORE; }
            set { _BESTBEFORE = value; }
        }
        public string CIP
        {
            get { return _CIP; }
            set { _CIP = value; }
        }
        //Obsolete
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public bool ContainsOrMayContainId
        {
            get { return _ContainsOrMayContainId; }
            set { _ContainsOrMayContainId = value; }
        }
        public string CONTENT
        {
            get { return _CONTENT; }
            set { _CONTENT = value; }
        }
        public string COUNT
        {
            get { return _COUNT; }
            set { _COUNT = value; }
        }
        public string CUSTPARTNO
        {
            get { return _CUSTPARTNO; }
            set { _CUSTPARTNO = value; }
        }
        public string EAN
        {
            get { return _EAN; }
            set { _EAN = value; }
        }
        public string Expiry
        {
            get { return _Expiry; }
            set { _Expiry = value; }
        }
        public string Family
        {
            get { return _Family; }
            set { _Family = value; }
        }
        public string GTIN
        {
            get { return _GTIN; }
            set { _GTIN = value; }
        }
        public string INTERNAL_90
        {
            get { return _INTERNAL_90; }
            set { _INTERNAL_90 = value; }
        }
        public string INTERNAL_91
        {
            get { return _INTERNAL_91; }
            set { _INTERNAL_91 = value; }
        }
        public string INTERNAL_92
        {
            get { return _INTERNAL_92; }
            set { _INTERNAL_92 = value; }
        }
        public string INTERNAL_93
        {
            get { return _INTERNAL_93; }
            set { _INTERNAL_93 = value; }
        }
        public string INTERNAL_94
        {
            get { return _INTERNAL_94; }
            set { _INTERNAL_94 = value; }
        }
        public string INTERNAL_95
        {
            get { return _INTERNAL_95; }
            set { _INTERNAL_95 = value; }
        }
        public string INTERNAL_96
        {
            get { return _INTERNAL_96; }
            set { _INTERNAL_96 = value; }
        }
        public string INTERNAL_97
        {
            get { return _INTERNAL_97; }
            set { _INTERNAL_97 = value; }
        }
        public string INTERNAL_98
        {
            get { return _INTERNAL_98; }
            set { _INTERNAL_98 = value; }
        }
        public string INTERNAL_99
        {
            get { return _INTERNAL_99; }
            set { _INTERNAL_99 = value; }
        }
        public string LIC
        {
            get { return _LIC;}
            set { _LIC = value; }
        }
        public string Lot
        {
            get { return _Lot; }
            set { _Lot = value; }
        }
        public string LPP
        {
            get { return _LPP; }
            set { _LPP = value; }
        }
        public string NaS7
        {
            get { return _NaS7; }
            set { _NaS7 = value; }
        }
        public string NormalizedBESTBEFORE
        {
            get { return _NormalizedBESTBEFORE; }
            set { _NormalizedBESTBEFORE = value; }
        }
        public string NormalizedExpiry
        {
            get { return _NormalizedExpiry; }
            set { _NormalizedExpiry = value; }
        }
        public string NormalizedPRODDATE
        {
            get { return _NormalizedPRODDATE; }
            set { _NormalizedPRODDATE = value; }
        }
        public string PCN
        {
            get { return _PCN; }
            set { _PCN = value; }
        }
        public string PRODDATE
        {
            get { return _PRODDATE; }
            set { _PRODDATE = value; }
        }
        //Obsolete
        public string Product
        {
            get { return _Product; }
            set { _Product = value; }
        }
        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string Reference
        {
            get { return _Reference; }
            set { _Reference = value; }
        }
        public string NaSIdParamName
        {
            get { return _NaSIdParamName; }
            set { _NaSIdParamName = value; }
        }
        public string Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }
        public string SSCC
        {
            get { return _SSCC; }
            set { _SSCC = value; }
        }
        public string StorageLocation
        {
            get { return _StorageLocation; }
            set { _StorageLocation = value; }
        }
        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
        public string SymbologyID
        {
            get { return _SymbologyID; }
            set { _SymbologyID = value; }
        }
        public string SymbologyIDDesignation
        {
            get { return _SymbologyIDDesignation; }
            set { _SymbologyIDDesignation = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string UDI
        {
            get { return _UDI; }
            set { _UDI = value; }
        }
        public string UoM
        {
            get { return _UoM; }
            set { _UoM = value; }
        }
        public  string UPN
        {
            get { return _UPN; }
            set { _UPN = value; }
        }
        public string VARCOUNT
        {
            get { return _VARCOUNT; }
            set { _VARCOUNT = value; }
        }
        public string VARIANT
        {
            get { return _VARIANT; }
            set { _VARIANT = value; }
        }
        public string AdditionalInformation
        {
            get { return _AdditionalInformation; }
            set { _AdditionalInformation = value; }
        }

        public List<Identifier> Identifiers
        {
            get { return _Identifiers; }
            set { _Identifiers = value; }
        }

        public string ParserIOVersion
        {
            get { return _ParserIOVersion; }
            set { _ParserIOVersion = value; }
        }

        public string UDI_DI
        {
            get
            {
                return _UDI_DI;
            }

            set
            {
                _UDI_DI = value;
            }
        }

        public string Issuer
        {
            get
            {
                return _Issuer;
            }

            set
            {
                _Issuer = value;
            }
        }

        public InformationSet()
        {
            //AdditionalInformation = "No errors detected!";
        }

    }
}
