using Library.Business.Models;
using Library.Business.Repositories.Interfaces;
using Library.Business.Services.Interfaces;
using Library.Database.Models;

namespace Library.Business.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IHttpContextAcessorService _httpContextAcessorService;

        public AuthorService(
            IAuthorRepository authorRepository,
            IHttpContextAcessorService httpContextAcessorService)
        {
            _authorRepository = authorRepository;
            _httpContextAcessorService = httpContextAcessorService;
        }

        public async Task AddAsync(AuthorDTO model)
        {
            Author dbAuthor = new()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedBy = "danielnenciu",// _httpContextAcessorService.GetUsername(),
                CreatedOn = DateTime.UtcNow
            };

            await _authorRepository.AddAsync(dbAuthor);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<List<AuthorDTO>> GetAllAsync()
        {
            List<Author> dbAuthors = await _authorRepository.GetAllAsync();

            List<AuthorDTO> result = dbAuthors
                .Select(x => new AuthorDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();

            return result;
        }

        public async Task UpdateAsync(AuthorDTO model)
        {

            Author dbAuthor = new()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                ModifiedBy = "danielnenciu",// _httpContextAcessorService.GetUsername(),
                LastModified = DateTime.UtcNow
            };

            await _authorRepository.UpdateAsync(dbAuthor);
        }
    }
}
