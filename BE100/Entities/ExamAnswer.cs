namespace BE100.Entities
{
    public class ExamAnswer
    {
        public int id { get; set; }

        public int exam_history_id { get; set; }
        public ExamHistory examHistory { get; set; }

        public int question_id { get; set; }
        public Question question { get; set; }

        public int answer_id { get; set; }
        public Answer Answer { get; set; }

        public bool is_correct { get; set; }

    }
}
