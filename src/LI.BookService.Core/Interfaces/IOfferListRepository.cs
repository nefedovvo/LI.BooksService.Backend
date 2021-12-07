using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IOfferListRepository : IGenericRepository<OfferList>
    {

        /// <summary>
        /// получаем все заявки пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<OfferList>> GetAllForUserAsync(int userId);


        Task<List<OfferList>> GetAllActiveForUserAsync(int userId);


        /// <summary>
        /// из списка офферлистов получаем названия книг
        /// </summary>
        /// <param name="offerLists"></param>
        /// <returns></returns>
        Task<List<BookLiterary>> GetBookLiterariesAsync(List<OfferList> offerLists);
    }
}
