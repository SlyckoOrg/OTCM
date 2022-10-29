namespace a;

public class Test5 : ITest
{
    public bool Test(MCG controlleur)
    {
        // Constant specification limitations
        string[] listOfNecessaryLanguages = { "C++", "C", "LUA" };
        
        return controlleur._languages.Intersect(listOfNecessaryLanguages).Count() == listOfNecessaryLanguages.Length;
    }
    public override string ToString()
    {
        return "[Test 5]\n   - Le microcontrôleur supporte plus au moins un language spécifique\n";
    }
}