namespace a;

public class MC2
{
    protected List<int> _power { get; set; }
    protected double[] _dimensions { get; set; }
    protected string  _manufacturer  { get; set; }
    protected string _model { get; set; }
    protected string _dd  { get; set; }
    protected  Dictionary<int, string> _gpio  { get; set; }
    protected bool _hasTestFunction  { get; set; }
}