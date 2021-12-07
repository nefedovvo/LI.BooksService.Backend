using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class ExchangeConfirmationRepository : GenericRepository<ExchangeList>, IExchangeConfirmationRepository
    {
        private readonly BookServiceDbContext _context;

        public ExchangeConfirmationRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExchangeList> GetExchangeListId(int exchangeListId)
        {
            var exList = await _context.ExchangeLists.SingleOrDefaultAsync(x => x.ExchangeListId == exchangeListId);
            return exList;
        }
    }
}

