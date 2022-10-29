namespace a;

public class Test8 : ITest
{
    public bool Test(MCG controlleur)
    {
        return controlleur.TestFunction;
    }
    public override string ToString()
    {
        return "[Test 8]\n   - Le controlleur est capable de réaliser des tests de maintenance\n";
    }
}