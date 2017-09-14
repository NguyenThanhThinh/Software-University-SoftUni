using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TraverseDirectory
{
    public static void Main()
    {
        string[] filePaths = Directory.GetFiles("../../");
        StreamWriter recordFilesPaths = new StreamWriter("../../result.txt");
        Dictionary<string, Dictionary<string, long>> fileExtensions = new Dictionary<string, Dictionary<string, long>>();

        // removing the "../../" part of the filePath
        for (int i = 0; i < filePaths.Length; i++)
        {
            filePaths[i] = filePaths[i].Remove(0, 6);
        }

        // fullfiling the fileExtensions with there keys and values
        for (int j = 0; j < filePaths.Length; j++)
        {
            //if key(extension) is not present, write it
            if (!fileExtensions.ContainsKey(Path.GetExtension(filePaths[j])))
            {
                fileExtensions.Add(Path.GetExtension(filePaths[j]), new Dictionary<string, long>());
            }

            // if key is present, write the file with this extension in it
            if (fileExtensions.ContainsKey(Path.GetExtension(filePaths[j])))
            {
                FileInfo fileSize = new FileInfo("../../" + filePaths[j]); // this line and the bottom one, are to get the size of the file
                long size = fileSize.Length;
                fileExtensions[Path.GetExtension(filePaths[j])].Add(filePaths[j], size); // writing the filename with it's size
            }
        }

        // opening the streamwriter and writing the values
        using (recordFilesPaths)
        {
            foreach (var extension in fileExtensions.OrderByDescending(i => i.Key))
            {
                recordFilesPaths.WriteLine(extension.Key);
                foreach (var fileName in fileExtensions[extension.Key].OrderBy(i => i.Value))
                {
                    recordFilesPaths.WriteLine("--" + fileName.Key + " - " + fileName.Value + "kb");
                }
            }
        }
    }
}