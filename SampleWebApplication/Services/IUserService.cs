using SampleWebApplication.Models;

namespace SampleWebApplication.Services
{
    public interface IUserService
    {
        Task<UserDetails> GetUser(int id);
        Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest);
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerUserRequest);
    }
}
