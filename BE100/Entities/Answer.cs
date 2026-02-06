namespace BE100.Entities
{
    public class Answer
    {
        public int id { get; set; }
        public int question_id { get; set; }
        public string content { get; set; } = null!;
        public bool is_correct { get; set; }

        public ICollection<ExamAnswer> ExamAnswers { get; set; } = new List<ExamAnswer>();

        public Question question { get; set; } = null!;

    }
}
