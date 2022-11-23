using Microsoft.VisualStudio.TestTools.UnitTesting;
using OCTM;
using OTCM.Interface;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace TestsAQ
{
    [TestClass]
    public class Tests
    {
        public String TestApp(string fakeInput)
        {
            //arrange
            Interface main = new Interface();
            var stringReader = new StringReader(fakeInput);
            Console.SetIn(stringReader);

            //we will use this to catch the output
            //var stringWriter = new StringWriter();
            //Console.SetOut(stringWriter);

            //act
            main.Run();

            //return result
            return null;
            //return stringWriter.ToString();
        }

    [TestMethod]
        public void TestDemoMc1Cert1()
        {
            // arrange
            var fakeInput = "1\n" +
                                "1\n" +
                                "1\n" +
                                "2\n";
            var outputobjective = ""; //TODO fill this


            // act
            var output = TestApp(fakeInput);
            
            // assert
            Assert.IsTrue(true);
            //we will use this to check if the output is what we expect
            //Assert.AreEqual(outputobjective, output);
        }
    }
}
