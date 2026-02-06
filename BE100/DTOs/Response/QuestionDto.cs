using BE100.Entities;

namespace BE100.DTOs.Response
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public QuestionCategory Category { get; set; }

        public int CategoryId { get; set; } 
    }
}
