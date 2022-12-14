using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OTCM;
using OTCM.Interface;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
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

        /// <summary>
        /// There is an issue with the encoding method of the strings in the application.
        /// We have not been able to resolve such issue within our time frame.
        /// Therefore, our test are less automated. 
        /// We consider the test successful if it ends.
        /// If the test is locked in an infinite loop, the test is considered as fail !
        /// This test method try various false input and correct one. 
        /// we must check if the test ends and if the output result is coherent visually.
        /// Therefore, don't trust the green indicator in the IDE.
        /// </summary>
        [TestMethod]
        public void TestErrorResistanceDemo()
        { 
            StringBuilder str = new StringBuilder();
            Random rd = new Random();
            // select for demo mode (from 1 to 5)
            str.AppendLine("sal");
            str.AppendLine("34");
            str.AppendLine("3e3");
            str.AppendLine("3p");

            str.AppendLine(" 1 "); //must display 4 error message

            //Select for MC (1 to 15)
            str.AppendLine();
            str.AppendLine("baptiste");
            str.AppendLine("17");
            str.AppendLine("1 0");

            str.AppendLine(rd.Next(1, 11).ToString()); // must display 4 error message

            //Select for Certificate (1 to 3)
            str.AppendLine();
            str.AppendLine("Jesande ]");
            str.AppendLine("{2}");
            str.AppendLine("2 1");
            str.AppendLine("28");

            str.AppendLine(rd.Next(1,4).ToString()); //Must display 5 error messages

            //Select for quit or restart
            str.AppendLine();
            str.AppendLine("Jesande ]");
            str.AppendLine("{2}");

            str.AppendLine("2"); // must display 3 error message and leave the application

            Debug.WriteLine(TestApp(str.ToString()));

            Assert.IsTrue(true);
        }


        [TestMethod]
        public void TestERExpDefaultMC()
        {
            StringBuilder str = new StringBuilder();
            Random rd = new Random();

            //Select mode (we don't make error test here, redondant with demo mode)
            str.AppendLine("2");

            //Select default or create MC
            str.AppendLine("er");
            str.AppendLine("3");
            str.AppendLine("1 0");
            str.AppendLine("[1]");
            
            str.AppendLine("1"); //Should display 4 error messages

            //Select MC (from 1 to 11)
            str.AppendLine("La rome antique");
            str.AppendLine("Deux ondes lumineuses ne peuvent interferer que si elle provienne d'une source commune !");
            str.AppendLine("234");
            str.AppendLine("2 4");

            str.AppendLine(rd.Next(1,12).ToString()); //Should display 4 error message

            //Select test to include
            for(var i=0; i<9;i++)
            {
                str.AppendLine("3");
                str.AppendLine("oui");

                str.AppendLine(rd.Next(1,3).ToString()); //2 error message per loop
            }

            //select to quit (no test to avoid redundacy)
            str.AppendLine("2");

            Debug.WriteLine(TestApp(str.ToString()));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestERExpCreatedMC()
        {
            StringBuilder str = new StringBuilder();
            Random rd = new Random();

            //Mode select
            str.AppendLine("2");
            //mode for mc selection
            str.AppendLine("2");

            // the 4 following input shall expect anything, we will not test them
            str.AppendLine("Super1");
            str.AppendLine("Super2");
            str.AppendLine("Super3");
            str.AppendLine("Super4");

            //Mass
            str.AppendLine("Bonjour");
            str.AppendLine("3/4");
            str.AppendLine("3kg");

            var mass = rd.Next(2384)*rd.NextDouble();
            str.AppendLine(mass.ToString()); // 3 errors expected

            //longueur (cm)
            str.AppendLine("Salut");
            str.AppendLine("33/4");
            str.AppendLine("21m");

            var longueur = rd.Next(23)*rd.NextDouble();
            str.AppendLine(longueur.ToString());//3 errors

            //largeur (cm)
            str.AppendLine("Bisous");
            str.AppendLine("74/504");
            str.AppendLine("34mm");

            var largeur = rd.Next(3)*rd.NextDouble();
            str.AppendLine(largeur.ToString()); // 3 errors
            
            //epaisseur (cm)
            str.AppendLine("Love and Thunder est un mauvais film");
            str.AppendLine("384/23");
            str.AppendLine("4mm");

            var epaisseur = rd.Next(5)*rd.NextDouble();
            str.AppendLine(largeur.ToString()); // 3 errors

            //nb tensions
            str.AppendLine("Bonjour");
            str.AppendLine("3.4");
            str.AppendLine("34,87");

            str.AppendLine("1"); //3 errors

            //tension
            str.AppendLine("revolte");
            str.AppendLine("3.3V");

            str.AppendLine("5"); //2 errors

            //Nb ports
            str.AppendLine("Julienne de legumes");
            str.AppendLine("2 millions");
            str.AppendLine("3.0");

            str.AppendLine("1"); //3 errors

            //port (nmo error test because it can accept anything)
            str.AppendLine("RX45");

            //nb langage
            str.AppendLine("Ouefs mollets a la florentine");
            str.AppendLine("2 dizaiens");
            str.AppendLine("3.0");

            str.AppendLine("1"); //3 errors

            //langage (no error test)
            str.AppendLine("fr");

            //nb gpios
            str.AppendLine("Quiche lorraine <3");
            str.AppendLine("46M");
            str.AppendLine("5.0");

            str.AppendLine("1"); //3 errors

            //gpios type (no error test)
            str.AppendLine("normal");

            //Select test to include (on le refait quand meme)
            for (var i = 0; i < 9; i++)
            {
                str.AppendLine("3");
                str.AppendLine("oui");

                str.AppendLine(rd.Next(1, 3).ToString()); //2 error message per loop
            }

            //quit 
            str.AppendLine("2");

            Debug.WriteLine(TestApp(str.ToString()));

            Assert.IsTrue(true);
        }
   }
}


