using LI.BookService.Core.Interfaces;
using LI.BookService.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LI.BookService.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<UserValueCategory>, ICategoryRepository
    {
        private readonly BookServiceDbContext _context;

        public CategoryRepository(BookServiceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesByUserListIdAsync(int userListId)
        {
            var list = await _context.UserValueCategories.Where(x => x.UserListId == userListId).ToListAsync();

            List<Category> listCategory = new List<Category>();

            foreach (var val in list)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == val.CategoryId);
                if (category != null)
                    listCategory.Add(category);
            }

            return listCategory;
        }

        public async Task<List<UserValueCategory>> GetUserValueCategoryAsync(List<Category> categories)
        {
            List<UserValueCategory> listCategories = new List<UserValueCategory>();

            foreach (var category in categories)
            {
                var userValueCategory = await _context.UserValueCategories.FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId);
                if (userValueCategory != null)
                    listCategories.Add(userValueCategory);
            }

            return listCategories;
        }

        public async Task CreateListCategoriesAsync(List<int> categories, int listId, UserListType listType)
        {
            var newUserList = new UserList()
            {
                ListId = listId,
                TypeList = listType,
                UserValueCategories = categories.Select(x => new UserValueCategory
                {
                    CategoryId = x,                   
                }).ToList()
            };

            await _context.AddAsync(newUserList);           
        }
    }
}
