namespace a;

public class Adapter3 : MCG

{

    public MC3 _mc3 { get; private set; }

    public Adapter3(List<int> power, double[] dimensions, string manufacturer, string firmware, string dd,
        Dictionary<int, string> gpio, List<string> connectors, List<string> languages, List<string> ports, MC3 mc3) 
        : base(power, dimensions, manufacturer, firmware, dd, gpio, connectors, languages, ports)
    {

    }

}