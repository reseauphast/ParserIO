using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParserIO_functions;

namespace ParserIO_functions_Test
{
    [TestClass]
    public class type_UT
    {
        ParserIO_func parser = new ParserIO_func();
      
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
               type = parser.Type(barcode);
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
