//using BE100.Data;
//using BE100.DTOs.Request;
//using BE100.Entities.Enum;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;

//namespace BE100.Controllers.ExamController
//{

//    [ApiController]
//    [Route("api/examhistory")]
//    public class ExamHistoryController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public ExamHistoryController(AppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpPost("submit")]

//        public async Task<IActionResult> SubmitExam(SubmitExamDto dto)
//        {
//            bool hasFailed = false;
//            foreach (var ans in dto.Answers)
//            {
//                var answer = await _context.Answer
//                    .Include(a => a.question)
//                    .FirstAsync(a => a.id == ans.AnswerId);
//                if (!answer.is_correct)
//                {
//                    if (answer.question.question_type == QuestionType.Liet)
//                    {
//                        hasFailed = true;
//                        break;
//                    }
//                }

//            }
//            var history = await _context.ExamHistory
//                .FirstAsync(h => h.id == dto.ExamHistoryId);
//            history.status = ExamStatus.HoanThanh;
//            history.result = hasFailed ? ExamResult.Truot : ExamResult.Dat;
//            await _context.SaveChangesAsync();

//            return Ok(new
//            {
//                Result = history.result
//            }
//            );

//        }
//    }
//}
