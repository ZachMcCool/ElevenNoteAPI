namespace ElevenNote.Models.User
{
    public class UserDetail
    {
        public interface IUserService
        {
            Task<bool> RegisterUserAsync(UserRegister model);
            Task<UserDetail> GetUserByIdAsync(int userId);
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}