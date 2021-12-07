using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;

namespace LI.BookService.DAL.Repositories
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        private readonly BookServiceDbContext _context;

        public WishListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
