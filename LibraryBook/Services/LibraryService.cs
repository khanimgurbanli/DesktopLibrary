using LibraryBook.Base;
using LibraryBook.Data;
using LibraryBook.IServices;
using LibraryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryBook.Services
{
    public class LibraryService : Repository<Book>, ILibraryService
    {
        //public LibraryService() { }
        //private readonly IRepository<Book> _repository;
        //public LibraryService(IRepository<Book> repository) => _repository = repository;
        Repository<Book> _repository = new Repository<Book>();
        public Book AddBook(params string[] values)
        {
            //Create a new book]
            Book addBook = new Book();

            addBook.Name = values[0];
            addBook.AuthorName = values[1];
            addBook.PageCount = int.Parse(values[2]);
            addBook.Code = (values[0] as string).GenerateCode();
            addBook.Price = double.Parse(values[3]);

            //And add a new book to list
                _repository.Add(addBook);


            //Show message about added book
            Console.WriteLine("Add a new book");
            return addBook;
        }
        public Book GetBook(string search)
        {
            //Search book in list by name, page count, author name or by other parameters 
            var findBook = _repository.Get((x => x.Name == search
                                            || x.AuthorName == search
                                            || x.PageCount == Double.Parse(search)
                                            || x.Price == double.Parse(search)
                                            || x.Code == search));

            //If not found record in list show from delegat message
            if (findBook == null)
                ErrorLoggerMessage();

            return findBook;
        }
        public List<Book> FindAllBooks(string search)
        {
            //Found book by name, page count, author name or price in list 
            var findBook = _repository.FindAll(x => x.Name == search
                                            || x.AuthorName == search
                                            || x.PageCount == Double.Parse(search)
                                            || x.Price == double.Parse(search)
                                            || x.Code == search);
            return findBook;
        }

        public int RemoveAllBooks(string search)
        {
            var findBook = FindAllBooks(search);

          //If not found record in list show from delegate message
            if (findBook == null)
                ErrorLoggerMessage();

            foreach (var book in findBook)
                findBook.Remove(book);

            //At last show message about deleted books
            Console.WriteLine("Remove book");
            return findBook.Count;
        }
        void ErrorLoggerMessage()
        {
            // Create logger class instance for using logger method
            ErrorLogger errorLogger = new ErrorLogger();

            //Generate  not found error message by delegate
            var errorLoggDelegate = new ErrorLoggDelegateHandler(errorLogger.FindBookLogger);
            errorLoggDelegate.Invoke("Not found book");
        }
    }
}

