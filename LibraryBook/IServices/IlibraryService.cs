using LibraryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.IServices
{
    public interface IlibraryService
    {
         List<Book> FindAllBooksByNAME(string bookName);
         List<Book> RemoveAllBooksByNAME(string bookName);
         List<Book> SearchBooks(string bookInfo);
         void RemoveBooksByCode(string Code);
    }
}
