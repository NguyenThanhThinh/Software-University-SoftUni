using System;
using System.Collections.Generic;

public class StudentGroup
{
    private static HashSet<String> uniqueStudents;
    private static int counter;

    public StudentGroup()
    {
        uniqueStudents = new HashSet<string>();
    }

    static StudentGroup()
    {
        Counter = 0;
    }

    public HashSet<string> UniqueStudents
    {
        get { return uniqueStudents; }
        set { uniqueStudents = value; }
    }

    public static int Counter
    {
        get { return uniqueStudents.Count; }
        set { counter = value; }
    }
}