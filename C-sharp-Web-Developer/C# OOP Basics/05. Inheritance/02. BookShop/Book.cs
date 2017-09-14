using System;
using System.Text;

public class Book
{
    private string title;
    private string author;
    private double price;

    public Book(string author, string title, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public virtual double Price
    {
        get { return price; }

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }


    public string Author
    {
        get { return author; }

        set
        {
            // I do this if/else here because the name can be only 1 not 2, and then I need to check first char of the single name, not splitting...
            if (value.Contains(" "))
            {
                if (char.IsDigit(value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            else if (char.IsDigit(value[0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }


    public string Title
    {
        get { return title; }

        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Type: ").Append(this.GetType().Name)
            .Append(Environment.NewLine)
            .Append("Title: ").Append(this.Title)
            .Append(Environment.NewLine)
            .Append("Author: ").Append(this.Author)
            .Append(Environment.NewLine)
            .Append("Price: ").Append($"{this.Price:0.0}")
            .Append(Environment.NewLine);

        return sb.ToString();
    }
}