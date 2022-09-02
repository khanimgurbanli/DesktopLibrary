using LibraryBook.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.Services
{
    public delegate void ErrorLoggDelegate(string message);

    internal class Logger : ILogger
    {
        public void SetLogger(string log)
        {
            Console.WriteLine($"Set  Logger  -> {log}");
        }
    }
    public class ErrorLogger : ILogger
    {
        public void SetLogger(string log)
        {
            Console.WriteLine($"Set  Logger  -> {log}");
        }
        public void FindBookLogger(string log)
        {
            Console.WriteLine($"Don't found bbok -> {log}");
        }
    }
}
