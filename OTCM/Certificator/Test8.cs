namespace a;

public class Test8 : ITest
{
    public bool Test(MCG controlleur)
    {
        return controlleur._hasTestFunction;
    }
    public override string ToString()
    {
        return "[Test 8]\n   - Le microcontrôleur est capable de réaliser des tests de maintenance\n";
    }
}