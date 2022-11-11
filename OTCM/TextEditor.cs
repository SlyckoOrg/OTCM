namespace OTCM;
public class TextEditor
{
        private static TextEditor _instance;

        public static TextEditor Instance()
        {
                if (_instance == null)
                {
                        _instance = new TextEditor();
                }

                return _instance;
        }
        public void WriteText(string fileName, string[] lines)
        {
                string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string resultFolderPath = projectRootPath + "//Files/Results";
                StreamWriter writer = null;

                try
                {
                        writer = new StreamWriter(File.Create(resultFolderPath + $"//{fileName}"));
                }
                catch (Exception e)
                {
                        writer = new StreamWriter(Directory.CreateDirectory(resultFolderPath).FullName + $"//{fileName}");
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

        public void WriteDLL(string fileName, string[] lines)
        {
                
        }

        public void WriteJSON(string fileName,string jsonContent)
        {
                string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string resultFolderPath = projectRootPath + "//Files/MCG";
                StreamWriter writer = null;

                try
                {
                        
                        writer = new StreamWriter(File.Create(resultFolderPath + $"//{fileName}"));
                }
                catch (Exception e)
                {
                        writer = new StreamWriter(Directory.CreateDirectory(resultFolderPath).FullName + $"//{fileName}");
                }
                finally
                {
                        writer.WriteLine(jsonContent);
                        writer?.Close();
                }
        }
}