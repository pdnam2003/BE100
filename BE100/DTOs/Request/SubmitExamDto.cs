namespace BE100.DTOs.Request
{
    public class SubmitExamDto
    {
        public int ExamHistoryId { get; set; }
        public List<UserAnswerDto> Answers { get; set; }
    }
}
