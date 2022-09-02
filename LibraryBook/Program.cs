using LibraryBook.Models;
using LibraryBook.Services;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;


namespace LibraryBook
{

    class Program
    {
        public static int CounterId { get; set; } = 1;
        public static int CounterCode { get; set; } = 100;
        static void Main()
        {
            Console.WriteLine("Enter book name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter author name");
            string AuthorName = Console.ReadLine();

            Console.WriteLine("Enter page count");
            double pageCount = Double.Parse(Console.ReadLine());

           BookService bookService = new BookService();
           var createedBook = bookService.CreateBook(name, AuthorName, pageCount);

            LibraryService libraryService = new LibraryService(bookService);

            Console.WriteLine("Enter book for search name");
            string bookname = Console.ReadLine();
            libraryService.FindAllBooksByNAME(bookname);

            Console.WriteLine("Enter book name for remove");
            string removebookname = Console.ReadLine();
            libraryService.RemoveAllBooksByNAME(removebookname);

            Console.WriteLine("Enter any book info for searching");
            string searchInfo = Console.ReadLine();


            Console.WriteLine("Book list");
            libraryService.SearchBooks(searchInfo);

        }
    }
}
//Library book = new Library("Animal Farm","George Orwel", 112);
