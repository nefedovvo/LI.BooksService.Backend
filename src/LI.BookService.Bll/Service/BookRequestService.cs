using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using LI.BookService.Model.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class BookRequestService : IBookRequestService
    {
        private IOfferListRepository _offerListRepository;
        private IAuthorRepository _authorRepository;
        private IBookLiteraryRepository _bookLiteraryRepository;
        private ICategoryRepository _categoryRepository;
        private IWishListRepository _wishListRepository;
        private IExchangeListRepository _exchangeListRepository;

        public BookRequestService(IOfferListRepository offerListRepository, IAuthorRepository authorRepository,
            IBookLiteraryRepository bookLiteraryRepository, ICategoryRepository categoryRepository,
            IWishListRepository wishListRepository, IExchangeListRepository exchangeListRepository)
        {
            _offerListRepository = offerListRepository;
            _authorRepository = authorRepository;
            _bookLiteraryRepository = bookLiteraryRepository;
            _categoryRepository = categoryRepository;
            _wishListRepository = wishListRepository;
            _exchangeListRepository = exchangeListRepository;

        }
        /// <summary>
        /// создание заявки на книгу
        /// </summary>
        /// <param name="dtoNewRequest"></param>
        /// <returns></returns>
        public async Task<int> CreateRequestBook(DtoNewRequest dtoNewRequest)
        {
            var offerList = await CreateOfferListAsync(dtoNewRequest);

            await CreateCategories(dtoNewRequest.OfferList.Categories, offerList.OfferListId, UserListType.OfferList);

            var wishList = await CreateWishList(dtoNewRequest);

            await CreateCategories(dtoNewRequest.WishListCategories, wishList.WishListId, UserListType.WishList);

            if (dtoNewRequest.AddressId == 0 || dtoNewRequest.WishListCategories.Count == 0)
            {
                return 0;
            }

            var id = await CreateExchangeList(offerList, wishList);

            return id;

        }
        
        /// <summary>
        /// редактирование заявки на книгу
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        public async Task EditRequestBookAsync(OfferListDto requestBook)
        {
            var author = await _authorRepository.GetAuthorByName(requestBook.AuthorFirstName, requestBook.AuthorLastName);
            var bookLiterary = await _bookLiteraryRepository.GetBookLiterary(requestBook, author);

            var offerList = await _offerListRepository.GetByIdAsync(requestBook.Id);

            offerList.BookLiteraryId = bookLiterary.BookLiteraryId;
            offerList.ISBN = requestBook.ISBN;
            offerList.UpdateAt = DateTime.Now;
            offerList.YearPublishing = requestBook.YearPublishing;

            await _offerListRepository.UpdateAsync(offerList);

        }
        public async Task<List<Model.DTO.UserExchangeList>> GetAllUserBookRequests(int userId)
        {
            return await _exchangeListRepository.GetAllUserExchangeLists(userId);
        }
        public Task RemoveBookRequest(int exchangeListId)
        {
            throw new NotImplementedException();
        }

        private async Task<Author> CrerateAuthorAsync(OfferListDto requestBook)
        {
            Author author = new Author() { FirstName = requestBook.AuthorFirstName, LastName = requestBook.AuthorLastName };
            await _authorRepository.CreateAsync(author);
            var selectAuthor = await _authorRepository.GetAuthorByName(author.FirstName, author.LastName);

            return selectAuthor;
        }
        private async Task<BookLiterary> CreateBookLIteraryAsync(OfferListDto requestBook, Author author)
        {
            BookLiterary bookLitherary = new BookLiterary() { Author = author, BookName = requestBook.BookName };
            await _bookLiteraryRepository.CreateAsync(bookLitherary);
            var selectBookLiterary = await _bookLiteraryRepository.GetBookLiterary(requestBook, author);

            return selectBookLiterary;
        }
        private async Task CreateCategories(List<int> categories, int listId, UserListType listType)
        {
            await _categoryRepository.CreateListCategoriesAsync(categories, listId, listType);
        }


        private async Task<OfferList> CreateOfferListAsync(DtoNewRequest dtoNewRequest)
        {
            var author = await CrerateAuthorAsync(dtoNewRequest.OfferList);
            var bookLitherary = await CreateBookLIteraryAsync(dtoNewRequest.OfferList, author);

            OfferList newOffer = new OfferList();
            newOffer.BookLiterary = bookLitherary;
            newOffer.YearPublishing = dtoNewRequest.OfferList.YearPublishing;
            newOffer.CreateAt = DateTime.Now;
            newOffer.UpdateAt = DateTime.Now;
            newOffer.UserId = dtoNewRequest.UserId;
            newOffer.StatusId = (int)RequestStatus.New;

            await _offerListRepository.CreateAsync(newOffer);

            return newOffer;

        }

        private async Task<WishList> CreateWishList(DtoNewRequest dtoNewRequest)
        {
            WishList wishList = new WishList();
            wishList.UserId = dtoNewRequest.UserId;
            wishList.UserAddressId = dtoNewRequest.AddressId;
            wishList.CreateAt = DateTime.Now;
            wishList.UpdateAt = DateTime.Now;
            wishList.StatusId = (int)RequestStatus.New;

            await _wishListRepository.CreateAsync(wishList);

            return wishList;
        }
        private async Task<int> CreateExchangeList(OfferList offer, WishList wish)
        {
            ExchangeList exchangeList = new ExchangeList();
            exchangeList.OfferList1Id = offer.OfferListId;
            exchangeList.WishList1Id = wish.WishListId;
            exchangeList.CreateAt = DateTime.Now;

            await _exchangeListRepository.CreateAsync(exchangeList);

            return exchangeList.ExchangeListId;
        }      
    }
}
