namespace a;

public class Test1 : ITest
{
    public bool Test(MCG controlleur)
    {
        return controlleur._voltage.Contains(3) && controlleur._voltage.Contains(5);
    }

    public override string ToString()
    {
        return "[Polyvalence Électrique]\n   - Le microcontrôleur supporte l'alimentation 3V et 5V\n";
    }
}