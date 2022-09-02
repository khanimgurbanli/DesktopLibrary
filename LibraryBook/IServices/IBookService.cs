using LibraryBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.IServices
{
    public interface IBookService
    {
        Book CreateBook (string name,string authhorName,double pageCount);
        List<Book> BookList ();
    }
}
