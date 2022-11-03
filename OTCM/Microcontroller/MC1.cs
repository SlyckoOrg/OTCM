namespace a;

public class MC1
{
    //Properties are Read-only:
    public List<double> _voltage { get; private set; }
    public string  _firmware  { get; private set; }
    public string _dd  { get; set; }
    public  Dictionary<int, string> _gpio  { get; private set; }
    public List<string> _connectors  { get; private set; }
    public List<string> _languages  { get; private set; }


    public MC1()
    {
        _voltage = new List<double>();
        _voltage.Add(3.3);
        _firmware = "circuit Python";
        _dd = "carte SD";
        
        _gpio = new Dictionary<int, string>();
        _gpio.Add(1, "VIN");
        _gpio.Add(2, "DATA");
        _gpio.Add(3, "DATA");
        _gpio.Add(4, "DATA");
        _gpio.Add(5, "DATA");
        _gpio.Add(6, "DATA");
        _gpio.Add(7, "OTHER");
        _gpio.Add(8, "OTHER");
        _gpio.Add(9, "GND");
        _gpio.Add(10, "OTHER");
        _gpio.Add(11, "OTHER");
        _gpio.Add(12, "DATA");
        _gpio.Add(13, "DATA");
        _gpio.Add(14, "OTHER");
        _gpio.Add(15, "OTHER");
        _gpio.Add(16, "OTHER");
        
        _connectors = new List<string>();
        _connectors.Add("HDMI");
        _connectors.Add("micro-USB");
        _connectors.Add("WIFI");
        _languages = new List<string>();
        _languages.Add("Python");
    }

    public MC1( List<double> power, string firmware,string dd, Dictionary<int, string> gpio, List<string> connectors, List<string> languages)
    {
        _voltage = power;
        _firmware = firmware;
        _dd = dd;
        _gpio = gpio;
        _connectors = connectors;
        _languages = languages;
    }
}