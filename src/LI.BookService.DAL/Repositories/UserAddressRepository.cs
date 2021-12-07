using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class UserAddressRepository : GenericRepository<UserAddress>, IUserAddressRepository
    {
        private readonly BookServiceDbContext _context;

        public UserAddressRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// получение адреса пользователя по id пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserAddress> GetAddressUser(int userId)
        {
            var adress = await _context.UserAddresses.FirstOrDefaultAsync(x => x.UserId == userId);
            return adress;
        }
    }
}
