using Library.Business.Models;
using Library.Business.Repositories.Interfaces;
using Library.Business.Services.Interfaces;
using Library.Database.Models;
using Microsoft.Extensions.Logging;

namespace Library.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IHttpContextAcessorService _httpContextAcessorService;
        private readonly ILogger<BookService> _logger;

        public BookService(
            IBookRepository bookRepository,
            IHttpContextAcessorService httpContextAcessorService,
            ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _httpContextAcessorService = httpContextAcessorService;
            _logger = logger;
        }

        public async Task AddAsync(BookDTO model)
        {
            Book dbBook = new()
            {
                Id = Guid.NewGuid(),
                Title = model.Title,
                Description = model.Description,
                FilePath = model.FilePath,
                CreatedOn = DateTime.Now,
                CreatedBy = "danielnenciu", //_httpContextAcessorService.GetUsername(),
                BookAuthors = model.Authors == null ? new List<BookAuthor>() : model.Authors.Select(x => new BookAuthor { BookId = model.Id, AuthorId = x.Id.Value }).ToList()
            };

            //write file to disk
            if (!string.IsNullOrWhiteSpace(model.CoverImageFileName))
            {
                string filename = $"{dbBook.Id}{Path.GetExtension(model.CoverImageFileName)}";

                model.FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\BooksCovers", filename);
                model.CoverImageContent = model.CoverImageContent.Substring(model.CoverImageContent.LastIndexOf(',') + 1);

                File.WriteAllBytes(model.FilePath, Convert.FromBase64String(model.CoverImageContent));
            }

            await _bookRepository.AddAsync(dbBook);
        }


        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<GridResult<BookDTO>> FilterAsync(FiltersDTO filters)
        {
            if (filters == null)
            {
                _logger.LogError("Filter model was not provided");
                return new GridResult<BookDTO>();
            }

            //material paginator starts from 0
            filters.CurrentPage++;

            int totalItems = await _bookRepository.GetFilteredCountAsync(filters);
            List<BookDTO> items = await _bookRepository.GetFilteredBooksAsync(filters);

            return new GridResult<BookDTO>
            {
                Items = items,
                Total = totalItems
            };
        }

        public async Task<BookDTO> GetByIdAsync(Guid id)
        {
            BookDTO result = await _bookRepository.GetByIdAsync(id);
            return result;
        }

        public async Task UpdateAsync(BookDTO model)
        {
            //write file to disk
            if (!string.IsNullOrWhiteSpace(model.CoverImageFileName))
            {
                string filename = $"{model.Id}{Path.GetExtension(model.CoverImageFileName)}";

                model.FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Files\\BooksCovers", filename);
                model.CoverImageContent = model.CoverImageContent.Substring(model.CoverImageContent.LastIndexOf(',') + 1);

                File.WriteAllBytes(model.FilePath, Convert.FromBase64String(model.CoverImageContent));
            }

            Book dbBook = new()
            {
                Id = model.Id,
                LastModified = DateTime.Now,
                ModifiedBy = "danielnenciu", //_httpContextAcessorService.GetUsername(),
                Title = model.Title,
                Description = model.Description,
                FilePath = model.FilePath,
                BookAuthors = model.Authors == null ? new List<BookAuthor>() : model.Authors.Select(x => new BookAuthor { BookId = model.Id, AuthorId = x.Id.Value }).ToList()
            };

            await _bookRepository.UpdateAsync(dbBook);
        }
    }
}
