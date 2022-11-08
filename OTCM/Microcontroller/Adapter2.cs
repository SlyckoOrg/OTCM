namespace a;

public class Adapter2 : MCG
{
    public MC2 _mc2 { get; private set; }

    public Adapter2(List<double> voltage, double[] dimensions, string producer, string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool hasTestFunction, List<string> languages, MC2 mc2) 
        : base(voltage, dimensions, producer, firmware, model, disk, gpios, ports, hasTestFunction, languages)
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

    public Adapter2(MC2 mc2)
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