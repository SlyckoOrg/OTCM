namespace a;

public class Test1 : ITestable
{
    public bool Test(MCG controller)
    {
        return controller._voltage.Contains(3.3M) && controller._voltage.Contains(5);
    }

    public override string ToString()
    {
        return "[Test 1 - Polyvalence Électrique]\n   - Le microcontrôleur supporte les alimentations 3V et 5V\n";
    }
}