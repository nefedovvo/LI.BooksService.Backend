using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class UserAddressServicecs : IUserAddressService
    {
        private IUserAddressRepository _userAddressRepository;

        public UserAddressServicecs (IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
        }
        /// <summary>
        /// создание адреса пользователя
        /// </summary>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        public async Task<DtoUserAddress> CreateUserAddressAsync(DtoUserAddress dtoUserAddress)
        {
            UserAddress userAddress = new UserAddress();
            AdressSetValue(userAddress, dtoUserAddress);
            await _userAddressRepository.CreateAsync(userAddress);

            return dtoUserAddress;
        }

        /// <summary>
        /// редактирование адреса пользователя
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="dtoUserAddress"></param>
        /// <returns></returns>
        public async Task<DtoUserAddress> EditUserAddressAsync(DtoUserAddress dtoUserAddress)
        {
            var address = await _userAddressRepository.GetByIdAsync(dtoUserAddress.Id);
            AdressSetValue(address, dtoUserAddress);
            await _userAddressRepository.UpdateAsync(address);

            return dtoUserAddress;
        }

        /// <summary>
        /// хелпер для установки значения полей сущности адреса пользователя
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="dtoUserAddress"></param>
        public void AdressSetValue(UserAddress userAddress, DtoUserAddress dtoUserAddress)
        {
            userAddress.AddrApart = dtoUserAddress.AddrApart;
            userAddress.UserId = 8;
            userAddress.AddrCity = dtoUserAddress.AddrCity;
            userAddress.AddrHouse = dtoUserAddress.AddrHouse;
            userAddress.AddrIndex = dtoUserAddress.AddrIndex;
            userAddress.AddrSreet = dtoUserAddress.AddrStreet;
            userAddress.AddrStructure = dtoUserAddress.AddrStructure;
            userAddress.IsDefault = dtoUserAddress.IsDefault;

        }

        /// <summary>
        /// преобразование сущности адреса в дто для отправки пользователю
        /// </summary>
        /// <param name="userAddress"></param>
        /// <returns></returns>
        public async Task<DtoUserAddress> GetAddressUserAsync(int userId)
        {
            var userAddress = await _userAddressRepository.GetAddressUser(userId);

            DtoUserAddress dtoUserAddress = new DtoUserAddress();
            dtoUserAddress.Id = userAddress.UserAddressId;
            dtoUserAddress.IsDefault = userAddress.IsDefault;
            dtoUserAddress.AddrApart = userAddress.AddrApart;
            dtoUserAddress.AddrCity = userAddress.AddrCity;
            dtoUserAddress.AddrHouse = userAddress.AddrHouse;
            dtoUserAddress.AddrIndex = userAddress.AddrIndex;
            dtoUserAddress.AddrStreet = userAddress.AddrSreet;
            dtoUserAddress.AddrStructure = userAddress.AddrStructure;

            return dtoUserAddress;
        }
    }
}
