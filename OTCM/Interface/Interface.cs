using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using a;

namespace OTCM.Interface;

public class Interface
{
    // debug parameter 
    public static bool Debug;
    // Startup title
    private string _title =
        "\u001b[1;34m       ___                         ___           ___     \n      /\\  \\                       /\\__\\         /\\  \\ \n     /::\\  \\         ___         /:/  /        |::\\  \\   \n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \n      \\/__/           \\/__/       \\/__/         \\/__/    \n  Outil de Test et de Certification pour Microcontrôleurs\n\u001b[0m";

    // UI tools
    private Tools _tools = new Tools("OTCM", Environment.CurrentDirectory + "//log.json");
    
    // Certifier main component
    private Certifier _certifier = new Certifier();
    
    // Number of ran tests
    private uint _testId = 0;
    
    //chosen microcontroller
    public static uint ChosenMc;
    
    //chosen certificate
    public static uint ChosenCertificate;
    
    //chosen mode
    public static uint ChosenMode;

    public Interface(bool isDebug = false)
    {
        Debug = isDebug;
    }

    // Main loop
    public void Run()
    {
        // Title display
        Console.WriteLine(_title);
        while (true)
        {
            bool breakLoop = false;
            uint mode = _tools.Select(
                new string[]
                {
                    "Mode démonstration", "Mode expérience", "Reset les microcontrôleurs par défauts",
                    "Afficher les microcontrôleurs", "Aide"
                },
                "Veuillez sélectionner un mode");

            switch (mode)
            {
                case 1:
                    ChosenMode = 1;
                    RunFirstMode();
                    break;
                case 2:
                    ChosenMode = 2;
                    RunSecondMode();
                    break;
                case 3:
                    breakLoop = true;
                    SaveAllMCG();
                    break;
                case 4:
                    breakLoop = true;
                    DisplayMCG();
                    break;
                case 5:
                    breakLoop = true;
                    DisplayGeneralHelp();
                    break;
                default:
                    _tools.Log("Une erreur s’est produite", "ERROR");
                    return;
            }

            if (!breakLoop)
            {
                uint next = _tools.Select(new string[] { "Relancer le programme", "Quitter le programme" },
                    "Veuillez effectuer un choix parmis les options suivantes");

                switch (next)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        return;
                    default:
                        _tools.Log("Une erreur s'est produite", "ERROR");
                        Console.Clear();

                        return;
                }
            }
        }
    }

    private void DisplayMCG()
    {
        _certifier.ReadMCGFile();
    }
    
    

    private void DisplayGeneralHelp()
    {

        String helpStr = "Aide:\n" +
                         "\u001b[1;34m- Mode démonstration :\n" +
                         "\u001b[1;32m  Permet de choisir un des microcontrôleurs par défaut et de lui faire passer une des " +
                         "batteries de test d'un certificat par défaut.\n" +
                         "\u001b[1;34m- Mode expérience :\n" +
                         "\u001b[1;32m  Donne le choix entre utiliser les microcontrôleurs par défaut et créer son propre " +
                         "microcontrôleur en choisissant chacune des caractéristiques. \n" +
                         "  Il faut ensuite choisir chaque test que le microcontrôleur devra passer.\n" +
                         "\u001b[1;34m- Reset les microcontrôleurs par défauts :\n" +
                         "\u001b[1;32m  Remet à zéros les microcontrôleurs, en ne gardant que les microcontrôleurs 1, 2 et 3.\n" +
                         "\u001b[1;31m  ATTENTION : Cela écrasera les nouveaux microcontrôleurs que fous avez créé !\n" +
                         "\u001b[1;34m- Afficher les microcontrôleurs  :\n" +
                         "\u001b[1;32m  Affiche les informations de tous les microcontrôleurs\n\n";
        
        
        Console.WriteLine(helpStr);
    }

    private void SaveAllMCG()
    {
        _certifier.resetMCGFile();
        _certifier.SaveMCG(new Adapter1(new MC1()));
        _certifier.SaveMCG(new Adapter2(new MC2()));
        _certifier.SaveMCG(new Adapter3(new MC3()));
    }

    // Demo mode branch
    private void RunFirstMode()
    {
        MCG mc = RequestDefaultMC();

        // Request certificate
        uint certificate = _tools.Select(new string[] { "Certificat #1", "Certificat #2", "Certificat #3" },
            "Veuillez choisir un certificat");

        Certificate crt;
        switch (certificate)
        {
            case 1:
                // Certificate #1
                crt = new Certificate(new List<ITestable>{ new Test1(), new Test2(), new Test3(), new Test4() }, mc);
                ChosenCertificate = 1;
                break;
            case 2:
                // Certificate #2
                crt = new Certificate(new List<ITestable>{ new Test5(), new Test6(), new Test7(), new Test8() }, mc);
                ChosenCertificate = 2;
                break;
            case 3:
                // Certificate #3
                crt = new Certificate(new List<ITestable>
                {
                    new Test1(), new Test3(), new Test5(), new Test7(),
                    new Test9()
                }, mc);
                ChosenCertificate = 3;
                break;
            default:
                _tools.Log("Une erreur s'est produite", "ERROR");
                return;
        }
        _certifier.AddCertificate(crt);

        // Test selected microcontroller with selected certificate
        Test(mc, crt);
    }

    private MCG RequestDefaultMC()
    {
        //re-generate MCG list : 
        _certifier.GenerateMCG();
        
        List<string> defaultMcgs = _certifier.ListMCGString();
        // Request microcontroller
        uint microController = _tools.Select(defaultMcgs.ToArray(),
            "Veuillez choisir le microcontrôleur à utiliser");

        ChosenMc = microController;
        return _certifier.GetMCG((int)(microController) -1);
        // MCG mc;
        // switch (microController)
        // {
        //     case 1:
        //         mc = new Adapter1(new MC1());
        //         break;
        //     case 2:
        //         mc = new Adapter2(new MC2());
        //         break;
        //     case 3:
        //         mc = new Adapter3(new MC3());
        //         break;
        //     default:
        //         _tools.Log("Une erreur c'est produite", "ERROR");
        //         return null;
        // }
        // _certifier.AddMCG(mc);
        // return mc;
    }

    // Normal mode branch
    private void RunSecondMode()
    {
        //Propose to use default MC or Create a new MC : 
        uint mode = _tools.Select(new string[]
            {
                "Utiliser un microcontrôleur par défaut", 
                "Créer un nouveau microcontrôleur"
            },
            "Veuillez sélectionner le microcontrôleur pour le mode expérience");
        MCG mc = null;
        switch (mode)
        {
            case 1:
                //Get one of the three defaul mc:
                mc = RequestDefaultMC();
                break;
            case 2:
                // Get customized mc from the user
                ChosenMode = 999; 
                _tools.Log("Création du microcontrôleur", "HEADER");
                mc = GetMc();
                break;
            default:
                _tools.Log("Une erreur s'est produite", "ERROR");
                return;
        }
       
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
        List<Decimal>dimensions =new List<decimal>( new []
        {
            _tools.Enter<Decimal>("Veuillez indiquer le poids du microcontrôleur (masse en g)"),
            _tools.Enter<Decimal>("Veuillez indiquer la longueur du microcontrôleur (cm)"),
            _tools.Enter<Decimal>("Veuillez indiquer la largeur du microcontrôleur (cm)"),
            _tools.Enter<Decimal>("Veuillez indiquer l'épaisseur du microcontrôleur (cm)")
        });
        List<Decimal> voltage = _tools.EnterList<Decimal>(
            "Veuillez indiquer le nombre de tensions supportées",
            "Veuillez indiquer la valeur (en Volt) pour la tension #");
        List<String> ports = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de ports disponibles",
            "Veuillez indiquer la type du port #");
        List<String> languages = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de langages  supportés",
            "Veuillez indiquer le nom du langage #");
        int gpio = 0;
        Dictionary<int, string> gpios = _tools.EnterList<String>(
            "Veuillez indiquer le nombre de gpios disponibles",
            "Veuillez indiquer le type du gpio #").ToDictionary(function => gpio++, function => function);

        MCG mc = new MCG(voltage, dimensions, producer, firmware, model, disk, gpios, ports, false, languages);
        _certifier.AddMCG(mc);
        _certifier.SaveMCG(mc);
        _tools.Log("Microcontrôleur généré avec succès", "SUCCESS");

        return mc;
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
            String testDescr = tests[i - 1].ToString().Split(new char[]{'[',']'})[1];
            if (_tools.Select(new string[] { "Oui", "Non" },
                    "Voulez-vous inclure le test [" +testDescr+ "] dans votre certificat ?") == 1)
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
            _tools.Log("Échec de la certification", "ERROR");

        // Tracing
        _tools.Trace(_testId++, result);
    }
}