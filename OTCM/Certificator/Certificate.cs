namespace a;

public class Certificate
{
    private List<ITestable> _tests;

    public Certificate()
    {
        _tests = new List<ITestable>();
    }
    
    public Certificate(List<ITestable> tests)
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