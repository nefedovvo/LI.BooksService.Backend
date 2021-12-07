namespace LI.BookService.Model.Entities
{
    public class List:IEntityBase
    {
        public int ListId { get; set; }
        public int OfferListId { get; set; }
        public int WishListId { get; set; }

        public OfferList OfferList { get; set; }
        public WishList WishList { get; set; }
    }
}
