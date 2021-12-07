using System.Collections.Generic;

namespace LI.BookService.Model.DTO
{
    public class DtoNewRequest
    {
        public OfferListDto OfferList { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public List<int> WishListCategories { get; set; }
    }
}
