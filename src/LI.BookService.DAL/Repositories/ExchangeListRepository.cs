using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using LI.BookService.Model.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class ExchangeListRepository : GenericRepository<ExchangeList>, IExchangeListRepository
    {
        private readonly BookServiceDbContext _context;

        public ExchangeListRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ExchangeList>> GetListByIdAsync(int exchangeListId)
        {
            var list = await _context.ExchangeLists.Where(x => x.ExchangeListId == exchangeListId && x.IsBoth).ToListAsync();
            return list;
        }

        public async Task<List<ExchangeList>> GetExchangeListsAsync(List<OfferList> offerLists)
        {
            List<ExchangeList> exchangeLists = new List<ExchangeList>();

            foreach (var s in offerLists)
            {
                var exchangeList = await _context.ExchangeLists.FirstOrDefaultAsync(x => x.OfferList1Id == s.OfferListId);
                if (exchangeList != null)
                    exchangeLists.Add(exchangeList);
            }

            return exchangeLists;
        }

        public async Task<List<DtoExchangeVariantsBook>> IncomingExchangeRequests(int exchangeListId)
        {
            var exchangeList = await this.GetByIdAsync(exchangeListId);

            if (exchangeList.IsBoth)
            {
                return null;
            }

            var incomings = _context.ExchangeLists.
                Where(x => x.OfferList2Id == exchangeList.OfferList1Id && !x.IsBoth)
                .Select(x => new DtoExchangeVariantsBook
                {
                    ExchangeListId = x.ExchangeListId,
                    AutorName = x.OfferList1.User.UserName,
                    DtoVariantes = new DtoVariantes
                    {
                        PercentCoincidence = 80,
                    },
                    ForExchangeListId = exchangeListId
                })
                .ToList();

            return incomings;
        }

        public async Task<List<DtoExchangeVariantsBook>> AllUserIncomingExchangeRequests(int userId)
        {
            var userOfferLists = _context.OfferLists.Where(x => x.UserId == userId).Select(x=> x.OfferListId);

            var res = await _context.ExchangeLists.Where(x => x.OfferList2Id != null)
                .Where(x=> userOfferLists.Contains(x.OfferList2Id.Value) && !x.IsBoth)
                .Select(x=> new DtoExchangeVariantsBook
                {
                    ExchangeListId = x.ExchangeListId,
                    AutorName = x.OfferList1.User.UserName,
                    DtoVariantes = new DtoVariantes
                    {
                        PercentCoincidence = 80,
                    },
                    ForExchangeListId = x.ExchangeListId
                }).ToListAsync();

            return res;
        }

        public async Task<List<Model.DTO.UserExchangeList>> GetAllUserExchangeLists(int userId)
        {
            var res = await _context.ExchangeLists.Where(x => x.OfferList1.UserId == userId).Select(x => new Model.DTO.UserExchangeList
            {
                Autor = x.OfferList1.BookLiterary.Author.LastName + " " + x.OfferList1.BookLiterary.Author.FirstName,
                BookName = x.OfferList1.BookLiterary.BookName,
                CreateDate= x.OfferList1.CreateAt,
                ExchangeListId=x.ExchangeListId,
                Status= (RequestStatus)x.OfferList1.StatusId,
                UpdateDate = x.OfferList1.UpdateAt
            }).ToListAsync();

            return res;
        }
    }
}
