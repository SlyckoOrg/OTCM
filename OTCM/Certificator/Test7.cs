namespace a;

public class Test7 : ITestable
{
    public bool Test(MCG controller)
    {
        return !string.IsNullOrEmpty(controller._disk);
    }
    public override string ToString()
    {
        return "[Test 7]\n   - Le microcontrôleur possède un disque dur\n";
    }
}