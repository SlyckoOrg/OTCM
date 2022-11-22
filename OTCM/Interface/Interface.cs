using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using a;

namespace OTCM.Interface
{
    public class Interface
{
    // Startup title
    private string _title =
        "\u001b[1;34m       ___                         ___           ___     \n      /\\  \\                       /\\__\\         /\\  \\ \n     /::\\  \\         ___         /:/  /        |::\\  \\   \n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \n      \\/__/           \\/__/       \\/__/         \\/__/    \n  Outil de Test et de Certification pour Microcontrôleurs\n\u001b[0m";

    // UI tools
    private Tools _tools = new Tools("OTCM", Environment.CurrentDirectory + "//log.json");
    
    // Certifier main component
    private Certifier _certifier = new Certifier();
    
    // Number of ran tests
    private uint _testId = 0;

    // Main loop
    public void Run()
    {
        // Title display
        Console.WriteLine(_title);
        while (true)
        {
            uint mode = _tools.Select(new string[] { "Mode démonstration", "Mode expérience", "Resauvegarder les microcontrôleurs", "Afficher les microcontrôleurs"},
                "Veuillez sélectionner un mode");

            switch (mode)
            {
                case 1:
                    RunFirstMode();
                    break;
                case 2:
                    RunSecondMode();
                    break;
                case 3:
                    SaveAllMCG();
                    break;
                case 4 :
                    DisplayMCG();
                    break;
                default:
                    _tools.Log("Une erreur c'est produite", "ERROR");
                    return;
            }

            uint next = _tools.Select(new string[] { "Relancer le programme", "Quitter le programme" },
                "Veuillez effectuer un choix parmis les options suivantes");

            switch (next)
            {
                case 1:
                    break;
                case 2:
                    return;
                default:
                    _tools.Log("Une erreur c'est produite", "ERROR");
                    return;
            }

        }
    }

    private void DisplayMCG()
    {
        _certifier.ReadMCGFile();
    }

    private void SaveAllMCG()
    {
        _certifier.SaveMCG(new Adapter1(new MC1()));
        _certifier.SaveMCG(new Adapter2(new MC2()));
        _certifier.SaveMCG(new Adapter3(new MC3()));
    }

    // Demo mode branch
    private void RunFirstMode()
    {
        // Request microcontroller
        uint microController = _tools.Select(new string[] { "MC1", "MC2", "MC3" },
            "Veuillez choisir le microcontrôleur à utiliser");

        MCG mc;
        switch (microController)
        {
            case 1:
                mc = new Adapter1(new MC1());
                break;
            case 2:
                mc = new Adapter2(new MC2());
                break;
            case 3:
                mc = new Adapter3(new MC3());
                break;
            default:
                _tools.Log("Une erreur c'est produite", "ERROR");
                return;
        }
        _certifier.AddMCG(mc);
        
        // Request certificate
        uint certificate = _tools.Select(new string[] { "Certificat #1", "Certificat #2", "Certificat #3" },
            "Veuillez choisir un certificat");

        Certificate crt;
        switch (certificate)
        {
            case 1:
                // Certificate #1
                crt = new Certificate(new List<ITestable>{ new Test1(), new Test2(), new Test3(), new Test4() }, mc);
                break;
            case 2:
                // Certificate #2
                crt = new Certificate(new List<ITestable>{ new Test5(), new Test6(), new Test7(), new Test8() }, mc);
                break;
            case 3:
                // Certificate #3
                crt = new Certificate(new List<ITestable>
                {
                    new Test1(), new Test3(), new Test5(), new Test7(),
                    new Test9()
                }, mc);
                break;
            default:
                _tools.Log("Une erreur c'est produite", "ERROR");
                return;
        }
        _certifier.AddCertificate(crt);

        // Test selected microcontroller with selected certificate
        Test(mc, crt);
    }
    
    // Normal mode branch
    private void RunSecondMode()
    {
        // Get customized mc from the user
        _tools.Log("Création du microcontrôleur", "HEADER");
        MCG mc = GetMc();
        _certifier.AddMCG(mc);
        _tools.Log("Microcontrolôleur généré avec succès", "SUCCESS");
        
        // Get customized certificate from the user
        _tools.Log("Création du certificat", "HEADER");
        Certificate crt = GetCrt();
        _certifier.AddCertificate(crt);
        _tools.Log("Certificat généré avec succès", "SUCCESS");

        // Test generated microcontroller with generated certificate
        Test(mc, crt);
    }

    private MCG GetMc()
    {
        // Fetch MC's specifications
        string producer = _tools.Enter<String>("Veuillez entrer le nom du fabriquant");
        string model = _tools.Enter<String>("Veuillez entrer le nom du modèle");
        string firmware = _tools.Enter<String>("Veuillez entrer le nom du micrologiciel");
        string disk = _tools.Enter<String>("Veuillez entrer le nom du système de stockage");
        double[] dimensions =
        {
            _tools.Enter<double>("Veuillez indiquer le poids du microcontrôleur (masse en g)"),
            _tools.Enter<double>("Veuillez indiquer la longueur du microcontrôleur (cm)"),
            _tools.Enter<double>("Veuillez indiquer la largeur du microcontrôleur (cm)"),
            _tools.Enter<double>("Veuillez indiquer l'épaisseur du microcontrôleur (cm)")
        };
        List<double> voltage = _tools.EnterList<double>(
            "Veuillez indiquer le nombre de tensions supportées",
            "Veuillez indiquer la valeur (en Volt) pour la tension #");
        List<String> ports = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de ports disponibles",
            "Veuillez indiquer la type du port #");
        List<String> languages = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de languages supportés",
            "Veuillez indiquer le nom du language #");
        int gpio = 0;
        Dictionary<int, string> gpios = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de gpio disponibles",
            "Veuillez indiquer le type du gpio #").ToDictionary(function => gpio++, function => function);

        return new MCG(voltage, dimensions, producer, firmware, model, disk, gpios, ports, false, languages);
    }

    private Certificate GetCrt()
    {
        ITestable[] tests =
        {
            new Test1(), new Test2(), new Test3(), new Test4(), new Test5(), new Test6(), new Test7(), new Test8(),
            new Test9()
        };

        List<ITestable> chosenTests = new List<ITestable>();
        for (uint i = 1; i <= 9; i++)
        {
            if (_tools.Select(new string[] { "Oui", "Non" },
                    "Voulez-vous inclure le test #" + i + " dans votre certificat ?") == 1)
                chosenTests.Add(tests[i - 1]);
        }

        return new Certificate(chosenTests, new MCG()); // Why is mc stored as an attribute in a certificate ???
    }

    private void Test(MCG mc, Certificate crt)
    {
        // Test of the microcontroller
        _tools.Log("Lancement des tests", "HEADER");
        bool result = _certifier.GenerateCertificate(crt, mc);

        // Logging the result
        if (result)
            _tools.Log("Succès de la certification", "SUCCESS");
        else
            _tools.Log("Échec de la certification", "WARNING");

        // Tracing
        _tools.Trace(_testId++, result);
    }
}
}

