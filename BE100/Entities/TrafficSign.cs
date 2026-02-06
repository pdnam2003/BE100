namespace BE100.Entities
{
    public class TrafficSign
    {

        public int id { get; set; }
        public string name { get; set; } = null!;
        public int category_id { get; set; }
        public string? image_url { get; set; }

        public TrafficSignCategory Category { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
