using System;
using System.Collections.Generic;

// Клас Book
public class Book
{
    public int Id { get; }
    public string Title { get; }
    public string Author { get; }
    public decimal Price { get; }

    public Book(int id, string title, string author, decimal price)
    {
        Id = id;
        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Title: '{Title}', Author: {Author}, Price: {Price:C}";
    }
}

// Клас BookStore
public class BookStore
{
    private Dictionary<int, Book> books = new Dictionary<int, Book>();

    // Метод для додавання нової книги до словника
    public void AddBook(Book book)
    {
        if (!books.ContainsKey(book.Id))
        {
            books[book.Id] = book;
            Console.WriteLine($"Book '{book.Title}' added to the store.");
        }
        else
        {
            Console.WriteLine($"A book with ID {book.Id} already exists.");
        }
    }

    // Метод для видалення книги зі словника
    public void RemoveBook(int id)
    {
        if (books.Remove(id))
        {
            Console.WriteLine($"Book with ID {id} has been removed from the store.");
        }
        else
        {
            Console.WriteLine($"No book found with ID {id}.");
        }
    }

    // Метод для отримання інформації про книгу за її унікальним ідентифікатором
    public void GetBookInfo(int id)
    {
        if (books.TryGetValue(id, out Book book))
        {
            Console.WriteLine(book);
        }
        else
        {
            Console.WriteLine($"No book found with ID {id}.");
        }
    }
}

// Клас Main для тестування BookStore
class Program
{
    static void Main(string[] args)
    {
        BookStore bookStore = new BookStore();

        // Створення кількох книг
        Book book1 = new Book(1, "1984", "George Orwell", 9.99m);
        Book book2 = new Book(2, "To Kill a Mockingbird", "Harper Lee", 7.99m);
        Book book3 = new Book(3, "The Great Gatsby", "F. Scott Fitzgerald", 10.99m);

        // Додавання книг до словника
        bookStore.AddBook(book1);
        bookStore.AddBook(book2);
        bookStore.AddBook(book3);

        // Отримання інформації про книгу
        bookStore.GetBookInfo(2); 

        // Видалення книги
        bookStore.RemoveBook(1); 

        // Спроба отримання інформації про видалену книгу
        bookStore.GetBookInfo(1);

        // Видалення неіснуючої книги
        bookStore.RemoveBook(5); 
    }
}