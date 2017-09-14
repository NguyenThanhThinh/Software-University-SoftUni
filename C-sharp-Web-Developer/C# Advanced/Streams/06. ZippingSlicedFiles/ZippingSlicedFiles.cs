using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

public class ZippingSlicedFiles
{
    public static void Main()
    {
        string sourceFileString = "../../Text.txt";
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
                FileStream destinationDirectory = new FileStream(destinationDirectoryString + "Part-" + i + ".gz", FileMode.Create);
                files.Add(destinationDirectoryString + "Part-" + i + ".gz");
                using (destinationDirectory)
                {
                    byte[] buffer = new byte[sourceFile.Length];
                    int bufferPieces = (int)sourceFile.Length / parts;
                    int readBytes = sourceFile.Read(buffer, 0, bufferPieces);

                    // Compressing files
                    using (GZipStream compress = new GZipStream(destinationDirectory, CompressionMode.Compress, false))
                    {
                        compress.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        return files;
    }

    private static void Assemble(List<string> files, string destinationDirectoryString)
    {
        for (int i = 0; i < files.Count; i++)
        {
            using (FileStream sourceFile = new FileStream(files[i], FileMode.Open))
            {
                byte[] buffer = new byte[sourceFile.Length];
                int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                var uzipedFile = Decompress(buffer);

                using (FileStream fs = new FileStream(destinationDirectoryString + "assembled.txt", FileMode.Append))
                {
                    fs.Write(uzipedFile, 0, uzipedFile.Length);
                }
            }
        }
    }

    private static byte[] Decompress(byte[] gzip)
    {
        // Create a GZIP stream with decompression mode.
        // ... Then create a buffer and write into while reading from the GZIP stream.
        using (GZipStream stream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
        {
            const int size = 4096;
            byte[] buffer = new byte[size];
            using (MemoryStream memory = new MemoryStream())
            {
                int count = 0;
                do
                {
                    count = stream.Read(buffer, 0, size);
                    if (count > 0)
                    {
                        memory.Write(buffer, 0, count);
                    }
                }
                while (count > 0);
                return memory.ToArray();
            }
        }
    }
}