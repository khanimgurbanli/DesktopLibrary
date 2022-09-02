using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.Models
{
    public class Book
    {
    //    public Book(string name, string authorName, double pageCount)
    //    {
    //        Id = ++CounterId;
    //        Name = name;
    //        AuthorName = authorName;
    //        PageCount = pageCount;
    //        Code = (name.Trim().Substring(0, 2) + CounterCode++);
    //    }

        public static int CounterId { get; set; }
        public static int CounterCode { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public double PageCount { get; set; }
        public string Code { get; set; }
    }
}
