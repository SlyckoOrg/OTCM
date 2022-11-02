namespace a;

public class Test1 : ITestable
{
    public bool Test(MCG controller)
    {
        return controller._voltage.Contains(3) && controller._voltage.Contains(5);
    }

    public override string ToString()
    {
        return "[Polyvalence Électrique]\n   - Le microcontrôleur supporte l'alimentation 3V et 5V\n";
    }
}