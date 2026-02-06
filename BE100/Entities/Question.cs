using BE100.Entities.Enum;

namespace BE100.Entities
{
    public class Question
    {
        public int id { get; set; }
        public string content { get; set; } = null!;
        public string? image_url { get; set; }
        public QuestionType question_type { get; set; }

        public int category_id { get; set; }
        public int? traffic_sign_id { get; set; }

        public QuestionCategory Category { get; set; } = null!;
        public TrafficSign? TrafficSign { get; set; }

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();

    }
}
