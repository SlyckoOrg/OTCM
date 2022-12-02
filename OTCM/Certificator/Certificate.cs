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
        _mcg = new MCG(new List<Decimal>(), new List<Decimal>(new [] { 0.0M }), 
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
        Action<int, ITestable> testBar = new Tools().TestBar;
        for (int i = 1; i <= _tests.Count; i++)
        {
            testBar(i * 20 / (_tests.Count), _tests[i - 1]);
            bool testResult = _tests[i - 1].Test(mcg);
            if (!testResult)
            {
                testBar(-1, _tests[i - 1]);
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
        
        var certificateDate = DateTime.Now;
        string filePath = CertificateName(certificateDate.ToString("yyyy-MM-dd_HH-mm-ss"));

        linesList.Add("Certificat : " + "CERTIFICATE N*" + TextEditor.getCertificateNumber()+1);

        linesList.Add("Date : " + certificateDate.ToString("yyyy-MM-dd"));
        
        linesList.Add("Tests : ");
        foreach(var test in _tests)
        {
            linesList.Add(item:test.ToString());
        }
        
        linesList.Add("MCG Infos : ");
        linesList.Add(_mcg.ToString());

        lines = linesList.ToArray();
        txtEditor.WriteFile(filePath, lines);
    }

    private string CertificateName(String date)
    {
        return $"certificate_{TextEditor.getCertificateNumber()+1}_{date}.txt";
    }
}