namespace Common.Models.Entities
{
    public class Post
    {
        public int Postid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; } // Navigation property to Blog
    }
}
