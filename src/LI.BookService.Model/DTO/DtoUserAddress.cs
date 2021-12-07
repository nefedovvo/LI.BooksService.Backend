

namespace LI.BookService.Model.DTO
{
    /// <summary>
    /// дто адрес пользователя
    /// </summary>
    public class DtoUserAddress
    {
        public int Id { get; set; }
        public string AddrIndex { get; set; }
        public string AddrCity { get; set; }
        public string AddrStreet { get; set; }
        public string AddrHouse { get; set; }
        public string AddrStructure { get; set; }
        public string AddrApart { get; set; }
        public bool IsDefault { get; set; }
    }
}
