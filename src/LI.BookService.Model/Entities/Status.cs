using System.Collections.Generic;

namespace LI.BookService.Model.Entities
{
    public class Status : IEntityBase
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
    }
}
