using QuoteApi_cs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteApi_cs.Repositories
{
    public interface IAuthorRepository
    {
        // get all Authors
        Task<IEnumerable<Author>> GetAuthors();
        // get an Author by Id
        Task<Author> GetAuthorById(long id);
        // add an Author
        Task<Author> AddAuthor(Author authorPayload);
        // update an Author
        Task<Author> UpdateAuthor(Author authorPayload);
        // delete an Author by Id
        Task<bool> DeleteAuthorById(long id);
    }
}