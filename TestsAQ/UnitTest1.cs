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
 
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            main.Run();
            //return result
            return stringWriter.ToString();
        }

    [TestMethod]
        public void TestDemoMc1Cert1()
        {
            // arrange
            string fakeInput = "1\n" +
                                "1\n" +
                                "1\n" +
                                "2\n";
            string outputobjective = "\u001b[1;34m       ___                         ___           ___     \r\n      /\\  \\                       /\\__\\         /\\  \\ \r\n     /::\\  \\         ___         /:/  /        |::\\  \\   \r\n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \r\n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \r\n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \r\n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\r\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \r\n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \r\n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \r\n      \\/__/           \\/__/       \\/__/         \\/__/    \r\n  Outil de Test et de Certification pour Microcontrôleurs\r\n\u001b[0m\r\n\u001b[1;94m[OTCM] \u001b[0mVeuillez sélectionner un mode\r\n\u001b[1;32m    1- Mode démonstration    2- Mode expérience    3- Resauvegarder les microcontrôleurs    4- Afficher les microcontrôleurs\r\n\u001b[1;0m\r\n\u001b[1;94m[OTCM] \u001b[0mVeuillez choisir le microcontrôleur à utiliser\r\n\u001b[1;32m    1- MC1    2- MC2    3- MC3\u001b[1;0m\r\n\u001b[1;94m[OTCM] \u001b[0mVeuillez choisir un certificat\r\n\u001b[1;32m    1- Certificat #1    2- Certificat #2    3- Certificat #3\u001b[1;0m\r\n\u001b[1;94m[OTCM] \u001b[0m\u001b[1;34mLancement des tests\u001b[1;0m\r\n\u001b[1;94m[OTCM] \u001b[0m\u001b[1;33mÉchec de la certification\u001b[1;0m\r\n\u001b[1;94m[OTCM] \u001b[0mVeuillez effectuer un choix parmis les options suivantes\r\n\u001b[1;32m    1- Relancer le programme    2- Quitter le programme\u001b[1;0m"; //TODO fill this


            // act
            string output = TestApp(fakeInput);
            
            // assert
            Assert.AreEqual(outputobjective, output);
        }

        [TestMethod]
        public void TestAllDemoEnd()
        {
            string fakeInputA = "1\n";
            string fakeInputD = "2\n";
            for (int i = 1; i<4; i++)
            {
                string fakeInputB = i.ToString() + "\n";
                for (int j = 1; j < 4; j++)
                {
                    string fakeInputC = j.ToString() + "\n";

                    string fakeInput = fakeInputA + fakeInputB + fakeInputC + fakeInputD;
                    TestApp(fakeInput);
                }
            }
            Assert.IsTrue(true);
        }
    }
}
