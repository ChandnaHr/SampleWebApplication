using Newtonsoft.Json;
using SampleWebApplication.CustomClient;
using SampleWebApplication.Models;

namespace SampleWebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly ICustomHttpClient _customHttpClient;

        public UserService()
        {
            _customHttpClient = new CustomHttpClient("https://reqres.in");
        }

        public UserService(ICustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<UserDetails> GetUser(int id)
        {
            var apiPath = $"/api/users/{id}";

            try
            {
                var response = await _customHttpClient.GetAsync(apiPath);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var userDetails = JsonConvert.DeserializeObject<UserDetails>(json);

                    return userDetails;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest)
        {
            var apiPath = $"/api/users";

            try
            {
                var response = await _customHttpClient.PostJsonAsync(apiPath, createUserRequest);

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var createdUser = JsonConvert.DeserializeObject<CreateUserResponse>(json);

                return createdUser;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest registerUserRequest)
        {
            var apiPath = $"/api/register";
            try {
                var response = await _customHttpClient.PostJsonAsync(apiPath, registerUserRequest);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return null;

                }
                else
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var generateUser = JsonConvert.DeserializeObject<RegisterUserResponse>(json);
                    return generateUser;
                }
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("Exception thrown");
                Console.WriteLine("Message: {0}", e.Message);
            }

            return null;
        }
       
    }
}