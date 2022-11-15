﻿namespace OTCM;
public class TextEditor
{
        private string resultFolderPath;
        private string mcgFolderPath;

        public TextEditor()
        {
                resultFolderPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Files\\Results";
                mcgFolderPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\Files\\MCG";
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
                        writer = new StreamWriter(File.Create($"{completePath}\\{fileName}"));
                }
                catch (Exception e)
                {
                        writer = new StreamWriter($"//{Directory.CreateDirectory(completePath).FullName}\\{fileName}");
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
                using (StreamReader r = new StreamReader($"{mcgFolderPath}\\{filename}"))
                {
                        string json = r.ReadToEnd();

                        return json;
                }
        }
}