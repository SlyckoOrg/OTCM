namespace a;

public class Certificate
{
    private List<ITestable> _tests;

    public Certificate()
    {
        _tests = new List<ITestable>();
        _mcg = new MCG(new List<double>(), new []{0.0}, 
            "", "", "", "", new Dictionary<int, string>(), new List<string>(),
            true, new List<string>(), new List<string>());
    }

    public  Certificate(List<ITestable> tests, MCG mcg)
    {
        _tests = tests;
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
        
    }
}