namespace a;

public class Test1 : ITest
{
    public bool Test(MCG controlleur)
    {
        return controlleur.Power.Contains(3) && controlleur.Power.Contains(5);
    }

    public override string ToString()
    {
        return "[Polyvalence Électrique]\n   - Le microcontrôleur supporte l'alimentation 3V et 5V\n";
    }
}