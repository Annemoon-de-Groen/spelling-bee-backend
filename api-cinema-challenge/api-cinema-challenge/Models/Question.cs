using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace api_cinema_challenge.Models
{
    [Table("questions")]
    public class Question
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("word")]
        public string Word { get; set; }
        [Column("definition")]
        public string Definition { get; set; }
        [Column("sentence")]
        public string Sentence { get; set; }
    }
}
