namespace a;

public class MC2
{
    //Properties are Read-only:
    public List<int> _power { get; private set; }
    public double[] _dimensions { get; private set; }
    public string  _manufacturer  { get; private set; }
    public string _model { get; private set; }
    public string _dd  { get; private set; }
    public  Dictionary<int, string> _gpio  { get; private set; }
    public bool _hasTestFunction  { get; private set; }

    public MC2()
    {
        _power = new List<int>();
        _gpio = new Dictionary<int, string>();
    }

    public MC2(List<int> power, double[] dimensions, string manufacturer, string model, string dd,
        Dictionary<int, string> gpio, bool hasTestFunction)
    {
        _power = power;
        _dimensions = dimensions;
        _manufacturer = manufacturer;
        _model = model;
        _dd = dd;
        _gpio = gpio;
        _hasTestFunction = hasTestFunction;
    }
}