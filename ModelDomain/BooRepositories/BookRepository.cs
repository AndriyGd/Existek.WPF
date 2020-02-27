using System;
using System.Collections.Generic;
using System.Linq;
using MVVMCore.Helpers;

namespace ModelDomain.BooRepositories
{
    using Models;

    public class BookRepository : IBookRepository
    {
        public Type BookType { get; }
        public LibraryContext Db { get; set; }

        public BookRepository(Type bookType)
        {
            BookType = bookType;
            var conStr = ConnectionStringFactory.GetConnectionString();
            Db = new LibraryContext(conStr);

            //Db.Database.Delete();
        }

        public List<IBook> GetBooks()
        {
            var books = new List<IBook>();

            try
            {
                var res = Db.Books.ToList();
                res.ForEach(b => books.Add(CopyValueHelper.CreateNewAndCopy<Book, IBook>(b, BookType)));
            }
            catch (Exception e)
            {
                throw;
            }

            return books;
        }

        public void AddBook(IBook book)
        {
            var bk = CopyValueHelper.CreateNewAndCopy<IBook, Book>(book);
            Db.Books.Add(bk);
            Db.SaveChanges();
        }

        public bool UpdateBook(IBook book)
        {
            var dbBook = Db.Books.FirstOrDefault(b => b.BookId == book.BookId);

            if (dbBook == null) return false;

            CopyValueHelper.CopyValuesOfDifferentEntity(book, dbBook);

            Db.SaveChanges();

            return true;
        }
    }
}
