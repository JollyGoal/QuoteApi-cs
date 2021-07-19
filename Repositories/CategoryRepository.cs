using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace QuoteApi_cs.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        // get all Categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        // get an Category by Id
        public async Task<Category> GetCategoryById(long id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // add an Category
        public async Task<Category> AddCategory(Category Category)
        {
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }
        // update an Category
        public async Task<Category> UpdateCategory(Category Category)
        {
            _context.Categories.Update(Category);
            await _context.SaveChangesAsync();
            return Category;
        }
        // delete an Category by Id
        public async Task<bool> DeleteCategoryById(long id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}