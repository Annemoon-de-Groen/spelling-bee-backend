using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("play")]
    public class Play
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("location")]
        public string Location { get; set; }
        [Column("capacity")]
        public int Capacity { get; set; }
        public ICollection<Tickets> Tickets { get; set; }

    }
}
