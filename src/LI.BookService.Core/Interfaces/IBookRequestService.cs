using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IBookRequestService
    {
        /// <summary>
        /// создание заявки на книгу
        /// </summary>
        /// <param name="dtoNewRequest"></param>
        /// <returns></returns>
        Task<int> CreateRequestBook(DtoNewRequest dtoNewRequest);

        /// <summary>
        ///  редактирование заявки на книгу
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        Task EditRequestBookAsync(OfferListDto requestBook);

        Task<List<Model.DTO.UserExchangeList>> GetAllUserBookRequests(int userId);

        Task RemoveBookRequest(int exchangeListId);
    }
}
