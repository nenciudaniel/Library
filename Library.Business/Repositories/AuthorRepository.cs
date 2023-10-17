using Library.Business.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Library.Database.Models;

namespace Library.Business.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public AuthorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LibraryConnectionString");
        }

        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Author entity)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"insert into AUTHORS([Id], [FirstName], [LastName], [CreatedBy], [CreatedOn]) 
                                 values (@Id, @FirstName, @LastName, @CreatedBy, @CreatedOn)";

                await connection.ExecuteAsync(query, new
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    CreatedBy = entity.CreatedBy,
                    CreatedOn = entity.CreatedOn
                });
            }
        }

        /// <summary>
        /// Delete author by id and books connections
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Guid id)
        {
            string booksAuthorsQuery = "delete from BOOKS_AUTHORS where AuthorId = @id";
            string authorsQuery = "delete from AUTHORS where Id = @id";

            string query = $"{booksAuthorsQuery} {authorsQuery}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int updatedRows = await connection.ExecuteAsync(query, new { id = id });
                return updatedRows;
            }
        }

        /// <summary>
        /// Get all authors options
        /// </summary>
        /// <returns></returns>
        public async Task<List<Author>> GetAllAsync()
        {
            var query = "select Id, FirstName, LastName from AUTHORS";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Author>(query);
                return result.ToList();
            }
        }

        public async Task<Author> GetByIdAsync(Guid id)
        {
            var query = "select Id, FirstName, LastName from AUTHORS where Id = @id";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                Author result = await connection.QueryFirstAsync<Author>(query, new { id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Author entity)
        {
            string query = @"update AUTHORS 
                            set FirstName = @FirstName,
                            LastName = @LastName,
                            ModifiedBy = @ModifiedBy,
                            ModifiedOn = @LastModified
                            where Id = @id";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                int updatedRows = await connection.ExecuteAsync(query, new { id = entity.Id});
                return updatedRows;
            }
        }
    }
}
