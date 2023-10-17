using Library.Business.Models;

namespace Library.Business.Services.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(BookDTO model);

        Task DeleteAsync(Guid id);

        Task<GridResult<BookDTO>> FilterAsync(FiltersDTO filters);

        Task<BookDTO> GetByIdAsync(Guid id);

        Task UpdateAsync(BookDTO model);
    }
}
