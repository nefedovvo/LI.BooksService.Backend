using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IUserAddressService
    {
        /// <summary>
        /// создание адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        Task<DtoUserAddress> CreateUserAddressAsync(DtoUserAddress dtoUserAddress);

        /// <summary>
        /// редактирование адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        Task<DtoUserAddress> EditUserAddressAsync(DtoUserAddress dtoUserAddress);

        /// <summary>
        /// преобразование сущности адреса в дто для отправки пользователю
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoUserAddress> GetAddressUserAsync(int userId);

    }
}
