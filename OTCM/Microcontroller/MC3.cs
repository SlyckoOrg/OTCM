using System.Collections.Generic;

namespace a
{
    //Properties are Read-only:
    public List<Decimal> _voltage { get; private set; }
    public List<Decimal> _dimensions { get; private set; }
    public string _producer { get; private set; }
    public string _firmware { get; private set; }
    public string _model { get; private set; }
    public string _disk { get; private set; }
    public Dictionary<int, string> _gpios { get; private set; }
    public List<string> _ports { get; private set; }
    public bool _isTestSystem { get; private set; }
    public List<string> _languages { get; private set; }

    public MC3()
    {
        _voltage = new List<Decimal>();
        _voltage.Add(3.3M);
        _voltage.Add(5.0M);
        _dimensions = new List<Decimal>(new [] { 82.0M, 3.8M, 1.72M, 0.68M});
        _producer = "Arduino";
        _model = "AR1240";
        _firmware = "Arduino";
        _disk = "Intégré";
        _gpios = new Dictionary<int, string>();
        _gpios.Add(1, "VIN");
        _gpios.Add(2, "GND");
        _gpios.Add(3, "DATA");
        _gpios.Add(4, "DATA");
        _gpios.Add(5, "DATA");
        _gpios.Add(6, "DATA");
        _gpios.Add(7, "OTHER");
        _gpios.Add(8, "GND");
        _gpios.Add(9, "DATA");
        _gpios.Add(10, "DATA");
        _gpios.Add(11, "DATA");
        _gpios.Add(12, "OTHER");

        _ports = new List<string>();
        _ports.Add("micro-USB");
        _isTestSystem = true;
        _languages = new List<string>();
        _languages.Add("C++");
    }
}

    public MC3(List<Decimal> voltage, List<Decimal> dimensions, string producer,string firmware, string model, string disk,
        Dictionary<int, string> gpios, List<string> ports, bool isTestSystem, List<string> languages)
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
}