using System.Collections.Generic;
using System.IO;

public class SlicingFIle
{
    public static void Main()
    {
        string sourceFileString = "../../HD Wallpaper.jpg";
        string destinationDirectoryString = "../../";
        int parts = 3;
        List<string> files = Slice(sourceFileString, destinationDirectoryString, parts);
        Assemble(files, destinationDirectoryString);
    }

    private static List<string> Slice(string sourceFileString, string destinationDirectoryString, int parts)
    {
        FileStream sourceFile = new FileStream(sourceFileString, FileMode.Open);
        List<string> files = new List<string>();
        using (sourceFile)
        {
            for (int i = 0; i < parts; i++)
            {
                FileStream destinationDirectory = new FileStream(destinationDirectoryString + "Part-" + i + ".jpg", FileMode.Create);
                files.Add(destinationDirectoryString + "Part-" + i + ".jpg");
                using (destinationDirectory)
                {
                    byte[] buffer = new byte[sourceFile.Length];
                    int bufferPieces = (int)sourceFile.Length / parts;
                    int readBytes = sourceFile.Read(buffer, 0, bufferPieces);

                    destinationDirectory.Write(buffer, 0, readBytes);
                }
            }
        }

        return files;
    }

    private static void Assemble(List<string> files, string destinationDirectoryString)
    {
        using (FileStream destinationDirectory = new FileStream(destinationDirectoryString + "assembled.jpg", FileMode.Append))
        {
            for (int i = 0; i < files.Count; i++)
            {
                using (FileStream sourceFile = new FileStream(files[i], FileMode.Open))
                {
                    byte[] buffer = new byte[sourceFile.Length];
                    int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                    destinationDirectory.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}