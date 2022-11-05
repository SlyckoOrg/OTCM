using a;

namespace OTCM.Interface;

public class Interface
{
    private readonly string _tag = "\u001b[1;94m[OTCM]\u001b[0m ";

    private string _title =
        "\u001b[1;34m       ___                         ___           ___     \n      /\\  \\                       /\\__\\         /\\  \\ \n     /::\\  \\         ___         /:/  /        |::\\  \\   \n    /:/\\:\\  \\       /\\__\\       /:/  /         |:|:\\  \\  \n   /:/  \\:\\  \\     /:/  /      /:/  /  ___   __|:|\\:\\  \\ \n  /:/__/ \\:\\__\\   /:/__/      /:/__/  /\\__\\ /::::|_\\:\\__\\ \n  \\:\\  \\ /:/  /  /::\\  \\      \\:\\  \\ /:/  / \\:\\~~\\  \\/__/\n   \\:\\  /:/  /  /:/\\:\\  \\      \\:\\  /:/  /   \\:\\  \\      \n    \\:\\/:/  /   \\/__\\:\\  \\      \\:\\/:/  /     \\:\\  \\     \n     \\::/  /         \\:\\__\\      \\::/  /       \\:\\__\\    \n      \\/__/           \\/__/       \\/__/         \\/__/    \nOutil de Test et de Certification pour Microcontrôleurs\n\u001b[0m";
    

    private uint Select(string[] options, string message)
    {
        // Display request
        uint index = 1;

        Console.WriteLine(_tag + message);
        Console.Write("\u001b[1;32m");
        foreach (var option in options)
        {
            Console.Write("    " + index + "- " + option);
            if (index % 3 == 0)
                Console.WriteLine();
            index++;
        }
        Console.WriteLine("\u001b[0m");

        // Parse answer
        uint answer = 0;

        uint.TryParse(Console.ReadLine(), out answer);
        while (answer == 0 || answer > options.Length)
        {
            Console.WriteLine(_tag + "\u001b[1;31mVeuillez sélectionner une option valide \u001b[1;33m(1-" + options.Length + ")\u001b[0m");
            uint.TryParse(Console.ReadLine(), out answer);
        }

        return answer;
    }

    public void Run()
    {
        Console.WriteLine(_title);
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
                break;
        }
    }

    private void RunFirstMode()
    {
        uint microController = Select(new string[] { "MC1", "MC2", "MC3", "MC4" },
            "Veuillez choisir le microcontrôleur à utiliser");

        MCG mc;
        switch (microController)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                Console.WriteLine(_tag + "\u001b[1;31mUne erreur c'est produite\u001b[0m");
                break;
        }
    }
    
    private void RunSecondMode()
    {
    }
}