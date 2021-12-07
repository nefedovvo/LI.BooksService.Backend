namespace LI.BookService.Model.Entities
{
    public class UserExchangeList : IEntityBase
    {
        public int UserExchangeListId { get; set; }
        public int ExchangeListId { get; set; }
        public int OfferListId { get; set; }
        public string TrackNumber { get; set; }
        public bool Receiving { get; set; }
        public ExchangeList ExchangeList { get; set; }
        public OfferList OfferList { get; set; }
    }
}
