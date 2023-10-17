using Library.Business.Models;

namespace Library.Business.Services.Interfaces
{
    public interface IAuthorService
    {
        Task AddAsync(AuthorDTO model);

        Task DeleteAsync(Guid id);

        Task<List<AuthorDTO>> GetAllAsync();

        Task UpdateAsync(AuthorDTO model);
    }
}
