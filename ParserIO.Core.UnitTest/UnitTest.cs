using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserIO.Core.UnitTest
{
    [TestClass]
    public class type_UT
    {
        ParserIO.Core.Functions client = new ParserIO.Core.Functions();

        [TestMethod]
        [TestCategory("Cat1")]
        [Description("To test type method with GS1-128 structure")]
        public void TestMethod1()
        {
            string type = "";
            string exp_type = "NaS";
            string barcode = "";
            try
            {
                type = client.Type(barcode);
            }
            catch
            {

            }
            finally
            {
                Assert.AreEqual(exp_type, type, "type");
            }
        }
    }
}
