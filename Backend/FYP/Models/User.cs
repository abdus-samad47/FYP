namespace FYP.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string role { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public string nic { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string status { get; set; }
    }
}
