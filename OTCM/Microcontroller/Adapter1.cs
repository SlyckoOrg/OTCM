using System.Collections.Generic;

namespace a
{
    public class Adapter1 : MCG
    {
    
        private static Adapter1 _Mc;
    
        public static Adapter1 Mc
        {
            get
            {
                if (_Mc == null)
                {
                    _Mc = new Adapter1(new MC1());
                }
    
                return _Mc;
            }
        }
        
       public Adapter1(List<double> voltage, double[] dimensions, string producer, string firmware, string model, string disk,
            Dictionary<int, string> gpios, List<string> ports, bool hasTestFunction, List<string> languages, MC1 mc1) 
            : base(voltage, dimensions, producer, firmware, model, disk, gpios, ports, hasTestFunction, languages)
        {
            
            //Set Dimensions:
            //weight(g):
            _dimensions[0] = 100;
            //lenght(cm):
            _dimensions[1] = 4.52;
            //width(cm):
            _dimensions[2] = 2.09;
            //thickness(cm):
            _dimensions[3] = 0.9;
            
            //Set Manufacturer:
            _producer = "Raspberry PI";
            
            //Set Firmware:
            _model = "RP4000";
            
            //Set Test Function: 
            _isTestSystem = true;
       
            //Properties from MC1 : 
            _voltage = mc1._voltage;
            _firmware = mc1._firmware;
            _disk = mc1._disk;
            _gpios = mc1._gpios;
            _ports = mc1._ports;
            _languages = mc1._languages;
        }
    
       public Adapter1(MC1 mc1)
       { 
           //Set Dimensions:
           //weight(g):
           _dimensions[0] = 100;
           //lenght(cm):
           _dimensions[1] = 4.52;
           //width(cm):
           _dimensions[2] = 2.09;
           //thickness(cm):
           _dimensions[3] = 0.9;
            
           //Set Manufacturer:
           _producer = "Raspberry PI";
             
           //Set Firmware:
           _model = "RP4000";
             
           //Set Test Function: 
           _isTestSystem = true;
    
           //Properties from MC1 : 
           _voltage = mc1._voltage;
           _firmware = mc1._firmware;
           _disk = mc1._disk;
           _gpios = mc1._gpios;
           _ports = mc1._ports;
           _languages = mc1._languages;
       }
    }
}

