namespace a;

public class Test3: ITestable
{
    public bool Test(MCG controller)
    {
        // Constant specification limitations
        const int minData  = 2,
                  minGrn   = 2,
                  minOther = 1;
        
        int numData  = controller._gpios.Count(pair => pair.Value == "DATA");
        int numGrn   = controller._gpios.Count(pair => pair.Value == "GRN");
        int numOther = controller._gpios.Count(pair => pair.Value == "OTHER");

        return numData >= minData && numGrn >= minGrn && numOther >= minOther;
    }
    public override string ToString()
    {
        return "[Test 3 - Spécification GPIO]\n" + 
               "   - Le nombre de GPIO de donnée respecte les spécifications\n" +
               "   - Le nombre de GPIO de masse respecte les spécifications\n" +
               "   - Le nombre de GPIO (donnée et masse excluent) respecte les spécifications\n";
    }
}