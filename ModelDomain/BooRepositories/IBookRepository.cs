using System.Collections.Generic;

namespace ModelDomain.BooRepositories
{
    using System;
    using Models;

    public interface IBookRepository
    {
        Type BookType { get; }
        List<IBook> GetBooks();
        void AddBook(IBook book);
        bool UpdateBook(IBook book);
    }
}
