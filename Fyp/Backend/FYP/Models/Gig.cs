namespace FYP.Models
{
    public class Gig
    {
        public int gig_id {  get; set; }
        public int user_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int category_id { get; set; }
        public decimal price { get; set; }
        public int delievery_time { get; set; }
        public decimal rating { get; set; }
        public DateTime created_at { get; set; }
    }
}
