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
    private Tools _tools = new Tools("OTCM");

    // Main loop
    public void Run()
    {
        Console.WriteLine(_title);
        while (true)
        {
            uint mode = _tools.Select(new string[] { "Mode démonstration", "Mode expérience" },
                "Veuillez sélectionner un mode");

            switch (mode)
            {
                case 1:
                    RunFirstMode();
                    break;
                case 2:
                    RunSecondMode();
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

    // Demo mode branch
    private void RunFirstMode()
    {
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