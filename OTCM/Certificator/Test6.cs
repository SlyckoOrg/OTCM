namespace a;

public class Test6 : ITestable
{
    public bool Test(MCG controller)
    {
        return !string.IsNullOrEmpty(controller._firmware);
    }
    public override string ToString()
    {
        return "[Test 6 - Firmware installé]\n   - Le microcontrôleur possède au moins un firmware\n";
    }
}