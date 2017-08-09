//For more information, please consult the ParserIO web site at
//<http://parserio.codeplex.com>
//<https://github.com/reseauphast/ParserIO>
//

using System;
using ParserIO.DAO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Reflection;

[assembly: AssemblyKeyFile("ParserIO.Core.snk")]
namespace ParserIO.Core
{

    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
    // InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IFunctions
    {
        [DispId(1)]
        InformationSet GetFullInformationSet(string code);
    }

    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA71"),
      InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ParserIO_Core_events
    {
    }

    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938"),
      ClassInterface(ClassInterfaceType.AutoDual),
      ComVisible(true)]
    // [fr] Verifier si  ComVisible(true) est utile
    // [en] Check if ComVisible(true) is useful or not
    //[ProgId("ParserIO_functions")]




    public class Functions : IFunctions
    {
        private InformationSet result = new InformationSet();
        private static int[] _month_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        private static System.Collections.Generic.List<char> nValuesAssignmets = new System.Collections.Generic.List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '.', ' ', '$', '/', '+', '%'
        };

        private static System.Collections.Generic.List<string> gs1AIList = new System.Collections.Generic.List<string>()
        {
            "00",
            "01",
            "02",
            "10",
            "11",
            "12",
            "13",
            "15",
            "16",
            "17",
            "20",
            "21",
            "240",
            "30",
            "90",
            "91",
            "92",
            "93",
            "94",
            "95",
            "96",
            "97",
            "98",
            "99"
        };

        private static DateTime ConvertDateTimeFromStr(String dateRaw, int dateType)
        {
            //if (dateType == 3)
            //{
            //    if (dateRaw.StartsWith("20"))
            //        if ((dateRaw.StartsWith("2013") |
            //             dateRaw.StartsWith("2014") |
            //             dateRaw.StartsWith("2015") |
            //             dateRaw.StartsWith("2016") |
            //             dateRaw.StartsWith("2017") |
            //             dateRaw.StartsWith("2018") |
            //             dateRaw.StartsWith("2019") |
            //             dateRaw.StartsWith("2020")) &
            //            (dateRaw.EndsWith("01") |
            //             dateRaw.EndsWith("02") |
            //             dateRaw.EndsWith("03") |
            //             dateRaw.EndsWith("04") |
            //             dateRaw.EndsWith("05") |
            //             dateRaw.EndsWith("06") |
            //             dateRaw.EndsWith("07") |
            //             dateRaw.EndsWith("08") |
            //             dateRaw.EndsWith("09") |
            //             dateRaw.EndsWith("10") |
            //             dateRaw.EndsWith("11") |
            //             dateRaw.EndsWith("12")))
            //        {
            //            // [fr] Est de la forme AAAAMM, devrait être AAMMJJ
            //            // [en] Is in YYYYMM form, should be YYMMDD
            //            dateRaw = dateRaw.Substring(2) + "00";  //27/01/2012 DU: A vérifier //TODO MB Controler Longueur code 
            //        }
            //}

            DateTime dt = DateTime.MinValue;
            int y = 0, m = 0, d = 0, h = 0, j = 0;
            // y ------years, m ------months, d ------days, h -------hours

            switch (dateType)
            {
                case 1:
                    m = int.Parse(dateRaw.Substring(0, 2));
                    y = int.Parse(dateRaw.Substring(2, 2));
                    break;
                case 2:
                    m = int.Parse(dateRaw.Substring(0, 2));
                    d = int.Parse(dateRaw.Substring(2, 2));
                    y = int.Parse(dateRaw.Substring(4, 2));
                    break;
                case 3:
                    //dateRaw = dateRaw.Substring(2);
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 2));
                    d = int.Parse(dateRaw.Substring(4, 2));
                    break;
                case 4:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 2));
                    d = int.Parse(dateRaw.Substring(4, 2));
                    h = int.Parse(dateRaw.Substring(6, 2));
                    break;
                case 5:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    j = int.Parse(dateRaw.Substring(2, 3));
                    break;
                case 6:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    j = int.Parse(dateRaw.Substring(2, 3));
                    h = int.Parse(dateRaw.Substring(5, 2));
                    break;
                case 7:
                    y = int.Parse(dateRaw.Substring(2, 2));
                    m = int.Parse(dateRaw.Substring(5, 2));
                    break;
                case 8:
                    y = int.Parse(dateRaw.Substring(4, 2));
                    m = int.Parse(dateRaw.Substring(0, 2));
                    d = int.Parse(dateRaw.Substring(2, 2));
                    break;
                case 9:
                    y = int.Parse(dateRaw.Substring(8, 2));
                    m = int.Parse(dateRaw.Substring(3, 2));
                    d = int.Parse(dateRaw.Substring(0, 2));
                    break;
                case 10:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 1));
                    break;
            }

            //convert 2 digits year to 4 digits year
            dt = DateTime.ParseExact(String.Format("{0:00}", y), "yy", CultureInfo.CurrentUICulture);
            y = dt.Year;

            if (0 == y)
            {
                //invalid date time string...
                return dt;
            }

            //convert Julian Date  to DateTime
            if (0 != j)
            {
                dt = dt.AddDays(j - 1);
                if (h > 0)
                {
                    dt = dt.AddHours(h);
                }
                return dt;
            }

            //if month is zero
            if (0 == m)
            {
                m = 12;
            }

            //if days invalid
            if (_month_days[m - 1] < d || 0 == d)
            {
                if (2 == m)
                {
                    //leap year 
                    if (DateTime.IsLeapYear(y))
                    {
                        d = 29;
                    }
                    else
                    {
                        d = 28;
                    }
                }
                else
                {
                    d = _month_days[m - 1];
                }
            }

            //convert y,m,d,h to DateTime
            if (y > 0 && m > 0)
            {
                dt = dt.AddMonths(m - 1);
                dt = dt.AddDays(d - 1);
                if (h > 0)
                {
                    dt = dt.AddHours(h);
                }
            }
            return dt;
        }
        private static string NormalizedDate(string dateRaw, string type, string subType)
        {
            string result = "";
            if (!String.IsNullOrEmpty(dateRaw))
            {
                int dateType = GetDateType(type, subType, dateRaw);
                if (dateType == 0)
                {
                    result = dateRaw;
                    return result;
                }
                else if (dateType != -1)
                {
                    DateTime dateTime = ConvertDateTimeFromStr(dateRaw, dateType);
                    if (dateTime != DateTime.MinValue)
                    {
                        if (dateTime.Hour > 0)
                        {
                            result = dateTime.ToString("yyyyMMddHH");
                        }
                        else
                        {
                            result = dateTime.ToString("yyyyMMdd");
                        }
                    }
                }
            }
            return result;
        }
        private static int GetDateType(String typeBarcode, String subType, String dateRaw)
        {
            int typeDate = -1;
            if (typeBarcode == "GS1-128")
            {
                // YYMMDD
                typeDate = 3;
            }
            else if (typeBarcode == "HIBC" && subType.Contains("Secondary"))
            {
                if (dateRaw.Length == 4)
                {
                    // MMYY
                    typeDate = 1;
                }
                else if (dateRaw.Length == 5)
                {
                    // YYJJJ
                    typeDate = 5;

                }
                else if (dateRaw.Length == 6)
                {
                    if ((subType.Contains("$$.2") | (subType.Contains("$$.8.2"))))
                    {
                        // MMDDYY
                        typeDate = 2;
                    }
                    else if ((subType.Contains("$$.3") | (subType.Contains("$$.8.3"))))
                    {
                        // YYMMDD
                        typeDate = 3;
                    }
                }
                else if (dateRaw.Length == 7)
                {
                    // YYJJJHH
                    typeDate = 6;
                }
                else if (dateRaw.Length == 8)
                {
                    if ((subType.Contains(".14") | subType.Contains(".16")) && !(subType.Contains("$$.4") | (subType.Contains("$$.8.4"))))
                    {
                        // YYYYMMDD
                        typeDate = 0;
                    }
                    else if (!(subType.Contains(".14") | subType.Contains(".16")) && (subType.Contains("$$.4") | (subType.Contains("$$.8.4"))))
                    {
                        // YYMMDDHH
                        typeDate = 4;
                    }
                    else
                    {
                        // If the secondary structure contains both?
                        //Todo
                        // ? > YYYY > ?
                        // 12 => MM >= 01
                        // 31 => DD >= 01
                        // 24 => HH >= 00

                    }
                }
            }
            else if (typeBarcode == "NaS")
            {
                if (subType == "005")
                {
                    typeDate = 7;
                }
                else if (subType == "007")
                {
                    typeDate = 8;
                }
                else if (subType == "015")
                {
                    typeDate = 9;
                }
                else if (subType == "016")
                {
                    typeDate = 3;
                }
                else if (subType == "017")
                {
                    typeDate = 10;
                }
            }
            return typeDate;
        }
        private static string Cleanse(string code)
        {
            string result = code;
            result = result.Replace("(01)", "01");
            result = result.Replace("(10)", "10");
            result = result.Replace("(11)", "11");
            result = result.Replace("(17)", "17");
            result = result.Replace("(21)", "21");
            result = result.Replace("(22)", "22");
            result = result.Replace("(30)", "30");
            result = result.Replace("(240)", "240");
            if (result.StartsWith("*") & (result.EndsWith("*")))
                result = result.Substring(1, result.Length - 2);
            if (result.StartsWith("]C0*") & (result.EndsWith("*")))
                result = result.Replace("*", "");
            return result;
        }
        private static string getGStype(string code)
        {
            string result = "Not";
            string GS = ((char)0x001d).ToString();
            if (code.Contains(GS))
                result = "GS";
            else if (code.Contains("@"))
                result = "@";
            return result;
        }
        private static int indexOfGS(string code, int start)
        {
            int result = -1;
            string GSchar = getGStype(code);
            if (GSchar == "GS")
            {
                string GS = ((char)0x001d).ToString();
                result = code.IndexOf(GS, start);
            }
            else if (GSchar == "@")
                result = code.IndexOf("@", start);
            return result;
        }
        private static bool containsGS(string code)
        {
            bool result = false;
            string temp = getGStype(code);
            if (temp != "Not")
                result = true;
            return result;
        }
        private static bool containsSymbologyId(string code)
        {
            bool result = false;
            if (code.StartsWith("]A0") |
                code.StartsWith("]C0") |
                code.StartsWith("]C1") |
                code.StartsWith("]d1") |
                code.StartsWith("]d2") |
                code.StartsWith("]E0"))
                result = true;
            return result;
        }
        private static string CleanSymbologyId(string code)
        {
            string result = code;
            if (containsSymbologyId(code))
                result = result.Substring(3, result.Length - 3);
            return result;
        }
        public string SymbologyID(string code)
        {
            string result = "";
            code = Cleanse(code);
            string ID = "";
            if (code.Length >= 3)
                ID = code.Substring(0, 3);
            if (ID == "]A0")
                result = "A0";
            else if (ID == "]C0")
                result = "C0";
            else if (ID == "]C1")
                result = "C1";
            else if (ID == "]d1")
                result = "d1";
            else if (ID == "]d2")
                result = "d2";
            return result;
        }
        private static bool NumericString(string code)
        {
            bool ok = true;
            char[] array = code.ToCharArray();
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }
        private static bool NumericChar(char c)
        // [fr] Pas utilisé la classe Char du .Net Framework pour faciliter la transposition dans un autre langage
        // [en] Not used the Char class of the .Net Framewort to facilitate the translation into another language
        {
            return (
              c == '0' |
              c == '1' |
              c == '2' |
              c == '3' |
              c == '4' |
              c == '5' |
              c == '6' |
              c == '7' |
              c == '8' |
              c == '9');
        }
        private bool Alphabetic(char c)
        // [fr] Pas utilisé la classe Char du .Net Framework pour faciliter la transposition dans un autre langage
        // [en] Not used the Char class of the .Net Framewort to facilitate the translation into another language
        {
            return (
              c == 'A' |
              c == 'B' |
              c == 'C' |
              c == 'D' |
              c == 'E' |
              c == 'F' |
              c == 'G' |
              c == 'H' |
              c == 'I' |
              c == 'J' |
              c == 'K' |
              c == 'L' |
              c == 'M' |
              c == 'N' |
              c == 'O' |
              c == 'P' |
              c == 'Q' |
              c == 'R' |
              c == 'S' |
              c == 'T' |
              c == 'U' |
              c == 'V' |
              c == 'W' |
              c == 'X' |
              c == 'Y' |
              c == 'Z');
        }
        private static bool CheckGTINKey(string code)
        {
            bool result = false;
            int length = code.Length;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < 13; i++)
            {
                char c = array[i];
                if (int.TryParse(c.ToString(), out n))
                {
                    if (i % 2 == 0)
                    { // [fr] pair 
                        // [en] even
                        sum = sum + (3 * n);
                    }
                    else
                    { // [fr] impair 
                        // [en] odd
                        sum = sum + n;
                    }
                }
            }
            int n1 = (10 - (sum % 10)) % 10;
            int n2;
            char key = array[13];
            if (int.TryParse(key.ToString(), out n2))
                result = (n1 == n2);
            return result;
        }
        private static bool CheckHIBCKey(string code)
        {
            bool result = false;
            int sum = 0;
            char[] array = code.ToCharArray();
            int mod = 0;
            for (int i = 0; i < code.Length - 1; i++)
            {
                char c = array[i];
                sum = sum + nValuesAssignmets.IndexOf(c);
                //sum = sum + mod; 
            }
            mod = sum % 43;
            char lastCharCode = array[code.Length - 1];
            if (nValuesAssignmets[mod] == lastCharCode)
                result = true;
            return result;
        }
        private static bool CheckSSCCKey(string code)
        {
            bool result = false;
            int length = code.Length;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 2; i < 19; i++)
            {
                char c = array[i];
                if (int.TryParse(c.ToString(), out n))
                {
                    if (i % 2 == 0)
                    { // [fr] pair 
                        // [en] even
                        sum = sum + (3 * n);
                    }
                    else
                    { // [fr] impair 
                        // [en] odd
                        sum = sum + n;
                    }
                }
            }
            int n1 = (10 - (sum % 10)) % 10;
            int n2;
            char key = array[19];
            if (int.TryParse(key.ToString(), out n2))
                result = (n1 == n2);
            return result;
        }
        private static bool CheckEan13Key(string code)
        {
            bool result = false;
            int length = code.Length;
            if (length == 13)
            {
                int sum = 0;
                char[] array = code.ToCharArray();
                bool ok = true;
                for (int i = 0; i < 12; i++)
                {
                    char c = array[i];
                    int n;
                    if (int.TryParse(c.ToString(), out n))
                    {
                        if (i % 2 == 0)
                        { // [fr] pair 
                            // [en] even
                            sum = sum + n;
                        }
                        else
                        { // [fr] impair 
                            // [en] odd
                            sum = sum + (3 * n);
                        }
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    int n1 = (10 - (sum % 10)) % 10;
                    int n2;
                    char c = array[12];
                    if (int.TryParse(c.ToString(), out n2))
                    {
                        result = (n1 == n2);
                    }
                }
            }
            return result;
        }
        private static bool Check7Car(string code)
        {
            bool result = false;
            bool ok = true;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                for (int i = 0; i < 6; i++)
                {
                    char c = array[i];
                    if (int.TryParse(c.ToString(), out n))
                    {
                        sum = sum + n * (i + 2);
                    }
                }
                int n1 = (sum % 11) % 10;
                int n2;
                char key = array[6];
                if (int.TryParse(key.ToString(), out n2))
                    result = (n1 == n2);
            }
            return result;
        }
        private string Key7Car(string code)
        {
            string result = "-1";
            bool ok = true;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                for (int i = 0; i < 6; i++)
                {
                    char c = array[i];
                    if (int.TryParse(c.ToString(), out n))
                    {
                        sum = sum + n * (i + 2);
                    }
                }
                int n1 = (sum % 11) % 10;
                result = n1.ToString();
            }
            return result;
        }
        public string Family(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (code.Length >= 7)
            {
                if (subType == "ACL 13")
                    result = code.Substring(4, 1);
                else if ((type.StartsWith("GS1-")) & (subType.StartsWith("01") & (code.Substring(3, 4) == "3401")))
                {
                    result = code.Substring(7, 1);//TODO MB Controler Longueur code  testée à 7
                }
                else if ((type == "NaS") & ((subType == "002") | (subType == "003")))
                    result = code.Substring(4, 1);
            }
            return result;
        }
        private void Parse(string code)
        {
            if (code.Length > 0)
            {
                if ((result.Type == "GS1-128") | (result.Type == "GS1-Datamatrix"))
                {
                    if (code.StartsWith("@"))
                    {
                        code = code.Substring(1, code.Length - 1);
                    }

                    if (code.StartsWith("00"))
                    {
                        result.SubType = result.SubType + ".00";
                        result.SSCC = code.Substring(2, 18);
                        code = code.Substring(20, code.Length - 20);
                        Parse(code);
                    }
                    else if (code.StartsWith("01"))
                    {
                        result.SubType = result.SubType + ".01";
                        //Check if GTIN-13 or GTIN-14

                        result.GTIN = code.Substring(2, 14);
                        result.UDI = result.GTIN;
                        if (result.GTIN.StartsWith("03400"))
                        {
                            result.CIP = result.GTIN.Substring(1, 13);
                        }
                        else if (result.GTIN.StartsWith("03401"))
                        {
                            result.ACL = result.GTIN.Substring(1, 13);
                        }
                        code = code.Substring(16, code.Length - 16);
                        Parse(code);
                    }
                    else if (code.StartsWith("02"))
                    {
                        result.SubType = result.SubType + ".02";
                        result.CONTENT = code.Substring(2, 14);
                        code = code.Substring(16, code.Length - 16);
                        Parse(code);
                    }
                    else if (code.StartsWith("10"))
                    {
                        result.SubType = result.SubType + ".10";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.Lot = code.Substring(2, skip - 2);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("11"))
                    {
                        result.SubType = result.SubType + ".11";
                        result.PRODDATE = code.Substring(2, 6);
                        code = code.Substring(8, code.Length - 8);
                        Parse(code);
                    }
                    else if (code.StartsWith("15"))
                    {
                        result.SubType = result.SubType + ".15";
                        result.BESTBEFORE = code.Substring(2, 6);
                        code = code.Substring(8, code.Length - 8);
                        Parse(code);
                    }
                    else if (code.StartsWith("17"))
                    {
                        result.SubType = result.SubType + ".17";
                        result.Expiry = code.Substring(2, 6);
                        code = code.Substring(8, code.Length - 8);
                        Parse(code);
                    }
                    else if (code.StartsWith("20"))
                    {
                        result.SubType = result.SubType + ".20";
                        result.VARIANT = code.Substring(2, 2);
                        code = code.Substring(4, code.Length - 4);
                        Parse(code);
                    }
                    else if (code.StartsWith("21"))
                    {
                        result.SubType = result.SubType + ".21";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.Serial = code.Substring(2, skip - 2);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    //Obsolete in v16
                    else if (code.StartsWith("22"))
                    {

                    }

                    else if (code.StartsWith("30"))
                    {
                        result.SubType = result.SubType + ".30";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.VARCOUNT = code.Substring(2, skip - 2);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("37"))
                    {
                        result.SubType = result.SubType + ".37";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.COUNT = code.Substring(2, skip - 2);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("91"))
                    {
                        result.SubType = result.SubType + ".91";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_91 = code.Substring(2, skip - 2);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("92"))
                    {
                        result.SubType = result.SubType + ".92";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_92 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("93"))
                    {
                        result.SubType = result.SubType + ".93";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_93 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("94"))
                    {
                        result.SubType = result.SubType + ".94";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_94 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("95"))
                    {
                        result.SubType = result.SubType + ".95";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_95 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("96"))
                    {
                        result.SubType = result.SubType + ".96";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_96 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("97"))
                    {
                        result.SubType = result.SubType + ".97";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_97 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("98"))
                    {
                        result.SubType = result.SubType + ".98";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_98 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("99"))
                    {
                        result.SubType = result.SubType + ".99";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.INTERNAL_99 = code.Substring(2, skip - 2);
                        code = code.Substring(2, code.Length - skip);
                        Parse(code);
                    }
                    else if (code.StartsWith("240"))
                    {
                        result.SubType = result.SubType + ".240";
                        int skip = 0;
                        if (containsGS(code))
                        {
                            skip = indexOfGS(code, 0);
                        }
                        else
                        {
                            skip = code.Length;
                        }
                        result.ADDITIONALID = code.Substring(3, skip - 3);
                        code = code.Substring(skip, code.Length - skip);
                        Parse(code);
                    }
                    if (result.SubType.StartsWith("."))
                    {
                        result.SubType = result.SubType.Substring(1, result.SubType.Length - 1);
                    }
                }
                else if (result.Type == "HIBC")
                {
                    if (result.SubType == "")
                    {
                        code = code.Substring(1, code.Length - 1);
                        char[] array = code.ToCharArray();
                        if (Alphabetic(array[0]))
                        {
                            result.SubType = "Primary";
                            int position = code.IndexOf('/');
                            if ((position != -1) & (position != code.Length - 1))
                            {
                                result.SubType = result.SubType + @"/Secondary";
                            }
                        }
                        else
                        {
                            result.SubType = "Secondary";

                        }
                        Parse(code);
                    }
                    else
                    {
                        string secondaryASD = "";
                        if (result.SubType.StartsWith("Primary"))
                        {
                            int endPrimary = code.Length; //Just Primary
                            int position = code.IndexOf("/");

                            if (position != -1)
                            {
                                if (position < code.Length - 1)
                                {
                                    endPrimary = position + 1;
                                }
                            }

                            result.LIC = code.Substring(0, 4);
                            result.PCN = code.Substring(4, endPrimary - 6);
                            result.UoM = code.Substring(endPrimary - 2, 1);
                            result.UPN = result.LIC + result.PCN + result.UoM;
                            result.UDI = result.UPN;

                            code = code.Substring(endPrimary, code.Length - endPrimary);
                        }
                        if (result.SubType.Contains("Secondary"))
                        {
                            string secondaryF1 = "";

                            int endSecondaryF1 = code.Length - 1;

                            code = code.Substring(0, endSecondaryF1); //Delete Check Digit

                            if (!result.SubType.StartsWith("Primary"))
                            {
                                endSecondaryF1 = endSecondaryF1 - 1;
                                code = code.Substring(0, endSecondaryF1); // Delete eventually Link Digit
                            }

                            int position = code.IndexOf("/");

                            if (position != -1)
                            {
                                if (position < code.Length - 1)
                                {
                                    endSecondaryF1 = position;
                                }
                            }
                            secondaryF1 = code.Substring(0, endSecondaryF1);
                            secondaryASD = code.Substring(endSecondaryF1, code.Length - endSecondaryF1);

                            if (secondaryF1.Substring(0, 3) == "$$+")
                            {
                                result.SubType = result.SubType + ".$$+";
                                secondaryF1 = secondaryF1.Substring(3, secondaryF1.Length - 3);
                                //Date & S/N

                            }
                            else if (secondaryF1.Substring(0, 2) == "$$")
                            {
                                result.SubType = result.SubType + ".$$";
                                secondaryF1 = secondaryF1.Substring(2, secondaryF1.Length - 2);
                                if (secondaryF1.Substring(0, 1) == "8")
                                {
                                    result.SubType = result.SubType + ".8";
                                    result.Quantity = secondaryF1.Substring(1, 2);
                                    secondaryF1 = secondaryF1.Substring(3, secondaryF1.Length - 3);
                                }
                                else if (secondaryF1.Substring(0, 1) == "9")
                                {
                                    result.SubType = result.SubType + ".9";
                                    result.Quantity = secondaryF1.Substring(1, 5);
                                    secondaryF1 = secondaryF1.Substring(6, secondaryF1.Length - 6);
                                }
                                //Date & Lot
                            }
                            else if (secondaryF1.Substring(0, 1) == "$")
                            {
                                result.SubType = result.SubType + ".$";
                                secondaryF1 = secondaryF1.Substring(1, secondaryF1.Length - 1);
                            }
                            else
                            {
                                result.SubType = result.SubType + ".N";
                                result.Expiry = secondaryF1.Substring(0, 5);
                                result.Lot = secondaryF1.Substring(5, secondaryF1.Length - 5);
                            }

                            if (result.SubType.Contains(".$$"))
                            {
                                string expDateFlag = secondaryF1.Substring(0, 1);
                                int dateLength = 4;
                                int shift = 1;
                                switch (expDateFlag)
                                {
                                    case "2":
                                        {
                                            result.SubType = result.SubType + "." + expDateFlag;
                                            dateLength = 6;
                                            break;
                                        }
                                    case "3":
                                        {
                                            result.SubType = result.SubType + "." + expDateFlag;
                                            dateLength = 6;
                                            break;
                                        }
                                    case "4":
                                        {
                                            result.SubType = result.SubType + "." + expDateFlag;
                                            dateLength = 8;
                                            break;
                                        }
                                    case "5":
                                        {
                                            result.SubType = result.SubType + "." + expDateFlag;
                                            dateLength = 5;
                                            break;
                                        }
                                    case "6":
                                        {
                                            result.SubType = result.SubType + "." + expDateFlag;
                                            dateLength = 7;
                                            break;
                                        }
                                    default:
                                        {
                                            shift = 0;
                                            break;
                                        }
                                }
                                result.Expiry = secondaryF1.Substring(shift, dateLength);
                                secondaryF1 = secondaryF1.Substring(shift + dateLength, secondaryF1.Length - shift - dateLength);
                            }

                            if (result.SubType.Contains("$$+"))
                            {
                                result.Serial = secondaryF1;
                            }
                            else if ((result.SubType.Contains("$$")) | result.SubType.Contains(".$"))
                            {
                                result.Lot = secondaryF1;
                            }


                        }
                        if (secondaryASD.Length > 0) //code ASD
                        {
                            char[] charSeparators = new char[] { '/' };
                            string[] parties = secondaryASD.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                            int count = parties.Length;

                            foreach (string item in parties)
                            {
                                string asd1 = item.Substring(0, 1); //
                                string asd3 = string.Empty;
                                if (item.Length > 2)
                                {
                                    asd3 = item.Substring(0, 3); //
                                }

                                int endData = item.Length;


                                switch (asd1)
                                {
                                    case "L": //Storage location
                                        {
                                            result.SubType = result.SubType + ".L";
                                            result.StorageLocation = item.Substring(1, endData - 1);
                                            break;
                                        }
                                    case "S":
                                        {
                                            result.SubType = result.SubType + ".S";
                                            result.Serial = item.Substring(1, endData - 1);
                                            break;
                                        }
                                }
                                switch (asd3)
                                {
                                    case "14D":
                                        {
                                            result.SubType = result.SubType + ".14D";
                                            result.Expiry = item.Substring(3, endData - 3);
                                            break;
                                        }
                                    case "16D":
                                        {
                                            result.SubType = result.SubType + ".16D";
                                            result.PRODDATE = item.Substring(3, endData - 3);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
                else if (result.Type == "EAN 13")
                {
                    result.EAN = code;
                    result.GTIN = code;

                    if (code.Substring(0, 4) == "3401")
                    {
                        result.SubType = "ACL 13";
                        result.ACL = code;
                    }
                    else if (code.Substring(0, 4) == "3400")
                    {
                        result.SubType = "CIP 13";
                        result.CIP = code;
                    }

                    //Obsolete
                    /*
                    if (code.Substring(0, 4) == "3401")
                    {
                        result.SubType = "ACL 13";
                        result.ACL = code;
                    }
                    else if (code.Substring(0, 4) == "3400")
                    {
                        result.SubType = "CIP 13";
                        result.CIP = code;
                    }
                    else
                    {
                        result.Company = code.Substring(0, 7);
                        result.Product = code.Substring(7, 5);
                    }
                    */
                }
                else if (result.Type == "NaS")
                {
                    if (code.Length == 7)
                        if (Check7Car(code))
                        {
                            // 9641309
                            result.SubType = "NaS7";
                            result.NaS7 = code;
                        }

                    if (code.Length == 19)
                    {
                        string subLeftCode = code.Substring(0, 13);
                        if (CheckEan13Key(subLeftCode))
                        {
                            // 4022495007216119361
                            result.SubType = "001"; // EAN 13 and LPP without checksum
                            result.EAN = subLeftCode;
                            //result.Company = code.Substring(0, 7);
                            //result.Product = code.Substring(7, 5);
                            result.LPP = code.Substring(13, 6) + Key7Car(code.Substring(13, 6));
                        }
                    }
                    if (code.Length == 20)
                    {
                        string subLeftCode = code.Substring(0, 13);
                        string subRightCode = code.Substring(13, 7);
                        if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & code.StartsWith("3401"))
                        {
                            // 34010798755871393295
                            result.SubType = "002"; // ACL 13 and LPP
                            result.ACL = subLeftCode;
                            result.LPP = code.Substring(13, 7);
                        }
                    }
                    if (code.Length == 21)
                    {
                        string subLeftCode = code.Substring(0, 13);
                        string subRightCode = code.Substring(14, 7);
                        if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & code.StartsWith("3401"))
                        {
                            // 3401079875587 1393295
                            result.SubType = "003"; // ACL 13 and LPP with Espace
                            result.ACL = subLeftCode;
                            result.LPP = subRightCode;
                        }
                    }
                    if (code.Length == 20)
                    {
                        string subLeftCode = code.Substring(0, 13);
                        string subRightCode = code.Substring(13, 7);
                        if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & !code.StartsWith("3401"))
                        {
                            // 40224950072161139964
                            result.SubType = "004"; // EAN 13 and LPP
                            //result.Company = code.Substring(0, 7);
                            //result.Product = code.Substring(7, 5);
                            result.EAN = subLeftCode;
                            result.LPP = subRightCode;
                        }
                    }
                    if (code.Length == 28)
                    {
                        if ((code.Substring(20, 1) == " ") & (code.Substring(25, 1) == "-"))
                        {
                            // ASK +20.0 1102745059 2016-05
                            result.SubType = "005"; // Chris Eyes Company
                            result.Reference = code.Substring(0, 9);
                            result.Serial = code.Substring(10, 10);
                            result.Expiry = code.Substring(21, 7);
                        }
                    }
                    if (code.Length == 17)
                    {
                        string maybeLot = code.Substring(11, 6);
                        bool ok = NumericString(maybeLot);
                        if ((ok) & (code.Substring(10, 1) == " "))
                        {
                            // FBIOW8D160 102223
                            result.SubType = "006"; // COUSIN BIOSERV Company
                            result.Reference = code.Substring(0, 10);
                            result.Lot = maybeLot;
                        }
                    }
                    if (code.Length == 22)
                    {
                        string maybeRef = code.Substring(0, 8);
                        string maybeLot = code.Substring(8, 8);
                        string maybeExpiry = code.Substring(16, 6);
                        bool ok1 = NumericString(maybeRef);
                        bool ok2 = NumericString(maybeExpiry);
                        bool ok3 = !NumericString(maybeLot);
                        if (ok1 & ok2 & ok3)
                        {
                            // 58562152ANTL0294122012
                            result.SubType = "007"; // BARD France Company
                            result.Reference = maybeRef;
                            result.Lot = maybeLot;
                            result.Expiry = maybeExpiry;
                        }
                    }
                    // Obsolete
                    //if (code.Length == 28)
                    //{
                    //    bool ok = NumericString(code);
                    //    if (ok)
                    //        result = "008"; // PHYSIOL France Company (Example: 2808123005365310060911306301)
                    //}                                                   //  28081230 053653 10060911306301
                    if (code.Length >= 8)
                    {
                        if (!NumericString(code) & (code.Substring(0, 4) == "PAR-"))
                        {
                            // PAR-1234-AB
                            result.SubType = "009"; //  Arthrex Company
                            result.Reference = code.Substring(1, code.Length - 1);
                        }
                    }
                    // Obsolete
                    //if (code.Length == 7)
                    //{
                    //    if (NumericString(code.Substring(1, 6)) & (code.Substring(0, 1) == "T"))
                    //    {
                    //        result.SubType = "010"; //  Arthrex Company (Example: T123456)
                    //        result.Reference = "";
                    //    }
                    //}
                    // Obsolete
                    //if (code.Length == 2)
                    //{
                    //    if (NumericString(code.Substring(1, 1)) & (code.Substring(0, 1) == "Q"))
                    //        result = "011"; //  Arthrex Company (Example: Q1)
                    //}
                    // Obsolete
                    //if (code.Length > 10)
                    //{
                    //  if (NumericString(code.Substring(3, 6)) & (code.Substring(0, 3) == "SEM") & (code.Substring(9, 1) == "^"))
                    //    result = "012"; //  SEM (Sciences Et Medecine) Company (Example: SEM171252^P30778E4009A)
                    //}
                    if (code.Length > 10)
                    {
                        if ((code.Substring(0, 3) == "SEM") & (code.Substring(9, 2) == "^P") & (Regex.IsMatch(code.Substring(code.Length - 1, 1), @"^[a-zA-Z]+$")))
                        {
                            // SEM171252^P30778E4009A
                            result.SubType = "012"; //  SEM (Sciences Et Medecine)
                            result.Reference = code.Substring(3, 6);
                            result.Lot = code.Substring(code.IndexOf('^') + 1, code.Length - code.IndexOf('^') - 2);
                        }
                    }
                    if (code.Length == 14)
                    {
                        if (NumericString(code.Substring(6, 8)) & (code.Substring(0, 1) == " ") & (code.Substring(5, 1) == "-"))
                        {
                            //  BF01-11018180
                            result.SubType = "013"; // ABS BOLTON Company
                            result.Reference = code.Substring(1, 13);
                        }
                    }
                    if (code.Length == 10)
                    {
                        if (NumericString(code.Substring(5, 5)) & (code.Substring(0, 5) == "CPDR "))
                        {
                            // CPDR 24602
                            result.SubType = "014"; // CHIRURGIE OUEST / EUROSILICONE / SORMED Company
                            result.Reference = code.Substring(0, 4) + code.Substring(5, 5);
                        }
                    }
                    if (code.Length == 17)
                    {
                        if ((code.Substring(4, 1) == "-") & (code.Substring(15, 1) == "-"))
                        {
                            //To Do : waiting for Symbios answer
                            // H080-25.01.2014-1
                            result.SubType = "015"; // Symbios Orthopédie
                            result.Reference = "";
                            result.Expiry = "";
                        }
                    }
                    if (code.Length == 24)
                    {
                        if (NumericString(code.Substring(18, 6)))
                        {
                            // ]C0FR04052CFZF3015237141231
                            result.SubType = "016"; // Teleflex / Arrow
                            result.Reference = code.Substring(0, 9);
                            result.Lot = code.Substring(9, 9);
                            result.Expiry = code.Substring(18, 6);
                        }
                    }
                    if (code.Length == 14)
                    {
                        if (NumericString(code.Substring(0, 9)) & (code.Substring(10, 1) == " "))
                        {
                            // ]C01401788197 001
                            result.SubType = "017"; // FCI
                            result.Lot = code.Substring(0, 7);
                            result.Expiry = code.Substring(7, 3);
                        }
                    }
                    if (result.SubType == "")
                    {
                        result.SubType = "NaS";
                        result.Reference = code;
                    }
                }

            }
        }
        public bool containsOrMayContainId(string code, string type, string subType)
        {
            bool result = false;
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            if (type.StartsWith("GS1-"))
            {
                if (subType.Contains("01") |
                    subType.Contains("240") |
                    subType.Contains("90") |
                    subType.Contains("91") |
                    subType.Contains("92") |
                    subType.Contains("93"))
                    result = true;
            }
            else if ((type == "HIBC") & (subType.Contains("Primary")))
            {
                result = true;
            }
            else if ((type == "NaS") & (code.Length > 0)) // To support case where just the SymbologyID is provided
            {
                if (subType == "" |
                     subType == "NaS" |
                     subType == "NaS7" |
                     subType == "001" |
                     subType == "002" |
                     subType == "003" |
                     subType == "004" |
                     subType == "005" |
                     subType == "006" |
                     subType == "007" |
                     subType == "008" |
                     subType == "009" |
                     subType == "012" |
                     subType == "013" |
                     subType == "014" |
                     subType == "016")
                    result = true;
            }
            else if (type == "EAN 13")
            {
                result = true;
            }
            return result;
        }
        public string NaSIdParamName(string type, string subType)
        {
            string result = "";
            if (type == "NaS")
            {
                if (subType == "NaS7")
                    result = "NaS7";
                else if (subType == "001" |
                         subType == "004")
                    result = "EAN";
                else if (subType == "002" |
                         subType == "003")
                    result = "ACL";
            }
            return result;
        }
        public string Type(string code)
        {
            string result = "NaS";
            int length = code.Length;
            code = Cleanse(code);
            if ((length > 5) && code.StartsWith("]C1"))
            {
                string ai2 = code.Substring(3,2);
                string ai3 = code.Substring(3, 3);
                if (gs1AIList.Contains(ai2) | gs1AIList.Contains(ai3))
                {
                    result = "GS1-128";
                }
            }

            else if ((length > 5) && code.StartsWith("]d2"))
            {
                string ai2 = code.Substring(3, 2);
                string ai3 = code.Substring(3, 3);
                if (gs1AIList.Contains(ai2) | gs1AIList.Contains(ai3))
                {
                    result = "GS1-Datamatrix";
                }
            }

            else if ((code.StartsWith("]d1+") | (code.StartsWith("]C0+") | code.StartsWith("]A0+") | code.StartsWith("+"))))
            {
                code = CleanSymbologyId(code);
                if (CheckHIBCKey(code))
                    result = "HIBC";
            }
            else if (code.StartsWith("]E0"))
            {
                code = CleanSymbologyId(code);
                length = code.Length;
                if (length == 13 && CheckEan13Key(code))
                {
                    result = "EAN 13";
                }
            }
            else if (length == 13 && CheckEan13Key(code))
            {
                result = "EAN 13";
            }

            else if ((length >= 20) && (code.StartsWith("00")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 20; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckSSCCKey(code))
                    {
                        result = "GS1-128";
                    }
                }
            }
            else if ((length >= 16) && (code.StartsWith("01")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 16; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckGTINKey(code.Substring(2, 14)))
                    {
                        result = "GS1-128";
                    }
                }
            }
            else if ((length >= 16) && (code.StartsWith("02")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 16; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckGTINKey(code.Substring(2, 14)))
                    {
                        result = "GS1-128";
                    }
                }
            }

            //else if ((length >= 10) && code.StartsWith("11"))
            //{
            //    if ((code.Substring(8, 2).Equals("17")) & (length >= 16))
            //        if ((code.Substring(16, 2).Equals("10")) & (length >= 18))
            //            result = "GS1-128";
            //}
            // This conditions is not enough strong
            //else if (code.StartsWith("17") & (length >= 11))
            //{
            //  string ai2 = code.Substring(8, 2);
            //  if ((ai2 == "10") | (ai2 == "30") | (ai2 == "21"))
            //    result = "GS1-128";
            //}

            // This conditions is not enough strong
            //else if (code.StartsWith("20") & (length >= 6))
            //{
            //  string ai2 = code.Substring(4, 2);
            //  if (ai2 == "17")
            //    result = "GS1-128";
            //}

            //else if ((code.StartsWith("240") & (length >= 4)))
            //{
            //  result = "GS1-128";
            //}
            else if (containsGS(code))
            {
                result = "GS1-128";
                // int testposition = indexOfBL(code, 0);
            }
            return result;
        }
        private static bool CheckParsing(InformationSet analyse)
        {
            bool result = false;

            //GTIN, SSCC, CONTENT, CIP, EAN, LPP, Quantity, UoM, VARCOUNT, COUNT
            //GTIN
            if ((analyse.GTIN.Length == 13) | (analyse.GTIN.Length == 14))
            {
                if(analyse.Type=="EAN 13")
                {
                    if (CheckEan13Key(analyse.GTIN) & CheckEan13Key(analyse.EAN))
                    {
                        result = true;
                    }
                }
                else if ((analyse.Type.Contains("GS1") & analyse.SubType.Contains("01")))
                {
                    if (CheckGTINKey(analyse.GTIN))
                    {
                        result = true;
                    }
                }
            }
            
            //Todo
            result = true;

            return result;
        }
        public InformationSet GetFullInformationSet(string code)
        {
            try
            {
                code = Cleanse(code);
                result.Type = Type(code);
                result.SymbologyID = SymbologyID(code);
                code = CleanSymbologyId(code);

                Parse(code);

                result.ContainsOrMayContainId = containsOrMayContainId(code, result.Type, result.SubType);
                result.NaSIdParamName = NaSIdParamName(result.Type, result.SubType);

                if (result.Expiry != "")
                {
                    result.NormalizedExpiry = NormalizedDate(result.Expiry, result.Type, result.SubType);
                }
                if (result.PRODDATE != "")
                {
                    result.NormalizedPRODDATE = NormalizedDate(result.PRODDATE, result.Type, result.SubType);
                }

                if (result.BESTBEFORE != "")
                {
                    result.NormalizedBESTBEFORE = NormalizedDate(result.BESTBEFORE, result.Type, result.SubType);
                }
                result.Family = Family(code, result.Type, result.SubType);

                if (CheckParsing(result))
                {
                    result.AdditionalInformation = "No errors detected!";
                }
                else
                {
                    result.AdditionalInformation = "Errors detected!";
                }
            }
            catch (Exception e)
            {
                result.executeResult = -1;
                result.AdditionalInformation = e.Message;
            }

            return result;
        }
    }
}