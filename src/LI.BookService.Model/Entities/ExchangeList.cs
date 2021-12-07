using System;

namespace LI.BookService.Model.Entities
{
    public class ExchangeList : IEntityBase
    {
        public int ExchangeListId { get; set; }
        public int OfferList1Id { get; set; }
        public int WishList1Id { get; set; }
        public int? OfferList2Id { get; set; }
        public int? WishList2Id { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsBoth { get; set; }
        public OfferList OfferList1 { get; set; }
        public WishList WishList1 { get; set; }

        public OfferList OfferList2 { get; set; }
        public WishList WishList2 { get; set; }
    }
}
