namespace a;

public class Adapter1 : MCG
{
    private MC1 _mc1 { get; set; }

    public Adapter1(MC1 mc1)
    {
        //Set Dimensions:
        //weight(g):
        _dimensions[0] = 100;
        //lenght(cm):
        _dimensions[1] = 4.52;
        //width(cm):
        _dimensions[0] = 2.09;
        //thickness(cm):
        _dimensions[0] = 0.9;
        
        //Set Manufacturer:
        _manufacturer = "Raspberry PI";
        
        //Set Firmware:
        _firmware = "RP4000";
        
        //Set Test Function: 
        _hasTestFunction = true;

        //set address for _mc1:
        _mc1 = mc1;
    }
}