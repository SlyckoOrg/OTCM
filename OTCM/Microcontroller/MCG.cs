namespace a;

public class MCG
{

    public List<Decimal> _voltage { get; set; }
    public Decimal[] _dimensions { get;  set; }
    public string  _producer  { get;  set; }
    public string  _firmware  { get;  set; }
    public string  _model  { get;  set; }
    public string _disk  { get;  set; }
    public  Dictionary<int, string> _gpios  { get;  set; }
    public List<string> _ports  { get;  set; }
    public bool _isTestSystem  { get;  set; }
    public List<string> _languages  { get;  set; }


    public MCG(List<Decimal> voltage, Decimal[] dimensions, string producer, string firmware, string model, string disk,
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
        _voltage = new List<Decimal>();
        _dimensions = new Decimal[4];
        _gpios = new Dictionary<int, string>();
        _ports = new List<string>();
        _languages = new List<string>();
    }
    
}