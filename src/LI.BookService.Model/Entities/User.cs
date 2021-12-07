using System;
using System.Collections.Generic;
using System.Text;

namespace LI.BookService.Model.Entities
{
    public class User : IEntityBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public byte[] Avatar { get; set; }
        public bool IsStaff { get; set; }
        public bool IsSuperAdmin { get; set; }
        public string Token { get; set; }

        public List<OfferList> OfferLists { get; set; }
        public List<UserAddress> UserAddresses { get; set; }

        public User() { }


        public User(string FirstName, string LastName, string SecondName,
          string Email, string UserName, string Password,
          int Rating, DateTime CreatedAt, bool Enabled, byte[] Avatar, bool IsStaff, bool IsSuperAdmin, string token,
          List<UserAddress> UserAddresses)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SecondName = SecondName;
            this.Email = Email;
            this.UserName = UserName;
            this.Password = Password;
            this.Rating = Rating;
            this.CreatedAt = CreatedAt;
            this.Enabled = Enabled;
            this.Avatar = Avatar;
            this.IsStaff = IsStaff;
            this.IsSuperAdmin = IsSuperAdmin;
            this.Token = token;
            this.UserAddresses = UserAddresses;
        }
    }
}
