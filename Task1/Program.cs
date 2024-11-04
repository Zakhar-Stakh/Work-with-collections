using System;
using System.Collections.Generic;

// Клас Document
public class Document
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nContent: {Content}";
    }
}

// Клас DocumentStack
public class DocumentStack
{
    private Stack<Document> documents = new Stack<Document>();

    // Метод для додавання нового документу до стеку
    public void AddDocument(Document document)
    {
        documents.Push(document);
        Console.WriteLine($"Document '{document.Title}' added to the stack.");
    }

    // Метод для видалення верхнього документу зі стеку
    public Document RemoveDocument()
    {
        if (documents.Count > 0)
        {
            Document removedDocument = documents.Pop();
            Console.WriteLine($"Document '{removedDocument.Title}' removed from the stack.");
            return removedDocument;
        }
        Console.WriteLine("No documents in the stack.");
        return null;
    }

    // Метод для отримання верхнього документу зі стеку без його видалення
    public Document PeekDocument()
    {
        if (documents.Count > 0)
        {
            return documents.Peek();
        }
        Console.WriteLine("No documents in the stack.");
        return null;
    }

    // Метод для виведення на екран інформації про верхній документ у стеці
    public void DisplayTopDocument()
    {
        Document topDocument = PeekDocument();
        if (topDocument != null)
        {
            Console.WriteLine("Top Document:");
            Console.WriteLine(topDocument);
        }
    }
}

// Клас Main для тестування DocumentStack
class Program
{
    static void Main(string[] args)
    {
        DocumentStack documentStack = new DocumentStack();

        // Створення документів
        Document doc1 = new Document("Document 1", "Content of Document 1");
        Document doc2 = new Document("Document 2", "Content of Document 2");
        Document doc3 = new Document("Document 3", "Content of Document 3");

        // Додавання документів до стеку
        documentStack.AddDocument(doc1);
        documentStack.AddDocument(doc2);
        documentStack.AddDocument(doc3);

        // Виведення верхнього документу
        documentStack.DisplayTopDocument();

        // Видалення документу зі стеку
        documentStack.RemoveDocument();

        // Виведення верхнього документу після видалення
        documentStack.DisplayTopDocument();

        // Видалення ще одного документу
        documentStack.RemoveDocument();

        // Виведення верхнього документу після другого видалення
        documentStack.DisplayTopDocument();

        // Видалення останнього документу
        documentStack.RemoveDocument();

        // Спроба виведення верхнього документу, коли стек порожній
        documentStack.DisplayTopDocument();
    }
}// See https://aka.ms/new-console-template for more information

