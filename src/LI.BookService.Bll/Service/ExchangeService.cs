using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class ExchangeService : IExchangeService
    {
        private IExchangeListRepository _exchangeListRepository;
        private IOfferListRepository _offerListRepository;
        private IWishListRepository _wishListRepository;
        private IUserListRepository _userListRepository;
        private ICategoryRepository _userValueCategoryRepository;
        public ExchangeService(IExchangeListRepository exchangeListRepository, IOfferListRepository offerListRepository, IWishListRepository wishListRepository, IUserListRepository userListRepository, ICategoryRepository userValueCategoryRepository)
        {
            _exchangeListRepository = exchangeListRepository;
            _offerListRepository = offerListRepository;
            _wishListRepository = wishListRepository;
            _userListRepository = userListRepository;
            _userValueCategoryRepository = userValueCategoryRepository;
        }

        public async Task<List<DtoExchangeVariantsBook>> GetAllUserIncomingExchangeRequests(int userId)
        {
            var res = await _exchangeListRepository.AllUserIncomingExchangeRequests(userId);

            return res;
        }

        public async Task<List<DtoExchangeVariantsBook>> GetIncomingExchangeRequests(int exchangeListId)
        {
            var res = await _exchangeListRepository.IncomingExchangeRequests(exchangeListId);

            return res;
        }

        /// <summary>
        /// Подбор вариантов для обмена системой
        /// </summary>
        /// <param name="exchangeListId"></param>
        /// <returns></returns>
        public async Task<List<DtoExchangeVariantsBook>> GetVariantesAsync(int exchangeListId)
        {
            var exchangeList = await _exchangeListRepository.GetByIdAsync(exchangeListId);

            var offerlist = await _offerListRepository.GetByIdAsync(exchangeList.OfferList1Id);
            var wishList = await _wishListRepository.GetByIdAsync(exchangeList.WishList1Id);

            var userListOfferType = await _userListRepository.GetUserListAsync(offerlist.OfferListId, UserListType.OfferList);
            var userListWishType = await _userListRepository.GetUserListAsync(wishList.WishListId, UserListType.WishList);

            var userValueCategoryOffer = await _userValueCategoryRepository.GetCategoriesByUserListIdAsync(userListOfferType.UserListId);// нашел категории из офферлистов
            var userValueCategoryWish = await _userValueCategoryRepository.GetCategoriesByUserListIdAsync(userListWishType.UserListId);// нашел категории из вишлистов


            var userValueCategoriesOffer = await _userValueCategoryRepository.GetUserValueCategoryAsync(userValueCategoryOffer);//по списку категорий находим список сущностей UserValueCategory для offerList
            var userValueCategoriesWish = await _userValueCategoryRepository.GetUserValueCategoryAsync(userValueCategoryWish);//по списку категорий находим список сущностей UserValueCategory для wishList

            var userListCategory = await _userListRepository.GetExchangeUserListAsync();//находим все UserList в бд

            var listVariantes = Helper(userListCategory, userValueCategoriesOffer, userValueCategoriesWish);//получаем варианты с процетом совпадения

            var selectOfferLists = await _userListRepository.GetOfferListAsync(listVariantes);//находим все offer-листы,содержащие книги с  выбранными категориями

            var selectBookLiteraries = await _offerListRepository.GetBookLiterariesAsync(selectOfferLists); //находим названия всех книг,которые содержатся в найденных офферлистах

            var selectExchangeLists = await _exchangeListRepository.GetExchangeListsAsync(selectOfferLists);///находим все exchange-листы по найденным offer-листам

            List<DtoExchangeVariantsBook> listDtoExckangeVariantes = new List<DtoExchangeVariantsBook>();

            for (int i = 0; i < selectBookLiteraries.Count(); i++)
            {
                DtoExchangeVariantsBook dto = new DtoExchangeVariantsBook();
                dto.AutorName = selectBookLiteraries.ElementAt(i).BookName;
                dto.DtoVariantes = listVariantes.ElementAt(i);
                dto.ExchangeListId = selectExchangeLists.ElementAt(i).ExchangeListId;

            }

            return listDtoExckangeVariantes;
        }
        /// <summary>
        /// заполняем лист дто с вариантами и процентом совпадения значениями
        /// </summary>
        /// <param name="userListCategory"></param>
        /// <param name="userValueCategoriesOffer"></param>
        /// <param name="userValueCategoriesWish"></param>
        /// <returns></returns>
        public List<DtoVariantes> Helper(List<UserList> userListCategory, List<UserValueCategory> userValueCategoriesOffer, List<UserValueCategory> userValueCategoriesWish)
        {
            List<DtoVariantes> listVariantes = new List<DtoVariantes>();

            foreach (var s in userListCategory)
            {
                if (userValueCategoriesOffer.All(x => s.UserValueCategories.Contains(x)))
                {
                    DtoVariantes variant = new DtoVariantes();
                    variant.PercentCoincidence = 100;
                    variant.VariantesList.Add(s);
                    listVariantes.Add(variant);
                }
                else
                {
                    var result = s.UserValueCategories.Intersect(userValueCategoriesOffer);
                    if (result.Count() != 0)
                    {
                        DtoVariantes variant = new DtoVariantes();
                        variant.VariantesList.Add(s);
                        double percent = (double)result.Count() / s.UserValueCategories.Count();
                        percent *= 100;
                        variant.PercentCoincidence = percent;
                        listVariantes.Add(variant);
                    }
                }
            }

            foreach (var s in userListCategory)
            {
                if (userValueCategoriesWish.All(x => s.UserValueCategories.Contains(x)))
                {
                    DtoVariantes variant = new DtoVariantes();
                    variant.PercentCoincidence = 100;
                    variant.VariantesList.Add(s);
                    listVariantes.Add(variant);
                }
                else
                {
                    var result = s.UserValueCategories.Intersect(userValueCategoriesWish);
                    if (result.Count() != 0)
                    {
                        DtoVariantes variant = new DtoVariantes();
                        variant.VariantesList.Add(s);
                        double percent = (double)result.Count() / s.UserValueCategories.Count();
                        percent *= 100;
                        variant.PercentCoincidence = percent;
                        listVariantes.Add(variant);
                    }
                }
            }

            return listVariantes;
        }

    }
}
