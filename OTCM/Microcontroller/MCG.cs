namespace a;

public class MCG
{

    public List<double> _voltage { get; protected set; }
    public double[] _dimensions { get; protected set; }
    public string  _producer  { get; protected set; }
    public string  _firmware  { get; protected set; }
    public string  _model  { get; protected set; }
    public string _disk  { get; protected set; }
    public  Dictionary<int, string> _gpios  { get; protected set; }
    public List<string> _ports  { get; protected set; }
    public bool _isTestSystem  { get; protected set; }
    public List<string> _languages  { get; protected set; }


    public MCG(List<double> voltage, double[] dimensions, string producer, string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool isTestSystem, List<string> languages)
    {
        _voltage = voltage;
        _dimensions = dimensions;
        _producer = producer;
        _firmware = firmware;
        _model = model;
        _disk = disk;
        _gpios = gpios;
        _ports = ports;
        _isTestSystem = isTestSystem;
        _languages = languages;
    }
    
    
    //Default constructor:
    public MCG()
    {
        _producer = "";
        _firmware = "";
        _model = "";
        _disk = "";
        _voltage = new List<double>();
        _dimensions = new double[4];
        _gpios = new Dictionary<int, string>();
        _ports = new List<string>();
        _languages = new List<string>();
    }
    
}