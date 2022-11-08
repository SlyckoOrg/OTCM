namespace a;

public class Adapter3 : MCG

{

    public MC3 _mc3 { get; private set; }

    public Adapter3(List<double> voltage, double[] dimensions, string producer, string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool hasTestFunction, List<string> languages, MC3 mc3) 
        : base(voltage, dimensions, producer, firmware, model, disk, gpios, ports, hasTestFunction, languages)
    {
        _mc3 = mc3;
    }

    public Adapter3(MC3 mc3)
    {
        _mc3 = mc3;
    }

}