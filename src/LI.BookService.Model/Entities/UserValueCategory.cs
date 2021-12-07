namespace LI.BookService.Model.Entities
{
    public class UserValueCategory : IEntityBase
    {
        public int UserValueCategoryId { get; set; }
        public int UserListId { get; set; }
        public int CategoryId { get; set; }
    
        public UserList UserList { get; set; }
        public Category Category { get; set; }
    }
}
