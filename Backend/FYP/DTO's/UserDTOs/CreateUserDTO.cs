namespace FYP.DTO_s
{
    public class CreateUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Nic { get; set; }
        public string Phonenumber { get; set; }
        public string Address { get; set; }
    }
}
