namespace a
{
    public class Test2 : ITestable
    {
        // Constant specification limitations
        const Decimal minWeight = 10,  // g
                     maxWeight = 150, // g
                     minLenght = 3,   // cm
                     maxLenght = 6,   // cm
                     minWidth  = 0.5M, // cm
                     maxWidth  = 2,   // cm
                     minDepth  = 0.2M, // cm
                     maxDepth  = 0.8M; // cm

        Decimal weight = controller._dimensions[0];
        Decimal lenght = controller._dimensions[1];
        Decimal width  = controller._dimensions[2];
        Decimal depth  = controller._dimensions[3];

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
}

