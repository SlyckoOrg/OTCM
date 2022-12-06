using System.Text;

namespace a;

public class Test5 : ITestable
{
    private string[] listOfNecessaryLanguages = { "C++", "C", "LUA" };

    public bool Test(MCG controller)
    {
        // Constant specification limitations
        
        return controller._languages.Intersect(listOfNecessaryLanguages).Count() == listOfNecessaryLanguages.Length;
    }
    public override string ToString()
    {
        StringBuilder langSupported = new StringBuilder();
        foreach (string lang in listOfNecessaryLanguages)
        {
            langSupported.Append(lang);
            langSupported.Append(" ");
        }
            
        return "[Test 5 - Support language(s) "+langSupported+"]\n   - Le microcontrôleur supporte le(s) language(s) "+langSupported+"\n";
    }
}