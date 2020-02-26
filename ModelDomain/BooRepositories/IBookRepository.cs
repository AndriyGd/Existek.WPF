using System.Collections.Generic;

namespace ModelDomain.BooRepositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();
        void AddBook(Book book);
    }
}
