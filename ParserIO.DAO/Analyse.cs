using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserIO.DAO
{
    public class Analyse // : InformationSet
    {
        private int _AnalyseId;
        private string _Barcode;
        private string _Commentary;
        private DateTime _TimeStamp;
        public InformationSet InformationSet;

        public int AnalyseId
        {
            get { return _AnalyseId; }
            set { _AnalyseId = value; }
        }
        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; }
        }
        public string Commentary
        {
            get { return _Commentary; }
            set { _Commentary = value; }
        }
        public DateTime TimeStamp
        {
            get { return _TimeStamp; }
            set { _TimeStamp = value; }
        }

        public Analyse()
        {
            InformationSet = new InformationSet();
        }
    }
}
