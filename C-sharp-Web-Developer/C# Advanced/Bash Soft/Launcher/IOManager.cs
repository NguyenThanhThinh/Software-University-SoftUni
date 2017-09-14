using System;
using System.Collections.Generic;
using System.IO;

public static class IOManager
{
    public static void TraverseDirectory(int depth)
    {
        OutputWriter.WriteEmtyLine();
        int initialIdentation = SessionData.currentPath.Split('\\').Length;
        var subFolders = new Queue<string>();
        subFolders.Enqueue(SessionData.currentPath);

        while (subFolders.Count != 0)
        {
            string currentPath = subFolders.Dequeue();
            int identation = currentPath.Split('\\').Length - initialIdentation;

            OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), currentPath));

            try
            {
                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName); // set indexOfLastSlash - 30 if your path is too long

                    // to check if the place for this if statement is here
                    if (depth - identation < 0)
                    {
                        break;
                    }
                }

                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage);
            }
        }
    }

    public static void CreateDirectoryInCurrentFolder(string name)
    {
        string path = SessionData.currentPath + "\\" + name;
        try
        {
            Directory.CreateDirectory(path);
        }
        catch (ArgumentException)
        {
            OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName);
        }
    }

    public static void ChangeCurrentDirectoryRelative(string relativePath)
    {
        try
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf("\\");
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }

            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
        }

    }

    public static void ChangeCurrentDirectoryAbsolute(string absolutePath)
    {
        if (!Directory.Exists(absolutePath))
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            return;
        }

        SessionData.currentPath = absolutePath;
    }
}