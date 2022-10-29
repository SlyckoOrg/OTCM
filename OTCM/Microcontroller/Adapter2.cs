namespace a;

public class Adapter2 : MCG
{
    public MC2 _mc2 { get; private set; }

    public Adapter2(List<int> power, double[] dimensions, string manufacturer, string firmware, string model, string dd,
        Dictionary<int, string> gpio, List<string> connectors, bool hasTestFunction, List<string> languages, List<string> ports, MC2 mc2) 
        : base(power, dimensions, manufacturer, firmware, model, dd, gpio, connectors, hasTestFunction, languages, ports)
    {
        //thickness(cm):
        _dimensions[3] = 0.77;
        
        //Set Firmware:
        _firmware = "Inconnu";
        
        //Set ports:
        _ports = new List<string> { "HDMI", "USB", "WIFI", "Bluetooth"};
        
        //Set languages:
        _languages = new List<string> {"C++" };
    }
}