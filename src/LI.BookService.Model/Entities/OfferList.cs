using System;
using System.Collections.Generic;

namespace LI.BookService.Model.Entities
{
    public class OfferList : IEntityBase
    {
        public int OfferListId { get; set; }
        public int BookLiteraryId { get; set; }
        public int UserId { get; set; }
        public string ISBN { get; set; }
        public DateTime YearPublishing { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int StatusId { get; set; }
        public BookLiterary BookLiterary { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
