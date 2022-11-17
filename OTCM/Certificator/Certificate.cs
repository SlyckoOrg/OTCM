using OTCM;

namespace a;

public class Certificate
{
    private List<ITestable> _tests;
    private MCG _mcg;

    public Certificate()
    {
        _tests = new List<ITestable>();
        _mcg = new MCG(new List<double>(), new []{0.0}, 
            "", "", "", "", new Dictionary<int, string>(), new List<string>(),
            true, new List<string>());
    }

    public Certificate(List<ITestable> tests, MCG mcg)
    {
        _tests = tests;
        _mcg = mcg;
    }

    public bool DoTests(MCG mcg)
    {
        for (int i = 0; i < _tests.Count; i++)
        {
            bool testResult = _tests[i].Test(mcg);
            if (!testResult)
                return false;
                //test failed 
        }

        return true;
        //all tests successful
    }

    public void WriteCertificate()
    {
        //Write the certificate
        TextEditor txtEditor = new TextEditor();
        string[] lines = Array.Empty<string>();
        var linesList = lines.ToList();
        foreach(var test in _tests)
        {
            linesList.Add(item:test.ToString());
        }

        lines = linesList.ToArray();
        string filePath = "certificat1.txt";
        txtEditor.WriteFile(filePath, lines);
        
    }
}