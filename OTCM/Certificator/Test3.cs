namespace a;

public class Test3: ITest
{
    public bool Test(MCG controlleur)
    {
        // Constant specification limitations
        const int minData  = 2,
                  minGrn   = 2,
                  minOther = 1;
        
        int numData  = controlleur._gpio.Count(pair => pair.Value == "DATA");
        int numGrn   = controlleur._gpio.Count(pair => pair.Value == "GRN");
        int numOther = controlleur._gpio.Count(pair => pair.Value == "OTHER");

        return numData >= minData && numGrn >= minGrn && numOther >= minOther;
    }
    public override string ToString()
    {
        return "[Spécification GPIO]\n" + 
               "   - Le nombre de GPIO de donnée respecte les spécifications\n" +
               "   - Le nombre de GPIO de masse respecte les spécifications\n" +
               "   - Le nombre de GPIO (donnée et masse excluent) respecte les spécifications\n";
    }
}