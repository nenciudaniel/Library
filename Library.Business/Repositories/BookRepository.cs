using Library.Business.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Library.Database.Models;
using Library.Business.Models;

namespace Library.Business.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LibraryConnectionString");
        }

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Book entity)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"insert into BOOKS([Id], [Title], [Description], [FilePath], [CreatedBy], [CreatedOn])
                                 values (@Id, @Title, @Description, @FilePath, @CreatedBy, @CreatedOn)";

                await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Description = entity.Description,
                    FilePath = entity.FilePath,
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn
                });

                //add book authors
                string insertAuthorsQuery = string.Empty;

                List<Guid> authorIds = entity.BookAuthors.Select(x => x.AuthorId).ToList();

                if (authorIds.Count > 0)
                {
                    foreach (Guid authorId in authorIds)
                    {
                        insertAuthorsQuery += $" insert into BOOKS_AUTHORS(AuthorId, BookId) values ('{authorId}', '{entity.Id}') ";
                    }

                    await connection.ExecuteAsync(insertAuthorsQuery);
                }
            }
        }

        /// <summary>
        /// Delete book by id and authors connections
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            string bookQuery = "delete from BOOKS where Id = @id";
            string booksAuthorsQuery = "delete from BOOKS_AUTHORS where BookId = @id";

            string query = $"{bookQuery} {booksAuthorsQuery}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int updatedRows = await connection.ExecuteAsync(query, new { id = id });
                return updatedRows;
            }
        }

        /// <summary>
        /// Filter books
        /// </summary>
        /// <returns></returns>
        public async Task<List<BookDTO>> GetFilteredBooksAsync(FiltersDTO filters)
        {
            string query = @"select [b].[Id],
                                    [b].[Title],
                            	    [b].[Description],
                                    [b].[FilePath],
                            	    [a].[FirstName] as 'AuthorFirstName',
                            	    [a].[LastName] as 'AuthorLastName'
                            from BOOKS_AUTHORS ba
                            inner join BOOKS b on b.[Id] = ba.[BookId]
                            inner join AUTHORS a on a.[Id] = ba.[AuthorId]";

            string conditions = GetBooksFilterCondition(filters);
            if (!string.IsNullOrEmpty(conditions))
            {
                query += " where " + conditions;
            }

            if (!string.IsNullOrWhiteSpace(filters.SortColumn))
            {
                query += $"\r\n order by {filters.SortColumn} {filters.IsSQLAscending}";
            }
            else
            {
                query += $"\r\n order by [Id] desc";
            }

            //query += $"\r\n offset {filters.SkipRows} rows " +
            //        $"\r\n fetch next {filters.PageSize} rows only";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                IEnumerable<BookAuthorDTO> dbItems = await connection.QueryAsync<BookAuthorDTO>(query);

                //group authors by book to show results
                List<BookDTO> result = dbItems
                    .GroupBy(x => x.Id)

                    //pagination is made after grouping
                    .Skip(filters.SkipRows)
                    .Take(filters.PageSize.Value)
                    .Select(x => new BookDTO
                    {
                        Id = x.Key,
                        Title = x.Select(y => y.Title).First(),
                        FilePath = x.Select(y => y.FilePath).First(),
                        Description = x.Select(y => y.Description).First(),
                        Authors = x.Select(y => new AuthorDTO
                        {
                            FirstName = y.AuthorFirstName,
                            LastName = y.AuthorLastName
                        })
                        .ToList()
                    })
                    .ToList();

                foreach (BookDTO item in result)
                {
                    SetBookCoverDetails(item);
                }

                return result;
            }
        }

        /// <summary>
        /// Get filtered books count
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetFilteredCountAsync(FiltersDTO filters)
        {
            string query = @"select count(distinct [b].[Id])
                            from BOOKS_AUTHORS ba
                            inner join BOOKS b on b.[Id] = ba.[BookId]
                            inner join AUTHORS a on a.[Id] = ba.[AuthorId]";

            string conditions = GetBooksFilterCondition(filters);
            if (!string.IsNullOrEmpty(conditions))
            {
                query += " where " + conditions;
            }

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int result = await connection.QueryFirstAsync<int>(query);
                return result;
            }
        }

        /// <summary>
        /// Get book details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookDTO> GetByIdAsync(Guid id)
        {
            string query = @"select [b].[Id],
                                    [b].[Title],
                            	    [b].[Description],
                                    [b].[FilePath],
                                    [a].[Id] as 'AuthorId'
                            from BOOKS_AUTHORS ba
                            inner join BOOKS b on b.[Id] = ba.[BookId]
                            inner join AUTHORS a on a.[Id] = ba.[AuthorId]
                            where [ba].[BookId] = @id";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                IEnumerable<BookAuthorDTO> dbItems = await connection.QueryAsync<BookAuthorDTO>(query, new { id = id });

                BookDTO result = dbItems
                    .GroupBy(x => x.Id)
                    .Select(x => new BookDTO
                    {
                        Id = x.Key,
                        Title = x.Select(y => y.Title).First(),
                        FilePath = x.Select(y => y.FilePath).First(),
                        Description = x.Select(y => y.Description).First(),
                        Authors = x.Select(y => new AuthorDTO
                        {
                            Id = y.AuthorId
                        })
                        .ToList()
                    })
                    .First();

                SetBookCoverDetails(result);

                return result;
            }
        }

        /// <summary>
        /// Update book details and add or remove book authors
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Book entity)
        {
            string updateBookQuery = @"update BOOKS  
                                       set Description = @Description,
                                           Title = @Title,
                                           FilePath = @FilePath,
                                           ModifiedBy = @ModifiedBy,
                                           LastModified = @LastModified
                                           where Id = @Id";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                IEnumerable<Guid> currentAuthorsIds = entity.BookAuthors.Select(x => x.AuthorId).ToList();

                //get current authors ids
                string currentAuthorsIdsQuery = "select AuthorId from BOOKS_AUTHORS where BookId = @bookId";
                IEnumerable<Guid> dbBookAuthorsIds = await connection.QueryAsync<Guid>(currentAuthorsIdsQuery, new { bookId = entity.Id });

                //book authors to delete
                string bookAuthorsToDeleteQuery = string.Empty;

                List<Guid> authorIdsToDelete = dbBookAuthorsIds.Except(currentAuthorsIds).ToList();
                foreach (Guid authorId in authorIdsToDelete)
                {
                    bookAuthorsToDeleteQuery += $" delete from BOOKS_AUTHORS where BookId = '{entity.Id}' and AuthorId = '{authorId}' ";
                }

                //book authors to add
                string bookAuthorsToAddQuery = string.Empty;

                List<Guid> authorIdsAdd = currentAuthorsIds.Except(dbBookAuthorsIds).ToList();
                foreach (Guid authorId in authorIdsAdd)
                {
                    bookAuthorsToAddQuery += $" insert into BOOKS_AUTHORS(AuthorId, BookId) values ('{authorId}', '{entity.Id}') ";
                }

                string query = $"{updateBookQuery} {bookAuthorsToDeleteQuery} {bookAuthorsToAddQuery}";

                int updatedRows = await connection.ExecuteAsync(query, entity);
                return updatedRows;
            }
        }


        #region Private methods

        private string GetBooksFilterCondition(FiltersDTO filters, bool firstClause = false)
        {
            List<string> filtersList = new();

            if (!string.IsNullOrWhiteSpace(filters.SearchText))
            {
                filtersList.Add($"[b].[Title] like '%{filters.SearchText}%'");
                filtersList.Add($"[b].[Description] like '%{filters.SearchText}%'");
                filtersList.Add($"[a].[FirstName] like '%{filters.SearchText}%'");
                filtersList.Add($"[a].[LastName] like '%{filters.SearchText}%'");
            }

            string result = string.Join(" or ", filtersList);
            return result;
        }

        private void SetBookCoverDetails(BookDTO book)
        {
            //get image details from disk
            if (!string.IsNullOrWhiteSpace(book.FilePath))
            {
                byte[] imageArray = File.ReadAllBytes(book.FilePath);
                book.CoverImageContent = Convert.ToBase64String(imageArray);
                book.CoverImageFileName = Path.GetFileName(book.FilePath);
            }
        }

        #endregion Private methods
    }
}
