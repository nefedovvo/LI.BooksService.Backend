using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using LI.BookService.Model.Entities;

namespace LI.BookService.Model.DTO
{
    public class GetUserDTO: ClaimsPrincipal
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

        public GetUserDTO Map(User user)
        {
            return new GetUserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                SecondName = user.SecondName,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                Rating = user.Rating,
                CreatedAt = user.CreatedAt,
                Enabled = user.Enabled,
                Avatar = user.Avatar,
                IsStaff = user.IsStaff,
                IsSuperAdmin = user.IsSuperAdmin,
                Token = user.Token
            };
        }
    }
}

