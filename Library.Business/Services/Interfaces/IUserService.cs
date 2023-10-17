using Library.Business.Models;

namespace Library.Business.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetCurrentUserAsync(string username);
    }
}
