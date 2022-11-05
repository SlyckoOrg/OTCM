namespace a;

public class MC3
{
    //Properties are Read-only:
    public List<double> _voltage { get; private set; }
    public double[] _dimensions { get; private set; }
    public string _manufacturer { get; private set; }
    public string _firmware { get; private set; }
    public string _model { get; private set; }
    public string _dd { get; private set; }
    public Dictionary<int, string> _gpio { get; private set; }
    public List<string> _connectors { get; private set; }
    public bool _hasTestFunction { get; private set; }
    public List<string> _languages { get; private set; }

    public MC3()
    {
        _voltage = new List<double>();
        _voltage.Add(3.3);
        _voltage.Add(5.0);
        _dimensions = new double[] { 82.0, 3.8, 1.72, 0.68};
        _manufacturer = "Arduino";
        _model = "AR1240";
        _firmware = "Arduino";
        _dd = "Intégré";
        _gpio = new Dictionary<int, string>();
        _gpio.Add(1, "VIN");
        _gpio.Add(2, "GND");
        _gpio.Add(3, "DATA");
        _gpio.Add(4, "DATA");
        _gpio.Add(5, "DATA");
        _gpio.Add(6, "DATA");
        _gpio.Add(7, "OTHER");
        _gpio.Add(8, "GND");
        _gpio.Add(9, "DATA");
        _gpio.Add(10, "DATA");
        _gpio.Add(11, "DATA");
        _gpio.Add(12, "OTHER");

        _connectors = new List<string>();
        _connectors.Add("micro-USB");
        _hasTestFunction = true;
        _languages = new List<string>();
        _languages.Add("C++");
    }

    public MC3(List<double> voltage, double[] dimensions, string manufacturer,string firmware, string model, string dd,
        Dictionary<int, string> gpio, List<string> connectors, bool hasTestFunction, List<string> languages)
    {
        _voltage = voltage;
        _dimensions = dimensions;
        _manufacturer = manufacturer;
        _model = model;
        _firmware = firmware;
        _dd = dd;
        _gpio = gpio;
        _connectors = connectors;
        _hasTestFunction = hasTestFunction;
        _languages = languages;
    }
}