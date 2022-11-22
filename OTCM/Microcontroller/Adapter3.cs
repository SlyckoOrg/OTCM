namespace a;

public class Adapter3 : MCG

{

    private static Adapter3 _Mc;
    public static Adapter3 Mc
    {
        get
        {
            if (_Mc == null)
            {
                _Mc = new Adapter3(new MC3());
            }

            return _Mc;
        }
    }

    public Adapter3(List<Decimal> voltage, Decimal[] dimensions, string producer, string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool isTestSystem, List<string> languages, MC3 mc3) 
        : base(voltage, dimensions, producer, firmware, model, disk, gpios, ports, isTestSystem, languages)
    {
        _voltage = voltage;
        _dimensions = dimensions;
        _producer = producer;
        _model = model;
        _firmware = firmware;
        _disk = disk;
        _gpios = gpios;
        _ports = ports;
        _isTestSystem = isTestSystem;
        _languages = languages;
    }

    public Adapter3(MC3 mc3)
    {
        _voltage = mc3._voltage;
        _dimensions = mc3._dimensions;
        _producer = mc3._producer;
        _model = mc3._model;
        _firmware = mc3._firmware;
        _disk = mc3._disk;
        _gpios = mc3._gpios;
        _ports = mc3._ports;
        _isTestSystem = mc3._isTestSystem;
        _languages = mc3._languages;
    }

}