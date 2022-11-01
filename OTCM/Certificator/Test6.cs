namespace a;

public class Test6 : ITest
{
    public bool Test(MCG controller)
    {
        return !string.IsNullOrEmpty(controller._firmware);
    }
    public override string ToString()
    {
        return "[Test 6]\n   - Le microcontrôleur possède un firmware\n";
    }
}