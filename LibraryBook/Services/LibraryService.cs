using LibraryBook.IServices;
using LibraryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.Services
{
    public class LibraryService : IlibraryService
    {
        ErrorLogger errorLogger = new ErrorLogger();
        private readonly IBookService _dbBooks;
        public LibraryService(IBookService books)
        {
            this._dbBooks = books;   
        }

        public List<Book> FindAllBooksByNAME(string bookName)
        {
            var findBook = _dbBooks.BookList().FindAll(x => x.Name == bookName).ToList();
            return findBook;
        }

        public List<Book> RemoveAllBooksByNAME(string bookName)
        {
            ErrorLoggDelegate errorLoggDelegate = new ErrorLoggDelegate(errorLogger.FindBookLogger);
            var findBook = _dbBooks.BookList().FindAll(x => x.Name == bookName).ToList();

            if (findBook == null)
                errorLoggDelegate.Invoke("Not found record");

            foreach (var book in findBook)
            {
                _dbBooks.BookList().Remove(book);
                Console.WriteLine("Remove book");
            }
            return findBook;
        }

        public void RemoveBooksByCode(string Code)
        {
            ErrorLoggDelegate errorLoggDelegate = new ErrorLoggDelegate(errorLogger.FindBookLogger);
            var findBook = _dbBooks.BookList().FirstOrDefault(x => x.Name == Code);

            if (findBook == null)
                errorLoggDelegate.Invoke("Not found book");

            _dbBooks.BookList().Remove(findBook);
            Console.WriteLine("Removed all  book ");
        }

        public List<Book> SearchBooks(string bookInfo)
        {
            ErrorLoggDelegate errorLoggDelegate = new ErrorLoggDelegate(errorLogger.FindBookLogger);

            var findBook = _dbBooks.BookList().FindAll(x => x.Name == bookInfo
            || x.AuthorName == bookInfo
            || x.PageCount == Double.Parse(bookInfo)).ToList();
            foreach (var book in findBook)
            {
                Console.WriteLine($"\nName: {book.Name}\n Authorname: {book.AuthorName }\n Page count: {book.PageCount}\n Code: {book.Code}");
            }

            if (findBook == null)
                errorLoggDelegate.Invoke("Not found book");

            return findBook;
        }
    }
}
