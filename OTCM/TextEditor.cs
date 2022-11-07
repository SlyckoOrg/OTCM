namespace OTCM;
public class TextEditor
{
        public void WriteText(string fileName, string[] lines)
        {
                string projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string resultFolderPath = projectRootPath + "//Results";
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
}