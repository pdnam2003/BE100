using BE100.Services.ExamService;
using Microsoft.AspNetCore.Mvc;


namespace BE100.Controllers.ExamController
{
    [ApiController]
    [Route("api/exams")]
    public class ExambyQuestiopnCategoryController :  ControllerBase
    {
        private readonly ExambyQuestionCategory _service;

        public ExambyQuestiopnCategoryController(ExambyQuestionCategory service)
        {
            _service = service;
        }
        ////  Sa hình
        //fetch("/api/exam/random/2")
        ////  Biển báo
        //fetch("/api/exam/random/1")
        ////  Luật
        //fetch("/api/exam/random/3")
        [HttpGet("random/{categoryId}")]
        public async Task<IActionResult> GetRandomExam(int categoryId)
        {
            var questions = await _service.GetRandom25ByCategory(categoryId);
            return Ok(questions);
        }

    }
}
