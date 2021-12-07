using LI.BookService.DAL.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<Author> GetAuthorByName(string firstName, string lastName);

    }
}
