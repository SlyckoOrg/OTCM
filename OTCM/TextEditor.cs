
using System;
using System.IO;

namespace OCTM
{
        public class TextEditor
{
        private string resultFolderPath;
        private string mcgFolderPath;

        public TextEditor()
        {
                resultFolderPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}//Files//Results";
                if (!Directory.Exists(resultFolderPath))
                        Directory.CreateDirectory(resultFolderPath);
                
                mcgFolderPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}//Files//MCG";
                if (!Directory.Exists(mcgFolderPath))
                        Directory.CreateDirectory(mcgFolderPath);
        }
        
        private static TextEditor _instance;

        public static TextEditor Instance()
        {
                if (_instance == null)
                {
                        _instance = new TextEditor();
                }

                return _instance;
        }
        public void WriteFile(string fileName, string[] lines)
        {
                StreamWriter writer = null;
                string completePath = "";
                switch (fileName.Split(".")[1])
                {
                        case "txt":
                                completePath = resultFolderPath;
                                break;
                        case "json":
                                completePath = mcgFolderPath;
                                break;
                }
                
                try
                {
                        writer = new StreamWriter(File.Create($"{completePath}//{fileName}"));
                }
                catch (Exception e)
                {
                        writer = new StreamWriter($"//{Directory.CreateDirectory(completePath).FullName}//{fileName}");
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

       

        public string ReadJSON(string filename)
        {
                var filenamePath = $"{mcgFolderPath}//{filename}";
                if (!File.Exists(filenamePath))
                {
                        FileStream fileStream = File.Create(filenamePath);
                        fileStream.Close();
                }

                using (StreamReader r = new StreamReader($"{mcgFolderPath}//{filename}"))
                {
                        string json = r.ReadToEnd();

                        return json;
                }
        }
}
}
