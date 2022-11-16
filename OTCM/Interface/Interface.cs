using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using a;

namespace OTCM.Interface;

public class Interface
{
    // Startup title
    private string _title =
        "\u001b[1;34m       ___                         ___           ___     \n      /\\  \\                       /\\__\\         /\\  \\ \n     /::\\  \\         ___         /:/  /        |::\\  \\   \n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \n      \\/__/           \\/__/       \\/__/         \\/__/    \n  Outil de Test et de Certification pour Microcontrôleurs\n\u001b[0m";

    // UI tools
    private Tools _tools = new Tools("OTCM", Environment.CurrentDirectory + "log.json");
    
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
                    _tools.Log("Une erreur c'est produite", true);
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
                    _tools.Log("Une erreur c'est produite", true);
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
                _tools.Log("Une erreur c'est produite", true);
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
                _tools.Log("Une erreur c'est produite", true);
                return;
        }
        _certifier.AddCertificate(crt);

        // Test of the microcontroller
        _tools.Log("Lancement des tests", false);
        _certifier.GenerateCertificate(crt, mc);

        // Tracing
        _tools.Trace(_testId, true);
        _testId++;
    }
    
    // Normal mode branch
    private void RunSecondMode()
    {
        MCG mc = GenerateMc();
    }

    private MCG GenerateMc()
    {
        return new MCG();
    }
}