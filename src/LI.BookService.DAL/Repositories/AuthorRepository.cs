using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LI.BookService.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly BookServiceDbContext _context;

        public AuthorRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Author> GetAuthorByName(string firstName,string lastName)
        {
            var selectAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName);
            return selectAuthor;
        }
    }
}
