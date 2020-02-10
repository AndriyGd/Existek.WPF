namespace WPF.Lesson12.Model
{
    public class DisplayBook
    {
        public Book Book { get; set; }
        public bool IsSelected { get; set; }

        public DisplayBook(Book book)
        {
            Book = book;
        }
    }
}
