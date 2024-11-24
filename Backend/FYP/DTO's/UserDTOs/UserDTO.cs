namespace FYP.DTO_s.UserDTOs
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string status { get; set; }
        public string salt { get; set; }
        public string password { get; set; }
    }
}
