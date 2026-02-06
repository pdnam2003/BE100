using BE100.Data;
using BE100.DTOs.Response;
using Microsoft.EntityFrameworkCore;
namespace BE100.Services.Question
{
    public class GetAllQuestion
    {
        private readonly AppDbContext _context;
        public GetAllQuestion(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> GetAllQuestions() {
            return await _context.Question
               .Include(q=> q.Answers)
               .Select(q => new QuestionDto
               {
                   Id = q.id,
                   Content = q.content,
                   ImageUrl = q.image_url,
                   CategoryId = q.category_id,
                   Answers = q.Answers.Select(a => new AnswerDto
                     {
                          Id = a.id,
                          Content = a.content,
                         IsCorrect = a.is_correct
                     }).ToList()
               }).ToListAsync();

        }
        

    }
}
