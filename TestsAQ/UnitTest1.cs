using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTCM;
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
            Interface main = new Interface(true);

            var stringReader = new StringReader(fakeInput);
            Console.SetIn(stringReader);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //act
            main.Run();
            //return result
            return stringWriter.ToString();
        }
/*
        [TestMethod]
        public void TestDemoMc1Cert1()
        {
            // arrange
            string fakeInput = "1\n" +
                                "1\n" +
                                "1\n" +
                                "2\n";
            string outputobjective = "       ___                         ___           ___\r\n      /\\  \\                       /\\__\\         /\\  \\\r\n     /::\\  \\         ___         /:/  /        |::\\  \\\r\n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\\r\n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\\r\n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\\r\n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\r\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\\r\n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\\r\n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\\r\n      \\/__/           \\/__/       \\/__/         \\/__/\r\n  Outil de Test et de Certification pour Microcontrôleurs\r\n\r\n[OTCM] Veuillez sélectionner un mode\r\n    1- Mode démonstration    2- Mode expérience    3- Reset les microcontrôleurs par défauts    4- Afficher les microcontrôleurs\r\n    5- Aide\r\n1\r\n[OTCM] Veuillez choisir le microcontrôleur à utiliser\r\n    1- MC1    2- MC2    3- MC3    4- MC4\r\n    5- MC5    6- MC6    7- MC7\r\n1\r\n[OTCM] Veuillez choisir un certificat\r\n    1- Certificat #1    2- Certificat #2    3- Certificat #3\r\n1\r\n[OTCM] Lancement des tests\r\n-----                25%\r\nTest actuel:[Test 1 - Polyvalence Électrique]\r\n   - Le microcontrôleur supporte les alimentations 3V et 5V\r\n\r\n[OTCM] Échec de la certification\r\n[OTCM] Veuillez effectuer un choix parmis les options suivantes\r\n    1- Relancer le programme    2- Quitter le programme\r\n2\r\n"; //TODO fill this


            // act
            string output = TestApp(fakeInput);

            // assert
            Assert.AreEqual(outputobjective, output);
        }
*/
        [TestMethod]
        public void TestAllDemoEnd()
        {
            string fakeInputA = "1\n";
            string fakeInputD = "2\n";
            for (int i = 1; i < 4; i++)
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


        [TestMethod]
        public void TestMCCreation()
        {
            string FakeInputMode = "2\n" + "2\n";
            string FakeInputMC = "Raspberry PI\nRP4000\ncircuit python\nCarte SD\n40\n5\n1\n0,5\n2\n3,3\n5\n2\nHDMI\nMICRO-USB\n1\nC++\n5\nDATA\nDATA\nGRN\nGRN\nOTHER\n";
            string FakeInputCertificat = "1\n1\n1\n2\n2\n2\n2\n2\n2\n2\n";

            string FakeInput = FakeInputMode + FakeInputMC + FakeInputCertificat;

            TestApp(FakeInput);

            Assert.IsTrue(true);
        }

    }
}


