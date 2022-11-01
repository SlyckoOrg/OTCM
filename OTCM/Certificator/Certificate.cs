using OTCM;

namespace a;

public class Certificate
{
    private List<ITest> _tests;

    private MCG _mcg;

    public Certificate()
    {
        _tests = new List<ITest>();
        _mcg = new MCG();
    }

    public Certificate(List<ITest> tests, MCG mcg)
    {
        _tests = tests;
        _mcg = mcg;
    }

    public bool DoTests(MCG mcg)
    {
        for (int i = 0; i < _tests.Count; i++)
        {
            // bool testResult = _tests[i].Test(mcg);
            // if (!testResult)
            //     return false;
                //test failed 
        }

        return true;
        //test successful
    }

    public void WriteCertificate()
    {
        //Write the certificate
        // string[] lines =
        // {
        //     "certificat n°"
        // };
        // await File.WriteAllLinesAsync("Certificat.txt", lines);
        TextEditor txtEditor = new TextEditor();
        string[] lines = { "certificat n°1 :" };
        string filePath = "certificat1.txt";
        txtEditor.WriteText(filePath, lines);
    }
}