namespace a;

public class Adapter2 : MCG
{
    private MC2 _mc2 { get; set; }

    public Adapter2(MC2 mc2)
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