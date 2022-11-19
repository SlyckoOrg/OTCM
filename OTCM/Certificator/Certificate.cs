using OTCM;
using OTCM.Interface;

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
        Action<int> testBar = new Tools().TestBar;
        for (int i = 0; i < _tests.Count; i++)
        {
            testBar(i * 20 / (_tests.Count - 1));
            bool testResult = _tests[i].Test(mcg);
            if (!testResult)
            {
                testBar(-1);
                return false;
                //test failed
            }
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