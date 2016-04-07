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
// parserio.svc.cs

// 12/18/2014 DU v 1.0.0.0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ParserIO_functions;

namespace ParserIO_WS_WCF
{
    public class parserio : Iparserio
    {
        public CompositeType Parse_1(string Barcode)
        {
            CompositeType result = new CompositeType();
            ParserIO_functions.ParserIO_func Parser = new ParserIO_functions.ParserIO_func();
            try
            {
                string Type = Parser.Type(Barcode);
                string SubType = Parser.SubType(Barcode, Type);
                result.Type = Type;
                result.SubType = SubType;
                result.ACL = Parser.ACL(Barcode, Type, SubType);
                result.GTIN = Parser.GTIN(Barcode, Type, SubType);
                result.SymbologyID = Parser.SymbologyID(Barcode);
                result.UPN = Parser.UPN(Barcode, result.Type, result.SubType);
            }
            catch (Exception e)
            {
                result.executeResult = -1;
                result.Errors = e.Message;
            }

            return result;
        }
        
    }
}
