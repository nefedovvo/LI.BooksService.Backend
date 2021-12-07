using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IUserAddressRepository : IGenericRepository<UserAddress>
    {
        /// <summary>
        /// получение адреса пользователя по id пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UserAddress> GetAddressUser(int userId);
    }
}
