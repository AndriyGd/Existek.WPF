namespace ModelDomain.Models
{
    public interface IBook
    {
        int BookId { get; set; }
        string BookName { get; set; }
        int Pages { get; set; }
        string Author { get; set; }
        int PublishYear { get; set; }
    }
}