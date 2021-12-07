
namespace LI.BookService.Model.Entities
{
    public class Category : IEntityBase
    { 
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool MultiSelect { get; set; }
        public Category Parent{ get; set; }
    }
}
