namespace a;

public class Test5 : ITestable
{
    public bool Test(MCG controller)
    {
        // Constant specification limitations
        string[] listOfNecessaryLanguages = { "C++", "C", "LUA" };
        
        return controller._languages.Intersect(listOfNecessaryLanguages).Count() == listOfNecessaryLanguages.Length;
    }
    public override string ToString()
    {
        return "[Test 5 - Support language C++, C et LUA]\n   - Le microcontrôleur supporte plus au moins un language spécifique\n";
    }
}