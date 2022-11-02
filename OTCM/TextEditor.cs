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
                string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string[] folderPaths = Directory.GetDirectories(@$"{projectRootPath}", "*.*",
                        SearchOption.TopDirectoryOnly);
                string resultFolderPath = projectRootPath + "//Results";
                StreamWriter writer = null;

                try
                {
                        if (!folderPaths.Contains("Results"))
                        {
                                writer = new StreamWriter(Directory.CreateDirectory(resultFolderPath).FullName + "//certificat.txt");
                        }
                        else
                        {
                                var file = File.Create(resultFolderPath + "//certificat.txt");
                                writer = new StreamWriter(file);
                        }
                }
                catch (Exception e)
                {
                        Console.WriteLine(e);
                        throw;
                }
                finally
                {
                        foreach (var line in lines)
                        { 
                                writer?.WriteLine(line);
                        }
                        writer?.Close();
                }

        }
}