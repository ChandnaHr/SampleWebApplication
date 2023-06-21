namespace SampleWebApplication.Models
{
    public class RegisterUserRequest
    {
       public String email { get; set; }
        public String password { get; set; }
    }

    public class RegisterUserResponse
    {
        public String id { get; set; }
        public String token { get; set; }
    }
}
