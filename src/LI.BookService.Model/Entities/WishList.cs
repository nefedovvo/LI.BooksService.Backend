using System;

namespace LI.BookService.Model.Entities
{
    public class WishList : IEntityBase
    {
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int StatusId { get; set; }
        public int UserAddressId { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
