using Library.Business.Models;
using Library.Database.Models;

namespace Library.Business.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task AddAsync(Book entity);

        Task<int> DeleteAsync(Guid id);

        Task<BookDTO> GetByIdAsync(Guid id);

        Task<List<BookDTO>> GetFilteredBooksAsync(FiltersDTO filters);

        Task<int> GetFilteredCountAsync(FiltersDTO filters);

        Task<int> UpdateAsync(Book entity);
    }
}
