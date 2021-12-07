using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly BookServiceDbContext _context;

        public UserRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// получение пользователя по id 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUser(int id)
        {
            var user = await _context.User.SingleOrDefaultAsync(x =>  x.UserId==id);
            return user;
        }

        public async Task<User> Authenticate(string UserName, string Password)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.UserName == UserName && x.Password == Password);
            return user;
        }
       
    }
}
