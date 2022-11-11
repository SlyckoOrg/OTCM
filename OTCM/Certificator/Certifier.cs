using System.Text.Json;
using OTCM;

namespace a;

public class Certifier
{
    private List<ITestable> _tests;
    private List<Certificate> _certificates;
    
    private List<MCG> _MCGS;

    public void GenerateMCG()
    {
        AddMCG(Adapter1.Mc);
        AddMCG(Adapter2.Mc);
        AddMCG(Adapter3.Mc);
    }

    public void GenerateCertificate(Certificate certificate, MCG microcontroller)
    {
        certificate.DoTests(microcontroller);
    }

    public void AddCertificate(Certificate certificate)
    {
        _certificates.Add(certificate);
    }

    public void AddMCG(MCG mcg)
    {
        _MCGS.Add(mcg);
    }

    public void SaveMCG(MCG mcg)
    {
        //TODO: Serialize MCG data in a DLL or JSon file 
        //Serialize MCG Data:
        string mcgJSON = JsonSerializer.Serialize(mcg);
        string filePath = "MCG"+mcg._model+".json";
        TextEditor.Instance().WriteJSON(filePath, mcgJSON);
    }

    public void ReadMCGFile()
    {
        //TODO: Show the MCG data to the user. 
    }

    public void Dialog()
    {
        //TODO : Decide either we keep the Interface class or we use Dialog as main() program to interact with the user   
    }
    
}