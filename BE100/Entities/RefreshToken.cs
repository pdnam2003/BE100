namespace BE100.Entities
{
    public class RefreshToken
    {

        public int id { get; set; }
        public string token { get; set; } = null!;
        public int user_id { get; set; }
        public DateTime ExpiredAt { get; set; }

        public AppUser User { get; set; } = null!;


    }
}
