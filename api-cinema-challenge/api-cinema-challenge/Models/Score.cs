using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("score")]
    public class Score
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("points")]
        public int Points { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
