namespace a;

public class MCG
{
    private List<int> Power { get; set; }
    private double[] Dimensions { get; set; }
    private string  Manufacturer  { get; set; }
    private string  Firmware  { get; set; }
    private string Dd  { get; set; }
    private  Dictionary<int, string> Gpio  { get; set; }
    private List<string> Connectors  { get; set; }
    private bool TestFunction  { get; set; }
    private List<string> Languages  { get; set; }
}