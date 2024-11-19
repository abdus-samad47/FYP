namespace FYP.DTO_s.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Status { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }
}
