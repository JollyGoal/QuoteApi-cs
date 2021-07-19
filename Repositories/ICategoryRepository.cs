using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Repositories
{
    public interface ICategoryRepository
    {
        // get all categories
        Task<IEnumerable<Category>> GetCategories();
        // get an Category by Id
        Task<Category> GetCategoryById(long id);
        // add an Category
        Task<Category> AddCategory(Category categoryPayload);
        // update an Category
        Task<Category> UpdateCategory(Category categoryPayload);
        // delete an Category by Id
        Task<bool> DeleteCategoryById(long id);
    }
}