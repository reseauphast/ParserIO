namespace ParserIO.WCF.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "+M150AR1588RT2E";
            DAO.InformationSet result = new DAO.InformationSet();
            ParserIOClient client = new ParserIOClient("BasicHttpBinding_IParserIO");
            result = client.GetFullInformationSet(code);
        }
    }
}
