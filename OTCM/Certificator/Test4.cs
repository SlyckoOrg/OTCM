namespace a;

public class Test4 : ITest
{
    public bool Test(MCG controlleur)
    {
        // Constant specification limitations
        string[] listOfNecessaryPorts = { "USB", "HDMI" };
        
        return controlleur._connectors.Intersect(listOfNecessaryPorts).Count() == listOfNecessaryPorts.Length;
    }
    public override string ToString()
    {
        return "[Test 4]\n   - Le microcontro supporte tous les connecteurs nécessaires\n";
    }
}