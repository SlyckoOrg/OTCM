using System.Text.Json;
using System.Text.Json.Serialization;
using OTCM;

namespace a;

public class Certifier
{
    private List<ITestable> _tests;
    private List<Certificate> _certificates;
    
    private List<MCG> _MCGS;

    public Certifier()
    {
        _tests = new List<ITestable>();
        _certificates = new List<Certificate>();
        _MCGS = new List<MCG>();
    }

    public void GenerateMCG()
    {
        AddMCG(Adapter1.Mc);
        AddMCG(Adapter2.Mc);
        AddMCG(Adapter3.Mc);
    }

    public void GenerateCertificate(Certificate certificate, MCG microcontroller)
    {
        if (!certificate.DoTests(microcontroller))
        {
            certificate.WriteCertificate();
        }
        else
        {
            Console.WriteLine("Test Failed");
        }
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
        string filePath = "MCG.json";
        //Get current MCG JSON file : 
        string content = TextEditor.Instance().ReadJSON(filePath);
        List<MCG> mcgs = new List<MCG>();
        if(content.Length != 0) mcgs = JsonSerializer.Deserialize<List<MCG>>(content);
        mcgs.Add(mcg);
        //Serialize new list of MCG Data:
        string mcgJSON = JsonSerializer.Serialize(mcgs);
        TextEditor.Instance().WriteFile(filePath, new string[] {mcgJSON});
        _certificates.Add(new Certificate());
            _certificates[0].WriteCertificate();
    }

    public void ReadMCGFile()
    {
        //TODO: Show the MCG data to the user. 
        string filePath = "MCG.json";
        string content = TextEditor.Instance().ReadJSON(filePath);

        List<MCG> mcgs = JsonSerializer.Deserialize<List<MCG>>(content);
        for (int i = 0; i < mcgs.Count; i++)
        {
            MCG m = mcgs[i];
            string line = $"MCG n°{i} : \n" +
                          $"voltage = {string.Join("", m._voltage.ToArray())}V, \n" +
                          $"dimension = {string.Join("",m._dimensions.ToArray())}, \n" +
                          $"fabriquant = {m._producer} \n" +
                          $"modèle = {m._model} \n" +
                          $"micrologiciel = {m._firmware} \n" +
                          $"disque = {m._disk} \n" +
                          $"GPIOs = {string.Join("",m._gpios.ToArray())} \n" +
                          $"Ports = {string.Join("",m._ports.ToArray())} \n" +
                          $"Languages supportés = {string.Join("",m._languages.ToArray())} \n \n";
            Console.WriteLine(line);
        }
    }

    public void Dialog()
    {
        //TODO : Decide either we keep the Interface class or we use Dialog as main() program to interact with the user   
    }
    
}