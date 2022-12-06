namespace a;

public class Test7 : ITestable
{
    public bool Test(MCG controller)
    {
        return !string.IsNullOrEmpty(controller._disk);
    }
    public override string ToString()
    {
        return "[Test 7 - Disque dur intégré]\n   - Le microcontrôleur possède un disque dur\n";
    }
}