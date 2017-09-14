using System.IO;

public class CopyBinaryFile
{
    public static void Main()
    {
        FileStream file = new FileStream("../../Softuni.jpg", FileMode.Open);
        FileStream copy = new FileStream("../../Softuni-Copied.jpg", FileMode.Create);
        var buffer = new byte[2048];

        using (file)
        {
            using (copy)
            {
                while (true)
                {
                    int readBytesFromFile = file.Read(buffer, 0, buffer.Length);
                    if (readBytesFromFile == 0)
                    {
                        break;
                    }
                    copy.Write(buffer, 0, readBytesFromFile);
                }
            }
        }
    }
}