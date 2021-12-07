using System;
using System.Collections.Generic;

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// заявка для обмена книги
    /// </summary>
    public class OfferListDto
    {
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string BookName { get; set; }
        public DateTime YearPublishing { get; set; }
        public string ISBN { get; set; }
        public List<int> Categories { get; set; }
    }

}
