using System;



class Book
{
    public string Title { get; set; }
    public string Author{ get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Book Name: {Title} and written by {Author}");
    }
}

class Library
{
    List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);

        Console.WriteLine("Book is added");
    }

    public void ShowALLBook()
    {
        Console.WriteLine("Here is the all books information");
        foreach (Book book in books)
        {
            book.DisplayInfo();
        }
    }
}


class Hudai
{
    public static void Run()
    {
        Book b1 = new Book();
        Book b2 = new Book();
        Book b3 = new Book();

        b1.Title = "hhdai1";
        b1.Author = "Heda1";

        b2.Author = "Heda2";
        b2.Title = "hhdai2";


        b3.Title = "hhdai3";
        b3.Author = "Heda3";


        Library heda = new Library();

        heda.AddBook(b1);
        heda.AddBook(b2);
        heda.AddBook(b3);

        heda.ShowALLBook();
    }
}