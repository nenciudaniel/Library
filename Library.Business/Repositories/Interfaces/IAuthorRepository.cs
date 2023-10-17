using Library.Database.Models;

namespace Library.Business.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAsync(Author entity);

        Task<int> DeleteAsync(Guid id);

        Task<List<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(Guid id);

        Task<int> UpdateAsync(Author entity);
    }
}
