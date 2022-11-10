using a;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OTCM.Interface;

public class Tools
{
    
    // ANSI color palette
    private readonly string[] _palette = 
    { "\u001b[1;32m", "\u001b[1;31m", "\u001b[1;33m", "\u001b[1;94m", "\u001b[0m" }; // Green, Red, Orange, Blue, Normal

    // Message tag
    private readonly string _tag;

    // Constructor with tag specification
    public Tools(string tag)
    {
        _tag = "\u001b[1;94m[" + tag + "] \u001b[0m";
    }

    public void Log(string message, bool error)
    {
        Console.WriteLine(_tag + (error ? _palette[1] : _palette[4]) + message + _palette[4]);
    }

    // Enables visual selection between different options (Supports ANSI escape sequences)
    public uint Select(string[] options, string message)
    {
        // Display request
        uint index = 1;

        Console.WriteLine(_tag + message);
        Console.Write(_palette[0]);
        foreach (var option in options)
        {
            Console.Write("    " + index + "- " + option);
            if (index % 4 == 0)
                Console.WriteLine();
            index++;
        }

        Console.WriteLine(_palette[4]);

        // Parse answer
        uint answer = 0;

        uint.TryParse(Console.ReadLine(), out answer);
        while (answer == 0 || answer > options.Length)
        {
            Console.WriteLine(_tag + _palette[1] + "Veuillez sélectionner une option valide " + _palette[2] + "(1-" +
                              options.Length + ")" + _palette[4]);
            uint.TryParse(Console.ReadLine(), out answer);
        }

        return answer;
    }
    
    // Enables inputting specifically typed values
    public T Enter<T>(string message)
    {
        // Display request
        Console.WriteLine(_tag + message + _palette[4]);

        // Parse answer
        T answer;
        try
        {
            answer = (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
        }
        catch (Exception e)
        {
            return Enter<T>(_palette[1] + "Veuillez entrer une valeur valide " + _palette[4]);
        }

        return answer;
    }
    
    // Tracing class
    private class _Trace
    {
        [JsonProperty("testId")]
        public uint _testId { get; set; }    // Test id (order of testing)

        [JsonProperty("result")] public bool _result { get; set; }
    }


    // Trace/Logging tool
    public void Trace(uint testId, bool result)
    {
        // Log file path
        string logPath = Environment.CurrentDirectory + "log.json";
        
        // Access old logs
        string oldTraces = File.ReadAllText(logPath);
        List<_Trace> traces = JsonConvert.DeserializeObject<List<_Trace>>(oldTraces) 
                              ?? new List<_Trace>();
        
        // Append new log
        traces.Add(new _Trace{_testId = testId, _result = result});
        string newTraces = JsonConvert.SerializeObject(traces);
        File.WriteAllText(logPath, newTraces);
    }
}