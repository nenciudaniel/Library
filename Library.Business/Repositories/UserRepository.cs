using Dapper;
using Library.Business.Repositories.Interfaces;
using Library.Database.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.Business.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LibraryConnectionString");
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            string userQuery = "select * from USERS where Username = @username";
            string userRolesQuery = "select Username, RoleId from USERS_ROLES where Username = @username";
            string rolesQuery = " select Id, Name from ROLES";

            string query = $"{userQuery} {userRolesQuery} {rolesQuery}";

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                User result;

                using (var multi = connection.QueryMultiple(query, new { username = username }))
                {
                    result = multi.Read<User>().First();

                    List<UserRole> userRoles = multi.Read<UserRole>().ToList();
                    List<Role> roles = multi.Read<Role>().ToList();
                    userRoles.ForEach(ur =>
                    {
                        ur.Role = roles.Where(x => x.Id == ur.RoleId).First();
                    });

                    result.UserRole = userRoles;
                }

                return result;
            }
        }

        public async Task<List<Role>> GetUserRolesByUsernameAsync(string username)
        {
            string userRolesQuery = "select Username, RoleId from USERS_ROLES where Username = @username";
            string rolesQuery = " select Id, Name from ROLES";

            string query = userRolesQuery + rolesQuery;

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                List<UserRole> userRoles = new();

                using (var multi = connection.QueryMultiple(query, new { username = username }))
                {
                    userRoles = multi.Read<UserRole>().ToList();
                    List<Role> roles = multi.Read<Role>().ToList();

                    userRoles.ForEach(ur =>
                    {
                        ur.Role = roles.Where(x => x.Id == ur.RoleId).First();
                    });
                }

                return userRoles.Select(x => x.Role).ToList();
            }
        }
    }
}
