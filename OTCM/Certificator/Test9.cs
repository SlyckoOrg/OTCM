namespace a;

public class Test9 : ITestable
{
    public bool Test(MCG controller)
    {
        // Constant specification limitations
        const string requiredFirmware = "Arduino";

        return controller._firmware == requiredFirmware;
    }
    public override string ToString()
    {
        return "[Test 9]\n   - Le microcontrôleur possède le firmware requis\n";
    }
}