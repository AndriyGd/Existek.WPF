using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ModelDomain
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }
        public LibraryContext(string connectionString) : base(connectionString) { }

        public virtual DbSet<Book> Books { get; set; }
    }
}
