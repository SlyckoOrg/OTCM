using System.Reflection.Metadata.Ecma335;
using a;

namespace OTCM.Interface;

public class Interface
{
    // Message tag
    private readonly string _tag = "\u001b[1;94m[OTCM]\u001b[0m ";

    // Startup title
    private string _title =
        "\u001b[1;34m       ___                         ___           ___     \n      /\\  \\                       /\\__\\         /\\  \\ \n     /::\\  \\         ___         /:/  /        |::\\  \\   \n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \n      \\/__/           \\/__/       \\/__/         \\/__/    \nOutil de Test et de Certification pour Microcontrôleurs\n\u001b[0m";
    
    //  Enables visual selection between different options (Supports ANSI escape sequences)
    private uint Select(string[] options, string message)
    {
        // Display request
        uint index = 1;

        Console.WriteLine(_tag + message);
        Console.Write("\u001b[1;32m");
        foreach (var option in options)
        {
            Console.Write("    " + index + "- " + option);
            if (index % 4 == 0)
                Console.WriteLine();
            index++;
        }

        Console.WriteLine("\u001b[0m");

        // Parse answer
        uint answer = 0;

        uint.TryParse(Console.ReadLine(), out answer);
        while (answer == 0 || answer > options.Length)
        {
            Console.WriteLine(_tag + "\u001b[1;31mVeuillez sélectionner une option valide \u001b[1;33m(1-" +
                              options.Length + ")\u001b[0m");
            uint.TryParse(Console.ReadLine(), out answer);
        }

        return answer;
    }

    // Main loop
    public void Run()
    {
        Console.WriteLine(_title);
        while (true)
        {
            uint mode = Select(new string[] { "Mode démonstration", "Mode expérience" },
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
                    Console.WriteLine(_tag + "\u001b[1;31mUne erreur c'est produite\u001b[0m");
                    return;
            }

            Console.WriteLine(
                "\n\u001b[1;94m————————————————————————————————————————————————————————————————————\u001b[0m\n");

            uint next = Select(new string[] { "Relancer le programme", "Quitter le programme" },
                "Veuillez effectuer un choix parmis les options suivantes");

            switch (next)
            {
                case 1:
                    break;
                case 2:
                    return;
                default:
                    Console.WriteLine(_tag + "\u001b[1;31mUne erreur c'est produite\u001b[0m");
                    return;
            }

        }
    }

    // Demo mode branch
    private void RunFirstMode()
    {
        uint microController = Select(new string[] { "MC1", "MC2", "MC3" },
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
                Console.WriteLine(_tag + "\u001b[1;31mUne erreur c'est produite\u001b[0m");
                return;
        }
        
        
    }
    
    // Normal mode branch
    private void RunSecondMode()
    {
    }
}