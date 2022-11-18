using a;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OTCM.Interface;

public class Tools
{
    
    // ANSI color palette
    private readonly IDictionary<string, string> _palette = new Dictionary<string, string>()
    {
        {"LABEL", "\u001b[1;32m"},
        {"ERROR", "\u001b[1;31m"},
        {"WARNING", "\u001b[1;33m"},
        {"HEADER", "\u001b[1;34m"},
        {"SUCCESS", "\u001b[1;92m"},
        {"NONE", "\u001b[1;0m"},
    };

    // Message tag
    private readonly string _tag;
    
    // Log file path
    private readonly string _logPath;

    // Constructor with tag specification
    public Tools(string tag, string logPath)
    {
        _tag = "\u001b[1;94m[" + tag + "] \u001b[0m";
        _logPath = logPath;
        
        // Initializing/Cleaning the log file
        File.WriteAllText(_logPath, "");
    }
    
    public void Log(string message, string lgType)
    {
        Console.WriteLine(_tag + _palette[lgType] + message + _palette["NONE"]);
    }

    // Enables visual selection between different options (Supports ANSI escape sequences)
    public uint Select(string[] options, string message)
    {
        // Display request
        uint index = 1;

        Console.WriteLine(_tag + message);
        Console.Write(_palette["LABEL"]);
        foreach (var option in options)
        {
            Console.Write("    " + index + "- " + option);
            if (index % 4 == 0)
                Console.WriteLine();
            index++;
        }

        Console.WriteLine(_palette["NONE"]);

        // Parse answer
        uint answer = 0;

        uint.TryParse(Console.ReadLine(), out answer);
        while (answer == 0 || answer > options.Length)
        {
            Console.WriteLine(_tag + _palette["ERROR"] + "Veuillez sélectionner une option valide " +
                              _palette["WARNING"] + "(1-" + options.Length + ")" + _palette["NONE"]);
            uint.TryParse(Console.ReadLine(), out answer);
        }

        return answer;
    }
    
    // Enables inputting specifically typed values
    public T Enter<T>(string message)
    {
        // Display request
        Console.WriteLine(_tag + message + _palette["ERROR"]);

        // Parse answer
        T answer;
        try
        {
            answer = (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
        }
        catch (Exception e)
        {
            return Enter<T>(_palette["ERROR"] + "Veuillez entrer une valeur valide " + _palette["NONE"
            ]);
        }

        return answer;
    }
    
    // Tracing class
    private class _Trace
    {
        [JsonProperty("testId")] public uint _testId { get; set; } // Test id (order of testing)

        [JsonProperty("result")] public bool _result { get; set; }
    }

    // Trace/Logging tool
    public void Trace(uint testId, bool result)
    {
        // Access old logs
        if (!File.Exists(_logPath))
            File.WriteAllText(_logPath, "");

        string oldTraces = File.ReadAllText(_logPath);
        List<_Trace> traces = JsonConvert.DeserializeObject<List<_Trace>>(oldTraces) 
                              ?? new List<_Trace>();
        
        // Append new log
        traces.Add(new _Trace{_testId = testId, _result = result});
        string newTraces = JsonConvert.SerializeObject(traces);
        File.WriteAllText(_logPath, newTraces);
    }
}