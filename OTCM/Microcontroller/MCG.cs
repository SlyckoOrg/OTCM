namespace a;

public class MCG
{
    protected List<int> Power { get; set; }
    protected double[] Dimensions { get; set; }
    protected string  Manufacturer  { get; set; }
    protected string  Firmware  { get; set; }
    protected string Dd  { get; set; }
    protected  Dictionary<int, string> Gpio  { get; set; }
    protected List<string> Connectors  { get; set; }
    protected bool TestFunction  { get; set; }
    protected List<string> Languages  { get; set; }
}