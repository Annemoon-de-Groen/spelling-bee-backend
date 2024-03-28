using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("players")]
    public class Players
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("bio")]
        public string Bio { get; set; }
        [Column("rol")]
        public string? Rol { get; set; }
        [Column("functie")]
        public string Functie { get; set; }
    }
}
