using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace LI.BookService.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// создание  пользователя
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        Task<CreateUserDTO> CreateUserAsync(CreateUserDTO createUserDTO);

        /// <summary>
        /// редактирование  пользователя
        /// </summary>
        /// <param name="editedUserDTO"></param>
        /// <returns></returns>
        Task<EditedUserDTO> EditUserAsync(EditedUserDTO editedUserDTO);

        /// <summary>
        /// преобразование сущности в дто 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<GetUserDTO> GetUserAsync(int userId);
        Task<GetUserDTO> Authenticate(LoginUserDTO model);
        Task<GetUserDTO> Register(CreateUserDTO userModel);
    }
}

