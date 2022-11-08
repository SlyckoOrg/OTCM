namespace a;

public class MC2
{
    //Properties are Read-only:
    public List<double> _voltage { get; private set; }
    public double[] _dimensions { get; private set; }
    public string  _producer  { get; private set; }
    public string _model { get; private set; }
    public string _disk  { get; private set; }
    public  Dictionary<int, string> _gpio  { get; private set; }
    public bool _isTestSystem  { get; private set; }

    public MC2()
    {
        _voltage = new List<double>();
        _voltage.Add(3.3);
        _voltage.Add(5.0);
        _dimensions = new[] { 182, 6, 2.9 };
        _producer = "Raspberry PI";
        _model = "RP2000";
        _disk = "Intégré";
        
        _gpio = new Dictionary<int, string>();
        _gpio.Add(1, "DATA");
        _gpio.Add(2, "DATA");
        _gpio.Add(3, "DATA");
        _gpio.Add(4, "DATA");
        _gpio.Add(5, "DATA");
        _gpio.Add(6, "DATA");
        _gpio.Add(7, "DATA");
        _gpio.Add(8, "DATA");
        _gpio.Add(9, "VIN");
        _gpio.Add(10, "VIN");
        _gpio.Add(11, "DATA");
        _gpio.Add(12, "DATA");
        _gpio.Add(13, "OTHER");
        _gpio.Add(14, "OTHER");
        _gpio.Add(15, "OTHER");
        _gpio.Add(16, "OTHER");
        _gpio.Add(17, "OTHER");
        _gpio.Add(18, "OTHER");
        _gpio.Add(19, "GND");
        _gpio.Add(20, "GND");

        _isTestSystem = true;
    }

    public MC2(List<double> voltage, double[] dimensions, string producer, string model, string disk,
        Dictionary<int, string> gpio, bool isTestSystem)
    {
        _voltage = voltage;
        _dimensions = dimensions;
        _producer = producer;
        _model = model;
        _disk = disk;
        _gpio = gpio;
        _isTestSystem = isTestSystem;
    }
}