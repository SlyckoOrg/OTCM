namespace a
{
    public class MC1
    {
        //Properties are Read-only:
        public List<double> _voltage { get; private set; }
        public string  _firmware  { get; private set; }
        public string _disk  { get; set; }
        public  Dictionary<int, string> _gpios  { get; private set; }
        public List<string> _ports  { get; private set; }
        public List<string> _languages  { get; private set; }
    
    
        public MC1()
        {
            _voltage = new List<double>();
            _voltage.Add(3.3);
            _firmware = "circuit Python";
            _disk = "carte SD";
            
            _gpios = new Dictionary<int, string>();
            _gpios.Add(1, "VIN");
            _gpios.Add(2, "DATA");
            _gpios.Add(3, "DATA");
            _gpios.Add(4, "DATA");
            _gpios.Add(5, "DATA");
            _gpios.Add(6, "DATA");
            _gpios.Add(7, "OTHER");
            _gpios.Add(8, "OTHER");
            _gpios.Add(9, "GND");
            _gpios.Add(10, "OTHER");
            _gpios.Add(11, "OTHER");
            _gpios.Add(12, "DATA");
            _gpios.Add(13, "DATA");
            _gpios.Add(14, "OTHER");
            _gpios.Add(15, "OTHER");
            _gpios.Add(16, "OTHER");
            
            _ports = new List<string>();
            _ports.Add("HDMI");
            _ports.Add("micro-USB");
            _ports.Add("WIFI");
            _languages = new List<string>();
            _languages.Add("Python");
        }
    
        public MC1( List<double> voltage, string firmware,string disk, Dictionary<int, string> gpios, List<string> ports, List<string> languages)
        {
            _voltage = voltage;
            _firmware = firmware;
            _disk = disk;
            _gpios = gpios;
            _ports = ports;
            _languages = languages;
        }
    }
}

