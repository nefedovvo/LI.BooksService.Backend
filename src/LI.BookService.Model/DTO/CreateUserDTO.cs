using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
   public class CreateUserDTO 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string AddrIndex { get; set; }
        public string AddrStructure { get; set; }
        public string AddrSreet { get; set; }

        public string AddrCity { get; set; }
        public string AddrHouse { get; set; }
        public string AddrApart { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
