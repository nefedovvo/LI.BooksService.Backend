using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IUserListRepository : IGenericRepository<UserList>
    {
        Task<UserList> GetUserListAsync(int userListId, UserListType type);
        Task<List<UserList>> GetExchangeUserListAsync();
        Task<List<OfferList>> GetOfferListAsync(List<DtoVariantes> listVariantes);
    }
}
