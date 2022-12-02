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
        // AddMCG(Adapter1.Mc);
        // AddMCG(Adapter2.Mc);
        // AddMCG(Adapter3.Mc);
        GetMCGFromFile();
    }

    public bool GenerateCertificate(Certificate certificate, MCG microcontroller)
    {
        if (!certificate.DoTests(microcontroller))
        {
            certificate.WriteCertificate();
            return true;
        }
        return false;
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
    
    
    public void resetMCGFile()
    {
        string filePath = "MCG.json";
        //write blank content on MCG file : 
        TextEditor.Instance().WriteFile(filePath, new string[] {});

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
            string line = $"MCG n°{i+1} :\n" +
                          $"voltage = {string.Join("V - ", m._voltage.ToArray())}V\n" +
                          $"dimension = {string.Join("cm - ",m._dimensions.ToArray())}cm\n" +
                          $"fabriquant = {m._producer}\n" +
                          $"modèle = {m._model}\n" +
                          $"micrologiciel = {m._firmware}\n" +
                          $"disque = {m._disk}\n" +
                          $"GPIOs = {string.Join("",m._gpios.ToArray())}\n" +
                          $"Ports = {string.Join(" - ",m._ports.ToArray())}\n" +
                          $"Languages supportés = {string.Join(" - ",m._languages.ToArray())}\n\n";
            Console.WriteLine(line);
        }
    }
    
    

    private void GetMCGFromFile()
    {
        string filePath = "MCG.json";
        string content = TextEditor.Instance().ReadJSON(filePath);

        _MCGS = JsonSerializer.Deserialize<List<MCG>>(content);
    }

    public List<string> ListMCGString()
    {
        List<string> mcgList = new List<string>();
        for(int i = 0; i <_MCGS.Count; i++)
            mcgList.Add("MC"+ (i + 1));
        return mcgList;
    }

    public MCG GetMCG(int i)
    {
        return _MCGS[i];
    }
    public void Dialog()
    {
        //TODO : Decide either we keep the Interface class or we use Dialog as main() program to interact with the user   
    }

}