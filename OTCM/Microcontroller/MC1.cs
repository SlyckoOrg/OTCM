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
        _gpio = new Dictionary<int, string>();
        _connectors = new List<string>();
        _languages = new List<string>();
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