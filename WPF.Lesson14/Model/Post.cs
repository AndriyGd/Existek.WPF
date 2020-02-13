namespace WPF.Lesson14.Model
{
    using System.Collections.Generic;

    public class Post
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Visitor> Visitors { get; set; }
    }
}
