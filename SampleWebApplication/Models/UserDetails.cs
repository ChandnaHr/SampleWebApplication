namespace SampleWebApplication.Models
{
    public class UserDetails
    {
        public User_Data data { get; set; }
        public User_Support support { get; set; }
    }

    public class User_Data
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String First_name { get; set; }
        public String Last_name { get; set; }
        public String Avatar { get; set; }
    }

    public class User_Support
    {
        public String Url { get; set; }
        public String Text { get; set; }
    }
}
