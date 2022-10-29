namespace a;

public class MCG
{

    public List<int> _power { get; protected set; }
    public double[] _dimensions { get; protected set; }
    public string  _manufacturer  { get; protected set; }
    public string  _firmware  { get; protected set; }
    public string  _model  { get; protected set; }
    public string _dd  { get; protected set; }
    public  Dictionary<int, string> _gpio  { get; protected set; }
    public List<string> _connectors  { get; protected set; }
    public bool _hasTestFunction  { get; protected set; }
    public List<string> _languages  { get; protected set; }
    public List<string> _ports { get; protected set; }


    public MCG(List<int> power, double[] dimensions, string manufacturer, string firmware, string model, string dd,
        Dictionary<int, string> gpio, List<string> connectors, List<string> languages, List<string> ports)
    {
        _power = power;
        _dimensions = dimensions;
        _manufacturer = manufacturer;
        _firmware = firmware;
        _model = model;
        _dd = dd;
        _gpio = gpio;
        _connectors = connectors;
        _languages = languages;
        _ports = ports;
    }
    
}