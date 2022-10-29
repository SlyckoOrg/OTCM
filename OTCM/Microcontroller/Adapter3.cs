namespace a;

public class Adapter3 : MCG

{

    public MC3 _mc3 { get; private set; }

    public Adapter3(List<int> power, double[] dimensions, string manufacturer, string firmware, string model, string dd,
        Dictionary<int, string> gpio, List<string> connectors, bool hasTestFunction, List<string> languages, List<string> ports, MC3 mc3) 
        : base(power, dimensions, manufacturer, firmware, model, dd, gpio, connectors, hasTestFunction, languages, ports)
    {
        _mc3 = new MC3(power, dimensions, manufacturer, firmware, model, dd, gpio, connectors, hasTestFunction, languages);
    }

}