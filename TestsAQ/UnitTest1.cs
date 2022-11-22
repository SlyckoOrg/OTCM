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
        public static void TestApp()
        {
            Console.WriteLine("Starting app");
            Interface main = new Interface();

            main.Run();
            Console.WriteLine("app execution finished");
        }

    [TestMethod]
        public void TestMethod1()
        {

            //arrange

            Interface main = new Interface();
            var fakeInput =     "1\n" +
                                "1\n" +
                                "1\n" +
                                "2\n";
            var outputobjective = ""; //TODO fill this

            var stringReader = new StringReader(fakeInput);
            Console.SetIn(stringReader);

            //we will use this to catch the output
            //var stringWriter = new StringWriter();
            //Console.SetOut(stringWriter);

            //act

            main.Run();

            Assert.IsTrue(true);

            //assert

            //we will use this to check if the output is what we expect
            //var output = stringWriter.ToString();
            //Assert.AreEqual(outputobjective, output);
        }
    }
}
