namespace a;

public class Adapter1 : MCG
{
    public MC1 _mc1 { get; private set; }

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
   
        //set address for _mc1:
        _mc1 = mc1;
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
       _firmware = "RP4000";
         
       //Set Test Function: 
       _isTestSystem = true;

       //set address for _mc1:
       _mc1 = mc1;
   }
}