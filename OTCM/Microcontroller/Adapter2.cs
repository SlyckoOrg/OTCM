namespace a;

public class Adapter2 : MCG
{
    public MC2 _mc2 { get; private set; }

    public Adapter2(List<double> voltage, double[] dimensions, string manufacturer, string firmware, string model, string dd,
        Dictionary<int, string> gpio, List<string> connectors, bool hasTestFunction, List<string> languages, List<string> ports, MC2 mc2) 
        : base(voltage, dimensions, manufacturer, firmware, model, dd, gpio, connectors, hasTestFunction, languages, ports)
    {
        //Set Firmware:
        _firmware = "Inconnu";
        
        //Set ports:
        _ports = new List<string> { "HDMI", "USB", "WIFI", "Bluetooth"};
        
        //Set languages:
        _languages = new List<string> {"C++" };

        _mc2 = mc2;
        
        //thickness(cm):
        _mc2._dimensions[3] = 0.77;
    }
}