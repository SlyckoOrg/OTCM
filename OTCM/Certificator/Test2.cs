namespace a;

public class Test2 : ITest
{
    public bool Test(MCG controlleur)
    {
        // Constant specification limitations
        const double minWeight = 10,  // g
                     maxWeight = 150, // g
                     minLenght = 3,   // cm
                     maxLenght = 6,   // cm
                     minWidth  = 0.5, // cm
                     maxWidth  = 2,   // cm
                     minDepth  = 0.2, // cm
                     maxDepth  = 0.8; // cm

        double weight = controlleur.Dimensions[0];
        double lenght = controlleur.Dimensions[1];
        double width  = controlleur.Dimensions[2];
        double depth  = controlleur.Dimensions[3];

        return weight is >= minWeight and <= maxWeight &&
               lenght is >= minLenght and <= maxLenght &&
               width  is >= minWidth  and <= maxWidth  &&
               depth  is >= minDepth  and <= maxDepth;
    }
    public override string ToString()
    {
        return "[Validation de spécifications physiques]\n   - Les dimensions respectent les spécifications\n";
    }
}