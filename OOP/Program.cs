using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OOP
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            IsAvailable = isAvailable;
        }

        // تعديل التنسيق هنا باستخدام String.Format بدلاً من استخدام $.
        public override string ToString()
        {
            return String.Format("Title: {0}, Author: {1}, Available: {2}", Title, Author, (IsAvailable ? "Yes" : "No"));
        }
    }

    class LibraryCatalogue
    {
        private List<Book> books;

        public LibraryCatalogue()
        {
            books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        public void SearchByTitle(string title)
        {
            var results = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplaySearchResults(results);
        }

        public void SearchByAuthor(string author)
        {
            var results = books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplaySearchResults(results);
        }

        public void DisplayAvailableBooks()
        {
            var availableBooks = books.Where(b => b.IsAvailable).ToList();

            if (availableBooks.Count == 0)
            {
                Console.WriteLine("No books are currently available.");
            }
            else
            {
                Console.WriteLine("Available Books:");
                foreach (var book in availableBooks)
                {
                    Console.WriteLine(book);
                }
            }
        }

        public void DisplayAvailableBooksCount()
        {
            int availableCount = books.Count(b => b.IsAvailable);
            Console.WriteLine("Number of available books: " + availableCount);
        }

        private void DisplaySearchResults(List<Book> results)
        {
            if (results.Count == 0)
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                Console.WriteLine("Search Results:");
                foreach (var book in results)
                {
                    Console.WriteLine(book);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LibraryCatalogue library = new LibraryCatalogue();

            while (true)
            {
                Console.WriteLine("\nLibrary Catalogue Menu:");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Search for a book by title");
                Console.WriteLine("3. Search for a book by author");
                Console.WriteLine("4. Display available books");
                Console.WriteLine("5. Display the number of available books");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter book author: ");
                        string author = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                        {
                            Console.WriteLine("Title and author cannot be empty. Please try again.");
                            continue;
                        }

                        bool isAvailable;
                        while (true)
                        {
                            Console.Write("Is the book available? (yes/no): ");
                            string availabilityInput = Console.ReadLine();
                            if (availabilityInput.Equals("yes", StringComparison.OrdinalIgnoreCase))
                            {
                                isAvailable = true;
                                break;
                            }
                            else if (availabilityInput.Equals("no", StringComparison.OrdinalIgnoreCase))
                            {
                                isAvailable = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                            }
                        }

                        library.AddBook(new Book(title, author, isAvailable));
                        break;

                    case "2":
                        Console.Write("Enter title to search: ");
                        string searchTitle = Console.ReadLine();
                        library.SearchByTitle(searchTitle);
                        break;

                    case "3":
                        Console.Write("Enter author to search: ");
                        string searchAuthor = Console.ReadLine();
                        library.SearchByAuthor(searchAuthor);
                        break;

                    case "4":
                        library.DisplayAvailableBooks();
                        break;

                    case "5":
                        library.DisplayAvailableBooksCount();
                        break;

                    case "6":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

