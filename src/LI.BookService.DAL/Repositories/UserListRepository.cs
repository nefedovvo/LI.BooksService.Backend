using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class UserListRepository : GenericRepository<UserList>, IUserListRepository
    {
        private readonly BookServiceDbContext _context;
        public UserListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserList> GetUserListAsync(int userListId, UserListType type)
        {
            var userList = await _context.UserLists.FirstOrDefaultAsync(x => x.ListId == userListId && x.TypeList == type);
            return userList;
        }
        public async Task<List<UserList>> GetExchangeUserListAsync()
        {
            var userList = await _context.UserLists.Include(x => x.UserValueCategories).ToListAsync();
            return userList;
        }
        public async Task<List<OfferList>> GetOfferListAsync(List<DtoVariantes> listVariantes)
        {
            List<OfferList> listOfferList = new List<OfferList>();

            foreach (var variant in listVariantes)
            {
                foreach (var s in variant.VariantesList)
                {
                    var offer = await _context.OfferLists.FirstOrDefaultAsync(x => x.OfferListId == s.ListId);
                    if (offer != null)
                        listOfferList.Add(offer);
                }
            }

            return listOfferList;
        }
    }
}
