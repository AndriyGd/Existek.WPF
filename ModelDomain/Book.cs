using System.ComponentModel.DataAnnotations;

namespace ModelDomain
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public int Pages { get; set; }
        [Required]
        public string Author { get; set; }
        public int PublishYear { get; set; }
    }
}
