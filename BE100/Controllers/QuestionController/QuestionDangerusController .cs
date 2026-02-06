using BE100.Services.Question;
using Microsoft.AspNetCore.Mvc;

namespace BE100.Controllers.QuestionController
{
    [ApiController]

    [Route("api/question")]
    public class QuestionDangerusController : Controller
    {
        private readonly ListQuestionDangerous _listQuestionDangerous;

        public QuestionDangerusController(ListQuestionDangerous listQuestionDangerous)
        {
            _listQuestionDangerous = listQuestionDangerous;
        }

        // GET: api/question/dangerous
        [HttpGet("dangerous")]
        public async Task<IActionResult> GetQuestionDangerous()
        {
            var questions = await _listQuestionDangerous.GetQuestionDangerous();
            return Ok(questions);
        }
    }
}
//OK