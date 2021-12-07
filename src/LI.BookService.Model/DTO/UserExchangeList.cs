using LI.BookService.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    public class UserExchangeList
    {
        public int ExchangeListId { get; set; }

        public string BookName { get; set; }

        public string Autor { get; set; }

        public RequestStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
