namespace BE100.Entities
{
    public class Exam
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public int duration_seconds { get; set; } = 1800;

        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
        public ICollection<ExamHistory> ExamHistories { get; set; } = new List<ExamHistory>();

    }
}
