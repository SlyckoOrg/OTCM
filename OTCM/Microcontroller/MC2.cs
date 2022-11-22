namespace a;

public class MC2
{
    //Properties are Read-only:
    public List<Decimal> _voltage { get; private set; }
    public List<Decimal> _dimensions { get; private set; }
    public string  _producer  { get; private set; }
    public string _model { get; private set; }
    public string _disk  { get; private set; }
    public  Dictionary<int, string> _gpios  { get; private set; }
    public bool _isTestSystem  { get; private set; }

    public MC2()
    {
        _voltage = new List<Decimal>();
        _voltage.Add(3.3M);
        _voltage.Add(5.0M);
        _dimensions = new List<decimal>(new []{ 182M, 6M, 2.9M });
        _producer = "Raspberry PI";
        _model = "RP2000";
        _disk = "Intégré";
        
        _gpios = new Dictionary<int, string>();
        _gpios.Add(1, "DATA");
        _gpios.Add(2, "DATA");
        _gpios.Add(3, "DATA");
        _gpios.Add(4, "DATA");
        _gpios.Add(5, "DATA");
        _gpios.Add(6, "DATA");
        _gpios.Add(7, "DATA");
        _gpios.Add(8, "DATA");
        _gpios.Add(9, "VIN");
        _gpios.Add(10, "VIN");
        _gpios.Add(11, "DATA");
        _gpios.Add(12, "DATA");
        _gpios.Add(13, "OTHER");
        _gpios.Add(14, "OTHER");
        _gpios.Add(15, "OTHER");
        _gpios.Add(16, "OTHER");
        _gpios.Add(17, "OTHER");
        _gpios.Add(18, "OTHER");
        _gpios.Add(19, "GND");
        _gpios.Add(20, "GND");

        _isTestSystem = true;
    }

    public MC2(List<Decimal> voltage, List<Decimal> dimensions, string producer, string model, string disk,
        Dictionary<int, string> gpios, bool isTestSystem)
    {
        _voltage = voltage;
        _dimensions = dimensions;
        _producer = producer;
        _model = model;
        _disk = disk;
        _gpios = gpios;
        _isTestSystem = isTestSystem;
    }
}