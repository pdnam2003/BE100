using BE100.Entities;
using BE100.Entities.Enum;
using Microsoft.EntityFrameworkCore;

namespace BE100.Data.Seed
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // =========================
            // ANSWERS FOR QUESTION 15 -> 50
            // =========================
            if (!context.Answer.Any(a => a.id >= 52))
            {
                var answers = new List<Answer>();

                int answerId = 52;

                for (int questionId = 15; questionId <= 50; questionId++)
                {
                    answers.AddRange(new[]
                    {
            new Answer
            {
                id = answerId++,
                question_id = questionId,
                content = "Đáp án đúng",
                is_correct = true
            },
            new Answer
            {
                id = answerId++,
                question_id = questionId,
                content = "Đáp án sai 1",
                is_correct = false
            },
            new Answer
            {
                id = answerId++,
                question_id = questionId,
                content = "Đáp án sai 2",
                is_correct = false
            },
            new Answer
            {
                id = answerId++,
                question_id = questionId,
                content = "Đáp án sai 3",
                is_correct = false
            }
        });
                }

                context.Answer.AddRange(answers);
                context.SaveChanges();
            }

        }
    }
}
