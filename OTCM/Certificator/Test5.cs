namespace a;

public class Test5 : ITest
{
    public bool Test(MCG controlleur)
    {
        return controlleur.Languages.Count >= 1;
    }
    public override string ToString()
    {
        return "[Test 5]\n   - Le controlleur supporte plus au moins un language spécifique\n";
    }
}