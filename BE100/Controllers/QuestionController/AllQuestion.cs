using BE100.Services.Question;
using Microsoft.AspNetCore.Mvc;

namespace BE100.Controllers.QuestionController
{

    [ApiController]
    [Route("api/allquestion")]
    public class Allquestion : ControllerBase
    {
        private readonly GetAllQuestion _getAllQuestion;
        public Allquestion(GetAllQuestion getAllQuestion)
        {
            _getAllQuestion = getAllQuestion;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _getAllQuestion.GetAllQuestions();
            Console.WriteLine(data.Count);
            return Ok(data);
        }

        //OKOK



    }
}
