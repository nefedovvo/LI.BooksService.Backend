using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.DTO;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IBookLiteraryRepository : IGenericRepository<BookLiterary>
    {
        Task<BookLiterary> GetBookLiterary(OfferListDto requestBook, Author author);
    }
}
