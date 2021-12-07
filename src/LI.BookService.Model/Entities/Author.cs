namespace LI.BookService.Model.Entities
{
    public class Author : IEntityBase
    {
        public int AuthorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
