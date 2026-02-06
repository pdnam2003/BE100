using BE100.Services.ExamService;
using Microsoft.AspNetCore.Mvc;

namespace BE100.Controllers.ExamController
{
    [ApiController]
    [Route("api/randoomexam")]
    public class RandoomQuestion : ControllerBase
    {
        private readonly RandoomExam _randoom;

        public RandoomQuestion(RandoomExam randoomExam)
        {
            _randoom = randoomExam;
        }

        // GET api/randoomexam/randoom-questions
        [HttpGet("randoom-questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _randoom.Get25QuestionsRandoom();
            return Ok(questions);
        }
    }
}
//OK