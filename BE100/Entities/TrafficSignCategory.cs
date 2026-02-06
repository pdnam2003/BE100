namespace BE100.Entities
{
    public class TrafficSignCategory
    {
        public int id { get; set; }
        public string name { get; set; } = null!;

        public ICollection<TrafficSign> TrafficSigns { get; set; } = new List<TrafficSign>();

    }
}
