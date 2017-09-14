using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace _09.BookLibrary
{
    class BookLibrary
    {
        static void Main()
        {
            var input = File.ReadAllLines(@"../../input.txt");
            Library library = new Library();
            library.Name = "Sevi";
            var outputValue = new Dictionary<string, double>();

            for (int i = 1; i < input.Length; i++)
            {
                var currentLine = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                library.Books.Add(CreateBook(currentLine[0], currentLine[1], currentLine[2], currentLine[3],  currentLine[4], double.Parse(currentLine[5])));
            }

            foreach (var book in library.Books)
            {
                if (!outputValue.ContainsKey(book.Author))
                {
                    outputValue.Add(book.Author, book.Price);
                }
                else
                {
                    outputValue[book.Author] += book.Price;
                }
            }

            foreach (var value in outputValue.OrderByDescending(n => n.Value).ThenBy(m => m.Key))
            {
                File.AppendAllText(@"../../output.txt", value.Key + " -> " + value.Value.ToString("0.00") + Environment.NewLine);
            }

        }

        private static Book CreateBook(string title, string author, string publisher, string releaseDate, string isbnNumber, double price)
        {
            var book = new Book();
            book.Author = author;
            book.Publisher = publisher;
            book.Title = title;
            book.ReleaseDate = releaseDate;
            book.Price = price;
            book.IsbnNumber = isbnNumber;

            return book;
        }
    }
}