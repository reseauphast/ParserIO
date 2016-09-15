using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParserIO.DAO
{
    public class Barcodestore
    {
        public string Version;
        public string ProviderName;
        public string ProviderVersion;
        public List<Analyse> Analyses { get; set; }
        
        //private string _version;
        //public string Version
        //{
        //    get { return _version; }
        //    set { _version = value; }
        //}
    }
}
