using Library.Business.Models;
using Library.Business.Repositories.Interfaces;
using Library.Business.Services.Interfaces;
using Library.Database.Models;

namespace Library.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetCurrentUserAsync(string username)
        {
            User user = await _userRepository.GetUserByUsernameAsync(username);

            return new UserDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = username,
                Role = user.UserRole != null && user.UserRole.Count > 0 ? user.UserRole.First().Role.Name : null
            };
        }
    }
}
