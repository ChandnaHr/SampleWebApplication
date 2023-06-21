namespace SampleWebApplication.Models
{
    public class CreateUserRequest
    {
        public String Name { get; set; }

        public String Job { get; set; }
    }

    public class CreateUserResponse
    {
        public String Name { get; set; }

        public String Job { get; set; }

        public String Id { get; set; }

        public String CreatedAt { get; set; }
    }
}
