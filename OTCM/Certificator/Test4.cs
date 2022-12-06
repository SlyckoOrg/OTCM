namespace a;

public class Test4 : ITestable
{
    public bool Test(MCG controller)
    {
        // Constant specification limitations
        string[] listOfNecessaryPorts = { "USB", "HDMI" };
        
        return controller._ports.Intersect(listOfNecessaryPorts).Count() == listOfNecessaryPorts.Length;
    }
    public override string ToString()
    {
        return "[Test 4 - Validation de spécification des connecteurs]\n   - Le microcontrôleur supporte tous les connecteurs nécessaires\n";
    }
}