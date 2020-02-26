using System;
using System.Collections.Generic;
using System.Linq;

namespace ModelDomain.BooRepositories
{
    public class BookRepository : IBookRepository
    {
        public LibraryContext Db { get; set; }

        public BookRepository()
        {
            var conStr = ConnectionStringFactory.GetConnectionString();
            Db = new LibraryContext(conStr);

            //Db.Database.Delete();
        }

        public List<Book> GetBooks()
        {
            var books = new List<Book>();

            try
            {
                var res = Db.Books.ToList();

                books.AddRange(res);
            }
            catch (Exception e)
            {
                throw;
            }

            return books;
        }

        public void AddBook(Book book)
        {
            Db.Books.Add(book);
            Db.SaveChanges();
        }
    }
}
