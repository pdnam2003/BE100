using BE100.Entities.Enum;

namespace BE100.Entities
{
    public class ExamHistory
    {

        public int id { get; set; }

        public int user_id { get; set; }
        public AppUser User { get; set; }

        public int exam_id { get; set; }
        public Exam Exam { get; set; }

        public int remaining_time { get; set; }
        public int? current_question_id { get; set; }

        public ExamStatus status { get; set; }
        public ExamResult? result { get; set; }


        public ICollection<ExamAnswer> ExamAnswers { get; set; } = new List<ExamAnswer>();

    }
}
