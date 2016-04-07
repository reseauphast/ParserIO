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
// Iparserio.cs

// 12/18/2014 DU v 1.0.0.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ParserIO_WS_WCF
{
    [ServiceContract]
    public interface Iparserio
    {
        [OperationContract]
        CompositeType Parse_1(string Barcode);
    }

    [DataContract]
    public class CompositeType
    {
        string acl = "";
        string additionalid = "";
        string bestbefore = "";
        string cip = "";
        string company = "";
        bool containsOrMayContainId = false;
        string content = "";
        string count = "";
        string ean = "";
        string expiry = "";
        string family = "";
        string gtin = "";
        string lic = "";
        string lot = "";
        string lpp = "";
        string nas7 = "";
        string normalizedBESTBEFORE = "";
        string normalizedExpiry = "";
        string normalizedPRODDATE = "";
        string pcn = "";
        string proddate = "";
        string product = "";
        string quantity = "";
        string reference = "";
        string nasidparamName = "";
        string serial = "";
        string sscc = "";
        string subType = "";
        string symbologyid = "";
        string type = "";
        string uom = "";
        string upn = "";
        string varcount = "";
        string variant = "";
        int executeresult = 0;
        string errors = "";


        [DataMember]
        public string ACL
        {
            get { return acl; }
            set { acl = value; }
        }

        [DataMember]
        public string GTIN
        {
            get { return gtin; }
            set { gtin = value; }
        }

        [DataMember]
        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        [DataMember]
        public string SymbologyID
        {
            get { return symbologyid; }
            set { symbologyid = value; }
        }

        [DataMember]
        public string Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public string SubType
        {
            get { return subType; }
            set { subType = value; }
        }

        [DataMember]
        public int executeResult
        {
            get { return executeresult; }
            set { executeresult = value; }
        }

        [DataMember]
        public string UPN
        {
            get { return upn; }
            set { upn = value; }
        }
    }
}