using System;
using System.Collections.Generic;
using System.Linq;
using MVVMCore.Helpers;

namespace ModelDomain.BooRepositories
{
    using System.Data.Entity;
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
            var dbBook = GetDbBook(book);
            if (dbBook == null) return false;

            CopyValueHelper.CopyValuesOfDifferentEntity(book, dbBook);

            Db.SaveChanges();

            return true;
        }

        public bool RemoveBook(IBook book)
        {
            var dbBook = GetDbBook(book);
            if (dbBook == null) return false;

            Db.Books.Remove(dbBook);
            Db.SaveChanges();

            return true;
        }

        public List<IBook> ReloadBooks(List<IBook> books)
        {
            var reloadedBooks = new List<IBook>();
            foreach (var book in books)
            {
                var dbBook = GetDbBook(book);

                Db.Entry(dbBook).State = EntityState.Unchanged;
                Db.Entry(dbBook).Reload();

                CopyValueHelper.CopyValuesOfDifferentEntity(dbBook, book);

                reloadedBooks.Add(book);
            }

            return reloadedBooks;
        }

        private Book GetDbBook(IBook book)
        {
            var dbBook = Db.Books.FirstOrDefault(b => b.BookId == book.BookId);
            return dbBook;
        }
    }
}
