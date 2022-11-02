namespace OTCM;
public class TextEditor
{
        // public static async Task WriteText(string fileName, string[] lines)
        // {
        //     Console.WriteLine("writing ...");
        //     await File.WriteAllLinesAsync(fileName, lines);
        // }

        public void WriteText(string fileName, string[] lines)
        {
                string filePath = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\", "Results", fileName)));
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                        Console.WriteLine("writing on "+ filePath + " ...");
                        foreach (string line in lines)
                        {
                                outputFile.WriteLine(line);
                        }
                }
        }
}