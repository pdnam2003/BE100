using System.ComponentModel.DataAnnotations.Schema;

namespace BE100.Entities
{
    [Table("QuestionCategory", Schema = "public")]

    public class QuestionCategory
    {

        public int id { get; set; }
        public string name { get; set; } = null!;

        public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
