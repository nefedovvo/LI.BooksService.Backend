using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
   public interface IUserRepository : IGenericRepository<User>
    { 
        // <summary>
        /// получение пользователя по id 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> GetUser(int id);
        Task<User> Authenticate(string UserName,string Password);
    }
}

