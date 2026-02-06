using BE100.Data;
using BE100.DTOs.Response;
using Microsoft.EntityFrameworkCore;
using System;

namespace BE100.Services.ExamService
{
    public class RandoomExam
    {
        private readonly AppDbContext _context;

        public RandoomExam(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionDto>> Get25QuestionsRandoom()
        {
            var lietquestion = await _context.Question
                .Where(q => q.question_type == Entities.Enum.QuestionType.Liet)
                .OrderBy(x => Guid.NewGuid())
                .Include(q => q.Answers)
                .FirstOrDefaultAsync();
            var nomalQuestion = await _context.Question
                .Where(q => q.question_type == Entities.Enum.QuestionType.Thuong)
                .OrderBy(x => Guid.NewGuid())
                .Include(q => q.Answers)
                .Take(24)
                .ToListAsync();


            var questions = new List<Entities.Question>();
            if (lietquestion != null)
            {
                questions.Add(lietquestion);
            }
            questions.AddRange(nomalQuestion);
            questions = questions
                .OrderBy(x => Guid.NewGuid())
                .ToList();
            return questions.Select(q => new QuestionDto
            {
                Id = q.id,
                Content = q.content,
                ImageUrl = q.image_url,
                CategoryId = q.category_id,
                Answers = q.Answers.Select(
                    q => new AnswerDto
                    {
                        Id = q.id,
                        Content = q.content,
                        IsCorrect = false,
                    }).ToList()
            }).ToList();
        }

    }
}
                  
