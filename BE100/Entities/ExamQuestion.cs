namespace BE100.Entities
{
    public class ExamQuestion
    {

        public int id { get; set; }
        public int exam_id { get; set; }
        public int question_id { get; set; }

        public Exam Exam { get; set; } = null!;
        public Question Question { get; set; } = null!;

    }
}
