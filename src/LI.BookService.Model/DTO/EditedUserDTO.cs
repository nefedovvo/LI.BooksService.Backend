using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.DTO
{
    public class EditedUserDTO 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
