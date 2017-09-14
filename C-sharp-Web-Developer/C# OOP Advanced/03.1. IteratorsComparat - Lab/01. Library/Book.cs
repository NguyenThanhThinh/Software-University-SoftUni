using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get; set; }
    public int Year { get; set; }
    public IReadOnlyList<string> Authors { get; set; }

    public int CompareTo(Book other)
    {
        if (this.Year == other.Year)
        {
            if (this.Title == other.Title)
            {
                return 0;
            }
            return String.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }
        return this.Year.CompareTo(other.Year);
    }

    public override string ToString()
    {
        return String.Format($"{this.Title} - {this.Year}");
    }
}