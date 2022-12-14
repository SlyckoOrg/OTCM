namespace a;

public class Adapter2 : MCG
{

    private static Adapter2 _Mc;
    
    public static Adapter2 Mc
    {
        get
        {
            if (_Mc == null)
            {
                _Mc = new Adapter2(new MC2());
            }

            return _Mc;
        }
    }
    public Adapter2(List<Decimal> voltage, List<Decimal> dimensions, string producer, string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool hasTestFunction, List<string> languages, MC2 mc2) 
        : base(voltage, dimensions, producer, firmware, model, disk, gpios, ports, hasTestFunction, languages)
    {
        //Set Firmware:
        _firmware = "Inconnu";
        
        //Set ports:
        _ports = new List<string> { "HDMI", "USB", "WIFI", "Bluetooth"};
        
        //Set languages:
        _languages = new List<string> {"C++" };

        //Properties from MC2:
        _voltage = mc2._voltage;
        _dimensions = mc2._dimensions;
        _producer = mc2._producer;
        _model = mc2._model;
        _disk = mc2._disk;
        _gpios = mc2._gpios;
        _isTestSystem = mc2._isTestSystem;
        
        //thickness(cm):
        _dimensions.Add(0.77M);
    }

    public Adapter2(MC2 mc2)
    {
        //Set Firmware:
        _firmware = "Inconnu";
        
        //Set ports:
        _ports = new List<string> { "HDMI", "USB", "WIFI", "Bluetooth"};
        
        //Set languages:
        _languages = new List<string> {"C++" };

        //Properties from MC2:
        _voltage = mc2._voltage;
        _dimensions = mc2._dimensions;
        _producer = mc2._producer;
        _model = mc2._model;
        _disk = mc2._disk;
        _gpios = mc2._gpios;
        _isTestSystem = mc2._isTestSystem;
        
        //thickness(cm):
        // _dimensions.Concat(new Decimal[] { 0.77M });
        _dimensions.Add(0.77M);
    }
}