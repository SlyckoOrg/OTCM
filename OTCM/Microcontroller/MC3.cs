namespace a;

public class MC3
{
    //Properties are Read-only:
    public List<int> _power { get; private set; }
    public double[] _dimensions { get; private set; }
    public string _manufacturer { get; private set; }
    public string _model { get; private set; }
    public string _firmware { get; private set; }
    public string _dd { get; private set; }
    public Dictionary<int, string> _gpio { get; private set; }
    public bool _hasTestFunction { get; private set; }
    public List<string> _connectors { get; private set; }
    public List<string> _languages { get; private set; }

    public MC3(List<int> power, double[] dimensions, string manufacturer, string model, string firmware, string dd,
        Dictionary<int, string> gpio, bool hasTestFunction, List<string> connectors, List<string> languages)
    {
        _power = power;
        _dimensions = dimensions;
        _manufacturer = manufacturer;
        _model = model;
        _firmware = firmware;
        _dd = dd;
        _gpio = gpio;
        _hasTestFunction = hasTestFunction;
        _connectors = connectors;
        _languages = languages;
    }
}