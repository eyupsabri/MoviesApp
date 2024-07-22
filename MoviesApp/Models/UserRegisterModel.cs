
namespace MoviesAppUser.Models
{
    public class UserRegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? NickName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
