using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_9_Session_11_DEPI
{
    public delegate string BookDelegate(Book b);

    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList, BookDelegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }
    }
}
