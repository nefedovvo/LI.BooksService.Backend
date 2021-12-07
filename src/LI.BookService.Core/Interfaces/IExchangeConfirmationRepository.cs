using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeConfirmationRepository : IGenericRepository<ExchangeList>
    {
        Task<ExchangeList> GetExchangeListId(int exchangeListId);
    }
}
