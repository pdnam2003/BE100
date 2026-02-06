using BE100.Data;
using BE100.DTOs.Response;
using Microsoft.EntityFrameworkCore;

namespace BE100.Services.ExamService
{
    public class ExambyQuestionCategory
    {
        private readonly AppDbContext _context;

        public ExambyQuestionCategory(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<QuestionDto>> GetRandom25ByCategory(int categoryId)
        {
            var questions = await _context.Question
                .Where(q => q.category_id == categoryId)
                .Include(q => q.Answers)
                .OrderBy(q => Guid.NewGuid())   
                .Take(25)                      
                .Select(q => new QuestionDto
                {
                    Id = q.id,
                    Content = q.content,
                    ImageUrl = q.image_url,
                    CategoryId = q.category_id,

                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        Id = a.id,
                        Content = a.content
                      
                    }).ToList()
                })
                .ToListAsync();

            return questions;
        }

    }
}
