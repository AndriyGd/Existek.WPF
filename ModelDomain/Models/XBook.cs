using PropertyChanged;

namespace ModelDomain.Models
{
    [AddINotifyPropertyChangedInterface]
    public class XBook : IBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
    }
}
