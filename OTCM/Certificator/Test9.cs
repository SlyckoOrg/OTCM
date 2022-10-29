namespace a;

public class Test9 : ITest
{
    public bool Test(MCG controlleur)
    {
        // Constant specification limitations
        const string requiredFirmware = "Arduino";

        return controlleur._firmware == requiredFirmware;
    }
    public override string ToString()
    {
        return "[Test 9]\n   - Le microcontrôleur possède le firmware requis\n";
    }
}