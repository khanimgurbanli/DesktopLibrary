using LibraryBook.IServices;
using LibraryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.Services
{
    public class BookService : IBookService
    {
         List<Book> bookList = new List<Book>();
        public Book CreateBook(string name,string authhorName,double pageCount)
        {
            Book addBook = new Book(); ;
            addBook.Name = name;
            addBook.AuthorName = authhorName;   
            addBook.PageCount=pageCount;

            bookList.Add(addBook);
            return addBook;
            return addBook;
        }

        public List<Book> BookList()
        {
            return bookList;
        }
    }
}
