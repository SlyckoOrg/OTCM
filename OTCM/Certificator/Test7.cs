namespace a;

public class Test7 : ITest
{
    public bool Test(MCG controller)
    {
        return !string.IsNullOrEmpty(controller._dd);
    }
    public override string ToString()
    {
        return "[Test 7]\n   - Le microcontrôleur possède un disque dur\n";
    }
}