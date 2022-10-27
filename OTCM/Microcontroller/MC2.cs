namespace a;

public class MC2
{
    protected List<int> Power { get; set; }
    protected double[] Dimensions { get; set; }
    protected string  Manufacturer  { get; set; }
    protected string Model { get; set; }
    protected string Dd  { get; set; }
    protected  Dictionary<int, string> Gpio  { get; set; }
    protected bool HasTestFunction  { get; set; }
}