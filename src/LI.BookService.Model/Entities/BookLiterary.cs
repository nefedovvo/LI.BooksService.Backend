namespace LI.BookService.Model.Entities
{
    public class BookLiterary : IEntityBase
    {
        public int BookLiteraryId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public string Note { get; set; }
        public Author Author { get; set; }
    }
}
